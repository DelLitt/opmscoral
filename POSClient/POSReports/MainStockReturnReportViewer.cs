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
    public partial class MainStockReturnReportViewer : Form
    {
        public MainStockReturnReportViewer()
        {
            InitializeComponent();
        }

        private void MainStockReturnReportViewer_Load(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReturnMainTableAdapter.Fill(this.posDataSet.returnMain,
                                                 Int32.Parse(this.departmentId.SelectedValue.ToString()),
                                                 ZeroTime(toDate.Value), MaxTime(toDate.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi xảy ra, vui lòng liên hệ với người quản trị!");
            }
        }
    }
}
