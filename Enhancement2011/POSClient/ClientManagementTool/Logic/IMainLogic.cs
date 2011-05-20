using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using ClientManagementTool.View;

namespace ClientManagementTool.Logic
{
    public interface IMainLogic
    {
        IMainView MainView { get; set; }

        IEmployeeWorkingDayLogic EmployeeWorkingDayLogic { get; set; }
        IEmployeeDetailLogic EmployeeInfoLogic { get; set; }
        IEmployeeLogic EmployeeLogic { get; set; }
        IDepartmentTimelineLogic DepartmentTimelineLogic { get; set; }
        IDepartmentManagementLogic DepartmentManagementLogic { get; set; }
        ILoginLogic LoginLogic { get; set; }
    }
}
