using Pregunta.Me.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Administration
{
    public class InquirerEdit
    {
        public static InquirerEdit Register(string firstName, string lastName, string email)
        {
            var inquirer = new InquirerEdit()
            {
                FirstName = firstName,
                LastName = lastName
            };
            inquirer.MakeEmailAddress(email, $"{inquirer.FirstName} {inquirer.LastName}");
            inquirer.Validate();
            return inquirer;
        }
        public InquirerEdit() { }

        public int InquirerId { get; private set; }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public Email Email { get; internal set; }
        public bool IsValid { get; internal set; }

        public void Save()
        {
            InquirerId = 2000;
            IsValid = true;
        }

        private void MakeEmailAddress(string email, string displayName)
        {
            if(string.IsNullOrEmpty(email)) { throw new ArgumentNullException("Email cannot be null or empty."); }
            this.Email = Email.Create(email, displayName);
        }
        private void Validate()
        {
            if(string.IsNullOrEmpty(FirstName)) { throw new ArgumentNullException("First name cannot be null or empty."); }
            if (string.IsNullOrEmpty(LastName)) { throw new ArgumentNullException("Last name cannot be null or empty."); }
        }
    }
}
