using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockOutView : IView<DepartmentStockOutEventArgs>
    {
        //IDepartmentStockOutController DepartmentStockOutController { set; }
        event EventHandler<DepartmentStockOutEventArgs> FindBarcodeEvent;
        event EventHandler<DepartmentStockOutEventArgs> SaveStockOutEvent;
        event EventHandler<DepartmentStockOutEventArgs> FillProductToComboEvent;
        event EventHandler<DepartmentStockOutEventArgs> LoadGoodsByNameEvent;
        event EventHandler<DepartmentStockOutEventArgs> LoadProductColorEvent;
        event EventHandler<DepartmentStockOutEventArgs> LoadProductSizeEvent;
        event EventHandler<DepartmentStockOutEventArgs> LoadStockStatusEvent;
        event EventHandler<DepartmentStockOutEventArgs> LoadGoodsByNameColorSizeEvent;
        event EventHandler<DepartmentStockOutEventArgs> GetSyncDataEvent;
        event EventHandler<DepartmentStockOutEventArgs> SyncToMainEvent;
        event EventHandler<DepartmentStockOutEventArgs> LoadAllDepartments;
    }
}
