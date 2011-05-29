using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInSearchView : IView<DepartmentStockInSearchEventArgs>
    {
        #region main controller and event
        IDepartmentStockInSearchController DepartmentStockInSearchController { set; }
        event EventHandler<DepartmentStockInSearchEventArgs> SearchDepartmentStockInEvent;
        #endregion
    }
}
