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
    public partial class DepartmentStockinReportViewer : FormBase
    {
        public DepartmentStockinReportViewer()
        {
            InitializeComponent();
        }

        private void DepartmentStockinReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.posDataSet.department);
            // TODO: This line of code loads data into the 'posDataSet.departmentStockIn' table. You can move, or remove it, as needed.
            //this.DepartmentStockInTableAdapter.Fill(this.posDataSet.departmentStockIn);
            if (CurrentDepartment.Get().DepartmentId != 0)
            {
                comboBox1.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                comboBox1.Enabled = false;
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

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        private int deptId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            deptId = Int32.Parse(comboBox1.SelectedValue.ToString());
            // just take 3 days before
            reqFromDate = ZeroTime(fromDate.Value);
            if (!comboBox1.Enabled)
            {
                if (ZeroTime(DateTime.Now).Subtract(reqFromDate).Days > 3)
                {
                    reqFromDate = ZeroTime(DateTime.Now).Subtract(new TimeSpan(3, 0, 0, 0, 0));
                }
            }
            reqToDate = MaxTime(toDate.Value);

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
            POSReports.posDataSetTableAdapters.DepartmentStockInTableAdapter adapter = new DepartmentStockInTableAdapter();
            adapter.ClearBeforeFill = true;
            adapter.Fill(posDataSet.departmentStockIn,deptId, reqFromDate, reqToDate);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
