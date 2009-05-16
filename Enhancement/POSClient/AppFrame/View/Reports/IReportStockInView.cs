using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Report;

namespace AppFrame.View.Reports
{
    public interface IReportStockInView
    {
        #region controller
        IReportStockInController ReportStockInController { get; set; }
        #endregion
        ReportStockInParam ReportStockInParam { get; set; }
        event EventHandler<ReportStockInEventArgs> LoadStockInByRangeEvent;
    }

    public class ReportStockInParam
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
