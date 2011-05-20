using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrameClient.View.Management;

namespace AppFrameClient.Logic
{
    public interface IEmployeeWorkingsLogic
    {
        IEmployeeWorkingsView EmployeeWorkingView { get; set; }

        // logic
        IEmployeeWorkingDayLogic EmployeeWorkingDayLogic { get; set; }
        IEmployeeDetailLogic EmployeeInfoLogic { get; set; }
        IEmployeeLogic EmployeeLogic { get; set; }
    }
}