using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;

namespace POSReports
{
    public partial class Stock2DeptReportViewer : Form
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
            try
            {
                this.StockOutTableAdapter.Fill(this.posDataSet.stockOut, ZeroTime(dtpFrom.Value), MaxTime(dtpTo.Value),
                                               Int32.Parse(departmentId.SelectedValue.ToString()));
                this.reportViewer1.RefreshReport();
            }catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong khi tạo báo cáo, vui lòng liên hệ nguwofi quản trị!");
            }
        }
    }
}
