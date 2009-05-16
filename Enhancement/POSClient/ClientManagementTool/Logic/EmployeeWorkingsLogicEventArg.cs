using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace ClientManagementTool.Logic
{
    public class EmployeeWorkingsLogicEventArg : BaseEventArgs
    {
        public EmployeeWorkingDay EmployeeWorkingDay { get; set;}
        public string EmployeeId { get; set; }
        public IList EmployeeWorkingList { get; set; }
    }
}
