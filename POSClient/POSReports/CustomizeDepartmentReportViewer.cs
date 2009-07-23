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
using Microsoft.Reporting.WinForms;
using POSReports.posDataSetTableAdapters;

namespace POSReports
{
    public partial class CustomizeDepartmentReportViewer : FormBase
    {
        public CustomizeDepartmentReportViewer()
        {
            InitializeComponent();
        }

        private void CustomizeReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            
            comboBox1.Items.Clear();
            comboBox1.Items.Add(new Department {DepartmentId = 0, DepartmentName = "Tất cả cửa hàng"});
            this.departmentTableAdapter1.Fill(posDataSet.department);
            foreach (posDataSet.departmentRow row in posDataSet.department)
            {
                comboBox1.Items.Add(new Department
                                        {DepartmentId = row.DEPARTMENT_ID, DepartmentName = row.DEPARTMENT_NAME});                
            }
            comboBox1.ValueMember = "DepartmentId";
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.Refresh();
            comboBox1.Invalidate();
            
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            cboIsolatedBy.SelectedIndex = 0;
            ReportParameter[] parameters = new ReportParameter[2];     
            parameters[0] = new ReportParameter("SerieType",cboIsolatedBy.SelectedIndex.ToString());
            parameters[1] = new ReportParameter("ReportType", (cboReportType.SelectedIndex+1).ToString());
            this.customizeReport.LocalReport.SetParameters(parameters);

            this.customizeReport.RefreshReport();
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
            deptId = Int32.Parse(((Department)comboBox1.SelectedItem).DepartmentId.ToString());
            isolatedBy = cboIsolatedBy.SelectedIndex;

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("SerieType", cboIsolatedBy.SelectedIndex.ToString());
            parameters[1] = new ReportParameter("ReportType", (cboReportType.SelectedIndex + 1).ToString());

            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();

            /*try
            {
                ReportType = cboReportType.SelectedIndex + 1;
                SortOrder = cboSortOrder.SelectedIndex;
                limit = Int32.Parse(txtTotalRecord.Text);
                deptId = Int32.Parse(((Department)comboBox1.SelectedItem).DepartmentId.ToString());
                isolatedBy = cboIsolatedBy.SelectedIndex;                
                
                CustomizeDepartmentDetailReportTableAdapter.Fill(posDataSet.CustomizeDepartmentDetailReport, ReportType, SortOrder,
                                                           deptId,isolatedBy, limit, fromDate, toDate);
                
                this.customizeReport.LocalReport.SetParameters(parameters);
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
            POSReports.posDataSetTableAdapters.CustomizeDepartmentDetailReportTableAdapter adapter = new CustomizeDepartmentDetailReportTableAdapter();
            adapter.ClearBeforeFill = true;
            adapter.Fill(posDataSet.CustomizeDepartmentDetailReport, ReportType, SortOrder,
                                                           deptId, isolatedBy, limit, reqFromDate, reqToDate);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void customizeReport_Load(object sender, EventArgs e)
        {

        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboReportType.SelectedIndex > 0 && cboReportType.SelectedIndex < 4)
            {
                cboIsolatedBy.SelectedIndex = 0;
                cboIsolatedBy.Enabled = false;
            }
            else
            {
                cboIsolatedBy.Enabled = true;
                cboIsolatedBy.SelectedIndex = 0;
            }
        }

        private void cboSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
