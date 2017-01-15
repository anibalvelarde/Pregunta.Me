using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Plugin.Contracts.DataTransferObjects;
using Pregunta.Me.Core.Administration;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.UnitTests.Core.Administration
{
    [TestClass]
    public class ExpertInfoTests
    {
        [TestMethod]
        public void Should_BeCorrect_When_SettingUpBillingRate()
        {
            // arrange...
            int expectedId = 1000; string expCur = "USD"; double expRate = 4.5;
            var dto = new ExpertInfoDto(expectedId) { AreaOfExpertise = "Neurology", BillingCurrency = expCur, BillingRate = expRate, FirstName = "Silvia", LastName = "Velarde" };
            var expectedBillingRate = new BillingRate(expRate, expCur);

            // act...
            var expert = ExpertInfo.Fetch(dto);

            // assert...
            Assert.IsInstanceOfType(expert.BillingRate, typeof(BillingRate));
            Assert.AreEqual(expectedBillingRate, expert.BillingRate);
        }
    }
}
