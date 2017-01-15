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
        public static Money operator +(Money a, Money b)
        {
            if (IsOfSameCurrency(a, b))
            {
                return new Money(a.Currency, (a.Amount + b.Amount));
            }
            else
            {
                throw new InvalidOperationException($"Attempted to add different currencies A:[{a.ToString()}] and B:[{b.ToString()}]");
            }
        }
        public static Money operator *(Money a, int multiplier)
        {
            return new Money(a.Currency, (a.Amount * multiplier));
        }
        public static Money NoMoney(Money m)
        {
            return NoMoney(m.Currency);
        }
        public static Money NoMoney(string currency)
        {
            return new Money(currency, 0);
        }
        public override string ToString()
        {
            return $"{this.Amount.ToString()} {this.Currency}";
        }

        public Money Add(Money m)
        {
            if (IsOfSameCurrency(this, m))
            {
                return new Money(this.Currency, (this.Amount + m.Amount));
            }
            else
            {
                return this;
            }
        }
        private static bool IsOfSameCurrency(Money a, Money b)
        {
            return a.Currency.Equals(b.Currency);
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
