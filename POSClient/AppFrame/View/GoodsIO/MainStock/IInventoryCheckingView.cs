using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.MainStock;

namespace AppFrame.View.GoodsIO.MainStock
{
    public interface IInventoryCheckingView
    {
        #region Event
        event EventHandler<InventoryCheckingEventArgs> FillProductMasterToComboEvent;
        event EventHandler<InventoryCheckingEventArgs> LoadGoodsByProductIdEvent;
        event EventHandler<InventoryCheckingEventArgs> SaveInventoryCheckingEvent;
        #endregion

        #region Controller
        IInventoryCheckingController InventoryCheckingController { get; set; }
        #endregion 
    }
}
