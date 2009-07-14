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

namespace POSReports
{
    public partial class DeptStockStatisticReportViewer : Form
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


        private void button1_Click(object sender, EventArgs e)
        {
            /*BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            button1.Text = "Đang xử lý";
            button1.Enabled = false;
            backgroundWorker.RunWorkerAsync();*/
            /*try
            {*/
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
                object deptId = departmentId.SelectedValue;
                this.DeptStockStatisticTableAdapter.Fill(posDataSet.deptStockStatistic, Int32.Parse(deptId.ToString()), ZeroTime(toDate.Value), MaxTime(toDate.Value));
                
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();

            /*}
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi xảy ra trong khi tạo báo cáo, vui lòng liên hệ người quản trị!");
                MessageBox.Show(ex.StackTrace);
            }*/

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
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
