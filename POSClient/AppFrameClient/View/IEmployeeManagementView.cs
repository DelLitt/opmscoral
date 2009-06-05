using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrameClient.Logic;

namespace AppFrameClient.View
{
    public interface IEmployeeManagementView
    {
        IMainLogic MainLogic { get;  set; }

        event EventHandler<MainLogicEventArgs> ProcessPeriodEvent;
        event EventHandler<MainLogicEventArgs> StartPeriodEvent;
        event EventHandler<MainLogicEventArgs> EndPeriodEvent;
    }
}