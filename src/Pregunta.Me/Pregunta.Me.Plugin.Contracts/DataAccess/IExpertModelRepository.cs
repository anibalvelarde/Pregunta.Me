using Pregunta.Me.Plugin.Contracts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Plugin.Contracts.DataAccess
{
    public interface IExpertModelRepository : IRepository
    {
        ExpertInfoDto Fetch(int identifier);
        List<ExpertInfoDto> Search(string areaOfExpertise);
    }
}
