using OM_PR3;
using System.Diagnostics;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");

PointND startPoint = PointND.Parse(new double[] { 6, 4 });
double eps = 1e-7;
(StrategyTypes, double) strategy =  new ( StrategyTypes.Div, 2 );
var task = new TaskA(2, 1, MethodTypes.InteriorPointReverse);

MethodFactoryND MF = new(new SimplexMethod(1000, eps), task, startPoint, strategy);
MF.Compute();
PointND min = MF.GetMinPoint();
Console.WriteLine(min.ToString());