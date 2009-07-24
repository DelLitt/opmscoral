using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using POSReports.posDataSetTableAdapters;

namespace POSReports
{
    public partial class CustomizeReportViewer : FormBase
    {
        public CustomizeReportViewer()
        {
            InitializeComponent();
        }

        private void CustomizeReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            this.customizeReport.RefreshReport();
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
        }
        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        int ReportType = 1;
        int SortOrder = 0;
        int limit = 10;
        int deptId = 0;
        int isolatedBy = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = dtpFromDate.Value;
            reqToDate = dtpToDate.Value;


            ReportType = cboReportType.SelectedIndex + 1;
            SortOrder = cboSortOrder.SelectedIndex;
            limit = Int32.Parse(txtTotalRecord.Text);
            //deptId = Int32.Parse(((Department)comboBox1.SelectedItem).DepartmentId.ToString());
            //isolatedBy = cboIsolatedBy.SelectedIndex;

            /*try
            {
                int ReportType = cboReportType.SelectedIndex + 1;
                int SortOrder = cboSortOrder.SelectedIndex;
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                int limit = Int32.Parse(txtTotalRecord.Text);
                CustomizeReportTableAdapter.Fill(posDataSet.CustomizeReport, ReportType, SortOrder,limit, fromDate, toDate);
                this.customizeReport.RefreshReport();
            }
            catch (Exception exception)
            {

                MessageBox.Show(" Có lỗi khi tạo báo cáo");
            }*/
            

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            StopShowProcessing();
            customizeReport.RefreshReport();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.CustomizeReportTableAdapter adapter = new CustomizeReportTableAdapter();
            adapter.ClearBeforeFill = true;
            adapter.Fill(posDataSet.CustomizeReport, ReportType, SortOrder, limit, reqFromDate, reqToDate);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void customizeReport_Load(object sender, EventArgs e)
        {

        }
    }
}
