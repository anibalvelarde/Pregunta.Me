using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Services.Administration;

namespace Pregunta.Me.UnitTests.Core.Administration
{
    [TestClass]
    public class ExpertEditTests
    {
        [TestMethod]
        public void Should_BeCorrect_When_CreatingExpertInstance()
        {
            // Arrange...
            var rog = TestUtilities.rog;
            var svc = new AdminService();
            var firstName = rog.Generate<string>();
            var lastName = rog.Generate<string>();
            var email = "someemail@domain.com";
            var currency = "USD";
            var billingRate = rog.Generate<decimal>();
            var language = rog.Generate<string>();
            var country = rog.Generate<string>();

            // Act...
            var expert = svc.CreateExpert(firstName, lastName, email, currency, billingRate, language, country);

            // Assert...
            Assert.AreEqual(firstName, expert.FirstName, "Failed to set first name");
            Assert.AreEqual(lastName, expert.LastName, "Failed to set last name");
            Assert.AreEqual(email, expert.Email.Address, "Failed to set email");
            Assert.AreEqual(currency, expert.Currency, "Failed to set currency");
            Assert.AreEqual(billingRate, expert.BillingRate, "Failed to set billing rate");
            Assert.AreEqual(language, expert.Language, "Failed to set language");
            Assert.AreEqual(country, expert.Country, "Failed to set country");
        }
    }
}
