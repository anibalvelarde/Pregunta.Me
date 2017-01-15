using Pregunta.Me.Core.Base;
using Pregunta.Me.Core.ValueObjects;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Pregunta.Me.Plugin.Contracts.DataTransferObjects;

namespace Pregunta.Me.Core.Administration
{
    public class ExpertInfo : Entity
    {
        private ExpertInfo(ExpertInfoDto initData)
        {
            this.FristName = initData.FirstName;
            this.LastName = initData.LastName;
            this.AreaOfExpertise = initData.AreaOfExpertise;
            this.BillingRate = new BillingRate(initData.BillingRate, initData.BillingCurrency);
        }

        public static ExpertInfo Fetch(int expertId, IExpertModelRepository repo)
        {
            var  dto = repo.Fetch(expertId);
            return new ExpertInfo(dto);
        }
        public static ExpertInfo Fetch(ExpertInfoDto data)
        {
            return new ExpertInfo(data);
        }

        public string FristName { get; private set; }
        public string LastName { get; private set; }
        public string AreaOfExpertise { get; private set; }
        public BillingRate BillingRate { get; private set; }
    }
}
