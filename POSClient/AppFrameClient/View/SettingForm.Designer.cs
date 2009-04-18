namespace AppFrameClient.View
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnExportPath;
            this.label1 = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.exportPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnImportPath = new System.Windows.Forms.Button();
            this.btnErrorPath = new System.Windows.Forms.Button();
            this.btnSuccessPath = new System.Windows.Forms.Button();
            this.importPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.errorPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.successPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnMySQLDump = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mySQLBinDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMySQLDump = new System.Windows.Forms.TextBox();
            this.backupDBDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBackupDB = new System.Windows.Forms.TextBox();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.txtSyncSuccessPath = new System.Windows.Forms.TextBox();
            this.txtSyncErrorPath = new System.Windows.Forms.TextBox();
            this.txtSyncImportPath = new System.Windows.Forms.TextBox();
            this.txtSyncExportPath = new System.Windows.Forms.TextBox();
            btnExportPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportPath
            // 
            btnExportPath.Location = new System.Drawing.Point(363, 30);
            btnExportPath.Name = "btnExportPath";
            btnExportPath.Size = new System.Drawing.Size(31, 23);
            btnExportPath.TabIndex = 13;
            btnExportPath.Text = "...";
            btnExportPath.UseVisualStyleBackColor = true;
            btnExportPath.Click += new System.EventHandler(this.btnExportPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn xuất file từ KHO-> CH:";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(302, 252);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Mặc định";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(383, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Đường dẫn nhập file từ CH-> KHO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lưu file lỗi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lưu file thành công:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Máy in hoá đơn:";
            // 
            // btnImportPath
            // 
            this.btnImportPath.Location = new System.Drawing.Point(363, 57);
            this.btnImportPath.Name = "btnImportPath";
            this.btnImportPath.Size = new System.Drawing.Size(31, 23);
            this.btnImportPath.TabIndex = 14;
            this.btnImportPath.Text = "...";
            this.btnImportPath.UseVisualStyleBackColor = true;
            this.btnImportPath.Click += new System.EventHandler(this.btnImportPath_Click);
            // 
            // btnErrorPath
            // 
            this.btnErrorPath.Location = new System.Drawing.Point(363, 83);
            this.btnErrorPath.Name = "btnErrorPath";
            this.btnErrorPath.Size = new System.Drawing.Size(31, 23);
            this.btnErrorPath.TabIndex = 15;
            this.btnErrorPath.Text = "...";
            this.btnErrorPath.UseVisualStyleBackColor = true;
            this.btnErrorPath.Click += new System.EventHandler(this.btnErrorPath_Click);
            // 
            // btnSuccessPath
            // 
            this.btnSuccessPath.Location = new System.Drawing.Point(363, 109);
            this.btnSuccessPath.Name = "btnSuccessPath";
            this.btnSuccessPath.Size = new System.Drawing.Size(31, 23);
            this.btnSuccessPath.TabIndex = 16;
            this.btnSuccessPath.Text = "...";
            this.btnSuccessPath.UseVisualStyleBackColor = true;
            this.btnSuccessPath.Click += new System.EventHandler(this.btnSuccessPath_Click);
            // 
            // btnMySQLDump
            // 
            this.btnMySQLDump.Location = new System.Drawing.Point(363, 188);
            this.btnMySQLDump.Name = "btnMySQLDump";
            this.btnMySQLDump.Size = new System.Drawing.Size(31, 23);
            this.btnMySQLDump.TabIndex = 18;
            this.btnMySQLDump.Text = "...";
            this.btnMySQLDump.UseVisualStyleBackColor = true;
            this.btnMySQLDump.Click += new System.EventHandler(this.btnMySQLDump_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Đường dẫn mysql\\bin:";
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Location = new System.Drawing.Point(362, 132);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(31, 23);
            this.btnBackupDB.TabIndex = 22;
            this.btnBackupDB.Text = "...";
            this.btnBackupDB.UseVisualStyleBackColor = true;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Backup dữ liệu:";
            // 
            // txtMySQLDump
            // 
            this.txtMySQLDump.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "MySQLDump", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMySQLDump.Location = new System.Drawing.Point(184, 188);
            this.txtMySQLDump.Name = "txtMySQLDump";
            this.txtMySQLDump.Size = new System.Drawing.Size(173, 20);
            this.txtMySQLDump.TabIndex = 23;
            this.txtMySQLDump.Text = global::AppFrameClient.Properties.Settings.Default.MySQLDump;
            // 
            // txtBackupDB
            // 
            this.txtBackupDB.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "DBBackupPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtBackupDB.Location = new System.Drawing.Point(184, 134);
            this.txtBackupDB.Name = "txtBackupDB";
            this.txtBackupDB.Size = new System.Drawing.Size(172, 20);
            this.txtBackupDB.TabIndex = 24;
            this.txtBackupDB.Text = global::AppFrameClient.Properties.Settings.Default.DBBackupPath;
            // 
            // cboPrinters
            // 
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(185, 161);
            this.cboPrinters.Name = global::AppFrameClient.Properties.Settings.Default.PrinterName;
            this.cboPrinters.Size = new System.Drawing.Size(172, 21);
            this.cboPrinters.TabIndex = 12;
            // 
            // txtSyncSuccessPath
            // 
            this.txtSyncSuccessPath.Location = new System.Drawing.Point(185, 111);
            this.txtSyncSuccessPath.Name = "txtSyncSuccessPath";
            this.txtSyncSuccessPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncSuccessPath.TabIndex = 7;
            this.txtSyncSuccessPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncSuccessPath;
            // 
            // txtSyncErrorPath
            // 
            this.txtSyncErrorPath.Location = new System.Drawing.Point(185, 85);
            this.txtSyncErrorPath.Name = "txtSyncErrorPath";
            this.txtSyncErrorPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncErrorPath.TabIndex = 6;
            this.txtSyncErrorPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncErrorPath;
            // 
            // txtSyncImportPath
            // 
            this.txtSyncImportPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "SyncImportPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSyncImportPath.Location = new System.Drawing.Point(185, 59);
            this.txtSyncImportPath.Name = "txtSyncImportPath";
            this.txtSyncImportPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncImportPath.TabIndex = 5;
            this.txtSyncImportPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncImportPath;
            // 
            // txtSyncExportPath
            // 
            this.txtSyncExportPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "SyncExportPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSyncExportPath.Location = new System.Drawing.Point(185, 33);
            this.txtSyncExportPath.Name = "txtSyncExportPath";
            this.txtSyncExportPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncExportPath.TabIndex = 1;
            this.txtSyncExportPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncExportPath;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 287);
            this.Controls.Add(this.txtBackupDB);
            this.Controls.Add(this.txtMySQLDump);
            this.Controls.Add(this.btnBackupDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMySQLDump);
            this.Controls.Add(this.btnSuccessPath);
            this.Controls.Add(this.btnErrorPath);
            this.Controls.Add(this.btnImportPath);
            this.Controls.Add(btnExportPath);
            this.Controls.Add(this.cboPrinters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSyncSuccessPath);
            this.Controls.Add(this.txtSyncErrorPath);
            this.Controls.Add(this.txtSyncImportPath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.txtSyncExportPath);
            this.Controls.Add(this.label1);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSyncExportPath;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSyncImportPath;
        private System.Windows.Forms.TextBox txtSyncErrorPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPrinters;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.FolderBrowserDialog exportPathDialog;
        private System.Windows.Forms.Button btnImportPath;
        private System.Windows.Forms.Button btnErrorPath;
        private System.Windows.Forms.Button btnSuccessPath;
        private System.Windows.Forms.FolderBrowserDialog importPathDialog;
        private System.Windows.Forms.FolderBrowserDialog errorPathDialog;
        private System.Windows.Forms.FolderBrowserDialog successPathDialog;
        private System.Windows.Forms.Button btnMySQLDump;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FolderBrowserDialog mySQLBinDialog;
        private System.Windows.Forms.Button btnBackupDB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMySQLDump;
        private System.Windows.Forms.FolderBrowserDialog backupDBDialog;
        private System.Windows.Forms.TextBox txtSyncSuccessPath;
        private System.Windows.Forms.TextBox txtBackupDB;
    }
}