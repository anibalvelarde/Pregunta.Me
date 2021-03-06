﻿using Pregunta.Me.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Administration
{
    public interface IExpertRegistrationRequest : IRequest
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Currency { get; set; }
        double BillingRate { get; set; }
        string Language { get; set; }
        string Country { get; set; }
    }
}
