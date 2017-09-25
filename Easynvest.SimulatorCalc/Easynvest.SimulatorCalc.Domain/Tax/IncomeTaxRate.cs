namespace Easynvest.SimulatorCalc.Domain.Tax
{
    public class IncomeTaxRange
    {
        public int From { get; set; }
        public int? Until { get; set; }

        public decimal Rate { get; set; }

        public IncomeTaxRange(int from, int? until, decimal rate)
        {
            From = from;
            Until = until;
            Rate = rate;
        }
    }
}
