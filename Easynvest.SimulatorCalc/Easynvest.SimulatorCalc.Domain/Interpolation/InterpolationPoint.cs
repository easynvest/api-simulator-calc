namespace Easynvest.SimulatorCalc.Domain.Interpolation
{
    public class InterpolationPoint
    {
        public int BusinessDays { get; }
        public double Rate { get; }
        public InterpolationPoint(int businessDays, double rate)
        {
            BusinessDays = businessDays;
            Rate = rate;
        }
    }
}
