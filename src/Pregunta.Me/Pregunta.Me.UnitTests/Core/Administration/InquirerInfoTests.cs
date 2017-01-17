using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.UnitTests.Core.Administration
{
    [TestClass]
    public class InquirerInfoTests
    {
        [TestMethod]
        public void Should_BeCorrect_WhenFetching()
        {
            // Arrange...
            int id = 1200;
            var fakeRepo = TestUtilities.MakeFakeInquirerModelRepo(id);

            // Act...
            var inq = InquirerInfo.Fetch(id, fakeRepo);

            // Assert...
            Assert.AreEqual(id, inq.Id);
        }
    }
}
