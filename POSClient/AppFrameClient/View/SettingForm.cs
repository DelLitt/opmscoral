using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
            cboPrinters.Items.Clear();
            PrinterSettings.StringCollection printerNames = PrinterSettings.InstalledPrinters;
            foreach (string printerName in printerNames)
            {
                cboPrinters.Items.Add(printerName);    
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClientSetting.SyncImportPath = txtSyncImportPath.Text;
            ClientSetting.SyncExportPath =txtSyncExportPath.Text;
            ClientSetting.SyncErrorPath = txtSyncErrorPath.Text;
            ClientSetting.SyncSuccessPath = txtSyncSuccessPath.Text;
            ClientSetting.PrinterName = (string)cboPrinters.SelectedItem;
            ClientSetting.Save();
            
            MessageBox.Show("Lưu cấu hình thành công!");
            
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
    }
}
