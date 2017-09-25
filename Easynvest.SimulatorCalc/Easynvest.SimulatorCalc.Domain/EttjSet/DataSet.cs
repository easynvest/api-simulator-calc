using System.Collections.Generic;

namespace Easynvest.SimulatorCalc.Domain.EttjSet
{
    public class DataSet
    {
        public string Index { get; set; }
        public IEnumerable<Rate> Rates { get; set; }
    }
}