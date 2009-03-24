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
    public partial class SupplierStockoutReportViewer : Form
    {
        public SupplierStockoutReportViewer()
        {
            InitializeComponent();
        }

        private void SupplierStockoutReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.supplierStockout' table. You can move, or remove it, as needed.
            //this.SupplierStockoutTableAdapter.Fill(this.posDataSet.supplierStockout);
            // TODO: This line of code loads data into the 'posDataSet.supplierStockout' table. You can move, or remove it, as needed.
            //this.SupplierStockoutTableAdapter.Fill(this.posDataSet.supplierStockout);

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
                this.SupplierStockoutTableAdapter.Fill(this.posDataSet.supplierStockout, ZeroTime(fromDate.Value), MaxTime(toDate.Value));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
