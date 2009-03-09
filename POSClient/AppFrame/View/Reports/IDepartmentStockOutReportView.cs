using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Report;

namespace AppFrame.View.Reports
{
    public interface IDepartmentStockOutReportView
    {
        #region controller
        IReportStockOutController ReportStockOutController { get; set; }
        #endregion
        ReportDepartmentStockOutParam ReportDepartmentStockOutParam { get; set; }
        event EventHandler<ReportStockOutEventArgs> LoadStockOutByRangeEvent;
        event EventHandler<ReportStockOutEventArgs> LoadAllDeparmentEvent;
    }
    public class ReportDepartmentStockOutParam
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
