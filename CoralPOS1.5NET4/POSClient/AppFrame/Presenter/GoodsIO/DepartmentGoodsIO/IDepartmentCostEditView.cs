using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentCostEditView
    {
        IDepartmentCostController DepartmentCostController { get; set; }
        event EventHandler<DepartmentCostEventArgs> EditDepartmentCostEvent;
    }
}
