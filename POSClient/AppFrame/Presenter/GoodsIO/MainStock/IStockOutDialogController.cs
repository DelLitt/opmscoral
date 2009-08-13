using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IStockOutDialogController
    {
        IStockOutDialogView StockOutDialogView { get; set; }
    }
}
