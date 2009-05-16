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
    public partial class PurchaseDetailsReportViewer : Form
    {
        public PurchaseDetailsReportViewer()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PurchaseDetailsReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.purchaseDetails' table. You can move, or remove it, as needed.
            try
            {
                //this.PurchaseDetailsTableAdapter.Fill(this.posDataSet.purchaseDetails);

                //this.reportViewer1.RefreshReport();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                object dept = departments.SelectedValue;
                this.purchaseOrderDetailReportTableAdapter1.Fill(this.posDataSet.PurchaseOrderDetailReport, Int32.Parse(dept.ToString()),ZeroTime(fromDate.Value), MaxTime(toDate.Value));

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'posDataSet.receiptInGeneral' table. You can move, or remove it, as needed.
            try
            {
                this.departmentTableAdapter1.Fill(this.posDataSet.department);
                if (CurrentDepartment.Get().DepartmentId != 0)
                {
                    departments.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                    departments.Enabled = false;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }

    }
}
