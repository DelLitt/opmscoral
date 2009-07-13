using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IMainStockInSearchController : IBaseController<MainStockInSearchEventArgs>
    {
        #region View use in IDepartmentStockInSearchController
        IMainStockInSearchView StockInSearchView { get; set; }
        #endregion

        #region Logic use in IDepartmentStockInSearchController
        IStockInLogic StockInLogic { get; set; }
        #endregion

        #region events in view
        event EventHandler<MainStockInSearchEventArgs> CompletedMainStockInSearchEvent;
        #endregion
    }
}