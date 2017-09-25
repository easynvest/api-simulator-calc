using Easynvest.SimulatorCalc.Domain.EttjSet;

namespace Easynvest.SimulatorCalc.Domain.Contracts
{
    public interface IEttjRepository
    {
        Ettj GetEttjByType(string type, int businessDays);
    }
}
