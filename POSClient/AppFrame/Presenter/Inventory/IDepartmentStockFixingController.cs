using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.Inventory;

namespace AppFrame.Presenter.Inventory
{
    public interface IDepartmentStockFixingController
    {
        IDepartmentStockFixingView DepartmentStockAdhocProcessingView { get; set; }
        IProductLogic ProductLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IDepartmentStockLogic DepartmentStockLogic { get; set; }
        IStockOutLogic StockOutLogic { get; set; }
        IStockInLogic StockInLogic { get; set; }
        IStockOutDetailLogic StockOutDetailLogic { get; set; }
        IStockInDetailLogic StockInDetailLogic { get; set; }
    }
}
