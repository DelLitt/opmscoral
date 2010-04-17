using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter
{
    public class ClosedPeriodEventArgs : BaseEventArgs
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public IList EmployeeMoneyList { get; set; }
    }
}