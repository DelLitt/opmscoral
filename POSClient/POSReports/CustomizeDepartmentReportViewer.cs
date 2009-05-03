using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace POSReports
{
    public partial class CustomizeDepartmentReportViewer : Form
    {
        public CustomizeDepartmentReportViewer()
        {
            InitializeComponent();
        }

        private void CustomizeReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            
            comboBox1.Items.Clear();
            comboBox1.Items.Add(new Department {DepartmentId = 0, DepartmentName = "Tất cả cửa hàng"});
            this.departmentTableAdapter1.Fill(posDataSet.department);
            foreach (posDataSet.departmentRow row in posDataSet.department)
            {
                comboBox1.Items.Add(new Department
                                        {DepartmentId = row.DEPARTMENT_ID, DepartmentName = row.DEPARTMENT_NAME});                
            }
            comboBox1.ValueMember = "DepartmentId";
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.Refresh();
            comboBox1.Invalidate();
            this.customizeReport.RefreshReport();
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ReportType = cboReportType.SelectedIndex + 1;
                int SortOrder = cboSortOrder.SelectedIndex;
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                int limit = Int32.Parse(txtTotalRecord.Text);
                int deptId = Int32.Parse(((Department)comboBox1.SelectedItem).DepartmentId.ToString());
                //CustomizeReportTableAdapter.Fill(posDataSet.CustomizeReport, ReportType, SortOrder,limit, fromDate, toDate);
                CustomizeDepartmentReportTableAdapter.Fill(posDataSet.CustomizeDepartmentReport, ReportType, SortOrder,
                                                           deptId,limit, fromDate, toDate);
                this.customizeReport.RefreshReport();
            }
            catch (Exception exception)
            {

                MessageBox.Show(" Có lỗi khi tạo báo cáo");
            }
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void customizeReport_Load(object sender, EventArgs e)
        {

        }
    }
}
