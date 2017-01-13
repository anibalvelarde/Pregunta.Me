using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Services.Base
{
    public interface IResponse
    {
        Exception Errors { get; }
        bool IsValid { get; }
    }
}
