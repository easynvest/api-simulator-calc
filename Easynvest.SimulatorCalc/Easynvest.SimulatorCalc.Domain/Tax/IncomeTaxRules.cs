using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easynvest.SimulatorCalc.Domain.Tax
{
    public class IncomeTaxRules
    {
        public decimal GetIncomeTaxRate(DateTime maturityDate)
        {
            var daysToExpire = (maturityDate - DateTime.Now.Date).Days;
            return GetIncomeTaxRate(daysToExpire);
        }

        public decimal GetIncomeTaxRate(int daysToExpire)
        {
            foreach (var range in IncomeTaxRegressiveTable.IncomeTaxRanges)
            {
                if (range.From <= daysToExpire && (!range.Until.HasValue || range.Until.Value >= daysToExpire))
                {
                    return range.Rate;
                }
            }

            throw new NotSupportedException($"Income Tax Range not found. Parameter: {daysToExpire} days");
        }

        public string GetIncomeTaxDescription(bool isIncomeTaxFree, bool hasLiquidity, decimal incomeTaxRate)
        {
            if (isIncomeTaxFree)
            {
                return "Isento de IR";
            }

            if (hasLiquidity)
            {
                var firstTaxRange = GetFirstTaxRange();
                return $"{firstTaxRange.Rate}% a {incomeTaxRate}% de IR";
            }

            return $"{incomeTaxRate}% de IR";
        }

        private IncomeTaxRange GetFirstTaxRange()
        {
            return IncomeTaxRegressiveTable.IncomeTaxRanges.First(range => range.From == 0);
        }
    }
}
