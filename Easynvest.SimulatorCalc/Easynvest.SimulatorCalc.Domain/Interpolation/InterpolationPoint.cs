namespace Easynvest.Simulator.Domain.Interpolation
{
    public class InterpolationPoint
    {
        public double BusinessDays { get; }
        public double InterestRate { get; }
        public InterpolationPoint(double businessDays, double interestRate)
        {
            BusinessDays = businessDays;
            InterestRate = interestRate;
        }
    }
}
