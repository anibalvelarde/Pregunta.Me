using Pregunta.Me.Core.Administration;
using Pregunta.Me.Services.Base;

namespace Pregunta.Me.Services.Administration
{
    public interface IInquirerRegistrationResponse : IResponse
    {
        InquirerEdit Inquirer { get; }
    }
}