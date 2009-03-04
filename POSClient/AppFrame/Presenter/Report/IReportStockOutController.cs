using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.Reports;

namespace AppFrame.Presenter.Report
{
    public interface IReportStockOutController
    {
        IDepartmentGoodsExportReportView ReportStockOutView { get; set; }


        #region logic
        IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; }
        #endregion
    }
}
