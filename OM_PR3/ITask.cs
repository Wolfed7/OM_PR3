namespace OM_PR3;

public enum MethodTypes
{
   Penalty,
   InteriorPointLog,
   InteriorPointReverse
}

public enum StrategyTypes
{
   Add,
   Mult,
   Div,
}

public interface ITask
{
   public double Coef { get; set; }
   public int Degree { get; init; }
   public MethodTypes MethodType { get; init; }

   public double Function(PointND point);
   public double Penalty(PointND point);
   public bool Limitation(PointND point);

}

class TaskA : ITask
{
   public double Coef { get; set; }
   public int Degree { get; init; }
   public MethodTypes MethodType { get; init; }

   public TaskA(double coef = 0, int degree = 0, MethodTypes methodType = MethodTypes.Penalty)
   {
      Coef = coef;
      Degree = degree;
      MethodType = methodType;
   }

   //5(x+y)^2+(x-2)^2
   public double Function(PointND point)
      => 5 * (point[0] + point[1]) * (point[0] + point[1]) + (point[0] - 2) * (point[0] - 2);

   public double Penalty(PointND point)
   {
      switch (MethodType)
      {
         case MethodTypes.InteriorPointLog:
            return -Coef * Math.Log( - (1 - point[0] - point[1]) );
         case MethodTypes.InteriorPointReverse:
            return Coef / Math.Max(0, -(1 - point[0] - point[1]));
         case MethodTypes.Penalty:
            return Coef * Math.Pow(0.5 * (-point[0] - point[1] + 1 + Math.Abs(-point[0] - point[1] + 1)), Degree);
         default:
            return 0;
      }

   }

   // 1 - x - y <= 0
   public bool Limitation(PointND point)
      => 1 - point[0] - point[1] <= 0;
}

class TaskB : ITask
{
   public double Coef { get; set; }
   public int Degree { get; init; }
   public MethodTypes MethodType { get; init; }

   public TaskB(double coef = 2, int degree = 1, MethodTypes methodType = MethodTypes.Penalty)
   {
      Coef = coef;
      Degree = degree;
      MethodType = methodType;
   }

   //5(x+y)^2+(x-2)^2
   public double Function(PointND point)
      => 5 * (point[0] + point[1]) * (point[0] + point[1]) + (point[0] - 2) * (point[0] - 2);

   public double Penalty(PointND point)
     => Coef * Math.Pow(Math.Abs(point[0] - point[1]), Degree);

   // x - y = 0
   public bool Limitation(PointND point)
      => Math.Abs(point[0] - point[1]) < 1e-12;
}