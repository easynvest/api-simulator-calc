using Easynvest.SimulatorCalc.Domain.Investment;
using MediatR;
using System;

namespace Easynvest.SimulatorCalc.Application.Commands
{
    public class SimulateInvestmentCommand : IRequest<InvestmentResult>
    {
        //public SimulateInvestmentCommand(decimal investedAmount, DateTime maturityDate, string index, double rateFactor, bool isTaxFree)
        //{
        //    InvestedAmount = investedAmount;
        //    MaturityDate = maturityDate;
        //    Index = index;
        //    RateFactor = rateFactor;
        //    IsTaxFree = isTaxFree;
        //}

        public decimal InvestedAmount { get; set; }
        public DateTime MaturityDate { get; set; }
        public string Index { get; set; }
        public double RateFactor { get; set; }
        public bool IsTaxFree { get; set; }
    }
}