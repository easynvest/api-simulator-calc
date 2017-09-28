using System.Collections.Generic;

namespace Easynvest.SimulatorCalc.Domain.EttjSet
{
    public class Ettj
    {
        public string Index { get; set; }
        public IEnumerable<Rate> Rates { get; set; }
        public IEnumerable<DataSet> DataSet { get; set; }
    }
}