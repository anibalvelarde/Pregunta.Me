using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Admin
{
    public class InquirerEdit
    {
        internal InquirerEdit() { }

        public int InquirerId { get; private set; }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }

        public bool IsValid { get; private set; }

        public void Save()
        {
            InquirerId = 2000;
            IsValid = true;
        }
    }
}
