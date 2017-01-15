using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Services.Administration;
using TechTalk.SpecFlow;

namespace Pregunta.Me.Specs
{
    [Binding]
    public class AdminSteps
    {
        private ExpertRegistrationService expService = new ExpertRegistrationService();
        private InquirerRegistrationService inqService = new InquirerRegistrationService();

        IExpertRegistrationResponse expertRegistratoinResponse { get; set; }
        IInquirerRegistrationResponse inquirerRegistrationResponse { get; set; }

        [Given(@"a well formed AdminService")]
        public void GivenAWellFormedAdminService()
        {
            Assert.IsTrue(expService.IsValid);
            Assert.IsTrue(inqService.IsValid);
        }
        
        [When(@"I create a new Expert User with its required properties")]
        public void WhenICreateANewExpertUserWithItSRequiredProperties()
        {
            var request = ExpertRegistrationService.IssueNewRegistrationRequestForExpert();
            request.FirstName = "Roger";
            request.LastName = "Fett";
            request.Email = "rfett@heaven.com";
            request.Currency = "USD";
            request.BillingRate = 5;
            request.Language = "English";
            request.Country = "USA";
            expertRegistratoinResponse = expService.Process(request);
        }
        
        [Then(@"a new Expert is created with IsValid property = true")]
        public void ThenANewExpertIsCreatedWithIsValidPropertyTrue()
        {
            Assert.IsTrue(expertRegistratoinResponse.IsValid, "expected a valid expert registration response");
            Assert.IsTrue(expertRegistratoinResponse.Expert.IsValid);
        }
        
        [Then(@"an ExpertId property != (.*)")]
        public void ThenAnExpertIdProperty(int expertId)
        {
            Assert.AreNotEqual(expertId, expertRegistratoinResponse.Expert.Id);
        }

        [When(@"I create a new Inquirer User with its required properties")]
        public void WhenICreateANewInquirerUserWithItsRequiredProperties()
        {
            var request = InquirerRegistrationService.IssueNewRegistrationRequestForInquirer();
            request.FirstName = "Anibal";
            request.LastName = "Velarde";
            request.Email = "anibal@earth.com";
            inquirerRegistrationResponse = inqService.Process(request);
        }

        [Then(@"a new Inquirer is created with IsValid property equals to true")]
        public void ThenANewInquirerIsCreatedWithIsValidPropertyEqualsToTrue()
        {
            Assert.IsTrue(inquirerRegistrationResponse.IsValid, "expected a valid inquirer registration response");
            Assert.IsTrue(inquirerRegistrationResponse.Inquirer.IsValid);
        }

        [Then(@"InquirerId propery != (.*)")]
        public void ThenInquirerIdPropery(int inquirerId)
        {
            Assert.AreNotEqual(inquirerId, inquirerRegistrationResponse.Inquirer.Id);
        }

    }
}
