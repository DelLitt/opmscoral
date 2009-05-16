using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientManagementTool.Logic;

namespace ClientManagementTool.View.Management
{
    public interface IEmployeeWorkingsView
    {
        IEmployeeWorkingsLogic EmployeeWorkingsLogic { get;set;}
        event EventHandler<EmployeeWorkingsLogicEventArg> SaveEmployeeWorkingDay;
        event EventHandler<EmployeeWorkingsLogicEventArg> LoadEmployeesWorkingDay;
    }
}
