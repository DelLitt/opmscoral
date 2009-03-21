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
    public partial class StockInReportViewer : Form
    {
        public StockInReportViewer()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

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
                this.StockInTableAdapter.Fill(this.posDataSet.stockIn, ZeroTime(fromDate.Value), ZeroTime(toDate.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi rút trích dữ liệu, xin vui lòng thử lại lần nữa hoặc liên hệ người quản trị");
            }
        }

        private void StockInReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.stockIn' table. You can move, or remove it, as needed.
            //this.StockInTableAdapter.Fill(this.posDataSet.stockIn);
            // TODO: This line of code loads data into the 'posDataSet.stockStatistic' table. You can move, or remove it, as needed.
    //        this.StockStatisticTableAdapter.Fill(this.posDataSet.stockStatistic);

      //      this.reportViewer1.RefreshReport();
          //  this.reportViewer1.RefreshReport();
        }
    }
}
