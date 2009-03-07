using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IBaseStockOutView
    {
        #region controller
        IBaseStockOutController BaseStockOutController { get; set; }
        event EventHandler<BaseStockOutEventArgs> FillGoodsToCombo;
        event EventHandler<BaseStockOutEventArgs> SaveTempStockOut;
        #endregion
    }
}
