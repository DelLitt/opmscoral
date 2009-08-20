using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter;

namespace AppFrame.View.GoodsIO
{
    public interface IStockOutConfirmView
    {
        IStockOutConfirmController StockOutConfirmController { get; set; }

        event EventHandler<StockOutConfirmEventArgs> ConfirmStockOutEvent;
        event EventHandler<StockOutConfirmEventArgs> DenyStockOutEvent;
        event EventHandler<StockOutConfirmEventArgs> LoadStockOutsEvent;
        event EventHandler<StockOutConfirmEventArgs> LoadConfirmingStockOutsEvent;
    }
}
