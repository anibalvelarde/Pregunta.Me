using Pregunta.Me.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.ValueObjects
{
    public class Question : ValueObject<Question>
    {
        private Question()
        {
            this.Id = Guid.Empty;
            this.Text = string.Empty;
            this.Answer = Answer.NullAnswer();
            this.AnsweredOn = DateTime.MinValue;
        }
        public Question(string questionText)
        {
            this.Id = Guid.NewGuid();
            this.Text = questionText;
            this.Answer = Answer.NullAnswer();
            this.AnsweredOn = Answer.CreatedOn;
        }
        public static Question NullQuestion()
        {
            return new Question();
        }

        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public DateTime AnsweredOn { get; private set; }

        public Answer Answer { get; private set; }

        public void Respond(Answer anAnswer)
        {
            this.Answer = anAnswer;
        }

        protected override bool EqualsCore(Question other)
        {
            return this.Id.Equals(other.Id);
        }
        protected override int GetHashCodeCore()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + Text.GetHashCode();
            hash = (hash * 7) + Answer.GetHashCode();
            hash = (hash * 7) + AnsweredOn.GetHashCode();
            return hash;
        }
    }
}
