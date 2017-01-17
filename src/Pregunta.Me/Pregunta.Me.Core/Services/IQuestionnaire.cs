using Pregunta.Me.Core.Administration;
using Pregunta.Me.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Services
{
    public interface IQuestionnaire
    {
        void LogQuestion(InquirerInfo asker, Question aQuestion, ExpertInfo responder);
    }
}
