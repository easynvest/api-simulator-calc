using Easynvest.SimulatorCalc.Domain;
using Easynvest.SimulatorCalc.Domain.Calendar;
using Easynvest.SimulatorCalc.Domain.Contracts;
using Microsoft.Extensions.Options;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            CalendarDaysCountResult calendarResult;
            var calendarAPI = Config.Value.CalendarAPI;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            
            var uri = $"{calendarAPI}/calendar?from={DateTime.Now.ToString("yyyyMMdd")}&to={until.ToString("yyyyMMdd")}";
            var result = client.GetStringAsync(new Uri(uri));
            var msg = result.Result;
            calendarResult = Newtonsoft.Json.JsonConvert.DeserializeObject<CalendarDaysCountResult>(msg);

            return calendarResult;
        }
    }
}