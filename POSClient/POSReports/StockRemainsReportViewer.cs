using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using POSReports.posDataSetTableAdapters;

namespace POSReports
{
    public partial class StockRemainsReportViewer : FormBase
    {
        public StockRemainsReportViewer()
        {
            InitializeComponent();
        }

        private void TempStockoutReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.TmpStockout' table. You can move, or remove it, as needed.
//            this.TmpStockoutTableAdapter.Fill(this.posDataSet.TmpStockout);
            // TODO: This line of code loads data into the 'posDataSet.TmpStockout' table. You can move, or remove it, as needed.
//            this.TmpStockoutTableAdapter.Fill(this.posDataSet.TmpStockout);

            BindingSource tempBindingSource = new BindingSource(this.StockRemainsStatisticBindingSource, "");
            this.reportViewer1.LocalReport.DataSources[0].Value = tempBindingSource;

        }
        public static DateTime ZeroTime(DateTime value)
        {
            return new DateTime(
                value.Year,
                value.Month,
                value.Day,
                0,
                0,
                0,
                0);
        }

        public static DateTime MaxTime(DateTime value)
        {
            return new DateTime(
                value.Year,
                value.Month,
                value.Day,
                23,
                59,
                59,
                999);
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        private int limit = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int limit = Int32.Parse(txtLimit.Text);
            }
            catch (Exception)
            {
                limit = 1;
                txtLimit.Text = "1";
            }
            if(chkZeroRemove.Checked)
            {
                StockRemainsStatisticBindingSource.Filter = " stkqty > 0 ";
            }
            else
            {
                StockRemainsStatisticBindingSource.Filter = "";
            }
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            
            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            /*stockStatisticBindingSource.DataSource = aSyncDS;
            stockStatisticBindingSource.ResetBindings(false);*/
            StopShowProcessing();
            reportViewer1.RefreshReport();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.StockRemainsStatisticTableAdapter adapter = new StockRemainsStatisticTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.StockRemainsStatistic, limit);
        }
    }
}
