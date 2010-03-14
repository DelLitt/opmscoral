using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Exceptions
{
    public class IllegalFlowStateException : System.Exception
    {
        public IllegalFlowStateException() : base()
        {}
        public IllegalFlowStateException(string message) : base(message)
        {
            
        }
    }
}