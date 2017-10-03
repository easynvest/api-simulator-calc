using System;

namespace Easynvest.SimulatorCalc.Domain.Calendar
{
    public class CalendarDaysCountResult
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int BusinessDays { get; set; }
        public int TotalDays { get; set; }
    }
}
