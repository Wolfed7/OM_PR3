using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OM_PR3;

public class SimplexMethod : IMinSearchMethodND
{
   private PointND _min;
   private PointND[] _simplex;

   public int FCALCS { get; private set; }

   public PointND Min => _min;
   public static double Alpha => 1; // Коэффициент отражения
   public static double Beta => 0.5;
   public static double Gamma => 2;
   public static double Distance => 1;

   public double Eps { get; init; }
   public int MaxIters { get; init; }


   public SimplexMethod(int maxIters, double eps)
   {
      FCALCS = 0;
      MaxIters = maxIters;
      Eps = eps;
      _min = new PointND(0);
      _simplex = new PointND[0];
   }

   public void Compute(PointND startPoint, ITask task, (StrategyTypes, double)? strategy)
   {
      FCALCS = 0;
      int PointDimension = startPoint.Dimention;
      int SimplexSize = PointDimension + 1;

      List<PointND> coords = new(); // Координаты для графики.
      List<double> funcs = new(); // Значения функции.
      List<PointND> dirs = new(); // Значения направлений поиска.
      List<double> corner = new(); // Угол между векторами (xi, yi) и (s1, s2)
      int iters = 0; // Количество итераций.

      _min = startPoint;
      _simplex = new PointND[SimplexSize];
      for (int i = 0; i < SimplexSize; i++)
         _simplex[i] = new PointND(PointDimension);

      double d1 = Distance * (Math.Sqrt(PointDimension + 1) + PointDimension - 1) / (PointDimension * Math.Sqrt(2));
      double d2 = Distance / ((PointDimension * Math.Sqrt(2)) * (Math.Sqrt(PointDimension + 1) - 1));

      // TODO сделать симплекс зависимым от стартовой точки. PS: вроде готово...?
      _simplex[PointDimension] = startPoint;
      for (int i = 0; i < PointDimension; i++)
         for (int j = 0; j < PointDimension; j++)
         {
            if (i == j)
            {
               _simplex[i][j] = d1 + _simplex[PointDimension][j];
               continue;
            }
            _simplex[i][j] = d2 + _simplex[PointDimension][j];
         }

      PointND xr = new(PointDimension);
      PointND xg = new(PointDimension);
      PointND xe = new(PointDimension);
      PointND xc = new(PointDimension); // Центр тяжести симплекса.

      for (iters = 0; iters < MaxIters; iters++)
      {
         iters++;
         _simplex = _simplex.OrderBy(val => task.Function(val) + task.Penalty(val)).ToArray();
         xc.Fill(0);
         FCALCS += _simplex.Length;

         // Центр тяжести = сумма всех векторов (не скалярка), кроме xh 
         for (int i = 0; i < PointDimension; i++)
            for (int j = 0; j < PointDimension; j++)
               xc[i] += _simplex[j][i] / PointDimension;

         // Выйдем, если достигли заданной точности.
         FCALCS += 2;
         if (IsAccuracyAchieved(_simplex, xc, task) && task.Penalty(_simplex[0]) < Eps)
         {
            _min = _simplex[0]; //xc
            break;
         }

         if (iters != 0)
         {
            if (strategy is not null)
            {
               task.Coef = strategy.Value.Item1 switch
               {
                  StrategyTypes.Mult => task.Coef *= strategy.Value.Item2,
                  StrategyTypes.Add => task.Coef == 0 ? 0 : task.Coef += strategy.Value.Item2,
                  StrategyTypes.Div => task.Coef /= strategy.Value.Item2,

                  _ => throw new InvalidEnumArgumentException($"This type of coefficient change strategy does not exist: {nameof(strategy.Value.Item1)}")
               };
            }
         }

         // Отразим наибольшую точку относительно центра тяжести.
         xr = Reflection(_simplex, xc);

         double fr = task.Function(xr) + task.Penalty(xr); // Новое значение функции.
         double fl = task.Function(_simplex[0]) + task.Penalty(_simplex[0]); // Худшее значение функции.
         double fg = task.Function(_simplex[PointDimension - 1]) + task.Penalty(_simplex[PointDimension - 1]);
         double fh = task.Function(_simplex[PointDimension]) + task.Penalty(_simplex[PointDimension]);
         FCALCS += 4;


         if (fl < fr && fr < fg)
         {
            _simplex[PointDimension] = (PointND)xr.Clone();
         }
         else if (fr < fl)
         {
            // Производим растяжение.
            xe = Expansion(xc, xr);

            // fe < fr
            FCALCS++;
            if (task.Function(xe) + task.Penalty(xe) < fr)
               _simplex[PointDimension] = (PointND)xe.Clone();
            else
               _simplex[PointDimension] = (PointND)xr.Clone();
         }
         else if (fr < fh)
         {
            // Вход в эту часть кода означает, что поменяны
            // местами xr и наибольший элемент симплекса.
            // Проведём сжатие.
            xg = OutsideContraction(xc, xr);

            // fg < fr - сжимаем ещё сильнее
            FCALCS++;
            if (task.Function(xg) + task.Penalty(xg) < fr)
               _simplex[PointDimension] = (PointND)xg.Clone();
            // Иначе глобально сжимаем симплекс к наименьшей точке.
            else
               Shrink(_simplex);
         }
         else
         {
            // Не меняем xr и наибольший элемент симплекса, делаем сжатие.
            xg = InsideContraction(_simplex, xc);

            FCALCS++;
            if (task.Function(xg) + task.Penalty(xg) < fh)
               _simplex[PointDimension] = (PointND)xg.Clone();
            else
               Shrink(_simplex);
         }
      }

      _min = xc;
      Console.Write($"{iters}  ");
   }

   private bool IsAccuracyAchieved(PointND[] Simplex, PointND xc, ITask task)
   {
      double sum = 0;
      double valueAtXc = task.Function(xc) + task.Penalty(xc);

      for (int i = 0; i < xc.Dimention + 1; i++)
      {
         double valueAtPoint = task.Function(Simplex[i]) + task.Penalty(Simplex[i]);
         sum += (valueAtPoint - valueAtXc) * (valueAtPoint - valueAtXc);
      }

      return Math.Sqrt(sum / (xc.Dimention + 1)) < Eps;
   }

   private static PointND Reflection(PointND[] Simplex, PointND xc)
      => (1 + Alpha) * xc - Alpha * Simplex[xc.Dimention];

   private static PointND Expansion(PointND xc, PointND xr)
      => (1 - Gamma) * xc + Gamma * xr;

   private static PointND OutsideContraction(PointND xc, PointND xr)
      => Beta * xr + (1 - Beta) * xc;

   private static PointND InsideContraction(PointND[] Simplex, PointND xc)
        => Beta * Simplex[xc.Dimention] + (1 - Beta) * xc;

   private static void Shrink(PointND[] Simplex)
   {
      for (int i = 1; i <= Simplex[0].Dimention; i++)
         Simplex[i] = (PointND)(Simplex[0] + (Simplex[i] - Simplex[0]) / 2).Clone();
   }
}                             
                              