using System;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.Services.Administration
{
    public class AdminService
    {
        public AdminService()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }

        public ExpertEdit CreateExpert(string firstName, string lastName, string email, string currency, decimal billingRate, string language, string country)
        {
            var user = ExpertEdit.Register(firstName, lastName, email, currency, billingRate, language, country);
            user.Save();

            return user;
        }

        public static IExpertRegistrationRequest IssueNewRegistrationRequestForExpert()
        {
            return new ExpertRegistrationRequest();
        }

        public InquirerEdit CreateInquirer(string firstName, string lastName, string email)
        {
            var user = InquirerEdit.Register(firstName, lastName, email);
            user.Save();

            return user;
        }

        internal IExpertRegistrationResponse RegisterExpert(IExpertRegistrationRequest request)
        {
            var response = new ExpertRegistrationResponse();

            try
            {
                response.SetExpert(this.CreateExpert(request.FirstName, request.LastName, request.Email, request.Currency, request.BillingRate, request.Language, request.Country));

            }
            catch (ArgumentNullException ex)
            {
                response.SetExceptions(ex);
            }

            return response; 
        }
    }
}
