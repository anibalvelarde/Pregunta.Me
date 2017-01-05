﻿using System;
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
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public string Currency { get; internal set; }
        public double BillingRate { get; internal set; }
        public string Language { get; internal set; }

        public bool IsValid { get; private set; }

        public void Save()
        {
            ExpertId = 1000;
            IsValid = true;
        }
    }
}