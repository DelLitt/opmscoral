using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public class ServiceResult
    {
        public bool HasError { get; set; }
        public IList Messages { get; set; }
    }
}
