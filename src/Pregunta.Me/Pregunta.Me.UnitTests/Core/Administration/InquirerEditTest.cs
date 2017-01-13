using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Services.Administration;

namespace Pregunta.Me.UnitTests.Core.Administration
{
    [TestClass]
    public class InquirerEditTest
    {
        [TestMethod]
        public void Shoul_BeCorrect_When_CreatingInquirerInstance()
        {
            // arrange...
            var rog = TestUtilities.rog;
            var request = InquirerRegistrationService.IssueNewRegistrationRequestForInquirer();
            request.FirstName = rog.Generate<string>();
            request.LastName = rog.Generate<string>();
            request.Email = "SomeEmail@Domain.com";
            var svc = new InquirerRegistrationService();

            // act...
            var response = svc.Process(request);

            // assert...
            Assert.AreEqual(request.FirstName, response.Inquirer.FirstName, "Failed to set first name.");
            Assert.AreEqual(request.LastName, response.Inquirer.LastName, "Failed to set last name.");
            Assert.AreEqual(request.Email, response.Inquirer.Email.Address, "Failed to set first name.");
        }
    }
}
