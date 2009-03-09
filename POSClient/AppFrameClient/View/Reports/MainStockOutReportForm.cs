using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.View.Reports;

namespace AppFrameClient.View.Reports
{
    public partial class MainStockOutReportForm : AppFrame.Common.BaseForm,IStockOutReportView
    {
        public MainStockOutReportForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if(rdoAll.Checked || rdoThisWeek.Checked || rdoToday.Checked)
           {
               
           }
           else
           {
               
           }
        }

        #region IStockOutReportView Members

        private AppFrame.Presenter.Report.IReportStockOutController reportStockOutController;
        public AppFrame.Presenter.Report.IReportStockOutController ReportStockOutController
        {
            get
            {
                return reportStockOutController;
            }
            set
            {
                reportStockOutController = value;
                reportStockOutController.MainStockOutReportView = this;
            }
        }

        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> LoadStockOutsEvent;

        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> LoadStockOutDetailEvent;

        #endregion
    }
}
