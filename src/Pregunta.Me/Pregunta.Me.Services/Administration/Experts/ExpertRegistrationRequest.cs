namespace Pregunta.Me.Services.Administration
{
    sealed class ExpertRegistrationRequest : IExpertRegistrationRequest
    {
        internal ExpertRegistrationRequest()
        {

        }

        public double BillingRate { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Language { get; set; }

        public string LastName { get; set; }
    }
}
