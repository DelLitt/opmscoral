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
    public partial class ReturnPOrderReportViewer : Form
    {
        public ReturnPOrderReportViewer()
        {
            InitializeComponent();
        }

        private void ReturnPOrderReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.returnPOrder' table. You can move, or remove it, as needed.
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
                this.ReturnPOrderTableAdapter.Fill(this.posDataSet.returnPOrder,ZeroTime(this.fromDate.Value), MaxTime(this.toDate.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
