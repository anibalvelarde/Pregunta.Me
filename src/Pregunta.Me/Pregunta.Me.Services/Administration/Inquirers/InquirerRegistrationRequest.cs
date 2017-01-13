using System;

namespace Pregunta.Me.Services.Administration
{
    internal class InquirerRegistrationRequest : IInquirerRegistrationRequest
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}