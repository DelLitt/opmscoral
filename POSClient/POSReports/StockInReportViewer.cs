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
    public partial class StockInReportViewer : FormBase
    {
        public StockInReportViewer()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = ZeroTime(fromDate.Value);
            reqToDate = MaxTime(toDate.Value);
            
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
            POSReports.posDataSetTableAdapters.StockInTableAdapter adapter = new StockInTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.stockIn, reqFromDate, reqToDate);
        }

        private void StockInReportViewer_Load(object sender, EventArgs e)
        {
            
        }
    }
}
