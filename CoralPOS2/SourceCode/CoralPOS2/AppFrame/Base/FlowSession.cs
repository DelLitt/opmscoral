using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public class FlowSession
    {
        private IFlow _flow;
        IFlow Flow 
        { 
            get
            {
                return _flow;        
            }
            set
            {
                _flow = value;
                _flow.Session = this;
            }
        }
    }
}
