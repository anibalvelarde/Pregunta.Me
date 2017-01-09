using Pregunta.Me.Core.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Administration
{
    public interface IExpertRegistrationResponse
    {
        ExpertEdit Expert { get; }
        AggregateException Errors { get; }
        bool IsValid { get; }
    }
}
