using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Presenter.Report;

namespace AppFrame.View.GoodsIO
{
    public interface IDepartmentStockOutReportView
    {
        IReportStockOutController ReportStockOutController { get; set; }

        event EventHandler<ReportStockOutEventArgs> ConfirmStockOutEvent;
        event EventHandler<ReportStockOutEventArgs> DenyStockOutEvent;
        event EventHandler<ReportStockOutEventArgs> LoadDepartmentStockOutsEvent;
    }
}
