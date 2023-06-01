namespace OM_PR3;

public interface IMinSearchMethodND
{
   PointND Min { get; }
   public int FCALCS { get; }
   public void Compute(PointND startPoint, ITask function, (StrategyTypes, double)? strategy);
}