using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrameClient.Logic;
using ClientManagementTool.Logic;

namespace AppFrameClient.View.Management
{
    public interface IEmployeeWorkingsView
    {
        IEmployeeWorkingsLogic EmployeeWorkingsLogic { get;set;}
        event EventHandler<EmployeeWorkingsLogicEventArg> SaveEmployeeWorkingDay;
        event EventHandler<EmployeeWorkingsLogicEventArg> LoadEmployeesWorkingDay;
    }
}