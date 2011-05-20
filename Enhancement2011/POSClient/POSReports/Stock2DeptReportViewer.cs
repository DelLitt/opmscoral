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
    public partial class Stock2DeptReportViewer : FormBase
    {
        public Stock2DeptReportViewer()
        {
            InitializeComponent();
        }

        private void Stock2DeptReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.stockOut' table. You can move, or remove it, as needed.
            //this.StockOutTableAdapter.Fill(this.posDataSet.stockOut);
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.posDataSet.department);
            if (CurrentDepartment.Get().DepartmentId != 0)
            {
                departmentId.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                departmentId.Visible = false;
            }
            this.reportViewer1.RefreshReport();
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


        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        private int deptId = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = ZeroTime(dtpFrom.Value);
            reqToDate = MaxTime(dtpTo.Value);
            deptId = Int32.Parse(departmentId.SelectedValue.ToString());
            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();

            /*try
            {
                this.StockOutTableAdapter.Fill(this.posDataSet.stockOut, Int32.Parse(departmentId.SelectedValue.ToString()),ZeroTime(dtpFrom.Value), MaxTime(dtpTo.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong khi tạo báo cáo, vui lòng liên hệ người quản trị!");
            }*/
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
            POSReports.posDataSetTableAdapters.StockOutTableAdapter adapter = new StockOutTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.stockOut,deptId,reqFromDate, reqToDate); 
        }
    }
}
