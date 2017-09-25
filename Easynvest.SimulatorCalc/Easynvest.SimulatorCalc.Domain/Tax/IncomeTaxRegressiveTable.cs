using System.Collections.Generic;

namespace Easynvest.SimulatorCalc.Domain.Tax
{
    public static class IncomeTaxRegressiveTable
    {
        public readonly static List<IncomeTaxRange> IncomeTaxRanges = new List<IncomeTaxRange>();

        static IncomeTaxRegressiveTable()
        {
            IncomeTaxRanges = new List<IncomeTaxRange>()
            {
                new IncomeTaxRange(0, 180, 22.5m),
                new IncomeTaxRange(181, 360, 20m),
                new IncomeTaxRange(361, 720, 17.5m),
                new IncomeTaxRange(721, null, 15m),
            };
        }
    }
}
