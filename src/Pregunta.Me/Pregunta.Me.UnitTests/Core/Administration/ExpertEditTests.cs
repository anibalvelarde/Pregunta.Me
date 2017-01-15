using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Services.Administration;
using Pregunta.Me.Core.ValueObjects;

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
            var request = ExpertRegistrationService.IssueNewRegistrationRequestForExpert();
            request.FirstName = rog.Generate<string>();
            request.LastName = rog.Generate<string>();
            request.Email = "someemail@domain.com";
            request.Currency = "USD";
            request.BillingRate = rog.Generate<double>();
            request.Language = rog.Generate<string>();
            request.Country = rog.Generate<string>();
            var expectedBillingRate = new BillingRate(request.BillingRate, request.Currency);

            var svc = new ExpertRegistrationService();

            // Act...
            var response = svc.Process(request);

            // Assert...
            var expert = response.Expert;
            Assert.AreEqual(request.FirstName, expert.FirstName, "Failed to set first name");
            Assert.AreEqual(request.LastName, expert.LastName, "Failed to set last name");
            Assert.AreEqual(request.Email, expert.Email.Address, "Failed to set email");
            Assert.AreEqual(request.Language, expert.Language, "Failed to set language");
            Assert.AreEqual(request.Country, expert.Country, "Failed to set country");
            Assert.AreEqual(expectedBillingRate, expert.BillingRate, "Failed to set billing rate");
        }
    }
}
