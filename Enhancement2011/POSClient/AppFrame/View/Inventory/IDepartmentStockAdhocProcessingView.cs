using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Inventory;

namespace AppFrame.View.Inventory
{
    public interface IDepartmentStockAdhocProcessingView
    {
        IDepartmentStockAdhocProcessingController DepartmentStockAdhocProcessingController { get; set; }
        event EventHandler<DepartmentStockAdhocProcessingEventArgs> LoadAdhocStocksEvent;
        event EventHandler<DepartmentStockAdhocProcessingEventArgs> ProcessAdhocStocksEvent;
    }
}
