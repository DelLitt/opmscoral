using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInExtraView : IDepartmentStockInView
    {
        
        event EventHandler<DepartmentStockInEventArgs> FillProductToComboEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByIdEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadProductColorEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadProductSizeEvent;
        event EventHandler<DepartmentStockInEventArgs> FillDepartmentEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadPriceAndStockEvent;
    }
}
