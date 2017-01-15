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
            var m1 = new Money("USD", 5.00); var m2 = new Money("USD", 5.00);

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
        public void Should_BeCorrect_When_AddingTwoMoneysOfSameCurrencyWithPlusOperator()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("USD", 3.00); var m3 = new Money("USD", 8.00);

            // act...
            var result = m1 + m2;

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

        [TestMethod]
        public void Should_BeCorrect_When_MultiplyingByAnInteger()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("USD", 25.00); var multiplier = 5;

            // act...
            var result = m1 * multiplier;

            // assert...
            Assert.AreEqual(m2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_ThrowException_When_AddingMoneysWithDifferentCurrencies()
        {
            // arrange...
            var m1 = new Money("USD", 5.00); var m2 = new Money("PAB", 3.00);

            // act...
            var result = m1 + m2;

            // assert...
            Assert.Fail("Expected exception to be thrown");
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowException_When_AttemptingToCreateMoneyWithNegativeAmount()
        {
            // arrange...

            // act...
            var result = new Money("USD", -1.00);

            // assert...
            Assert.Fail($"'{typeof(ArgumentException).Name}' Exception expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowException_When_AttemptingToCreateMoneyWithBadCurrencyCode()
        {
            // arrange...

            // act...
            var result = new Money("BitCoin", 1.00);

            // assert...
            Assert.Fail($"'{typeof(ArgumentException).Name}' Exception expected.");
        }
    }
}