using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.UnitTests.Core.ValueObjectTests
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void Should_BeEqual_When_HavingSameProperties()
        {
            // arrange...
            var m1 = new Money("USD", 5.00);  var m2 = new Money("USD", 5.00);

            // act...
            var result = m1.Equals(m2);

            // assert...
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_NotBeEqual_When_NotHavingSameValue()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("USD", 1.00);

            // act...
            var result = m1.Equals(m2);

            // assert...
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_NotBeEqual_When_NotHavingSameCurrency()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("PAB", 5.00);

            // act...
            var result = m1.Equals(m2);

            // assert...
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_BeCorrect_When_AddingTwoMoneysOfSameCurrency()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("USD", 3.00); var m3 = new Money("USD", 8.00);

            // act...
            var result = m1.Add(m2);

            // assert...
            Assert.AreEqual(m3, result);
        }

        [TestMethod]
        public void Should_NotChange_When_AddingTwoMoneysOfDifferentCurrency()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("PAB", 3.00); var m3 = new Money("USD", 5.00);

            // act...
            var result = m1.Add(m2);

            // assert...
            Assert.AreEqual(m3, result);
        }
    }
}
