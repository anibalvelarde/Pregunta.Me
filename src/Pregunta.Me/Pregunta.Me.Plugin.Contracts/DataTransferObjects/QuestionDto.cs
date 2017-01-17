using Pregunta.Me.Plugin.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Plugin.Contracts.DataTransferObjects
{
    public class QuestionDto : Dto
    {
        public QuestionDto(int identifier) : base(identifier)
        {
        }

        public Guid QuestionReference { get; set; }
        public string QuestionText { get; set; }
        public long AskedBy { get; set; }
        public long AskedTo { get; set; }
        public DateTime AskedOnDateTimeStamp { get; set; }
    }
}
