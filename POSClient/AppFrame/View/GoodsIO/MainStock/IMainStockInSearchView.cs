using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IMainStockInSearchView : IView<MainStockInSearchEventArgs>
    {
        #region main controller and event
        IMainStockInSearchController MainStockInSearchController { set; }
        event EventHandler<MainStockInSearchEventArgs> SearchStockInEvent;
        event EventHandler<MainStockInSearchEventArgs> SearchSingleStockInEvent;
        #endregion
    }
}
