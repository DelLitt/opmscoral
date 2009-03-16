using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter
{
    public class SecurityEventArgs : BaseEventArgs
    {
        public IList departmentList { get; set; }
        public IList employees { get; set; }
        public IList userInfoList { get; set; }
    }
}
