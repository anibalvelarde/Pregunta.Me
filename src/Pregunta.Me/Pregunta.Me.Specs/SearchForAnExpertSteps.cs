using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta.Me.Core.Administration;
using Pregunta.Me.Infra.DataAccess;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Pregunta.Me.Services.Administration;
using Pregunta.Me.Services.Administration.Search;
using TechTalk.SpecFlow;

namespace Pregunta.Me.Specs
{
    [Binding]
    public class SearchForAnExpertSteps
    {
        private IInquirerModelRepository _repoInq = new InquirerModelRepository();
        private IExpertModelRepository _repoExp = new ExpertModelRepository();
        int expertIdentifier = 2000;
        private ExpertInfo _expert;
        int inquirerIdentifier = 1000;
        private InquirerInfo _inquirer;
        private ExpertSearchService _svc;
        IExpertSearchRequest _expertSearchRequest;
        IExpertSearchResult _expertSearchResult;

        private void Initialize()
        {
            _svc = new ExpertSearchService(_repoExp);
        }

        [Given(@"A valid Inquirer")]
        public void GivenAValidInquirer()
        {
            this.Initialize();
            _inquirer = InquirerInfo.Fetch(inquirerIdentifier, _repoInq);
        }

        [Given(@"Area of Expretise to search")]
        public void GivenAreaOfExpretiseToSearch()
        {
            _expertSearchRequest = new ExpertSearchRequest();
            _expertSearchRequest.AreaOfExpertise = "Neurology";
        }

        [When(@"I invoke search")]
        public void WhenIInvokeSearch()
        {
            _expertSearchResult = _svc.Process(_expertSearchRequest);
            Assert.IsNotNull(_expertSearchResult);
            Assert.IsInstanceOfType(_expertSearchResult, typeof(ExpertSearchResult));
            Assert.IsTrue(_expertSearchResult.Result.Count != 0);
        }

        [Then(@"I can obtain the list of Experts in that Area of Expertise")]
        public void ThenICanObtainTheListOfExpertsInThatAreaOfExpertise()
        {
            foreach (var expert in _expertSearchResult.Result)
            {
                Assert.AreEqual(_expertSearchRequest.AreaOfExpertise, expert.AreaOfExpertise);
            };
        }
    }
}
