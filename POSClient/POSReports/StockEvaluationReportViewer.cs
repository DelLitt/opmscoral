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
    public partial class StockEvaluationReportViewer : FormBase
    {
        public StockEvaluationReportViewer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StockEvaluationReportViewer_Load(object sender, EventArgs e)
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
                5,                59,
                999);
        }
        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = ZeroTime(FromDate.Value);
            reqToDate = MaxTime(ToDate.Value);

            Enabled = false;
            if (chkEqualsValue.Checked)
            {
                string extraFilterStr = "";
                if (!string.IsNullOrEmpty(StockEvaluationReportBindingSource.Filter))
                {
                    extraFilterStr += " AND ";
                }

                StockEvaluationReportBindingSource.Filter += extraFilterStr + "  quantity <> realquantity  ";
            }
            else
            {
                StockEvaluationReportBindingSource.Filter = "";
            }

            StockEvaluationReportBindingSource.SuspendBinding();
            StockEvaluationReportBindingSource.RaiseListChangedEvents = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            
            StopShowProcessing();
            posDataSet.StockEvaluationReport.DefaultView.RowFilter = StockEvaluationReportBindingSource.Filter;
            StockEvaluationReportBindingSource.RaiseListChangedEvents = true;
            StockEvaluationReportBindingSource.ResumeBinding();
            StockEvaluationReportBindingSource.DataSource = posDataSet.StockEvaluationReport.DefaultView;
            reportViewer1.RefreshReport(); 
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.StockEvaluationReportTableAdapter adapter = new StockEvaluationReportTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.StockEvaluationReport, reqFromDate, reqToDate);
        }
    }
}
