using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentCostListView
    {
        IDepartmentCostController DepartmentCostController { get; set; }
        event EventHandler<DepartmentCostEventArgs> SearchDepartmentCostEvent;
    }
}
