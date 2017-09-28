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
<<<<<<< HEAD
                Index = type,
                Rates = rates,
=======
                DataSet = new List<DataSet>()
                {
                    new DataSet()
                    {
                        Index = "PRE",
                        Rates = new List<Rate>()
                        {
                            new Rate()
                            {
                                BusinessDays = 252,
                                RateValue = 11
                            },
                            new Rate()
                            {
                                BusinessDays = 378,
                                RateValue = 12
                            }
                        }
                    }
                }
>>>>>>> 85f393e640d9aec726e17403a53369c3b552b37a
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
