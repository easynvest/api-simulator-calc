using Easynvest.SimulatorCalc.Domain.Investment;
using NUnit.Framework;
using System.Collections.Generic;

namespace Easynvest.SimulatorCalc.Tests.Domain
{
    [TestFixture]
    public class InvestmentTests
    {
        #region TestCases
        private static IEnumerable<TestCaseData> CorrectInvestmentResults
        {
            get
            {
                yield return new TestCaseData(new InvestmentParameter(1000, 10, 368, 252), new InvestmentResult(new InvestmentParameter(1000, 10, 368, 252), 1100m, 17.50m));
                yield return new TestCaseData(new InvestmentParameter(1000, 10, 369, 252, 110), new InvestmentResult(new InvestmentParameter(1000, 10, 369, 252, 110), 1110.53m, 17.50m));
                yield return new TestCaseData(new InvestmentParameter(1000, 10, 369, 252, 110, true), new InvestmentResult(new InvestmentParameter(1000, 10, 369, 252, 110, true), 1110.53m, 0));
                yield return new TestCaseData(new InvestmentParameter(5000, 12, 130, 90, 115), new InvestmentResult(new InvestmentParameter(5000, 12, 130, 90, 115), 5238.22m, 22.5m));
                yield return new TestCaseData(new InvestmentParameter(9000, 9.5, 730, 505, 115.50), new InvestmentResult(new InvestmentParameter(9000, 9.5, 730, 505, 115.50), 11103.69m, 15m));
            }
        }

        private static IEnumerable<TestCaseData> CorrectInvestmentNetProfitAmount
        {
            get
            {
                yield return new TestCaseData(new InvestmentParameter(1000, 10, 368, 252), 82.5m);
                yield return new TestCaseData(new InvestmentParameter(1000, 10, 369, 252, 110), 91.19m);
                yield return new TestCaseData(new InvestmentParameter(1000, 10, 369, 252, 110, true), 110.53m);
                yield return new TestCaseData(new InvestmentParameter(5000, 12, 130, 90, 115), 184.62m);
                yield return new TestCaseData(new InvestmentParameter(9000, 9.5, 730, 505, 115.50), 1788.14m);
            }
        }

        [TestCaseSource(nameof(CorrectInvestmentResults))]
        public void TestInvestmentCalculations(InvestmentParameter parameter, InvestmentResult expectedResult)
        {
            var actualResult = new InvestmentSimulator().Simulate(parameter);
            CheckEquality(expectedResult, actualResult);
        }

        [TestCaseSource(nameof(CorrectInvestmentNetProfitAmount))]
        public void TestInvestmentNetProfitAmount(InvestmentParameter parameter, decimal netProfitAmount)
        {
            var actualResult = new InvestmentSimulator().Simulate(parameter);
            Assert.AreEqual(netProfitAmount, actualResult.NetAmountProfit);
        }

        private void CheckEquality(InvestmentResult expectedResult, InvestmentResult actualResult)
        {
            Assert.AreEqual(expectedResult.GrossAmount, actualResult.GrossAmount, nameof(actualResult.GrossAmount));
            Assert.AreEqual(expectedResult.TaxesAmount, actualResult.TaxesAmount, nameof(actualResult.TaxesAmount));
        }
        #endregion
    }
}
