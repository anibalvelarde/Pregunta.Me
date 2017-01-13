using System;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.Services.Administration
{
    public class InquirerRegistrationService : Base.Interactor<InquirerRegistrationService, 
                                                        IInquirerRegistrationRequest, 
                                                        IInquirerRegistrationResponse> 
    {
        public InquirerRegistrationService()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }

        public static IInquirerRegistrationRequest IssueNewRegistrationRequestForInquirer()
        {
            return new InquirerRegistrationRequest();
        }

        private InquirerEdit CreateInquirer(string firstName, string lastName, string email)
        {
            var user = InquirerEdit.Register(firstName, lastName, email);
            user.Save();

            return user;
        }

        public override IInquirerRegistrationResponse Process(IInquirerRegistrationRequest request)
        {
            var response = new InquirerRegistrationResponse();

            try
            {
                response.SetInquirer(this.CreateInquirer(request.FirstName, request.LastName, request.Email));
                return response;
            }
            catch (ArgumentNullException ex)
            {
                response.AddException(ex);
                return response;
            }
        }
    }
}
