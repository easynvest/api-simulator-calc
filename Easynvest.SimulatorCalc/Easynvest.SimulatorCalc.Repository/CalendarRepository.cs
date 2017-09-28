using Easynvest.SimulatorCalc.Domain;
using Easynvest.SimulatorCalc.Domain.Calendar;
using Easynvest.SimulatorCalc.Domain.Contracts;
using Microsoft.Extensions.Options;

using System;

namespace Easynvest.SimulatorCalc.Repository
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly IOptions<MyConfig> Config;

        public CalendarRepository(IOptions<MyConfig> config)
        {
            Config = config;
        }

        public CalendarDaysCountResult GetCountByRange(DateTime until)
        {
            var calendarAPI = Config.Value.CalendarAPI;
            return new CalendarDaysCountResult() { BusinessDays = 252, TotalDays = 365, ToDate = DateTime.Now.AddYears(1) };
        }
    }
}