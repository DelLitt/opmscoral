using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInView : IView<DepartmentStockInEventArgs>
    {
        #region main controller and event
        IDepartmentStockInController DepartmentStockInController { set; }
        IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController { set; }
        event EventHandler<DepartmentStockInEventArgs> InitDepartmentStockInEvent;
        event EventHandler<ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;
        event EventHandler<DepartmentStockInEventArgs> SaveDepartmentStockInEvent;
        event EventHandler<DepartmentStockInEventArgs> FindProductMasterEvent;
        event EventHandler<DepartmentStockInEventArgs> SyncDepartmentStockInEvent;
        
        #endregion
        
    }
}
