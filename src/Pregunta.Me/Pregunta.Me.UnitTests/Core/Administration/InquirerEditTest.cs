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
            var fName = rog.Generate<string>();
            var lName = rog.Generate<string>();
            var email = "SomeEmail@Domain.com";
            var svc = new AdminService();

            // act...
            var inquirer = svc.CreateInquirer(fName, lName, email);

            // assert...
            Assert.AreEqual(fName, inquirer.FirstName, "Failed to set first name.");
            Assert.AreEqual(lName, inquirer.LastName, "Failed to set last name.");
            Assert.AreEqual(email, inquirer.Email.Address, "Failed to set first name.");
        }
    }
}
