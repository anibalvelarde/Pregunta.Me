using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Admin
{
    public class AdminService
    {
        public AdminService()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }

        public ExpertEdit CreateExpert(string firstName, string lastName, string email, string currency, double billingRate, string language)
        {
            var user = new ExpertEdit();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.Currency = currency;
            user.BillingRate = billingRate;
            user.Language = language;
            user.Save();

            return user;
        }

        public InquirerEdit CreateInquirer(string firstName, string lastName, string email)
        {
            var user = new InquirerEdit();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.Save();

            return user;
        }
    }
}
