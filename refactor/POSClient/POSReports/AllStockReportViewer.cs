using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSReports
{
    public partial class AllStockReportViewer : Form
    {
        public AllStockReportViewer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AllStockReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.allStock' table. You can move, or remove it, as needed.
            //this.AllStockTableAdapter.Fill(this.posDataSet.allStock);

            //this.reportViewer1.RefreshReport();
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
                5,                59,
                999);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.AllStockTableAdapter.Fill(this.posDataSet.allStock, ZeroTime(ToDate.Value), MaxTime(ToDate.Value));
                this.reportViewer1.RefreshReport();
            } catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo báo cáo. Vui lòng liên hệ người quản trị", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}
