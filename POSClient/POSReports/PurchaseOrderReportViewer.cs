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
    public partial class PurchaseOrderReportViewer : Form
    {
        public PurchaseOrderReportViewer()
        {
            InitializeComponent();
        }

        private void PurchaseOrrderReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.receiptInGeneral' table. You can move, or remove it, as needed.
            try
            {
                //this.ReceiptInGeneralTableAdapter.Fill(this.posDataSet.receiptInGeneral);

                //this.reportViewer1.RefreshReport();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReceiptInGeneralTableAdapter.Fill(this.posDataSet.receiptInGeneral, ZeroTime(dtpFrom.Value), MaxTime(dtpTo.Value));

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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


        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReceiptInGeneralTableAdapter.FillBy(this.posDataSet.receiptInGeneral);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
