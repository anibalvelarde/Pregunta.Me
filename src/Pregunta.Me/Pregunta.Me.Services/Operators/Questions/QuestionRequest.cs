using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregunta.Me.Core.Administration;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.Services.Operators.Questions
{
    internal class QuestionRequest : IQuestionRequest
    {
        public static QuestionRequest Issue(InquirerInfo askedBy, ExpertInfo askedTo, string questionText)
        {
            return new QuestionRequest(askedBy, askedTo, questionText);
        }

        private QuestionRequest(InquirerInfo askedBy, ExpertInfo askedTo, string text)
        {
            this.AskedBy = askedBy;
            this.AskTo = askedTo;
            this.QuestionText = text;
        }

        public InquirerInfo AskedBy { get; private set; }
        public ExpertInfo AskTo { get; private set; }
        public string QuestionText { get; private set; }
        public Question DraftQuestion()
        {
            return new Question(this.QuestionText);
        }
    }
}
