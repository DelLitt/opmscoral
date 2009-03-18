using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View;

namespace AppFrame.Presenter
{
    public interface ISecurityController
    {
        ISecurityView SecurityView { get; set; }

        ILoginLogic LoginLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; } 
    }
}
