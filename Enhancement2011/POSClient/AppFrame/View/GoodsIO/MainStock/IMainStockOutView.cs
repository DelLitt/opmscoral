using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IMainStockOutView : IView<MainStockOutEventArgs>
    {
        IMainStockOutController MainStockOutController { set; }
        event EventHandler<MainStockOutEventArgs> FindBarcodeEvent;
        event EventHandler<MainStockOutEventArgs> FindByStockInIdEvent;
        event EventHandler<MainStockOutEventArgs> SaveStockOutEvent;
        event EventHandler<MainStockOutEventArgs> FillProductToComboEvent;
        event EventHandler<MainStockOutEventArgs> LoadGoodsByNameEvent;
        event EventHandler<MainStockOutEventArgs> LoadProductColorEvent;
        event EventHandler<MainStockOutEventArgs> LoadProductSizeEvent;
        event EventHandler<MainStockOutEventArgs> LoadStockStatusEvent;
        event EventHandler<MainStockOutEventArgs> LoadGoodsByNameColorSizeEvent;
    }
}
