using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.Reports;

namespace AppFrame.Presenter.Report
{
    public interface IReportStockInController
    {
        IReportStockInParamView ReportStockInParamView { get; set;}
        IReportStockInView ReportStockInView { get; set; }    


    #region logic
        IStockLogic StockLogic { get; set; }
        IStockInLogic StockInLogic { get; set; }
        IStockInDetailLogic StockInDetailLogic { get; set; }
    #endregion
    }
}
