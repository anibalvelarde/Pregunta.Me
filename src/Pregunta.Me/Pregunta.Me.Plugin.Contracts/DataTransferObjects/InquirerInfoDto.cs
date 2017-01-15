using Pregunta.Me.Plugin.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Plugin.Contracts.DataTransferObjects
{
    public class InquirerInfoDto : Dto
    {
        public InquirerInfoDto(int identifier)
            : base(identifier)
        { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
