using System;

namespace Easynvest.SimulatorCalc.Domain.Calendar
{
    public class CalendarDaysCountResult
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BusinessDays { get; set; }
        public int TotalDays { get; set; }
    }
}
