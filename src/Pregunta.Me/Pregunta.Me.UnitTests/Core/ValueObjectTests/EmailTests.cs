using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.UnitTests.Core.ValueObjectTests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Should_BeCorrect_When_CreatingEmailInstance()
        {
            // arrange...
            var emailText = "someemail@domain.com"; string displayName = TestUtilities.rog.Generate<string>();

            // act...
            var email = Email.Create(emailText, displayName);

            // assert...
            Assert.AreEqual(emailText, email.Address, "Failed to set the email text.");
            Assert.AreEqual(displayName, email.DisplayName, "Failed to set the email text.");
        }
    }
}
