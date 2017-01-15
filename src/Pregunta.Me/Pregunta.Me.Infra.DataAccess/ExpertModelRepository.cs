using Pregunta.Me.Plugin.Contracts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregunta.Me.Plugin.Contracts.DataTransferObjects;

namespace Pregunta.Me.Infra.DataAccess
{
    public class ExpertModelRepository : IExpertModelRepository
    {
        public ExpertInfoDto Fetch(int identifier)
        {
            var data = new ExpertInfoDto(identifier);
            data.AreaOfExpertise = $"Area of expertise for Expert:{identifier}";
            data.BillingCurrency = "USD";
            data.BillingRate = 4.00;
            data.FirstName = $"fname-{identifier}";
            data.LastName = $"lname-{identifier}";
            return data;
        }

        public List<ExpertInfoDto> Search(string areaOfExpertise)
        {
            return GetExperts().FindAll(e => e.AreaOfExpertise.Equals(areaOfExpertise)).ToList();
        }

        private List<ExpertInfoDto> GetExperts()
        {
            var experts = new List<ExpertInfoDto>()
            {
                new ExpertInfoDto(1000) { AreaOfExpertise = "Neurology", BillingCurrency = "USD", BillingRate = 4.00, FirstName = "Silvia", LastName = "Velarde"  },
                new ExpertInfoDto(1001) { AreaOfExpertise = "Pediatrist", BillingCurrency = "PAB", BillingRate = 4.50, FirstName = "Jami", LastName = "Kello" },
                new ExpertInfoDto(1002) { AreaOfExpertise = "Anesthesyologist", BillingCurrency = "USD", BillingRate = 6.75, FirstName = "Adrian", LastName = "Chino" },
                new ExpertInfoDto(1003) { AreaOfExpertise = "Neurology", BillingCurrency = "PAB", BillingRate = 3.67, FirstName = "Ivan", LastName = "Abadia" }
            };
            return experts;
        }
    }
}
