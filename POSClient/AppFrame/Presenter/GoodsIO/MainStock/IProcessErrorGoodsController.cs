using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IProcessErrorGoodsController
    {
        IProcessErrorGoodsView ProcessErrorGoodsView { get; set; }

        IStockOutLogic StockOutLogic { get; set; }
        IStockOutDetailLogic StockOutDetailLogic { get; set; }
        IStockLogic StockLogic { get; set; }
    }
}
