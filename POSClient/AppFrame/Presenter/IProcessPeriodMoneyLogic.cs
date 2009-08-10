using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View;

namespace AppFrame.Presenter
{
    public interface IProcessPeriodMoneyLogic
    {
        // view
        IProcessPeriodMoneyView ProcessPeriodMoneyView { get; set; }

        // logic
        IEmployeeMoneyLogic EmployeeMoneyLogic { get; set; }
    }
}