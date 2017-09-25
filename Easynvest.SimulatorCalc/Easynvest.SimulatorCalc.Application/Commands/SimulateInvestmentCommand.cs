using Easynvest.SimulatorCalc.Domain.Investment;
using MediatR;
using System;

namespace Easynvest.SimulatorCalc.Application.Commands
{
    public class SimulateInvestmentCommand : IRequest<InvestmentResult>
    {
        public SimulateInvestmentCommand(decimal investedAmount, DateTime maturityDate, string index, double rateFactor, bool isTaxFree)
        {
            InvestedAmount = investedAmount;
            MaturityDate = maturityDate;
            Index = index;
            RateFactor = rateFactor;
            IsTaxFree = isTaxFree;
        }

        public decimal InvestedAmount { get; }
        public DateTime MaturityDate { get; }
        public string Index { get; }
        public double RateFactor { get; }
        public bool IsTaxFree { get; }
    }
}