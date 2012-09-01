using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Validation
{
    public class POSError
    {
        public POSError()
        {
        }
        public POSError(string name, string detail, string property, string trace)
        {
            ErrorName = name;
            ErrorDetail = detail;
            InvalidProperty = property;
            StackTrace = trace;
        }

        public string ErrorName { get; set; }
        public string ErrorDetail { get; set; }
        public string StackTrace { get; set; }
        public string InvalidProperty { get; set; }
    }
}
