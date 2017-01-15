using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.UnitTests.Core.ValueObjectTests
{
    [TestClass]
    public class BillingRateTests
    {
        [TestMethod]
        public void Should_BeEqual_When_HavingSameProperties()
        {
            // arrange...
            var br1 = new BillingRate(4.00, "USD"); var br2 = new BillingRate(4.00, "USD");

            // act...
            var result = br1.Equals(br2);

            // assert...
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_BeCorrect_When_ComputingBillingAmount()
        {
            // arrange...
            var br1 = new BillingRate(4.00, "USD"); var m1 = new Money("USD", 16.00);

            // act...
            var result = br1.CalculateBillingAmount(4);

            // assert...
            Assert.AreEqual(m1, result);
        }
    }
}
