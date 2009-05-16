using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IDepartmentStockCheckingController
    {
        #region View
        IDepartmentStockCheckingView DepartmentStockCheckingView { get; set; }
        #endregion
        #region Logic
        IDepartmentStockLogic DepartmentStockLogic { get; set; }
        IProductLogic ProductLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
        IDepartmentStockTempLogic DepartmentStockTempLogic { get; set; }

        #endregion
    }
}
