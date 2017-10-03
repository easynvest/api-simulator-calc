using System;
using Easynvest.Simulator.Domain;

namespace Easynvest.SimulatorCalc.Domain.Investment
{
    public class InvestmentResult
    {
        public InvestmentResult(InvestmentParameter investmentParameter, decimal grossAmount, decimal taxesRate)
        {
            InvestmentParameter = investmentParameter;
            GrossAmount = Math.Round(grossAmount, DomainConstants.DEFAULT_ROUND);
            TaxesRate = taxesRate;
        }

        public InvestmentParameter InvestmentParameter { get; }

        #region Amounts
        public decimal GrossAmount { get; }
        public decimal TaxesAmount { get { return CalculateTaxAmount(GrossAmountProfit, TaxesRate); } }
        public decimal NetAmount { get { return GrossAmount - TaxesAmount; } }
        public decimal GrossAmountProfit { get { return CalculateAmountProfit(GrossAmount); } }
        public decimal NetAmountProfit { get { return CalculateAmountProfit(NetAmount); } }
        #endregion

        #region Rate
        public decimal AnnualGrossRateProfit { get { return CalculateAnnualRateProfit(GrossAmountProfit); } }
        public decimal MonthlyGrossRateProfit { get { return CalculateMonthlyRateProfit(RateProfit); } }
        public decimal DailyGrossRateProfit { get; set; }
        public decimal TaxesRate { get; }
        public decimal RateProfit { get { return (decimal)InvestmentParameter.YearlyInterestRate; } }
        public decimal AnnualNetRateProfit { get { return CalculateAnnualRateProfit(NetAmountProfit); } }
        #endregion





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
            return Math.Round((Math.Pow(1 + annualRate / 100, period) - 1) * 100, DomainConstants.DEFAULT_ROUND);
        }

        private decimal CalculateTaxAmount(decimal profit, decimal taxRate)
        {
            return Math.Round(profit * taxRate / 100, DomainConstants.DEFAULT_ROUND);
        }
    }
}
