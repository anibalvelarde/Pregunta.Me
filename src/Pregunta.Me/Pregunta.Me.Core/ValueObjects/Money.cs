using Pregunta.Me.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.ValueObjects
{
    public class Money : ValueObject<Money>
    {
        public Money(string currency, double amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        public string Currency { get; private set; }
        public double Amount { get; private set; }

        public Money Add(Money m)
        {
            if (IsOfSameCurrency(m))
            {
                return new Money(this.Currency, (this.Amount + m.Amount));
            }
            else
            {
                return this;
            }
        }
        private bool IsOfSameCurrency(Money m)
        {
            return this.Currency.Equals(m.Currency);
        }

        protected override bool EqualsCore(Money other)
        {
            return Currency == other.Currency &&
                   Amount == other.Amount;
        }
        protected override int GetHashCodeCore()
        {
            ///////////////
            // MOTIVATION:
            // More info about the motivation for this design approach can be found at the following link: 
            // http://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
            ///////////////
            int hash = 13;
            hash = (hash * 7) + Currency.GetHashCode();
            hash = (hash * 7) + Amount.GetHashCode();
            return hash;
        }
    }
}
