using Easynvest.SimulatorCalc.Domain.Investment;
using MediatR;
using System;

namespace Easynvest.SimulatorCalc.Application.Commands
{
    public class SimulateInvestmentCommand : IRequest<InvestmentResult>
    {
        public decimal InvestedAmount { get; set; }
        public DateTime MaturityDate { get; set; }
        public string Index { get; set; }
        public double Rate { get; set; }
        public bool IsTaxFree { get; set; }
    }
}