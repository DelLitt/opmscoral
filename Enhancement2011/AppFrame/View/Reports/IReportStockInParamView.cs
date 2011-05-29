using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.Report;

namespace AppFrame.View.Reports
{
    public interface IReportStockInParamView
    {
        #region controller 
        IReportStockInController ReportStockInController {get;set;}
        #endregion

        event EventHandler<ReportStockInEventArgs> CreateReportStockIn;
    }
}
