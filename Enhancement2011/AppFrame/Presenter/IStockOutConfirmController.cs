using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;

namespace AppFrame.Presenter
{
    public interface IStockOutConfirmController
    {
        IStockOutConfirmView MainStockOutReportView { get; set; }
        //IDepartmentStockOutReportView DepartmentStockOutReportView { get; set; }
        #region logic
        IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; }

        IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }

        IStockOutLogic StockOutLogic { get; set; }
        IStockOutDetailLogic StockOutDetailLogic { get; set; }
        IStockLogic StockLogic { get; set; }
        #endregion
    }
}
