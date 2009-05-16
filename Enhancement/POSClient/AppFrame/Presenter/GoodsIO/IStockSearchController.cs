using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;

namespace AppFrame.Presenter.GoodsIO
{
    public interface IStockSearchController : IBaseController<StockSearchEventArgs>
    {
        #region View use in IStockSearchController
        IStockSearchView StockSearchView { get; set; }
        #endregion

        #region Logic use in IStockSearchController
        #endregion
    }
}
