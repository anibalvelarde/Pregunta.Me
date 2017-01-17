using Moq;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Spackle;

namespace Pregunta.Me.UnitTests
{
    internal class TestUtilities
    {
        internal static RandomObjectGenerator rog { get { return Singleton.Instance.Rog; } }

        internal static IInquirerModelRepository MakeFakeInquirerModelRepo(int inquirerId)
        {
            var dto = new Plugin.Contracts.DataTransferObjects.InquirerInfoDto(inquirerId)
            {
                FirstName = $"fn-{inquirerId}",
                LastName = $"ln-{inquirerId}",
                Email = $"email@inquirer-{inquirerId}.com"
            };
            return Mock.Of<IInquirerModelRepository>(repo => repo.Fetch(inquirerId) == dto);
        }

        internal static IExpertModelRepository MakeFakeExpertModelRepo(int expertId,
                                                    string areaOfExpertise = "Neurology",
                                                    string currency = "USD",
                                                    double rate = 4.50)
        {
            var dto = new Plugin.Contracts.DataTransferObjects.ExpertInfoDto(expertId)
            {
                FirstName = $"fn-{expertId}",
                LastName = $"ln-{expertId}",
                AreaOfExpertise = areaOfExpertise,
                BillingCurrency = currency,
                BillingRate = rate
            };
            return Mock.Of<IExpertModelRepository>(repo => repo.Fetch(expertId) == dto);
        }
    }


}
