using Pregunta.Me.Plugin.Contracts.DataTransferObjects;

namespace Pregunta.Me.Plugin.Contracts.DataAccess
{
    public interface IQuestionnaireRepository : IRepository
    {
        void Log(QuestionDto questionData);
    }
}
