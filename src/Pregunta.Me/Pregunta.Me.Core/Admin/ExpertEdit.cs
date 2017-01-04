using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Admin
{
    public class ExpertEdit
    {
        internal ExpertEdit() { }

        public int ExpertId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Currency { get; set; }
        public double BillingRate { get; set; }
        public string Language { get; set; }

        public bool IsValid { get; set; }

        public void Save()
        {
            ExpertId = 1000;
            IsValid = true;
        }
    }
}
