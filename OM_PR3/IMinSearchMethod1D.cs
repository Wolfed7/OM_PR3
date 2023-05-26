namespace OM_PR3;

public interface IMinSearchMethod1D
{
   public double Min { get; }
   public void Compute(ITask function, Interval interval, PointND argument, PointND direction);
}