using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Base
{
    public abstract class Interactor<T, Request, Response>
        where Request : IRequest
        where Response : IResponse
    {
        public abstract Response Process(Request aRequest);
    }
}
