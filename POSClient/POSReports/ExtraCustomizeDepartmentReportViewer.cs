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
    public partial class ExtraCustomizeDepartmentReportViewer : FormBase
    {
        public ExtraCustomizeDepartmentReportViewer()
        {
            InitializeComponent();
        }

        private void CustomizeReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            
            
            this.departmentTableAdapter1.Fill(posDataSet.department);
            
            
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
            
            cboIsolatedBy.SelectedIndex = 0;
            cboReportBy.SelectedIndex = 0;
            /*ReportParameter[] parameters = new ReportParameter[2];     
            parameters[0] = new ReportParameter("SerieType",cboIsolatedBy.SelectedIndex.ToString());
            parameters[1] = new ReportParameter("ReportType", (cboReportType.SelectedIndex+1).ToString());
            this.customizeReport.LocalReport.SetParameters(parameters);

            this.customizeReport.RefreshReport();*/
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        int ReportType = 1;
        int SortOrder = 0;
        int limit = 10;
        int deptId = 0;
        int isolatedBy = 0;
        private int ReportBy = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = dtpFromDate.Value;
            reqToDate = dtpToDate.Value;


            ReportType = cboReportType.SelectedIndex;
            SortOrder = cboSortOrder.SelectedIndex;
            limit = Int32.Parse(txtTotalRecord.Text);
            isolatedBy = cboIsolatedBy.SelectedIndex;
            if(isolatedBy == 2)
            {
                deptId = Int32.Parse(cboDepartments.SelectedValue.ToString());   
            }
            else
            {
                deptId = 0;
            }
            ReportBy = cboReportBy.SelectedIndex;
            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            StopShowProcessing();

            switch (ReportBy)
            {
                case 1:
                    customizeSizeReport.Visible = true;
                    customizeSizeReport.BringToFront();
                    customizeSizeReport.RefreshReport();
                    break;  
                case 2:
                    customizeColorReport.Visible = true;
                    customizeColorReport.BringToFront();
                    customizeColorReport.RefreshReport();
                    break;
                default:
                    customizeReport.Visible = true;
                    customizeReport.BringToFront();
                    customizeReport.RefreshReport();
                    break;
            }
            
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            switch (ReportBy)
            {
                case 1:
                    POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentSizeReportTableAdapter sizeReportTableAdapter = new ExtraCustomizeDepartmentSizeReportTableAdapter();
                    sizeReportTableAdapter.ClearBeforeFill = true;
                    sizeReportTableAdapter.Fill(posDataSet.ExtraCustomizeDepartmentSizeReport, ReportType, SortOrder, isolatedBy, deptId, limit,
                                 reqFromDate, reqToDate);
                    break;
                case 2:
                    POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentColorReportTableAdapter colorReportTableAdapter = new ExtraCustomizeDepartmentColorReportTableAdapter();
                    colorReportTableAdapter.ClearBeforeFill = true;
                    colorReportTableAdapter.Fill(posDataSet.ExtraCustomizeDepartmentColorReport, ReportType, SortOrder, isolatedBy, deptId, limit,
                                 reqFromDate, reqToDate);

                    break;
                default:
                    POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentReportTableAdapter adapter = new ExtraCustomizeDepartmentReportTableAdapter();
                    adapter.ClearBeforeFill = true;
                    adapter.Fill(posDataSet.ExtraCustomizeDepartmentReport, ReportType, SortOrder, isolatedBy, deptId, limit,
                                 reqFromDate, reqToDate);
                    break;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void customizeReport_Load(object sender, EventArgs e)
        {

        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(cboReportType.SelectedIndex > 0 && cboReportType.SelectedIndex < 4)
            {
                cboIsolatedBy.SelectedIndex = 0;
                cboIsolatedBy.Enabled = false;
            }
            else
            {
                cboIsolatedBy.Enabled = true;
                cboIsolatedBy.SelectedIndex = 0;
            }*/
        }

        private void cboSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboIsolatedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboIsolatedBy.SelectedIndex == 2)
            {
                cboDepartments.Enabled = true;
            }
            else
            {
                cboDepartments.Enabled = false;
            }
        }

        private void customizeColorReport_Load(object sender, EventArgs e)
        {

        }
    }
}
