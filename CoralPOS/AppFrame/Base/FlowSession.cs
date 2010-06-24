using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public class FlowSession : DefaultSession,IFlowSession
    {

        public IFlow Flow
        {
            get; set;
        }

        public event EventHandler OnFlowChanged;
        public void Clear()
        {
            _dictionary.Clear();
        }
    }
}
