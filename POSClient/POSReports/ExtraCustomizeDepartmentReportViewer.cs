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
            // TODO: This line of code loads data into the 'posDataSet.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.posDataSet.product_type);
            this.posDataSet.product_type.Addproduct_typeRow
            (0, "-- Tat ca các loai --", DateTime.Now, "admin",
                                                            DateTime.Now, "admin", 0, 0);
            cboTypes.Items.Add(new ProductType { TypeId = 0, TypeName = " --Tất cả mặt hàng--" });
            foreach (posDataSet.product_typeRow row in posDataSet.product_type)
            {
                cboTypes.Items.Add(new ProductType { TypeId = row.TYPE_ID, TypeName = row.TYPE_NAME });
            }

            cboTypes.DisplayMember = "TypeName";
            cboTypes.ValueMember = "TypeId";

            cboTypes.Refresh();
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            
            
            this.departmentTableAdapter1.Fill(posDataSet.department);
            
            
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
            
            cboIsolatedBy.SelectedIndex = 0;
            cboReportBy.SelectedIndex = 0;
            // create extra binding source for filter
            // because the beyond binding source just can be filtered if it has another binding source stay on it
            BindingSource customizeBindingSource = new BindingSource(this.ExtraCustomizeDepartmentReportBindingSource, "");
            this.customizeReport.LocalReport.DataSources[0].Value = customizeBindingSource;

            BindingSource customizeSizeBindingSource = new BindingSource(this.ExtraCustomizeDepartmentSizeReportBindingSource, "");
            this.customizeSizeReport.LocalReport.DataSources[0].Value = customizeSizeBindingSource;

            BindingSource customizeColorBindingSource = new BindingSource(this.ExtraCustomizeDepartmentColorReportBindingSource, "");
            this.customizeColorReport.LocalReport.DataSources[0].Value = customizeColorBindingSource;
            
            TxtFillResult();
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        int ReportType = 1;
        int SortOrder = 0;
        int limit = 10;
        int deptId = 0;
        int isolatedBy = 0;
        private int ReportBy = 0;
        private string typeName = "%%";
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
            //int typeId = Int32.Parse(cboTypes.SelectedValue.ToString());
            
            ReportBy = cboReportBy.SelectedIndex;

            typeName = cboTypes.SelectedIndex > 0 ? ((ProductType)cboTypes.SelectedItem).TypeName :"%%";
            

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
                                 reqFromDate, reqToDate,typeName);
                    break;
                case 2:
                    POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentColorReportTableAdapter colorReportTableAdapter = new ExtraCustomizeDepartmentColorReportTableAdapter();
                    colorReportTableAdapter.ClearBeforeFill = true;
                    colorReportTableAdapter.Fill(posDataSet.ExtraCustomizeDepartmentColorReport, ReportType, SortOrder, isolatedBy, deptId, limit,
                                 reqFromDate, reqToDate, typeName);

                    break;
                default:
                    POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentReportTableAdapter adapter = new ExtraCustomizeDepartmentReportTableAdapter();
                    adapter.ClearBeforeFill = true;
                    adapter.Fill(posDataSet.ExtraCustomizeDepartmentReport, ReportType, SortOrder, isolatedBy, deptId, limit,
                                 reqFromDate, reqToDate, typeName);
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
            TxtFillResult();
        }

        private void cboSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFillResult();
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
            TxtFillResult();
        }
        private void TxtFillResult()
        {
            string filter = " Tìm ";
            int prdCount = 0;
            try
            {
                prdCount = Int32.Parse(txtTotalRecord.Text);
            }
            catch (Exception)
            {
                
            }
            filter += prdCount.ToString() + " " + cboReportBy.Text;
            if(cboTypes.SelectedIndex >0)
            {
                filter += " thuộc CHỦNG LOẠI (" + ((ProductType) cboTypes.SelectedItem).TypeName + ") ";
            }
            else
            {
                filter += " thuộc MỌI CHỦNG LOẠI ";
            }
            filter += " có " + cboReportType.Text.ToString();
            filter += " " + cboSortOrder.Text.ToString();
            filter += " của " + cboIsolatedBy.Text.ToString();
            if(cboIsolatedBy.SelectedIndex > 1)
            {
                filter += " " + cboDepartments.Text;
            }
            filter += " từ " + dtpFromDate.Value.ToString("dd/MM/yyyy");
            filter += " đến " + dtpToDate.Value.ToString("dd/MM/yyyy");

            txtResult.Text = filter;
            
        }
        private void customizeColorReport_Load(object sender, EventArgs e)
        {

        }

        private void cboDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFillResult();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            TxtFillResult();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            TxtFillResult();
        }

        private void cboTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFillResult();
        }

        private void cboReportBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFillResult();
        }

        private void txtTotalRecord_TextChanged(object sender, EventArgs e)
        {
            TxtFillResult();
        }
    }
}
