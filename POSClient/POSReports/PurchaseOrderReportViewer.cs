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
    public partial class PurchaseOrderReportViewer : Form
    {
        public PurchaseOrderReportViewer()
        {
            InitializeComponent();
        }

        private void PurchaseOrrderReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'posDataSet.receiptInGeneral' table. You can move, or remove it, as needed.
            try
            {
                this.departmentTableAdapter.Fill(this.posDataSet.department);
                if (CurrentDepartment.Get().DepartmentId != 0)
                {
                    departmentId.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                    departmentId.Enabled = false;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Object dept = departmentId.SelectedValue;
                int frmDept, toDept = 0;
                if (Int32.Parse(dept.ToString()) != 0)
                {
                    frmDept = Int32.Parse(dept.ToString());
                    toDept = Int32.Parse(dept.ToString());
                } else
                {
                    frmDept = 1;
                    toDept = 100;
                }
                //this.ReceiptInGeneralTableAdapter.Fill(this.posDataSet.receiptInGeneral, ZeroTime(dtpFrom.Value), MaxTime(dtpTo.Value));
                this.reportViewer1.LocalReport.Refresh();
                //this.purchaseOrderTableAdapter.Fill(posDataSet.PurchaseOrderReport,Int32.Parse(dept.ToString()), ZeroTime(dtpFrom.Value),MaxTime(dtpTo.Value));
                this.purchaseOrderReportTableAdapter1.Fill(posDataSet.PurchaseOrderReport, Int32.Parse(dept.ToString()),
                                                           ZeroTime(dtpFrom.Value), MaxTime(dtpTo.Value));
                this.reportViewer1.LocalReport.Refresh();
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

    }
}
