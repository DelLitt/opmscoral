using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockSearchView : IView<DepartmentStockSearchEventArgs>
    {
        #region main controller and event
        IDepartmentStockSearchController DepartmentStockSearchController { set; }
        event EventHandler<DepartmentStockSearchEventArgs> InitDepartmentStockSearchEvent;
        event EventHandler<DepartmentStockSearchEventArgs> SearchDepartmentStockEvent;
        #endregion
    }
}
