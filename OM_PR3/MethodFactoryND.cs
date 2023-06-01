namespace OM_PR3;

public class MethodFactoryND
{
   private PointND _startPoint;
   private IMinSearchMethodND _minSearchMethod;
   private ITask _function;
   (StrategyTypes, double)? _strategy;

   public MethodFactoryND(IMinSearchMethodND minSearchMethod, ITask function, PointND startPoint, (StrategyTypes, double)? strategy)
   {
      _startPoint = startPoint;
      _minSearchMethod = minSearchMethod;
      _function = function;
      _strategy = strategy;
   }

   public void Compute()
      => _minSearchMethod.Compute(_startPoint, _function, _strategy);

   public int GetFCALCS()
      => _minSearchMethod.FCALCS;
   public PointND GetMinPoint() 
      => _minSearchMethod.Min;
   public void SetMinSearchMethod(IMinSearchMethodND method) 
      => _minSearchMethod = method;
   public void SetFunction(ITask function) 
      => _function = function;
}
