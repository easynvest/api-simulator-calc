using Easynvest.SimulatorCalc.Domain.Contracts;
using Easynvest.SimulatorCalc.Domain.EttjSet;
using System.Collections.Generic;

namespace Easynvest.SimulatorCalc.Repository
{
    public class EttjRepository : IEttjRepository
    {
        public Ettj GetEttjByType(string type, int businessDays)
        {
            return new Ettj()
            {
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
                                RateValue = 3.17
                            },
                            new Rate()
                            {
                                BusinessDays = 378,
                                RateValue = 3.15
                            }
                        }
                    }
                }
            };
        }
    }
}
