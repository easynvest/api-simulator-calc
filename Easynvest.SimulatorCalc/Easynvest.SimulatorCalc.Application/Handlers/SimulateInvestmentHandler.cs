using Easynvest.SimulatorCalc.Application.Commands;
using Easynvest.SimulatorCalc.Domain.Investment;
using MediatR;
using System.Threading.Tasks;

namespace Easynvest.SimulatorCalc.Application.Handlers
{
    public class SimulateInvestmentHandler : IAsyncRequestHandler<SimulateInvestmentCommand, InvestmentResult>
    {
        public Task<InvestmentResult> Handle(SimulateInvestmentCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}