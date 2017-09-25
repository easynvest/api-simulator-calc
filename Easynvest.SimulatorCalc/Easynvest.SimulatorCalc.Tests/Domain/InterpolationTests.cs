using Easynvest.Simulator.Domain.Interpolation;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Easynvest.Simulator.Tests.Domain
{
    [TestFixture]
    public class InterpolationTests
    {
        #region TestCases
        private static IEnumerable<TestCaseData> CorrectInterpolations {
            get
            {
                yield return new TestCaseData(new InterpolationSet(2142, 10.1749, 2268, 10.192, 2147), 10.1756);
                yield return new TestCaseData(new InterpolationSet(126, 9.6394, 252, 9.2371, 201), 9.3377);
                yield return new TestCaseData(new InterpolationSet(2268, 10.3209, 2394, 10.3296, 2380), 10.3287);
            }
        }

        private static IEnumerable<TestCaseData> InvalidInterpolations
        {
            get
            {
                yield return new TestCaseData(new InterpolationSet(200, 10, 100, 11, 150));
                yield return new TestCaseData(new InterpolationSet(100, 10, 200, 11, 90));
                yield return new TestCaseData(new InterpolationSet(100, 10, 200, 11, 300));
            }
        }
        #endregion

        [TestCaseSource(nameof(CorrectInterpolations))]
        public void TestExponentialInterpolation(InterpolationSet set, double expectedResult)
        {
            Assert.AreEqual(expectedResult, new InterpolationCalculator().CalculateExponential(set));
        }

        [TestCaseSource(nameof(InvalidInterpolations))]
        public void TestExponentialInterpolationInvalidParameters(InterpolationSet set)
        {
            Assert.That(() => new InterpolationCalculator().CalculateExponential(set),
                        Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
