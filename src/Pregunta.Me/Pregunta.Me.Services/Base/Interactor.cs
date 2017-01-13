using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Base
{
    public abstract class Interactor<T, Req, Resp>
        where Req : IRequest
        where Resp : IResponse
    {
        public abstract Resp Process(Req aRequest);
    }
}
