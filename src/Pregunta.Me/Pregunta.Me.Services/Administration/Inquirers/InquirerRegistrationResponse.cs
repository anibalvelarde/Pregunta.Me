using System;
using Pregunta.Me.Core.Administration;
using Pregunta.Me.Services.Base;

namespace Pregunta.Me.Services.Administration
{
    internal class InquirerRegistrationResponse : Response, IInquirerRegistrationResponse
    {
        public InquirerRegistrationResponse()
        {
        }

        public InquirerEdit Inquirer { get; private set; }

        internal void SetInquirer(InquirerEdit inquirer)
        {
            this.Inquirer = inquirer;
            this.IsValid = true;
        }
    }
}