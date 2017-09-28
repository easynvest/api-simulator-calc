using Easynvest.SimulatorCalc.Domain.Calendar;
using System;

namespace Easynvest.SimulatorCalc.Domain.Investment
{
    public class InvestmentParameter
    {
        private const double RATE_FACTOR_DEFAULT = 100;
        private const bool IS_TAX_FREE_DEFAULT = false;
        private CalendarDaysCountResult CalendarCount {
            set
            {
                MaturityDate = value.ToDate.Date;
            }
        }

        public decimal InvestedAmount { get; private set; }
        public double YearlyInterestRate { get; private set; }
        public int MaturityTotalDays { get; private set; }
        public int MaturityBusinessDays { get; private set; }
        public DateTime MaturityDate { get; private set; }
        public double Rate { get; private set; }
        public bool IsTaxFree { get; private set; }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, int maturityTotalDays, int maturityBusinessDays)
            : this(investedAmount, yearlyInterestRate, maturityTotalDays, maturityBusinessDays, RATE_FACTOR_DEFAULT, IS_TAX_FREE_DEFAULT)
        {
        }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, int maturityTotalDays, int maturityBusinessDays, double rate)
            : this(investedAmount, yearlyInterestRate, maturityTotalDays, maturityBusinessDays, rate, IS_TAX_FREE_DEFAULT)
        {
        }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, CalendarDaysCountResult calendarCount, double rate, bool isTaxFree)
            : this(investedAmount, yearlyInterestRate, calendarCount.TotalDays, calendarCount.BusinessDays, rate, isTaxFree)
        {
            CalendarCount = calendarCount;
        }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, int maturityTotalDays, int maturityBusinessDays, double rate, bool isTaxFree)
        {
            InvestedAmount = investedAmount;
            YearlyInterestRate = yearlyInterestRate;
            MaturityTotalDays = maturityTotalDays;
            MaturityBusinessDays = maturityBusinessDays;
            Rate = rate;
            IsTaxFree = isTaxFree;
        }
    }
}
