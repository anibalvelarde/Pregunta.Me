using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Administration.Search
{
    public class ExpertSearchRequest : IExpertSearchRequest
    {
        public string AreaOfExpertise { get; set; }
    }
}
