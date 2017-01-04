using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Core.Admin;
using System;
using TechTalk.SpecFlow;

namespace Pregunta.Me.Specs
{
    [Binding]
    public class AdminSteps
    {
        AdminService svc = new AdminService();

        ExpertEdit expert { get; set; }

        [Given(@"a well formed AdminService")]
        public void GivenAWellFormedAdminService()
        {
            Assert.IsTrue(svc.IsValid);
        }
        
        [When(@"I create a new Expert User with it's required properties")]
        public void WhenICreateANewExpertUserWithItSRequiredProperties()
        {
            expert = svc.CreateExpert("Roger", "Fett", "rfet@heaven.com", "USD", 5.00, "English");
        }
        
        [Then(@"a new Expert is created with IsValid property = true")]
        public void ThenANewExpertIsCreatedWithIsValidPropertyTrue()
        {
            Assert.IsTrue(expert.IsValid);
        }
        
        [Then(@"an ExpertId property != (.*)")]
        public void ThenAnExpertIdProperty(int expertId)
        {
            Assert.AreNotEqual(expertId, expert.ExpertId);
        }
    }
}
