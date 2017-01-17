using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pregunta.Me.Core.Administration;
using Pregunta.Me.Core.Services;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Pregunta.Me.Services.Operators;
using Pregunta.Me.Services.Operators.Questions;
using Pregunta.Me.UnitTests;
using System;
using TechTalk.SpecFlow;

namespace Pregunta.Me.Specs
{
    [Binding]
    public class AskAQuestionSteps
    {
        private InquirerInfo _inquirer;
        private ExpertInfo _expert;
        private Receptionist _svc;
        private IQuestionRequest _questionRequest;
        private IQuestionReceipt _questionReceipt;

        [Given(@"that I formulate a Question")]
        public void GivenThatIFormulateAQuestion()
        {
            _inquirer = InquirerInfo.Fetch(1200, TestUtilities.MakeFakeInquirerModelRepo(1200));
            _questionRequest = Receptionist.AskQuestion(_inquirer, _expert, $"How much liquid Tylenol can a 2 year old kid have?");
        }

        [Given(@"select a valid Expert to answer it")]
        public void GivenSelectAValidExpertToAnswerIt()
        {
            _expert = ExpertInfo.Fetch(4200, TestUtilities.MakeFakeExpertModelRepo(4200));
        }

        [When(@"I submit the Question")]
        public void WhenISubmitTheQuestion()
        {
            var questionnaire = Mock.Of<IQuestionnaire>(); 
            _svc = new Receptionist(questionnaire);
            _questionReceipt = _svc.Process(_questionRequest);
        }

        [Then(@"the system produces a Question Receipt")]
        public void ThenTheSystemProducesAQuestionReceipt()
        {
            Assert.IsInstanceOfType(_questionReceipt, typeof(QuestionReceipt));
            Assert.AreEqual(_questionRequest.QuestionText, _questionReceipt.QuestionAsked.Text);
            Assert.AreNotEqual(Guid.Empty, _questionReceipt.Id);
            Assert.AreEqual(_questionReceipt.Id, _questionReceipt.QuestionAsked.Id);
        }

        [Given(@"I have Question Receipts")]
        public void GivenIHaveQuestionReceipts()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I invoke get list of Receipts")]
        public void WhenIInvokeGetListOfReceipts()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system produces a list of Question Receipts")]
        public void ThenTheSystemProducesAListOfQuestionReceipts()
        {
            ScenarioContext.Current.Pending();
        }

        private IInquirerModelRepository MakeMockRepo(int inquirerId)
        {
            var dto = new Plugin.Contracts.DataTransferObjects.InquirerInfoDto(inquirerId)
            {
                FirstName = $"fn-{inquirerId}",
                LastName = $"ln-{inquirerId}",
                Email = $"email@inquirer-{inquirerId}.com"
            };
            return Mock.Of<IInquirerModelRepository>(repo => repo.Fetch(inquirerId) == dto);
        }
    }
}
