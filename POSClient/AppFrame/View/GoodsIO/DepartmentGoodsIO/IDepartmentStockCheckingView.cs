using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockCheckingView
    {
        #region Event
        event EventHandler<DepartmentStockCheckingEventArgs> FillProductMasterToComboEvent;
        event EventHandler<DepartmentStockCheckingEventArgs> LoadGoodsByProductIdEvent;
        event EventHandler<DepartmentStockCheckingEventArgs> SaveInventoryCheckingEvent;
        #endregion

        #region Controller
        IDepartmentStockCheckingController DepartmentStockCheckingController { get; set; }
        #endregion 
    }
}
