using Pregunta.Me.Core.Administration;
using Pregunta.Me.Services.Base;
using System;

namespace Pregunta.Me.Services.Administration
{
    internal class ExpertRegistrationResponse : Response, IExpertRegistrationResponse
    {

        internal ExpertRegistrationResponse()
        {
        }

        public ExpertEdit Expert { get; private set; }

        internal void SetExpert(ExpertEdit expertEdit)
        {
            this.Expert = expertEdit;
            this.IsValid = true;
        }
    }
}