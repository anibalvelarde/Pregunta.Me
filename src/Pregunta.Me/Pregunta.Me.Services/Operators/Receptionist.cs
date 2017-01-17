using Pregunta.Me.Services.Base;
using Pregunta.Me.Services.Operators.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregunta.Me.Core.Administration;
using Pregunta.Me.Core.Services;
using Pregunta.Me.Core.ValueObjects;

namespace Pregunta.Me.Services.Operators
{
    public class Receptionist : Interactor<Receptionist, IQuestionRequest, IQuestionReceipt>
    {
        private readonly IQuestionnaire _questionnaire;

        public Receptionist(IQuestionnaire questionnaire)
        {
            _questionnaire = questionnaire;
            this.IsValid = true;
        }

        private IQuestionnaire Questionnaire
        {
            get { return _questionnaire; }
        }
        public bool IsValid { get; private set; }


        public override IQuestionReceipt Process(IQuestionRequest aRequest)
        {
            var aQuestion = aRequest.DraftQuestion();
            this.Questionnaire.LogQuestion(aRequest.AskedBy, aQuestion, aRequest.AskTo);
            return Receptionist.CreateReceipt(aQuestion); 
        }

        public static IQuestionRequest AskQuestion(InquirerInfo inquirer, ExpertInfo expert, string question)
        {
            return QuestionRequest.Issue(inquirer, expert, question);
        }

        private static IQuestionReceipt CreateReceipt(Question aQuestion)
        {
            return new QuestionReceipt(aQuestion);
        }
    }
}
