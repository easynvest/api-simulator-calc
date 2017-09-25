namespace Easynvest.Simulator.Domain.Interpolation
{
    public class InterpolationSet
    {
        public InterpolationPoint PreviousPoint { get; private set; }

        public InterpolationPoint NextPoint { get; private set; }

        public double TargetMaturityDays { get; private set; }

        public InterpolationSet(double previousBusinessDays, double previousInterestRate,
            double nextBusinessDays, double nextInterestRate,
            double targetMaturityDays)
        {
            var previousPoint = new InterpolationPoint(previousBusinessDays, previousInterestRate);
            var nextPoint = new InterpolationPoint(nextBusinessDays, nextInterestRate);

            Initialize(previousPoint, nextPoint, targetMaturityDays);
        }

        public InterpolationSet(InterpolationPoint previousPoint, InterpolationPoint nextPoint, double targetMaturityDays)
        {
            Initialize(previousPoint, nextPoint, targetMaturityDays);
        }

        private void Initialize(InterpolationPoint previousPoint, InterpolationPoint nextPoint, double targetMaturityDays)
        {
            PreviousPoint = previousPoint;
            NextPoint = nextPoint;
            TargetMaturityDays = targetMaturityDays;
        }
    }
}
