using Easynvest.SimulatorCalc.Domain.Interpolation;

namespace Easynvest.SimulatorCalc.Domain.Contracts
{
    public interface IInterpolationCalculator
    {
        double CalculateExponential(InterpolationSet set);
    }
}