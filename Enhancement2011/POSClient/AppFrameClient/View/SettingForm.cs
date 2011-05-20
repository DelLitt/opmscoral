using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrameClient.Common;

namespace AppFrameClient.View
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter1.Fill(this.posDataSet.department);
            this.departmentTableAdapter.Fill(this.masterDB.Department);
            ClientSetting.Reload();
            cboBarcodeType.Items.Clear();
            cboBarcodeType.Items.Add(BarcodeLib.TYPE.CODE39);
            cboBarcodeType.Items.Add(BarcodeLib.TYPE.CODE128);
            cboBarcodeType.SelectedItem = ClientSetting.BarcodeType;
            cboPrinters.Items.Clear();
            txtSyncImportPath.Text = ClientSetting.SyncImportPath;
            txtSyncExportPath.Text = ClientSetting.SyncExportPath;
            txtSyncInternal.Text = ClientSetting.SyncInternalPath;
            txtSyncErrorPath.Text = ClientSetting.SyncErrorPath;
            txtSyncSuccessPath.Text = ClientSetting.SyncSuccessPath;
            txtBackupDB.Text = ClientSetting.DBBackupPath;
            txtMySQLDump.Text = ClientSetting.MySQLDumpPath;
            cboBinding.SelectedItem = ClientSetting.ServiceBinding;
            cboDepartment.SelectedValue = ClientSetting.MarketDept;
            cboFastDept.SelectedValue = ClientSetting.FastDept;
            PrinterSettings.StringCollection printerNames = PrinterSettings.InstalledPrinters;
            foreach (string printerName in printerNames)
            {
                cboPrinters.Items.Add(printerName);    
            }
            cboPrinters.SelectedItem = ClientSetting.PrinterName;

            if (ClientSetting.IsSubStock())
            {
                grpSubStock.Visible = true;
                if(ClientSetting.ConfirmByEmployeeId)
                {
                    rdoEmployeeId.Checked = true;
                }
                else
                {
                    rdoLogin.Checked = true;
                }
            }
            else
            {
                               
                grpSubStock.Visible = false;
                if(ClientSetting.IsClient())
                {
                    if (ClientSetting.ConfirmByEmployeeId) chkCheckingById.Checked = true;
                    else chkCheckingById.Checked = false;
                }
            }

            chkNegativeExport.Checked = ClientSetting.NegativeExport;
            chkNegativeSelling.Checked = ClientSetting.NegativeSelling;
            chkExportConfirmation.Checked = ClientSetting.ExportConfirmation;
            chkImportConfirmation.Checked = ClientSetting.ImportConfirmation;
            chkBlockSliding.Checked = ClientSetting.IsBlockSliding;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMySQLDump.Text) 
                || !Directory.Exists(txtMySQLDump.Text)
                || !File.Exists(txtMySQLDump.Text + "\\mysqldump.exe"))
            {
                MessageBox.Show("Không thể tìm ra đường dẫn file backup dữ liệu.");
                return;
            }
            ClientSetting.DBBackupPath = txtBackupDB.Text;
            ClientSetting.MySQLDumpPath = txtMySQLDump.Text;
            ClientSetting.SyncImportPath = txtSyncImportPath.Text;
            ClientSetting.SyncExportPath =txtSyncExportPath.Text;
            ClientSetting.SyncErrorPath = txtSyncErrorPath.Text;
            ClientSetting.SyncInternalPath = txtSyncInternal.Text;
            ClientSetting.SyncSuccessPath = txtSyncSuccessPath.Text;
            ClientSetting.PrinterName = (string)cboPrinters.SelectedItem;
            ClientSetting.ServiceBinding = (string)cboBinding.SelectedItem;
            if (ClientSetting.IsSubStock())
            {
                ClientSetting.MarketDept = cboDepartment.SelectedValue.ToString();
                ClientSetting.FastDept = cboFastDept.SelectedValue.ToString();
                if (rdoEmployeeId.Checked)
                {
                    ClientSetting.ConfirmByEmployeeId = true;                    
                }
                else
                {
                    ClientSetting.ConfirmByEmployeeId = false;
                }
            }
            else
            {
                if(ClientSetting.IsClient())
                {
                    ClientSetting.ConfirmByEmployeeId = chkCheckingById.Checked;
                }
            }
            ClientSetting.NegativeSelling = chkNegativeSelling.Checked;
            ClientSetting.NegativeExport = chkNegativeExport.Checked;
            ClientSetting.ImportConfirmation = chkImportConfirmation.Checked;
            ClientSetting.ExportConfirmation = chkExportConfirmation.Checked;
            ClientSetting.BarcodeType = (BarcodeLib.TYPE)cboBarcodeType.SelectedItem;
            ClientSetting.IsBlockSliding = chkBlockSliding.Checked;
            
            ClientSetting.Save();
            
            MessageBox.Show("Lưu cấu hình thành công!");
            ClientSetting.Reload();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            ClientSetting.Reset();
            ClientSetting.Reload();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientSetting.Save();
        }

        private void btnExportPath_Click(object sender, EventArgs e)
        {
            exportPathDialog.ShowDialog();
            string selectedPath = exportPathDialog.SelectedPath;

            txtSyncExportPath.Text = selectedPath.Length > 2 ? selectedPath.Substring(2): selectedPath;
        }

        private void btnImportPath_Click(object sender, EventArgs e)
        {
            importPathDialog.ShowDialog();
            string selectedPath = importPathDialog.SelectedPath;
            txtSyncImportPath.Text = selectedPath.Length > 2 ? selectedPath.Substring(2) : selectedPath;
        }

        private void btnErrorPath_Click(object sender, EventArgs e)
        {
            errorPathDialog.ShowDialog();
            string selectedPath = errorPathDialog.SelectedPath;
            txtSyncErrorPath.Text = selectedPath.Length > 2 ? selectedPath.Substring(2) : selectedPath;
        }

        private void btnSuccessPath_Click(object sender, EventArgs e)
        {
            successPathDialog.ShowDialog();
            string selectedPath = successPathDialog.SelectedPath;
            txtSyncSuccessPath.Text = selectedPath.Length > 2 ? selectedPath.Substring(2) : selectedPath;
        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            backupDBDialog.ShowDialog();
            string selectedPath = backupDBDialog.SelectedPath;
            txtBackupDB.Text = selectedPath.Length > 2 ? selectedPath.Substring(2) : selectedPath;
        }

        private void btnMySQLDump_Click(object sender, EventArgs e)
        {
            mySQLBinDialog.ShowDialog();
            txtMySQLDump.Text = mySQLBinDialog.SelectedPath;
        }

        private void btnDeptToDeptPath_Click(object sender, EventArgs e)
        {
            deptToDeptDialog.ShowDialog();
            string selectedPath = deptToDeptDialog.SelectedPath;
            txtSyncInternal.Text = selectedPath.Length > 2 ? selectedPath.Substring(2) : selectedPath;
        }
    }
}
