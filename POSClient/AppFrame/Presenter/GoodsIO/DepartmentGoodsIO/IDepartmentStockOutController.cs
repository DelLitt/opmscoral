using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockOutController : IBaseController<DepartmentStockOutEventArgs>
    {
        IDepartmentStockOutView DepartmentStockOutView { get; set; }

        event EventHandler<DepartmentStockOutEventArgs> CompletedFindByStockInEvent;
        
    }
}
