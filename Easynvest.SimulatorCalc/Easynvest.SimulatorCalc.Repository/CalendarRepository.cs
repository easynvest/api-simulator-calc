using Easynvest.SimulatorCalc.Domain.Calendar;
using Easynvest.SimulatorCalc.Domain.Contracts;
using System;

namespace Easynvest.SimulatorCalc.Repository
{
    public class CalendarRepository : ICalendarRepository
    {
        public CalendarDaysCountResult GetCountByRange(DateTime until)
        {
            return new CalendarDaysCountResult() { BusinessDays = 252, TotalDays = 365, ToDate = DateTime.Now.AddYears(1) };
        }
    }
}