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
        
        event EventHandler<StockOutDialogEventArgs> InitDialogEvent;
        event EventHandler<StockOutDialogEventArgs> FindProductMasterNameEvent;
        event EventHandler<StockOutDialogEventArgs> FindProductMastersEvent;
        event EventHandler<StockOutDialogEventArgs> FindProductColorNameEvent;
        event EventHandler<StockOutDialogEventArgs> FindProductSizeNameEvent;
        event EventHandler<StockOutDialogEventArgs> DivideProductMastersEvent;

    }
}
