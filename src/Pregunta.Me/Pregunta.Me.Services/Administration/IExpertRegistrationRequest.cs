using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Administration
{
    public interface IExpertRegistrationRequest
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Currency { get; set; }
        decimal BillingRate { get; set; }
        string Language { get; set; }
        string Country { get; set; }
    }
}
