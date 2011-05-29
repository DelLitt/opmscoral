using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentCostCreateView
    {
        IDepartmentCostController DepartmentCostController { get; set; }
        event EventHandler<DepartmentCostEventArgs> CreateDepartmentCostEvent;
    }
}
