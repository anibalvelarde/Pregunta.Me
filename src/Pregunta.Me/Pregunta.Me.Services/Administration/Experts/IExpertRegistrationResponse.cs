using Pregunta.Me.Core.Administration;
using Pregunta.Me.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Administration
{
    public interface IExpertRegistrationResponse : IResponse
    {
        ExpertEdit Expert { get; }
    }
}
