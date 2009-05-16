using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientManagementTool.Logic;

namespace ClientManagementTool.View
{
    public interface IMainView
    {
        IMainLogic MainLogic { get;  set; }

        event EventHandler<MainLogicEventArgs> ProcessPeriodEvent;
        event EventHandler<MainLogicEventArgs> StartPeriodEvent;
        event EventHandler<MainLogicEventArgs> EndPeriodEvent;
    }
}
