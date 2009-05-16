using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockDetailView : IView<DepartmentStockDetailEventArgs>
    {
        #region main controller and event
        IDepartmentStockDetailController DepartmentStockDetailController { set; }
        event EventHandler<DepartmentStockDetailEventArgs> SaveDepartmentPriceEvent;
        event EventHandler<DepartmentStockDetailEventArgs> SearchDepartmentStockInDetailEvent;
        #endregion
    }
}
