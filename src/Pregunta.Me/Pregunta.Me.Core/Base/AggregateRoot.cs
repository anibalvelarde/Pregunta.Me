using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.Base
{
    public abstract class AggregateRoot : Entity
    {
        public int Version { get; internal set; }
    }
}
