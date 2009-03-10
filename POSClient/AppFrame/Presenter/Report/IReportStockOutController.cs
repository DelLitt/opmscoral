using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;
using AppFrame.View.Reports;

namespace AppFrame.Presenter.Report
{
    public interface IReportStockOutController
    {
        /*IDepartmentStockInReportView ReportDepartmentStockOutView { get; set; }*/
        IStockOutReportView MainStockOutReportView { get; set; }
        IDepartmentStockOutReportView DepartmentStockOutReportView { get; set; }
        #region logic
        IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; }

        IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }

        IStockOutLogic StockOutLogic { get; set; }
        IStockOutDetailLogic StockOutDetailLogic { get; set; }

        #endregion
    }
}
