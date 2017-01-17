using Pregunta.Me.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Operators.Questions
{
    internal class QuestionReceipt : IQuestionReceipt
    {
        public QuestionReceipt(Question aQuestion)
        {
            this.Id = aQuestion.Id;
            this.QuestionAsked = aQuestion;
            IsValid = true;
        }
        public QuestionReceipt(Exception error)
        {
            this.Errors = error;
            this.IsValid = false;
            this.QuestionAsked = Question.NullQuestion();
        }

        public Exception Errors { get; private set; }
        public Guid Id { get; private set; }
        public bool IsValid { get; private set; }
        public Question QuestionAsked { get; private set; }
    }
}
