using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IMainStockInView : IView<MainStockInEventArgs>
    {

        event EventHandler<MainStockInEventArgs> FillProductToComboEvent;
        event EventHandler<MainStockInEventArgs> LoadGoodsByIdEvent;
        event EventHandler<MainStockInEventArgs> LoadGoodsByNameEvent;
        event EventHandler<MainStockInEventArgs> LoadProductColorEvent;
        event EventHandler<MainStockInEventArgs> LoadProductSizeEvent;
        event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorEvent;
        event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        event EventHandler<MainStockInEventArgs> SaveStockInEvent;
        event EventHandler<MainStockInEventArgs> GetPriceEvent;
        event EventHandler<MainStockInEventArgs> LoadAllGoodsByNameEvent;
        event EventHandler<MainStockInEventArgs> FindByBarcodeEvent;
        event EventHandler<MainStockInEventArgs> SaveReStockInEvent;
        event EventHandler<MainStockInEventArgs> LoadStockInEvent;
        event EventHandler<MainStockInEventArgs> UpdateStockInEvent;
    }
}
