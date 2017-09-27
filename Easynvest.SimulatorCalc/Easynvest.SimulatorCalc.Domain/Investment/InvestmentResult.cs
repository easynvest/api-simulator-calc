using System;
using Easynvest.Simulator.Domain;

namespace Easynvest.SimulatorCalc.Domain.Investment
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
        public decimal AnnualGrossRateProfit { get { return CalculateAnnualRateProfit(GrossAmountProfit); } }
        public decimal AnnualNetRateProfit { get { return CalculateAnnualRateProfit(NetAmountProfit); } }
        public decimal MonthlyGrossRateProfit { get { return CalculateMonthlyRateProfit(AnnualGrossRateProfit); } }

        private decimal CalculateAmountProfit(decimal finalAmount)
        {
            return finalAmount - InvestmentParameter.InvestedAmount;
        }

        private decimal CalculateAnnualRateProfit(decimal finalAmount)
        {
            return Math.Round(finalAmount / InvestmentParameter.InvestedAmount * 100, DomainConstants.DEFAULT_ROUND);
        }

        private decimal CalculateMonthlyRateProfit(decimal annualRateProfit)
        {
            const double monthlyPeriod = (double)1 / 12;
            return (decimal)ConvertRate((double) annualRateProfit, monthlyPeriod);
        }

        private double ConvertRate(double annualRate, double period)
        {
            return Math.Round(Math.Pow(annualRate / 100, period), DomainConstants.DEFAULT_ROUND);
        }
    }
}
