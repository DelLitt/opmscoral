using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface IProcessPeriodMoneyView
    {
        IProcessPeriodMoneyControler ProcessPeriodMoneyControler { get; set; }

        event EventHandler<ProcessPeriodMoneyEventArgs> LoadProcessPeriodMoneyEvent;
        event EventHandler<ProcessPeriodMoneyEventArgs> ProcessEmployeeMoneyEvent;
    }
}