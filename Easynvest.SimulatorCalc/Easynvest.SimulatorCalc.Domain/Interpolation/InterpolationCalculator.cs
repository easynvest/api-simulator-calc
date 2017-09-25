using System;
using Easynvest.Simulator.Domain;
using Easynvest.SimulatorCalc.Domain.Contracts;

namespace Easynvest.SimulatorCalc.Domain.Interpolation
{
    public class InterpolationCalculator : IInterpolationCalculator
    {
        public double CalculateExponential(InterpolationSet set)
        {
            ValidateSet(set);

            return CalculateExponential(
                    set.PreviousPoint.BusinessDays, set.PreviousPoint.Rate,
                    set.NextPoint.BusinessDays, set.NextPoint.Rate,
                    set.TargetMaturityDays
                );
        }

        private void ValidateSet(InterpolationSet set)
        {
            if(set.PreviousPoint.BusinessDays > set.NextPoint.BusinessDays)
            {
                throw new ArgumentOutOfRangeException($"Previous business days can not be greater than next business days. Previous: {set.PreviousPoint.BusinessDays}. Next: {set.NextPoint.BusinessDays}");
            }

            if(set.PreviousPoint.BusinessDays > set.TargetMaturityDays || set.NextPoint.BusinessDays < set.TargetMaturityDays)
            {
                throw new ArgumentOutOfRangeException($"Target maturity days is not in the allowed range. Previous: {set.PreviousPoint.BusinessDays}. Next: {set.NextPoint.BusinessDays}. Target: {set.TargetMaturityDays}");
            }
        }

        private double CalculateExponential(
            double previousBusinessDays, double previousInterestRate,
            double nextBusinessDays, double nextInterestRate,
            double targetMaturityDays
        )
        {
            var step1 = Math.Pow(1 + previousInterestRate, previousBusinessDays / DomainConstants.BUSINESS_DAYS_PER_YEAR);
            var step2 = Math.Pow(1 + nextInterestRate, nextBusinessDays / DomainConstants.BUSINESS_DAYS_PER_YEAR) / Math.Pow(1 + previousInterestRate, previousBusinessDays / DomainConstants.BUSINESS_DAYS_PER_YEAR);
            var step3 = (targetMaturityDays - previousBusinessDays) / (nextBusinessDays - previousBusinessDays);
            var step4 = DomainConstants.BUSINESS_DAYS_PER_YEAR / targetMaturityDays;

            var result = Math.Pow(step1 * Math.Pow(step2, step3), step4) - 1;
            var roundedResult = Math.Round(result, DomainConstants.DEFAULT_ROUND_INTERPOLATION_INTEREST_RATE);

            return roundedResult;
        }
    }
}
