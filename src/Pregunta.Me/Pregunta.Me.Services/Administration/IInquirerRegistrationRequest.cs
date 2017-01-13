using Pregunta.Me.Services.Base;

namespace Pregunta.Me.Services.Administration
{
    public interface IInquirerRegistrationRequest : IRequest
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
}