using System;

namespace Easynvest.Simulator.Domain.Investment
{
    public class InvestmentResult
    {
        public InvestmentResult(InvestmentParameter investmentParameter, decimal grossAmount, decimal taxesAmount)
        {
            InvestmentParameter = investmentParameter;
            GrossAmount = Math.Round(grossAmount, DomainConstants.DEFAULT_ROUND);
            TaxesAmount = Math.Round(taxesAmount, DomainConstants.DEFAULT_ROUND);
        }


        public InvestmentParameter InvestmentParameter { get; }
        public decimal GrossAmount { get; }
        public decimal TaxesAmount { get; }

        public decimal NetAmount { get { return GrossAmount - TaxesAmount; } }
        public decimal GrossAmountProfit { get { return CalculateAmountProfit(GrossAmount); } }
        public decimal NetAmountProfit { get { return CalculateAmountProfit(NetAmount); } }
        public decimal GrossRateProfit { get { return CalculateRateProfit(GrossAmountProfit); } }
        public decimal NetRateProfit { get { return CalculateRateProfit(NetAmountProfit); } }

        private decimal CalculateAmountProfit(decimal finalAmount)
        {
            return finalAmount - InvestmentParameter.InvestedAmount;
        }

        private decimal CalculateRateProfit(decimal finalAmount)
        {
            return Math.Round(finalAmount / InvestmentParameter.InvestedAmount * 100, DomainConstants.DEFAULT_ROUND);
        }
    }
}
