using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter
{
    public class ProcessPeriodMoneyEventArgs : BaseEventArgs
    {
        public IList PeriodMoneyList { get; set; }
        public long InMoney { get; set; }
    }
}