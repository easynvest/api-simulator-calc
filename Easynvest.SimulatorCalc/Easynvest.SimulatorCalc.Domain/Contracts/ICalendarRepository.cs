using Easynvest.SimulatorCalc.Domain.Calendar;
using System;
using System.Threading.Tasks;

namespace Easynvest.SimulatorCalc.Domain.Contracts
{
    public interface ICalendarRepository
    {
        CalendarDaysCountResult GetCountByRange(DateTime until);
    }
}
