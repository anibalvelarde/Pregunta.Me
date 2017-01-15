using Pregunta.Me.Core.Administration;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Pregunta.Me.Services.Administration.Search;
using Pregunta.Me.Services.Base;
using System.Collections.Generic;

namespace Pregunta.Me.Services.Administration
{
    public class ExpertSearchService : Interactor<ExpertSearchService, IExpertSearchRequest, IExpertSearchResult>
    {
        private readonly IExpertModelRepository _repository;

        public ExpertSearchService(IExpertModelRepository repo)
        {
            _repository = repo;
        }
        public override IExpertSearchResult Process(IExpertSearchRequest aRequest)
        {
            var resultDto = _repository.Search(aRequest.AreaOfExpertise);

            var list = new List<ExpertInfo>();
            foreach (var dto in resultDto)
            {
                var expert = ExpertInfo.Fetch(dto);
                list.Add(expert);
            }

            return ExpertSearchResult.Create(list);
        }
    }
}
