using Pregunta.Me.Core.Administration;
using Pregunta.Me.Services.Base;
using System.Collections.Generic;

namespace Pregunta.Me.Services.Administration.Search
{
    public interface IExpertSearchResult : IResponse
    {
        List<ExpertInfo> Result { get; }
    }
}