using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Services.Administration;
using Pregunta.Me.Core.Administration;
using System;
using TechTalk.SpecFlow;

namespace Pregunta.Me.Specs
{
    [Binding]
    public class AdminSteps
    {
        AdminService svc = new AdminService();

        ExpertEdit expert { get; set; }
        InquirerEdit inquirer { get; set; }

        [Given(@"a well formed AdminService")]
        public void GivenAWellFormedAdminService()
        {
            Assert.IsTrue(svc.IsValid);
        }
        
        [When(@"I create a new Expert User with its required properties")]
        public void WhenICreateANewExpertUserWithItSRequiredProperties()
        {
            expert = svc.CreateExpert("Roger", "Fett", "rfet@heaven.com", "USD", 5, "English", "USA");
        }
        
        [Then(@"a new Expert is created with IsValid property = true")]
        public void ThenANewExpertIsCreatedWithIsValidPropertyTrue()
        {
            Assert.IsTrue(expert.IsValid);
        }
        
        [Then(@"an ExpertId property != (.*)")]
        public void ThenAnExpertIdProperty(int expertId)
        {
            Assert.AreNotEqual(expertId, expert.Id);
        }

        [When(@"I create a new Inquirer User with its required properties")]
        public void WhenICreateANewInquirerUserWithItsRequiredProperties()
        {
            inquirer = svc.CreateInquirer("Anibal", "Velarde", "anibal@earth.com");
        }

        [Then(@"a new Inquirer is created with IsValid property equals to true")]
        public void ThenANewInquirerIsCreatedWithIsValidPropertyEqualsToTrue()
        {
            Assert.IsTrue(inquirer.IsValid);
        }

        [Then(@"InquirerId propery != (.*)")]
        public void ThenInquirerIdPropery(int inquirerId)
        {
            Assert.AreNotEqual(inquirerId, inquirer.Id);
        }

    }
}
