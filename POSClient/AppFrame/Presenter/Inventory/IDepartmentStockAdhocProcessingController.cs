using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.Inventory;

namespace AppFrame.Presenter.Inventory
{
    public interface IDepartmentStockAdhocProcessingController
    {
        IDepartmentStockAdhocProcessingView DepartmentStockAdhocProcessingView { get; set; }
        IProductLogic ProductLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IDepartmentStockTempLogic DepartmentStockTempLogic { get; set; }
    }
}
