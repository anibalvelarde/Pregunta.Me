using Pregunta.Me.Plugin.Contracts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregunta.Me.Plugin.Contracts.DataTransferObjects;

namespace Pregunta.Me.Infra.DataAccess
{
    public class InquirerModelRepository : IInquirerModelRepository
    {
        public InquirerInfoDto Fetch(int identifier)
        {
            var data = new InquirerInfoDto(identifier);
            data.FirstName = $"fname-{identifier}";
            data.LastName = $"lname-{identifier}";
            data.Email = $"flname-{identifier}@domain.com";
            return data;
        }
    }
}
