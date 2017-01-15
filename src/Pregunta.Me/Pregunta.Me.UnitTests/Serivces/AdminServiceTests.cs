using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Services.Administration;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.UnitTests.Serivces
{
    [TestClass]
    public class AdminServiceTests
    {
        [TestMethod]
        public void Should_BeCorrect_When_CreatingNewExpertRegistrationRequest()
        {
            // Arrange...
            IExpertRegistrationRequest req;
            
            // Act...
            req = ExpertRegistrationService.IssueNewRegistrationRequestForExpert();

            // Assert...
            Assert.IsInstanceOfType(req, typeof(ExpertRegistrationRequest));
        }

        [TestMethod]
        public void Should_BeCorrect_When_CreatingExpertWithRegistrationRequest()
        {
            // arrange...
            IExpertRegistrationRequest request = this.MakeNewRegistrationRequest();
            var svc = new ExpertRegistrationService();
            var expBillingRate = new BillingRate(request.BillingRate, request.Currency);

            // act...
            IExpertRegistrationResponse response = svc.Process(request);

            // assert...
            Assert.IsNotNull(response.Expert);
            Assert.IsTrue(response.IsValid);
            Assert.AreEqual(request.FirstName, response.Expert.FirstName, "Failed to set First Name.");
            Assert.AreEqual(request.LastName, response.Expert.LastName, "Failed to set Last Name.");
            Assert.AreEqual(request.Country, response.Expert.Country, "Failed to set County.");
            Assert.AreEqual(request.Email, response.Expert.Email.Address, "Failed to set Email.");
            Assert.AreEqual(request.Language, response.Expert.Language, "Failed to set Language.");
            Assert.AreEqual(expBillingRate, response.Expert.BillingRate, "Failed to set Billing Rate.");
        }

        [TestMethod]
        public void Should_BeIncorrect_When_CreatingExpertWithRegistrationRequestThrowsExceptions()
        {
            // arrange...
            IExpertRegistrationRequest request = this.MakeNewRegistrationRequest();
            request.Email = string.Empty;
            var svc = new ExpertRegistrationService();            

            // act...
            IExpertRegistrationResponse response = svc.Process(request);

            // assert...
            Assert.IsNull(response.Expert);
            Assert.IsNotNull(response.Errors);
            Assert.IsFalse(response.IsValid);
        }


        private IExpertRegistrationRequest MakeNewRegistrationRequest()
        {
            var rog = TestUtilities.rog;
            var req = ExpertRegistrationService.IssueNewRegistrationRequestForExpert();
            req.FirstName = rog.Generate<string>();
            req.LastName = rog.Generate<string>();
            req.BillingRate = rog.Generate<double>();
            req.Country = "USA";
            req.Currency = "USD";
            req.Email = "anyuser@anydomain.com";
            req.Language = "English";
            return req;
        }
    }
}
