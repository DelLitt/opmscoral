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
    public partial class DepartmentStockinReportViewer : Form
    {
        public DepartmentStockinReportViewer()
        {
            InitializeComponent();
        }

        private void DepartmentStockinReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.posDataSet.department);
            // TODO: This line of code loads data into the 'posDataSet.departmentStockIn' table. You can move, or remove it, as needed.
            //this.DepartmentStockInTableAdapter.Fill(this.posDataSet.departmentStockIn);

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
                
                int test = Int32.Parse(comboBox1.SelectedValue.ToString());
                // just take 3 days before
                DateTime fromDay = ZeroTime(fromDate.Value);
                if(ZeroTime(DateTime.Now).Subtract(fromDay).Days > 3)
                {
                    fromDay = ZeroTime(DateTime.Now).Subtract(new TimeSpan(3, 0, 0, 0, 0));
                }
                this.DepartmentStockInTableAdapter.Fill(posDataSet.departmentStockIn, test, fromDay,
                                                        MaxTime(toDate.Value));
                this.reportViewer1.RefreshReport();
            } catch(Exception ex)
            {
                
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
