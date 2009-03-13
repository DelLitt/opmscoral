using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IBaseStockOutController
    {
        IBaseStockOutView BaseStockOutView { get; set; }
        IProductLogic ProductLogic { get; set; }
        IStockLogic StockLogic { get; set; }
        IStockOutLogic StockOutLogic { get; set; }
        IStockOutDetailLogic StockOutDetailLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }

        IDepartmentStockHistoryLogic DepartmentStockHistoryLogic { get; set; }
        IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
    }
}
