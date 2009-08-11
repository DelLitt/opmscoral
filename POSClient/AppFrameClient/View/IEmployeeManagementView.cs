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

        event EventHandler<EmployeeManagementEventArgs> ProcessPeriodEvent;
        event EventHandler<EmployeeManagementEventArgs> StartPeriodEvent;
        event EventHandler<EmployeeManagementEventArgs> EndPeriodEvent;
        event EventHandler<EmployeeManagementEventArgs> ProcessEmployeeMoneyEvent;
    }
}