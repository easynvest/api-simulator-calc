using Easynvest.SimulatorCalc.Domain.Contracts;
using Easynvest.SimulatorCalc.Domain.EttjSet;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Easynvest.SimulatorCalc.Repository
{
    public class EttjRepository : IEttjRepository
    {
        public Ettj GetEttjByType(string type, int businessDays)
        {
            var rates = ProcessRepositories(type, businessDays).Result;

            return new Ettj
            {
                Index = type,
                Rates = rates,
            };
        }

        private static async Task<IEnumerable<Rate>> ProcessRepositories(string type, int businessDays)
        {
            IEnumerable<Rate> ratesResult = new List<Rate>();
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            try
            {
                var result = client.GetStringAsync(new Uri(string.Format("https://easynvest-ettj-api.herokuapp.com/{0}/{1}", type, businessDays)));
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
