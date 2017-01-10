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

        [TestMethod]
        public void Should_BeFalse_When_NotEqual()
        {
            // arrange...
            var email1 = "email@domain1.com"; string name1 = "Display Name 1";
            var email2 = "email@domain2.com"; string name2 = "Display Name 2";

            var e1 = Email.Create(email1, name1);
            var e2 = Email.Create(email2, name2);

            // act...
            var result1 = e1.Equals(e2);
            var result2 = (e1 == e2);
            var result3 = (e1.GetHashCode().Equals(e2.GetHashCode()));

            // assert...
            Assert.AreEqual(false, result1, "'Equals()' method failed");
            Assert.AreEqual(false, result2, "'==' operator failed");
            Assert.AreEqual(false, result3, "GetHashCode() method failed");
        }

        [TestMethod]
        public void Should_BeTrue_When_Equal()
        {
            // arrange...
            var email1 = "email@domain1.com"; string name1 = "Display Name 1";
            var email2 = email1; string name2 = name1;

            var e1 = Email.Create(email1, name1);
            var e2 = Email.Create(email2, name2);

            // act...
            var result1 = e1.Equals(e2);
            var result2 = (e1 == e2);
            var result3 = (e1.GetHashCode().Equals(e2.GetHashCode()));

            // assert...
            Assert.AreEqual(true, result1, "'Equals()' method failed");
            Assert.AreEqual(true, result2, "'==' operator failed");
            Assert.AreEqual(true, result3, "GetHashCode() method failed");
        }
    }
}
