using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            // TODO: This line of code loads data into the 'masterDB.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.masterDB.Department);

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
            }
            dgvDeptStock.Refresh();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(@"D:\test.txt",FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);
            foreach (DataRow row in this.masterDB.deptstock_def_file.Rows)
            {
                string rowText = row[masterDB.deptstock_def_file.product_master_idColumn] + " ,\"" +
                                 row[masterDB.deptstock_def_file.product_nameColumn] + "\" ," +
                                 row[masterDB.deptstock_def_file.product_idColumn] +" ,0";
                writer.WriteLine(rowText);
            }
            writer.Flush();
            writer.Close();
            InformationBox.Show("Xuất định nghĩa hoàn tất", new AutoCloseParameters(2));
        }
    }
}
