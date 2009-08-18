using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;

namespace AppFrame.Presenter
{
    public interface IStockInConfirmController
    {
        IStockInConfirmView StockInConfirmView { get; set; }
        //IDepartmentStockOutReportView DepartmentStockOutReportView { get; set; }
        #region logic
        IStockInLogic DepartmentStockInLogic { get; set; }
        IStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        
        IDepartmentLogic DepartmentLogic { get; set; }
        IDepartmentPriceLogic DepartmentPriceLogic { get; set; }

        IStockOutLogic DepartmentStockOutLogic { get; set; }
        IStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
        
        IStockLogic StockLogic { get; set; }
        #endregion
    }
}
