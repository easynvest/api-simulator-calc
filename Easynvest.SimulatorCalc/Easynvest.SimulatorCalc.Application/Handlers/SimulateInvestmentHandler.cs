using Easynvest.SimulatorCalc.Application.Commands;
using Easynvest.SimulatorCalc.Domain.Contracts;
using Easynvest.SimulatorCalc.Domain.Interpolation;
using Easynvest.SimulatorCalc.Domain.Investment;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Easynvest.SimulatorCalc.Domain.EttjSet;
using System;

namespace Easynvest.SimulatorCalc.Application.Handlers
{
    public class SimulateInvestmentHandler : IRequestHandler<SimulateInvestmentCommand, InvestmentResult>
    {
        private readonly IInterpolationCalculator _interpolationCalculator;
        private readonly IInvestmentSimulator _investmentSimulator;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IEttjRepository _ettjRepository;


        public SimulateInvestmentHandler(
            ICalendarRepository calendarRepository, IEttjRepository ettjRepository, 
            IInterpolationCalculator interpolationCalculator, IInvestmentSimulator investmentSimulator)
        {
            _calendarRepository = calendarRepository;
            _ettjRepository = ettjRepository;
            _interpolationCalculator = interpolationCalculator;
            _investmentSimulator = investmentSimulator;
        }

        public InvestmentResult Handle(SimulateInvestmentCommand command)
        {
            var calendarCount = _calendarRepository.GetCountByRange(command.MaturityDate);
            var ettj = _ettjRepository.GetEttjByType(command.Index, calendarCount.BusinessDays);

            var projectedRate = GetProjectedRate(ettj, calendarCount.BusinessDays);

            var investmentParameter = new InvestmentParameter(
                                        command.InvestedAmount, projectedRate, 
                                        calendarCount.TotalDays, calendarCount.BusinessDays,
                                        command.Rate, command.IsTaxFree);
            var investmentResult = _investmentSimulator.Simulate(investmentParameter);

            return investmentResult;
        }

        private double GetProjectedRate(Ettj ettj, int businessDays)
        {
            var interpolationSet = TransformEttjToInterpolationSet(ettj, businessDays);
            return _interpolationCalculator.CalculateExponential(interpolationSet);
        }

        private InterpolationSet TransformEttjToInterpolationSet(Ettj ettj, int targetMaturityDays)
        {
            var rates = ettj.DataSet.First().Rates.OrderBy(x => x.BusinessDays).ToList();
            var firstRate = rates[0];
            var secondRate = rates[1];

            var firstInterpolationPoint = new InterpolationPoint(firstRate.BusinessDays, firstRate.RateValue);
            var secondInterpolationPoint = new InterpolationPoint(secondRate.BusinessDays, secondRate.RateValue);

            return new InterpolationSet(firstInterpolationPoint, secondInterpolationPoint, targetMaturityDays);
        }
    }
}