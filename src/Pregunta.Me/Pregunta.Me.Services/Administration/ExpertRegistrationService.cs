using System;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.Services.Administration
{
    public class ExpertRegistrationService : Base.Interactor<ExpertRegistrationService, IExpertRegistrationRequest, IExpertRegistrationResponse> 
    {
        public ExpertRegistrationService()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }

        private ExpertEdit CreateExpert(string firstName, string lastName, string email, string currency, double billingRate, string language, string country)
        {
            var user = ExpertEdit.Register(firstName, lastName, email, currency, billingRate, language, country);
            user.Save();

            return user;
        }

        public static IExpertRegistrationRequest IssueNewRegistrationRequestForExpert()
        {
            return new ExpertRegistrationRequest();
        }

        public override IExpertRegistrationResponse Process(IExpertRegistrationRequest request)
        {
            var response = new ExpertRegistrationResponse();

            try
            {
                response.SetExpert(this.CreateExpert(request.FirstName, request.LastName, request.Email, request.Currency, request.BillingRate, request.Language, request.Country));
                return response;
            }
            catch (ArgumentNullException ex)
            {
                response.AddException(ex);
                return response;
            }
        }
    }
}
