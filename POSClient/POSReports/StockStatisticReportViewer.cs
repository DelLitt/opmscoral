using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using Microsoft.Reporting.WinForms;
using POSReports.posDataSetTableAdapters;

namespace POSReports
{
    public partial class StockStatisticReportViewer : FormBase
    {
        public StockStatisticReportViewer()
        {
            InitializeComponent();
        }

        private void StockStatisticReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'posDataSet.stockStatistic' table. You can move, or remove it, as needed.
         //   this.StockStatisticTableAdapter.Fill(this.posDataSet.stockStatistic);

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


        private Stopwatch watcher = null;
        private void button1_Click(object sender, EventArgs e)
        {           
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = ZeroTime(ToDate.Value);
            reqToDate = MaxTime(ToDate.Value);
            if (!chkZeroValue.Checked)
            {
                stockStatisticBindingSource.Filter = " (prestk_qty <> 0) " + 
                    "OR (instock_qty <> 0)  OR (mainrtnqty <> 0) OR (stkout_qty <> 0) " + 
                    "OR (destroy_qty <> 0) OR (tmpout_qty <> 0) OR (rtn_qty <> 0 )";
            }
            else
            {
                stockStatisticBindingSource.Filter = "";
            }

            stockStatisticBindingSource.RaiseListChangedEvents = false;
            stockStatisticBindingSource.SuspendBinding();

            

            Enabled = false;
            watcher = new Stopwatch();
            watcher.Start();
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            watcher.Stop();
            ShowMessage("Queries run in " + watcher.ElapsedMilliseconds/ 1000 + " seconds ..");
            stockStatisticBindingSource.RaiseListChangedEvents = true;
            stockStatisticBindingSource.ResumeBinding();
            
            Enabled = true;
            StopShowProcessing();
            reportViewer1.RefreshReport();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.StockStatisticTableAdapter adapter = new StockStatisticTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.StockStatistic, reqFromDate, reqToDate);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
