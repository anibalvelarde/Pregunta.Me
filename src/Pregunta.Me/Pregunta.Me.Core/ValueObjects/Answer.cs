using Pregunta.Me.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.ValueObjects
{
    public class Answer : ValueObject<Answer>
    {
        public static Answer NullAnswer()
        {
            return new Answer();
        }

        private Answer()
        {
            this.Id = Guid.Empty;
            this.Text = string.Empty;
            this.CreatedOn = DateTime.MinValue;
        }
        public Answer(string answerText)
        {
            this.Id = Guid.NewGuid();
            this.Text = answerText;
            this.CreatedOn = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedOn { get; private set; }

        protected override bool EqualsCore(Answer other)
        {
            return this.Id.Equals(other.Id);
        }
        protected override int GetHashCodeCore()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + Text.GetHashCode();
            hash = (hash * 7) + CreatedOn.GetHashCode();
            return hash;
        }
    }
}
