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

        public InquirerEdit CreateInquirer(string firstName, string lastName, string email)
        {
            var user = InquirerEdit.Register(firstName, lastName, email);
            user.Save();

            return user;
        }
    }
}
