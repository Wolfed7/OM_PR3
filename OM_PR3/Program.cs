using OM_PR3;
using System.Diagnostics;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

//PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//double eps = 1e-7;
//(StrategyTypes, double) strategy =  new ( StrategyTypes.Mult, 4 );
//var task = new TaskA(2, 1, MethodTypes.Penalty);
//MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);


double[] srtats = new double[] { 2, 4, 8, -15, -100 };
StrategyTypes[] srtatsTps = new StrategyTypes[] { StrategyTypes.Div, StrategyTypes.Div, StrategyTypes.Div, StrategyTypes.Add, StrategyTypes.Add };
int[] alphas = new int[] { 1, 2, 4, 8, 16 };
double[] penaltys = new double[] { 1000, 2000, 4000, 8000, 16000 };

PointND[] points = new PointND[] { PointND.Parse(new double[] { 6, 4 }), PointND.Parse(new double[] { 2, 8 }), PointND.Parse(new double[] { 3, 1 }), PointND.Parse(new double[] { 4, 5 }), PointND.Parse(new double[] { -2, -10 }) };
double[] epss = new double[] { 1e-3, 1e-4, 1e-5, 1e-6, 1e-7 };

//for (int i = 0; i < alphas.Length; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(StrategyTypes.Mult, 2);
//   var task = new TaskB(1, alphas[i], MethodTypes.Penalty);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

//for (int i = 0; i < alphas.Length; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(StrategyTypes.Mult, 2);
//   var task = new TaskB(penaltys[i], 4, MethodTypes.Penalty);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

//for (int i = 0; i < srtatsTps.Length; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(srtatsTps[i], srtats[i]);
//   var task = new TaskB(1, 4, MethodTypes.Penalty);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

//for (int i = 0; i < points.Length; i++)
//{
//   PointND startPoint = points[i];
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(StrategyTypes.Mult, 2);
//   var task = new TaskA(1, 4, MethodTypes.Penalty);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

//for (int i = 0; i < epss.Length; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = epss[i];
//   (StrategyTypes, double) strategy = new(StrategyTypes.Mult, 2);
//   var task = new TaskA(1, 4, MethodTypes.Penalty);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}















//for (int i = 0; i < 1; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(StrategyTypes.Div, 2);
//   var task = new TaskA(1000, alphas[i], MethodTypes.InteriorPointReverse);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

//for (int i = 0; i < alphas.Length; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(StrategyTypes.Div, 2);
//   var task = new TaskA(penaltys[i], 4, MethodTypes.InteriorPointLog);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

//for (int i = 0; i < srtatsTps.Length; i++)
//{
//   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
//   double eps = 1e-7;
//   (StrategyTypes, double) strategy = new(srtatsTps[i], srtats[i]);
//   var task = new TaskA(5000, 4, MethodTypes.InteriorPointLog);
//   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

//   Console.Write($"{startPoint[0]}  ");
//   Console.Write($"{startPoint[1]}  ");
//   //Console.Write($"{eps}  ");

//   MF.Compute();
//   Console.Write($"{MF.GetFCALCS()}  ");

//   PointND min = MF.GetMinPoint();
//   Console.Write($"{min[0]}  ");
//   Console.Write($"{min[1]}  ");
//   Console.WriteLine($"{task.Function(min)}  ");
//}

for (int i = 0; i < points.Length; i++)
{
   PointND startPoint = points[i];
   double eps = 1e-7;
   (StrategyTypes, double) strategy = new(StrategyTypes.Div, 2);
   var task = new TaskA(5000, 4, MethodTypes.InteriorPointLog);
   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

   Console.Write($"{startPoint[0]}  ");
   Console.Write($"{startPoint[1]}  ");
   //Console.Write($"{eps}  ");

   MF.Compute();
   Console.Write($"{MF.GetFCALCS()}  ");

   PointND min = MF.GetMinPoint();
   Console.Write($"{min[0]}  ");
   Console.Write($"{min[1]}  ");
   Console.WriteLine($"{task.Function(min)}  ");
}

for (int i = 0; i < epss.Length; i++)
{
   PointND startPoint = PointND.Parse(new double[] { 6, 4 });
   double eps = epss[i];
   (StrategyTypes, double) strategy = new(StrategyTypes.Div, 2);
   var task = new TaskA(5000, 4, MethodTypes.InteriorPointLog);
   MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);

   Console.Write($"{startPoint[0]}  ");
   Console.Write($"{startPoint[1]}  ");
   //Console.Write($"{eps}  ");

   MF.Compute();
   Console.Write($"{MF.GetFCALCS()}  ");

   PointND min = MF.GetMinPoint();
   Console.Write($"{min[0]}  ");
   Console.Write($"{min[1]}  ");
   Console.WriteLine($"{task.Function(min)}  ");
}