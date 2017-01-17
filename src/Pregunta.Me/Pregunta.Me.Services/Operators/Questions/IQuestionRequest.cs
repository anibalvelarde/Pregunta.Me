using Pregunta.Me.Core.Administration;
using Pregunta.Me.Core.ValueObjects;
using Pregunta.Me.Services.Base;

namespace Pregunta.Me.Services.Operators.Questions
{
    public interface IQuestionRequest : IRequest
    {
        InquirerInfo AskedBy { get; }
        ExpertInfo AskTo { get; }
        string QuestionText { get; }
        Question DraftQuestion();
    }
}
