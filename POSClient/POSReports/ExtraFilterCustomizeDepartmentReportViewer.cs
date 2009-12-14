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
    public partial class ExtraFilterCustomizeDepartmentReportViewer : FormBase
    {
        public ExtraFilterCustomizeDepartmentReportViewer()
        {
            InitializeComponent();
        }

        private void CustomizeReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.posDataSet.product_type);
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            
            
            this.departmentTableAdapter1.Fill(posDataSet.department);
            
            
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
            
            cboIsolatedBy.SelectedIndex = 0;
            
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
        private string FilterString = "";
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = dtpFromDate.Value;
            reqToDate = dtpToDate.Value;


            ReportType = cboReportType.SelectedIndex;
            SortOrder = cboSortOrder.SelectedIndex;
            
            isolatedBy = cboIsolatedBy.SelectedIndex;
            if(isolatedBy == 2)
            {
                deptId = Int32.Parse(cboDepartments.SelectedValue.ToString());   
            }
            else
            {
                deptId = 0;
            }
            
            FilterString = "";
            // filter cho ten san pham
            if (!string.IsNullOrEmpty(txtPrdFilter.Text))
            {
                string productTotalFilter = "";
                string productNamesFilter = txtPrdFilter.Text.Trim();
                string[] pmFilters = productNamesFilter.Split(',');
                if (pmFilters.Length <= 1)
                {
                    productTotalFilter = "product_name like '%" + productNamesFilter + "%'";
                }
                else
                {
                    string startFilterStr = "";
                    int count = 0;
                    string endFilterStr = "";

                    foreach (string pmFilter in pmFilters)
                    {
                        count += 1;
                        if (string.IsNullOrEmpty(productTotalFilter))
                        {
                            startFilterStr = "( ";
                        }
                        else
                        {
                            startFilterStr = " ";
                        }

                        if (count == pmFilters.Length) endFilterStr = " ) ";
                        else
                        {
                            endFilterStr = " OR ";
                        }

                        productTotalFilter += startFilterStr + " ( product_name like '%" + pmFilter.Trim() + "%') " + endFilterStr;

                    }
                }
                FilterString += productTotalFilter;
            }

            // filter cho kich co san pham
            if (!string.IsNullOrEmpty(txtSizeFilter.Text))
            {
                if (!string.IsNullOrEmpty(FilterString)) FilterString += " AND ";
                string sizeTotalFilter = "";
                string productSizesFilter = txtSizeFilter.Text.Trim();
                string[] pmFilters = productSizesFilter.Split(',');
                if (pmFilters.Length <= 1)
                {
                    sizeTotalFilter = "size_name like '%" + productSizesFilter + "%'";
                }
                else
                {
                    string startFilterStr = "";
                    int count = 0;
                    string endFilterStr = "";

                    foreach (string pmFilter in pmFilters)
                    {
                        count += 1;
                        if (string.IsNullOrEmpty(sizeTotalFilter))
                        {
                            startFilterStr = "( ";
                        }
                        else
                        {
                            startFilterStr = " ";
                        }

                        if (count == pmFilters.Length) endFilterStr = " ) ";
                        else
                        {
                            endFilterStr = " OR ";
                        }

                        sizeTotalFilter += startFilterStr + " ( size_name like '%" + pmFilter.Trim() + "%') " + endFilterStr;

                    }
                }
                FilterString += sizeTotalFilter;
            }

            // filter cho mau sac san pham
            if (!string.IsNullOrEmpty(txtColorFilter.Text))
            {
                if (!string.IsNullOrEmpty(FilterString)) FilterString += " AND ";
                string colorTotalFilter = "";
                string productColorsFilter = txtColorFilter.Text.Trim();
                string[] pmFilters = productColorsFilter.Split(',');
                if (pmFilters.Length <= 1)
                {
                    colorTotalFilter = "color_name like '%" + productColorsFilter + "%'";
                }
                else
                {
                    string startFilterStr = "";
                    int count = 0;
                    string endFilterStr = "";

                    foreach (string pmFilter in pmFilters)
                    {
                        count += 1;
                        if (string.IsNullOrEmpty(colorTotalFilter))
                        {
                            startFilterStr = "( ";
                        }
                        else
                        {
                            startFilterStr = " ";
                        }

                        if (count == pmFilters.Length) endFilterStr = " ) ";
                        else
                        {
                            endFilterStr = " OR ";
                        }

                        colorTotalFilter += startFilterStr + " ( color_name like '%" + pmFilter.Trim() + "%') " + endFilterStr;

                    }
                }
                FilterString += colorTotalFilter;
            }


            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            StopShowProcessing();

            customizeReport.Visible = true;
            customizeReport.BringToFront();
            customizeReport.RefreshReport();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

            POSReports.posDataSetTableAdapters.ExtraFilterCustomizeDepartmentReportTableAdapter adapter = new ExtraFilterCustomizeDepartmentReportTableAdapter();
            adapter.ClearBeforeFill = true;
            adapter.Fill(posDataSet.ExtraFilterCustomizeDepartmentReport, ReportType, SortOrder, isolatedBy, deptId, FilterString,
                                 reqFromDate, reqToDate);
                    
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            FillTxtResult();
        }

        private void txtPrdFilter_TextChanged(object sender, EventArgs e)
        {
            FillTxtResult();
        }

        private void txtSizeFilter_TextChanged(object sender, EventArgs e)
        {
            FillTxtResult();
        }
        private void FillTxtResult()
        {
            string result = "";
            if(    string.IsNullOrEmpty(txtSizeFilter.Text)  
                && string.IsNullOrEmpty(txtColorFilter.Text) 
                && string.IsNullOrEmpty(txtPrdFilter.Text))
            {
                result = "Tất cả sản phẩm";
            }
            else
            {
                result = " Những sản phẩm có ";
            }
            if(!string.IsNullOrEmpty(txtPrdFilter.Text))
            {
                result += " TÊN tương tự như ( " + txtPrdFilter.Text.Trim() + ") ";
            }
            if (!string.IsNullOrEmpty(txtSizeFilter.Text))
            {
                result += " K.CỠ tương tự như ( " + txtSizeFilter.Text.Trim() + ") ";
            }
            if (!string.IsNullOrEmpty(txtColorFilter.Text))
            {
                result += " MÀU SẮC tương tự như ( " + txtColorFilter.Text.Trim() + ") ";
            }
            txtResult.Text = result;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTxtResult();
        }
    }
}
