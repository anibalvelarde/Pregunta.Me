using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Plugin.Contracts.Base
{
    public abstract class Dto
    {
        public Dto (int identifier)
        {
            this.Id = identifier;
        }

        public int Id { get; private set; }
    }
}
