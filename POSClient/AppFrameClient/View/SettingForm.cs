﻿using System;
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
            ClientSetting.Reload();
            cboPrinters.Items.Clear();
            txtSyncImportPath.Text = ClientSetting.SyncImportPath;
            txtSyncExportPath.Text = ClientSetting.SyncExportPath;
            txtSyncErrorPath.Text = ClientSetting.SyncErrorPath;
            txtSyncSuccessPath.Text = ClientSetting.SyncSuccessPath;
            PrinterSettings.StringCollection printerNames = PrinterSettings.InstalledPrinters;
            foreach (string printerName in printerNames)
            {
                cboPrinters.Items.Add(printerName);    
            }
            cboPrinters.SelectedItem = ClientSetting.PrinterName;
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
            ClientSetting.SyncSuccessPath = txtSyncSuccessPath.Text;
            ClientSetting.PrinterName = (string)cboPrinters.SelectedItem;
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
            txtSyncExportPath.Text = exportPathDialog.SelectedPath;
        }

        private void btnImportPath_Click(object sender, EventArgs e)
        {
            importPathDialog.ShowDialog();
            txtSyncImportPath.Text = importPathDialog.SelectedPath;
        }

        private void btnErrorPath_Click(object sender, EventArgs e)
        {
            errorPathDialog.ShowDialog();
            txtSyncErrorPath.Text = errorPathDialog.SelectedPath;
        }

        private void btnSuccessPath_Click(object sender, EventArgs e)
        {
            successPathDialog.ShowDialog();
            txtSyncSuccessPath.Text = successPathDialog.SelectedPath;
        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            backupDBDialog.ShowDialog();
            txtBackupDB.Text = backupDBDialog.SelectedPath;
        }

        private void btnMySQLDump_Click(object sender, EventArgs e)
        {
            mySQLBinDialog.ShowDialog();
            txtMySQLDump.Text = mySQLBinDialog.SelectedPath;
        }
    }
}
