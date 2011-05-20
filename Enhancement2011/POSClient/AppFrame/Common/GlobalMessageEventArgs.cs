using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    [Serializable]
    public class GlobalMessageEventArgs : EventArgs
    {
        public bool IsError { get; set; }
        public string Channel { get; set; }
        public string Message { get; set; }
        public IList Messages { get; set; }
    }
}
