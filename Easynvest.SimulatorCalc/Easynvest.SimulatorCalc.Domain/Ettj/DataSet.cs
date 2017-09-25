using System.Collections.Generic;

namespace Easynvest.SimulatorCalc.Domain.Ettj
{
    public class DataSet
    {
        public string Index { get; set; }
        public IEnumerable<Rate> Rates { get; set; }
    }
}