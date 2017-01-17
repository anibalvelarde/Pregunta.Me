using Pregunta.Me.Core.ValueObjects;
using Pregunta.Me.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Operators.Questions
{
    public interface IQuestionReceipt : IResponse
    {
        Guid Id { get; }
        Question QuestionAsked { get; }
    }
}
