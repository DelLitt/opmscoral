using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Inventory;

namespace AppFrame.View.Inventory
{
    public interface IDepartmentStockFixingView
    {
        IDepartmentStockFixingController DepartmentStockAdhocProcessingController { get; set; }
        event EventHandler<DepartmentStockFixingEventArgs> LoadAdhocStocksEvent;
        event EventHandler<DepartmentStockFixingEventArgs> ProcessAdhocStocksEvent;
    }
}
