using Easynvest.SimulatorCalc.Domain.Calendar;
using System;

namespace Easynvest.SimulatorCalc.Domain.Contracts
{
    public interface ICalendarRepository
    {
        CalendarDaysCountResult GetCountByRange(DateTime until);
    }
}
