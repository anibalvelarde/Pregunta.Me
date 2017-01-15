using Pregunta.Me.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.ValueObjects
{
    public enum Unit
    {
        Invalid,
        Answer
    }

    public class BillingRate : ValueObject<BillingRate>
    {
        public BillingRate(double rate, string currency)
        {
            this.Rate = new Money(currency, rate);
            this.Unit = Unit.Answer;
            this.IsValid = true;
        }

        public Money Rate { get; private set; }
        public Unit Unit { get; private set; }
        public bool IsValid { get; internal set; }

        public Money CalculateBillingAmount(int unitCount)
        {
            return this.Rate * unitCount;
        }

        protected override bool EqualsCore(BillingRate other)
        {
            return Rate == other.Rate && 
                   Unit == other.Unit;
        }
        protected override int GetHashCodeCore()
        {
            ///////////////
            // MOTIVATION:
            // More info about the motivation for this design approach can be found at the following link: 
            // http://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
            ///////////////
            int hash = 13;
            hash = (hash * 7) + Rate.GetHashCode();
            hash = (hash * 7) + Unit.GetHashCode();
            return hash;
        }
    }
}
