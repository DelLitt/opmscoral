using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public interface IFlowSession : ISession
    {
        IFlow Flow { get; set; }
    }
}
