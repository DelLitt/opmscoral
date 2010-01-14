using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentCostController
    {
        // views
        IDepartmentCostCreateView DepartmentCostCreateView { get; set; }
        IDepartmentCostEditView DepartmentCostEditView { get; set; }
        IDepartmentCostListView DepartmentCostListView { get; set; }
        IDepartmentCostSummaryView DepartmentCostSummaryView { get; set; } 

        // logic
        IDepartmentCostLogic DepartmentCostLogic { get; set; }
        IEmployeeMoneyLogic EmployeeMoneyLogic { get; set; }
    }
}
