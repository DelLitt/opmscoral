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
    public partial class DailyMatrixPurchaseOrderReportViewer : FormBase
    {
        public DailyMatrixPurchaseOrderReportViewer()
        {
            InitializeComponent();
        }

        private void PurchaseOrrderReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'posDataSet.receiptInGeneral' table. You can move, or remove it, as needed.
            try
            {
                this.departmentTableAdapter.Fill(this.posDataSet.department);
                if (CurrentDepartment.Get().DepartmentId != 0)
                {
                    departmentId.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                    departmentId.Enabled = false;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
            
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        private int deptId = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            //reqFromDate = ZeroTime(dtpFrom.Value);
            //reqToDate = MaxTime(dtpTo.Value);
            reqFromDate = dtpFrom.Value;
            reqToDate = dtpTo.Value;
            deptId = Int32.Parse(departmentId.SelectedValue.ToString());
            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            StopShowProcessing();
            reportViewer1.RefreshReport(); 
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.PurchaseOrderReportTableAdapter adapter = new PurchaseOrderReportTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.PurchaseOrderReport, deptId, reqFromDate, reqToDate);
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

    }
}
