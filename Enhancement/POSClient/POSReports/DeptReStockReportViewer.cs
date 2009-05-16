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
    public partial class DeptReStockReportViewer : Form
    {
        public DeptReStockReportViewer()
        {
            InitializeComponent();
        }

        private void DeptReStockReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.posDataSet.department);
            // TODO: This line of code loads data into the 'posDataSet.deptReStock' table. You can move, or remove it, as needed.
            //this.DeptReStockTableAdapter.Fill(this.posDataSet.deptReStock);

            //this.reportViewer1.RefreshReport();
            if (CurrentDepartment.Get().DepartmentId != 0)
            {
                departmentId.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                departmentId.Visible = false;
            }
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
            try
            {
                this.DeptReStockTableAdapter.Fill(posDataSet.deptReStock,
                                                  Int32.Parse(departmentId.SelectedValue.ToString()),
                                                  ZeroTime(dtpFrom.Value), MaxTime(dtpTo.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong khi tạo báo cáo, vui lòng liên hệ người quản trị!");
            }
        }
    }
}
