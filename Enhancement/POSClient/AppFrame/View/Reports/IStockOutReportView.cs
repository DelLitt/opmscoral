using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Report;

namespace AppFrame.View.Reports
{
    public interface IStockOutReportView
    {
        IReportStockOutController ReportStockOutController { get; set; }

        #region event

        event EventHandler<ReportStockOutEventArgs> LoadStockOutsEvent;
        event EventHandler<ReportStockOutEventArgs> LoadStockOutDetailEvent;
        
        #endregion
    }
}
