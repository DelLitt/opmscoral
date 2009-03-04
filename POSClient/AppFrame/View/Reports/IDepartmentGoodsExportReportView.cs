using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Report;

namespace AppFrame.View.Reports
{
    public interface IDepartmentGoodsExportReportView
    {
        #region controller
        IReportStockOutController ReportStockOutController { get; set; }
        #endregion
        ReportStockOutParam ReportStockOutParam { get; set; }
        event EventHandler<ReportStockOutEventArgs> LoadStockOutByRangeEvent;
        event EventHandler<ReportStockOutEventArgs> LoadAllDeparmentEvent;
    }
    public class ReportStockOutParam
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
