using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.Services.Administration.Search
{
    public class ExpertSearchResult : IExpertSearchResult
    {
        public static ExpertSearchResult Create(Exception ex)
        {
            return new ExpertSearchResult(ex);
        }
        private ExpertSearchResult(Exception ex)
        {
            this.Errors = ex;
            this.IsValid = false;
        }
        public static ExpertSearchResult Create(List<ExpertInfo> result)
        {
            return new ExpertSearchResult(result);
        }
        private ExpertSearchResult(List<ExpertInfo> result)
        {
            this.Result = result;
            this.IsValid = true;
        }

        public Exception Errors { get; private set; }
        public bool IsValid { get; private set; }

        public List<ExpertInfo> Result { get; private set; }
    }
}
