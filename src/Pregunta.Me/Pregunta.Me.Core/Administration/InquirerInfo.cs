using Pregunta.Me.Core.Base;
using Pregunta.Me.Core.ValueObjects;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Pregunta.Me.Plugin.Contracts.DataTransferObjects;

namespace Pregunta.Me.Core.Administration
{
    public class InquirerInfo : Entity
    {
        private InquirerInfo(InquirerInfoDto initData)
        {
            this.Id = initData.Id;
            this.FirstName = initData.FirstName;
            this.LastName = initData.LastName;
            this.Email = Email.Create(initData.Email, $"{initData.FirstName} {initData.LastName}");
        }

        public static InquirerInfo Fetch(int inquirerId, IInquirerModelRepository repo)
        {
            var  dto = repo.Fetch(inquirerId);
            return new InquirerInfo(dto);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
    }
}
