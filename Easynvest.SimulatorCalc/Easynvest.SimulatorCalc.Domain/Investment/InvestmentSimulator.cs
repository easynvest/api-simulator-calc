using System;
using Easynvest.Simulator.Domain;
using Easynvest.SimulatorCalc.Domain.Tax;
using Easynvest.SimulatorCalc.Domain.Contracts;

namespace Easynvest.SimulatorCalc.Domain.Investment
{
    public class InvestmentSimulator : IInvestmentSimulator
    {
        public InvestmentResult Simulate(InvestmentParameter parameter)
        {
            var taxRate = GetTaxRate(parameter);
            var grossAmount = CalculateGrossAmount(parameter);
            var profit = grossAmount - parameter.InvestedAmount;
            var taxesAmount = CalculateTaxAmount(profit, taxRate);

            return new InvestmentResult(parameter, grossAmount, taxesAmount);
        }

        private decimal GetTaxRate(InvestmentParameter parameter)
        {
            const decimal AMOUNT_TAX_FREE = 0;
            if (parameter.IsTaxFree)
            {
                return AMOUNT_TAX_FREE;
            }

            return new IncomeTaxRules().GetIncomeTaxRate(parameter.MaturityTotalDays);
        }

        private decimal CalculateGrossAmount(InvestmentParameter parameter)
        {
            var dailyInterestRate = Math.Pow(1 + parameter.YearlyInterestRate / 100, 1.0f / DomainConstants.BUSINESS_DAYS_PER_YEAR) - 1;
            var dailyInterestRateWithFactor = dailyInterestRate * parameter.RateFactor / 100;
            var periodInterestRate = Math.Pow(1 + dailyInterestRateWithFactor, parameter.MaturityBusinessDays);
            return parameter.InvestedAmount * (decimal)periodInterestRate; 
        }

        private decimal CalculateTaxAmount(decimal profit, decimal taxRate)
        {
            return profit * taxRate / 100;
        }
    }
}
