namespace Easynvest.SimulatorCalc.Domain.Investment
{
    public class InvestmentParameter
    {
        private const double RATE_FACTOR_DEFAULT = 100;
        private const bool IS_TAX_FREE_DEFAULT = false;

        public decimal InvestedAmount { get; private set; }
        public double YearlyInterestRate { get; private set; }
        public int MaturityTotalDays { get; private set; }
        public int MaturityBusinessDays { get; private set; }
        public double RateFactor { get; private set; }
        public bool IsTaxFree { get; private set; }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, int maturityTotalDays, int maturityBusinessDays)
            : this(investedAmount, yearlyInterestRate, maturityTotalDays, maturityBusinessDays, RATE_FACTOR_DEFAULT, IS_TAX_FREE_DEFAULT)
        {
        }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, int maturityTotalDays, int maturityBusinessDays, double rateFactor)
            : this(investedAmount, yearlyInterestRate, maturityTotalDays, maturityBusinessDays, rateFactor, IS_TAX_FREE_DEFAULT)
        {
        }

        public InvestmentParameter(decimal investedAmount, double yearlyInterestRate, int maturityTotalDays, int maturityBusinessDays, double rateFactor, bool isTaxFree)
        {
            InvestedAmount = investedAmount;
            YearlyInterestRate = yearlyInterestRate;
            MaturityTotalDays = maturityTotalDays;
            MaturityBusinessDays = maturityBusinessDays;
            RateFactor = rateFactor;
            IsTaxFree = isTaxFree;
        }
    }
}
