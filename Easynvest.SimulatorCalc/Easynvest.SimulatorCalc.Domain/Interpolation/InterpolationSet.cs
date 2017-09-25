namespace Easynvest.SimulatorCalc.Domain.Interpolation
{
    public class InterpolationSet
    {
        public InterpolationPoint PreviousPoint { get; private set; }

        public InterpolationPoint NextPoint { get; private set; }

        public int TargetMaturityDays { get; private set; }

        public InterpolationSet(int previousBusinessDays, double previousInterestRate,
            int nextBusinessDays, double nextInterestRate,
            int targetMaturityDays)
        {
            var previousPoint = new InterpolationPoint(previousBusinessDays, previousInterestRate);
            var nextPoint = new InterpolationPoint(nextBusinessDays, nextInterestRate);

            Initialize(previousPoint, nextPoint, targetMaturityDays);
        }

        public InterpolationSet(InterpolationPoint previousPoint, InterpolationPoint nextPoint, int targetMaturityDays)
        {
            Initialize(previousPoint, nextPoint, targetMaturityDays);
        }

        private void Initialize(InterpolationPoint previousPoint, InterpolationPoint nextPoint, int targetMaturityDays)
        {
            PreviousPoint = previousPoint;
            NextPoint = nextPoint;
            TargetMaturityDays = targetMaturityDays;
        }
    }
}
