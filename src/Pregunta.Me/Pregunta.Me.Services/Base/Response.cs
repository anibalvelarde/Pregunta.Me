using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Base
{
    public abstract class Response : IResponse
    {
        public Response()
        {
            this.IsValid = false;
        }

        public Exception Errors { get; protected set; }

        public bool IsValid { get; protected set; }

        internal void AddException(Exception ex)
        {
            this.Errors = new Exception("Sum Ting Wong", ex);
            this.IsValid = false;
        }
    }
}
