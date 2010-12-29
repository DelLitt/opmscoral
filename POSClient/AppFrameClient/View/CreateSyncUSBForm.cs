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
using AppFrameClient.Common;
using AppFrameClient.MasterDBTableAdapters;
using AppFrameClient.Utility;

namespace AppFrameClient.View
{
    public partial class CreateSyncUSBForm : Form
    {
        public CreateSyncUSBForm()
        {
            InitializeComponent();
        }

        private void dtpCHKHO_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CreateSyncUSBForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.masterDB.Department);

        }

        private void btnExportFromDB_Click(object sender, EventArgs e)
        {
            ExportMaxDateTableAdapter exportMaxDateTableAdapter = new ExportMaxDateTableAdapter();
            exportMaxDateTableAdapter.ClearBeforeFill = true;
            exportMaxDateTableAdapter.Fill(masterDB.ExportMaxDate, Int32.Parse(cboDepartment.SelectedValue.ToString()));
            if(masterDB.ExportMaxDate.Rows.Count == 1)
            {
                dtpKHOCH.Value = (DateTime)masterDB.ExportMaxDate.Rows[0]["sync_date"];//DateTime.ParseExact(masterDB.ExportMaxDate.Rows[0][0].ToString(), "dd/MM/yy HH:mm:ss",null);
            }
            else
            {
                txtStatus.Text = "Không thể lấy ngày đồng bộ từ DB";
            }
        }

        private void btnImportFromDB_Click(object sender, EventArgs e)
        {
            ImportMaxDateTableAdapter importMaxDateTableAdapter = new ImportMaxDateTableAdapter();
            importMaxDateTableAdapter.ClearBeforeFill = true;
            importMaxDateTableAdapter.Fill(masterDB.ImportMaxDate, Int32.Parse(cboDepartment.SelectedValue.ToString()));
            if (masterDB.ImportMaxDate.Rows.Count == 1)
            {
                dtpCHKHO.Value = (DateTime)masterDB.ImportMaxDate.Rows[0]["sync_date"]; //DateTime.ParseExact(masterDB.ImportMaxDate.Rows[0][0].ToString(), "dd/MM/yy HH:mm:ss", null);
            }
            else
            {
                txtStatus.Text = "Không thể lấy ngày đồng bộ từ DB";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string POSSyncDrive = ClientUtility.GetUSBDrives()[0].ToString();
                DialogResult dResult = MessageBox.Show(
                    "Bạn muốn tạo USB đồng bộ cho cửa hàng ? ",
                    "Tạo USB đồng bộ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dResult == DialogResult.No)
                {
                    return;
                }
                var masterPath = POSSyncDrive + "\\POS";
                var importPath = POSSyncDrive + ClientSetting.SyncImportPath;
                var exportPath = POSSyncDrive + ClientSetting.SyncExportPath;
                var successPath = POSSyncDrive + ClientSetting.SyncSuccessPath;
                var errorPath = POSSyncDrive + ClientSetting.SyncErrorPath;
                // get import path of this department
                importPath = importPath + "\\" + Int32.Parse(cboDepartment.SelectedValue.ToString());
                exportPath = exportPath + "\\" + Int32.Parse(cboDepartment.SelectedValue.ToString());
                //errorPath = ClientUtility.EnsureSyncPath(errorPath, CurrentDepartment.Get());
                //successPath = ClientUtility.EnsureSyncPath(successPath, CurrentDepartment.Get()); 
                if (!Directory.Exists(masterPath))
                {
                    Directory.CreateDirectory(masterPath);
                }

                if (!Directory.Exists(importPath))
                {
                    Directory.CreateDirectory(importPath);
                }
                if (!Directory.Exists(exportPath))
                {
                    Directory.CreateDirectory(exportPath);
                }
                //var successPath = (string)configurationAppSettings.GetValue("SyncImportSuccessPath", typeof(String));

                if (!Directory.Exists(successPath))
                {
                    Directory.CreateDirectory(successPath);
                }
                //var errorPath = (string)configurationAppSettings.GetValue("SyncImportErrorPath", typeof(String));

                if (!Directory.Exists(errorPath))
                {
                    Directory.CreateDirectory(errorPath);
                }
                int departmentId = Int32.Parse(cboDepartment.SelectedValue.ToString());
                Department syncDept = new Department { DepartmentId = departmentId };

                ClientUtility.WriteLastSyncTime(dtpKHOCH.Value, exportPath, syncDept,
                                                                    ClientUtility.SyncType.SyncDown);

                ClientUtility.WriteLastSyncTime(dtpCHKHO.Value, importPath, syncDept,
                                                                    ClientUtility.SyncType.SyncUp);
                txtStatus.Text = " TẠO USB ĐỒNG BỘ THÀNH CÔNG";
            }
            catch (Exception exception)
            {
                txtStatus.Text = exception.Message;
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStatus.Text = "";
        }
    }
}
