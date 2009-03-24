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
    public partial class DeptStockStatisticReportViewer : Form
    {
        public DeptStockStatisticReportViewer()
        {
            InitializeComponent();
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
                object deptId = departmentId.SelectedValue;
                this.DeptStockStatisticTableAdapter.Fill(posDataSet.deptStockStatistic, Int32.Parse(deptId.ToString()),ZeroTime(fromDate.Value),MaxTime(toDate.Value) );
                this.reportViewer1.RefreshReport();

            } catch (Exception ex)
            {
                MessageBox.Show("Co loi , lien he nguoi quan tri");
            }
        }

        private void DeptStockStatisticReportViewer_Load(object sender, EventArgs e)
        {
            departmentTableAdapter.Fill(this.posDataSet.department);
            
            
            // TODO: This line of code loads data into the 'posDataSet.deptStockStatistic' table. You can move, or remove it, as needed.
//            this.DeptStockStatisticTableAdapter.Fill(this.posDataSet.deptStockStatistic);
            if(CurrentDepartment.Get().DepartmentId!=0)
            {
                departmentId.SelectedValue = CurrentDepartment.Get().DepartmentId.ToString();
                departmentId.Visible = false;
            }
        }
    }
}
