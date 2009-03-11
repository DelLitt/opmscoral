using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IProcessErrorGoodsView
    {
        IProcessErrorGoodsController ProcessErrorGoodsController { get; set; }

        event EventHandler<ProcessErrorGoodsEventArgs> LoadAllStockDefects;
        event EventHandler<ProcessErrorGoodsEventArgs> SaveStockDefects;
    }
}
