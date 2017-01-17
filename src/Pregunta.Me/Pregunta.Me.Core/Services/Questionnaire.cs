using Pregunta.Me.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregunta.Me.Core.ValueObjects;
using Pregunta.Me.Plugin.Contracts.DataAccess;
using Pregunta.Me.Plugin.Contracts.DataTransferObjects;
using Pregunta.Me.Core.Administration;

namespace Pregunta.Me.Core.Services
{
    public class Questionnaire : DomainService<Questionnaire>, IQuestionnaire
    {
        private readonly IQuestionnaireRepository _repo;

        public Questionnaire(IQuestionnaireRepository repo)
        {
            _repo = repo;
        }

        public void LogQuestion(InquirerInfo asker, Question aQuestion, ExpertInfo responder)
        {
            _repo.Log(ExtractData(asker, aQuestion, responder));
        }

        private QuestionDto ExtractData(InquirerInfo asker, Question aQuestion, ExpertInfo responder)
        {
            return new QuestionDto(0)
            {
                QuestionReference = aQuestion.Id,
                QuestionText = aQuestion.Text,
                AskedBy = asker.Id,
                AskedTo = responder.Id,
                AskedOnDateTimeStamp = DateTime.UtcNow
            };
        }
    }
}
