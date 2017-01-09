using System;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.Services.Administration
{
    internal class ExpertRegistrationResponse : IExpertRegistrationResponse
    {
        internal ExpertRegistrationResponse()
        {
        }

        public ExpertEdit Expert { get; private set; }
        public AggregateException Errors { get; private set; }
        public bool IsValid { get; private set; }

        internal void SetExpert(ExpertEdit expertEdit)
        {
            this.Expert = expertEdit;
            this.IsValid = true;
        }

        internal void SetExceptions(ArgumentNullException ex)
        {
            this.Errors = new AggregateException("Sum Ting Wong", ex);
            this.IsValid = false;
        }
    }
}