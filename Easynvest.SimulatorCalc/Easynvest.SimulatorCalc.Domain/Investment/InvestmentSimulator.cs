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
            var investmentResult = new InvestmentResult(parameter, grossAmount, taxRate)
            {
                DailyGrossRateProfit = (decimal)CalculateDailyRate(parameter)
            };

            return investmentResult;
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
            var dailyInterestRate = CalculateDailyRate(parameter);
            var periodInterestRate = Math.Pow(1 + dailyInterestRate, parameter.MaturityBusinessDays);
            return parameter.InvestedAmount * (decimal)periodInterestRate; 
        }

        private double CalculateDailyRate(InvestmentParameter parameter)
        {
            return CalculatePeriod(parameter, DomainConstants.BUSINESS_DAYS_PER_YEAR);
        }

        private double CalculateMonthlyRate(InvestmentParameter parameter)
        {
            const int MONTHS_IN_YEAR = 12;
            return CalculatePeriod(parameter, MONTHS_IN_YEAR);
        }

        private double CalculateAnnualyRate(InvestmentParameter parameter)
        {
            return CalculatePeriod(parameter, 1);
        }

        private double CalculatePeriod(InvestmentParameter parameter, double period)
        {
            var rate = Math.Pow(1 + parameter.YearlyInterestRate / 100, 1.0f / period) - 1;
            return rate * parameter.Rate / 100;
        }
    }
}
