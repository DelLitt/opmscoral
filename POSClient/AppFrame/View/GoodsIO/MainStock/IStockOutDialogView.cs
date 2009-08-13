using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IStockOutDialogView
    {
        IStockOutDialogController StockOutDialogController { get; set; }
        
        event EventHandler<StockOutDialogEventArg> InitDialogEvent;
        event EventHandler<StockOutDialogEventArg> FindProductMasterNameEvent;
        event EventHandler<StockOutDialogEventArg> FindProductMastersEvent;
        event EventHandler<StockOutDialogEventArg> FindProductColorNameEvent;
        event EventHandler<StockOutDialogEventArg> FindProductSizeNameEvent;
        event EventHandler<StockOutDialogEventArg> DivideProductMastersEvent;

    }
}
