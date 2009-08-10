using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface IProcessPeriodMoneyView
    {
        IProcessPeriodMoneyLogic ProcessPeriodMoneyLogic { get; set; }

        event EventHandler<ProcessPeriodMoneyEventArgs> LoadProcessPeriodMoneyEvent;
    }
}