using Pregunta.Me.Plugin.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Plugin.Contracts.DataTransferObjects
{
    public class ExpertInfoDto : Dto
    {
        public ExpertInfoDto(int identifier)
            : base(identifier)
        { }
        public string AreaOfExpertise { get; set; }
        public string BillingCurrency { get; set; }
        public double BillingRate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
