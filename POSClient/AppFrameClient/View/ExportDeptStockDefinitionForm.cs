using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;
using AppFrameClient.Utility;
using InfoBox;

namespace AppFrameClient.View
{
    public partial class ExportDeptStockDefinitionForm : Form
    {
        public ExportDeptStockDefinitionForm()
        {
            InitializeComponent();
        }

        private void ExportDeptStockDefinitionForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB1.stock_def_file' table. You can move, or remove it, as needed.
            //this.stock_def_fileTableAdapter.Fill(this.masterDB1.stock_def_file);
            // TODO: This line of code loads data into the 'masterDB.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.masterDB.Department);
            departmentBindingSource1.Clear();

            Department mainStock = new Department
                                       {
                                           DepartmentId = 0,
                                           DepartmentName = "KHO CHINH"
                                       };
            departmentBindingSource1.Add(mainStock);
            foreach (MasterDB.DepartmentRow row in masterDB.Department)
            {
                Department department = new Department
                                            {
                                                DepartmentId = row.DEPARTMENT_ID,
                                                DepartmentName = row.DEPARTMENT_NAME
                                            };
                departmentBindingSource1.Add(department);
            }
            departmentBindingSource1.ResetBindings(false);
            this.masterDB1.EnforceConstraints = false;
            
            
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int departmentId = 0;
            ClientUtility.TryActionHelper(delegate() {
                                                         departmentId =
                                                             Int32.Parse(cboDepartment.SelectedValue.ToString()); }, 1);

            if(departmentId > 0 )
            {
                this.deptstock_def_fileTableAdapter.Fill(this.masterDB.deptstock_def_file, departmentId);
                dgvDeptStock.Visible = true;
                dgvMainStock.Visible = false;
            }
            else
            {
                this.stock_def_fileTableAdapter.Fill(this.masterDB1.stock_def_file);
                dgvDeptStock.Visible = false;
                dgvMainStock.Visible = true;
            }
            dgvDeptStock.Refresh();
            dgvMainStock.Refresh();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(@"D:\KIEMHANG\dinhnghia.txt",FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);
            if (dgvDeptStock.Visible)
            {
                foreach (DataRow row in this.masterDB.deptstock_def_file.Rows)
                {
                    string rowText = row[masterDB.deptstock_def_file.product_idColumn] + ",0";
                    writer.WriteLine(rowText);
                }
            }
            else
            {
                foreach (DataRow row in this.masterDB1.stock_def_file.Rows)
                {
                    string rowText = row[masterDB1.stock_def_file.product_idColumn] + ",0";
                    writer.WriteLine(rowText);
                }
            }
            writer.Flush();
            writer.Close();
            InformationBox.Show("Xuất định nghĩa hoàn tất", new AutoCloseParameters(2));
        }
    }
}
