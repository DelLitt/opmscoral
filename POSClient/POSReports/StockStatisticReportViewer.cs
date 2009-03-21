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
    public partial class StockStatisticReportViewer : Form
    {
        public StockStatisticReportViewer()
        {
            InitializeComponent();
        }

        private void StockStatisticReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.stockStatistic' table. You can move, or remove it, as needed.
         //   this.StockStatisticTableAdapter.Fill(this.posDataSet.stockStatistic);

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
                this.StockStatisticTableAdapter.Fill(posDataSet.stockStatistic, ZeroTime(fromDate.Value), ZeroTime(toDate.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Có lỗi xảy ra khi xem báo cáo, hãy thử lại lần nữa hoặc liên hệ người quản trị!");
            }
        }
    }
}
