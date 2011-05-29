using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.Reports;

namespace AppFrameClient.View.Reports
{
    public partial class frmStockinRpt : BaseForm,IReportStockInParamView
    {
        public frmStockinRpt()
        {
            InitializeComponent();
        }

       

        #region IReportStockInParamView Members

        private AppFrame.Presenter.Report.IReportStockInController reportStockInController;
        public AppFrame.Presenter.Report.IReportStockInController ReportStockInController
        {
            get
            {
                return reportStockInController;
            }
            set
            {
                reportStockInController = value;
                reportStockInController.ReportStockInParamView = this;

            }
        }

        #endregion

        #region IReportStockInParamView Members


        public event EventHandler<AppFrame.Presenter.Report.ReportStockInEventArgs> CreateReportStockIn;

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            ReportStockInParam reportStockInParam = new ReportStockInParam();
            reportStockInParam.FromDate = dtpReportTimeFrom.Value;
            reportStockInParam.ToDate = dtpReportTimeTo.Value;
            ReportStockInEventArgs eventArgs = new ReportStockInEventArgs();
            eventArgs.ReportStockInParam = reportStockInParam;
            EventUtility.fireEvent(CreateReportStockIn,this,eventArgs);
            Close();
        }
    }
}
