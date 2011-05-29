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
        IStockInLogic StockInLogic { get; set; }
        IStockInDetailLogic StockInDetailLogic { get; set; }
        
        IDepartmentLogic DepartmentLogic { get; set; }
        IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        
        IStockLogic StockLogic { get; set; }
        #endregion
    }
}
