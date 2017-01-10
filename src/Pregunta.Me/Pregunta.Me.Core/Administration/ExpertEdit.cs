using Pregunta.Me.Core.Base;
using Pregunta.Me.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Administration
{
    public class ExpertEdit : Entity
    {
        public static ExpertEdit Register(string firstName, string lastName, string email, string currency, decimal billingRate, string language, string country)
        {
            var expert = new ExpertEdit()
            {
                BillingRate = billingRate,
                Country = country,
                Currency = currency,
                FirstName = firstName,
                Language = language,
                LastName = lastName
            };
            expert.MakeEmailAddress(email);
            expert.Validate();
            return expert;
        }

        internal ExpertEdit() { }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public Email Email { get; internal set; }
        public string Currency { get; internal set; }
        public decimal BillingRate { get; internal set; }
        public string Language { get; internal set; }
        public string Country { get; internal set; }

        public bool IsValid { get; private set; }
        public void Save()
        {
            Id = 1000;
            IsValid = true;
        }
        
        private void MakeEmailAddress(string email)
        {
            this.Email = Email.Create(email, $"{FirstName} {LastName}");
        }
        private void Validate()
        {
            if(string.IsNullOrEmpty(FirstName)) { throw new ArgumentNullException("First Name cannot be null or empty."); }
            if(string.IsNullOrEmpty(LastName)) { throw new ArgumentNullException("Last Name cannot be null or empty."); }
            if(string.IsNullOrEmpty(Currency)) { throw new ArgumentNullException("Currency cannot be null or empty."); }
            if(BillingRate<0) { throw new ArgumentException("Billing rate must be => 0."); }
            if(string.IsNullOrEmpty(Language)) { throw new ArgumentNullException("Language cannot be null or empty."); }
            this.IsValid = true;
        }
    }
}
