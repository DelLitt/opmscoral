using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using AppFrame.Base;

namespace POSClient.Actions
{
    public class LoginActionResult :IPosActionResult
    {
        public HybridDictionary Result
        {
            get; set;
        }
        public bool IsValidated { get; set; }
    }
}
