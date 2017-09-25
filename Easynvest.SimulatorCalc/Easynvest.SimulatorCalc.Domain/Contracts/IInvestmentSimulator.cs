using Easynvest.SimulatorCalc.Domain.Investment;

namespace Easynvest.SimulatorCalc.Domain.Contracts
{
    public interface IInvestmentSimulator
    {
        InvestmentResult Simulate(InvestmentParameter parameter);
    }
}