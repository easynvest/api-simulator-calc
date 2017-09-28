using Easynvest.SimulatorCalc.Domain;
using Easynvest.SimulatorCalc.Domain.Contracts;
using Easynvest.SimulatorCalc.Domain.EttjSet;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Easynvest.SimulatorCalc.Repository
{
    public class EttjRepository : IEttjRepository
    {
        private readonly IOptions<MyConfig> _config;

        public EttjRepository(IOptions<MyConfig> config)
        {
            _config = config;
        }

        public Ettj GetEttjByType(string type, int businessDays)
        {
            var rates = ProcessRepositories(type, businessDays).Result;

            return new Ettj
            {
                Index = type,
                Rates = rates,
            };
        }

        private async Task<IEnumerable<Rate>> ProcessRepositories(string type, int businessDays)
        {
            IEnumerable<Rate> ratesResult = new List<Rate>();
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            try
            {
                var uriString = $"{_config.Value.EttjAPI}/{type}/{businessDays}";

                var result = client.GetStringAsync(new Uri($"{_config.Value.EttjAPI}/{type}/{businessDays}"));
                var msg = await result;
                ratesResult = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Rate>>(msg);
            }
            catch (Exception)
            {
                throw;
            }

            return ratesResult;

        }
    }
}
