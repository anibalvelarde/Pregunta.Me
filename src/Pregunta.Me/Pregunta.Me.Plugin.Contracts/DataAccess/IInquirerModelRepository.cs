using Pregunta.Me.Plugin.Contracts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Plugin.Contracts.DataAccess
{
    public interface IInquirerModelRepository : IRepository
    {
        InquirerInfoDto Fetch(int identifier);
    }
}
