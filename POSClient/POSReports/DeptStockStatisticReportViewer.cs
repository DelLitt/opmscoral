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
    public partial class DeptStockStatisticReportViewer : FormBase
    {
        public DeptStockStatisticReportViewer()
        {
            InitializeComponent();
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
            deptId = Int32.Parse(departmentId.SelectedValue.ToString());
            // just take 3 days before
            reqFromDate = ZeroTime(toDate.Value);
            if (ZeroTime(DateTime.Now).Subtract(reqFromDate).Days > 3)
            {
                reqFromDate = ZeroTime(DateTime.Now).Subtract(new TimeSpan(3, 0, 0, 0, 0));
            }
            reqToDate = MaxTime(toDate.Value);

            Enabled = false;
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            
                ReportParameter[] parameters = new ReportParameter[1];

                if (!string.IsNullOrEmpty(txtFilter.Text))
                {
                    parameters[0] = new ReportParameter("StrFilter", txtFilter.Text.Trim());
                    this.deptStockStatisticBindingSource.Filter = "product_name like '%" + txtFilter.Text + "%'";
                }
                else
                {
                    parameters[0] = new ReportParameter("StrFilter", "");
                    this.deptStockStatisticBindingSource.Filter = "";
                }
                if (comboBox1.SelectedIndex != -1)
                {
                    ProductType productType = (ProductType)comboBox1.SelectedItem;
                    if (productType.TypeId != 0)
                    {
                        string extraFilterStr = "";
                        if (!string.IsNullOrEmpty(deptStockStatisticBindingSource.Filter))
                        {
                            extraFilterStr += " AND ";
                        }

                        deptStockStatisticBindingSource.Filter += extraFilterStr + " type_name = '" + productType.TypeName + "'";
                    }
                }

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
            POSReports.posDataSetTableAdapters.DeptStockStatisticTableAdapter adapter = new DeptStockStatisticTableAdapter();
            adapter.ClearBeforeFill = true;
            adapter.Fill(posDataSet.deptStockStatistic, deptId, reqFromDate, reqToDate);
        }

        private void DeptStockStatisticReportViewer_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(new ProductType {TypeId = 0, TypeName = "Tất cả cửa hàng"});
            departmentTableAdapter.Fill(this.posDataSet.department);
            product_typeTableAdapter1.Fill(posDataSet.product_type);
            foreach(posDataSet.product_typeRow row in posDataSet.product_type)
            {
                comboBox1.Items.Add(new ProductType {TypeId = row.TYPE_ID, TypeName = row.TYPE_NAME});
            }
            comboBox1.DisplayMember = "TypeName";
            
            // TODO: This line of code loads data into the 'posDataSet.deptStockStatistic' table. You can move, or remove it, as needed.
            // this.DeptStockStatisticTableAdapter.Fill(this.posDataSet.deptStockStatistic);
            BindingSource tempBindingSource = new BindingSource(this.deptStockStatisticBindingSource, "");
            this.reportViewer1.LocalReport.DataSources[0].Value = tempBindingSource;

            if(CurrentDepartment.Get().DepartmentId!=0)
            {
                departmentId.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                departmentId.Enabled = false;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
