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
            this.components = new System.ComponentModel.Container();
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
            this.txtSyncSuccessPath = new System.Windows.Forms.TextBox();
            this.txtSyncErrorPath = new System.Windows.Forms.TextBox();
            this.txtSyncImportPath = new System.Windows.Forms.TextBox();
            this.txtSyncExportPath = new System.Windows.Forms.TextBox();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.departmentTableAdapter = new AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter();
            this.grpSync = new System.Windows.Forms.GroupBox();
            this.grpPrinting = new System.Windows.Forms.GroupBox();
            this.grpSubStock = new System.Windows.Forms.GroupBox();
            this.grpService = new System.Windows.Forms.GroupBox();
            this.cboBinding = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            btnExportPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            this.grpSync.SuspendLayout();
            this.grpPrinting.SuspendLayout();
            this.grpSubStock.SuspendLayout();
            this.grpService.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportPath
            // 
            btnExportPath.Location = new System.Drawing.Point(344, 16);
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
            this.label1.Location = new System.Drawing.Point(52, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn xuất file: ";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(314, 373);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Mặc định";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(395, 373);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(233, 373);
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
            this.label2.Location = new System.Drawing.Point(47, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Đường dẫn nhập file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lưu file lỗi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lưu file thành công:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Máy in hoá đơn:";
            // 
            // btnImportPath
            // 
            this.btnImportPath.Location = new System.Drawing.Point(344, 43);
            this.btnImportPath.Name = "btnImportPath";
            this.btnImportPath.Size = new System.Drawing.Size(31, 23);
            this.btnImportPath.TabIndex = 14;
            this.btnImportPath.Text = "...";
            this.btnImportPath.UseVisualStyleBackColor = true;
            this.btnImportPath.Click += new System.EventHandler(this.btnImportPath_Click);
            // 
            // btnErrorPath
            // 
            this.btnErrorPath.Location = new System.Drawing.Point(344, 69);
            this.btnErrorPath.Name = "btnErrorPath";
            this.btnErrorPath.Size = new System.Drawing.Size(31, 23);
            this.btnErrorPath.TabIndex = 15;
            this.btnErrorPath.Text = "...";
            this.btnErrorPath.UseVisualStyleBackColor = true;
            this.btnErrorPath.Click += new System.EventHandler(this.btnErrorPath_Click);
            // 
            // btnSuccessPath
            // 
            this.btnSuccessPath.Location = new System.Drawing.Point(344, 95);
            this.btnSuccessPath.Name = "btnSuccessPath";
            this.btnSuccessPath.Size = new System.Drawing.Size(31, 23);
            this.btnSuccessPath.TabIndex = 16;
            this.btnSuccessPath.Text = "...";
            this.btnSuccessPath.UseVisualStyleBackColor = true;
            this.btnSuccessPath.Click += new System.EventHandler(this.btnSuccessPath_Click);
            // 
            // btnMySQLDump
            // 
            this.btnMySQLDump.Location = new System.Drawing.Point(345, 147);
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
            this.label6.Location = new System.Drawing.Point(43, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Đường dẫn mysql\\bin:";
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Location = new System.Drawing.Point(343, 118);
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
            this.label7.Location = new System.Drawing.Point(72, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Backup dữ liệu:";
            // 
            // txtMySQLDump
            // 
            this.txtMySQLDump.Location = new System.Drawing.Point(166, 147);
            this.txtMySQLDump.Name = "txtMySQLDump";
            this.txtMySQLDump.Size = new System.Drawing.Size(173, 20);
            this.txtMySQLDump.TabIndex = 23;
            this.txtMySQLDump.Text = "C:\\Program Files\\MySQL\\MySQL Server 5.1\\bin";
            // 
            // txtBackupDB
            // 
            this.txtBackupDB.Location = new System.Drawing.Point(165, 120);
            this.txtBackupDB.Name = "txtBackupDB";
            this.txtBackupDB.Size = new System.Drawing.Size(172, 20);
            this.txtBackupDB.TabIndex = 24;
            this.txtBackupDB.Text = "\\POS\\BackupDB";
            // 
            // txtSyncSuccessPath
            // 
            this.txtSyncSuccessPath.Location = new System.Drawing.Point(166, 97);
            this.txtSyncSuccessPath.Name = "txtSyncSuccessPath";
            this.txtSyncSuccessPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncSuccessPath.TabIndex = 7;
            this.txtSyncSuccessPath.Text = "\\POS\\Success";
            // 
            // txtSyncErrorPath
            // 
            this.txtSyncErrorPath.Location = new System.Drawing.Point(166, 71);
            this.txtSyncErrorPath.Name = "txtSyncErrorPath";
            this.txtSyncErrorPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncErrorPath.TabIndex = 6;
            this.txtSyncErrorPath.Text = "\\POS\\Error";
            // 
            // txtSyncImportPath
            // 
            this.txtSyncImportPath.Location = new System.Drawing.Point(166, 45);
            this.txtSyncImportPath.Name = "txtSyncImportPath";
            this.txtSyncImportPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncImportPath.TabIndex = 5;
            this.txtSyncImportPath.Text = "\\POS\\CH-KHO";
            // 
            // txtSyncExportPath
            // 
            this.txtSyncExportPath.Location = new System.Drawing.Point(166, 19);
            this.txtSyncExportPath.Name = "txtSyncExportPath";
            this.txtSyncExportPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncExportPath.TabIndex = 1;
            this.txtSyncExportPath.Text = "\\POS\\KHO-CH";
            // 
            // cboPrinters
            // 
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(167, 15);
            this.cboPrinters.Name = global::AppFrameClient.Properties.Settings.Default.PrinterName;
            this.cboPrinters.Size = new System.Drawing.Size(172, 21);
            this.cboPrinters.TabIndex = 12;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DataSource = this.departmentBindingSource;
            this.cboDepartment.DisplayMember = "DEPARTMENT_NAME";
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(167, 19);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(173, 21);
            this.cboDepartment.TabIndex = 25;
            this.cboDepartment.ValueMember = "DEPARTMENT_ID";
            this.cboDepartment.Visible = false;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.masterDBBindingSource;
            // 
            // masterDBBindingSource
            // 
            this.masterDBBindingSource.DataSource = this.masterDB;
            this.masterDBBindingSource.Position = 0;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(49, 22);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(112, 13);
            this.lblDepartment.TabIndex = 26;
            this.lblDepartment.Text = "Nơi xuất của kho phụ:";
            this.lblDepartment.Visible = false;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // grpSync
            // 
            this.grpSync.Controls.Add(this.txtSyncImportPath);
            this.grpSync.Controls.Add(this.label1);
            this.grpSync.Controls.Add(this.txtSyncExportPath);
            this.grpSync.Controls.Add(this.txtMySQLDump);
            this.grpSync.Controls.Add(this.label6);
            this.grpSync.Controls.Add(this.txtBackupDB);
            this.grpSync.Controls.Add(this.btnMySQLDump);
            this.grpSync.Controls.Add(this.txtSyncErrorPath);
            this.grpSync.Controls.Add(this.label2);
            this.grpSync.Controls.Add(this.btnBackupDB);
            this.grpSync.Controls.Add(this.label3);
            this.grpSync.Controls.Add(this.label7);
            this.grpSync.Controls.Add(btnExportPath);
            this.grpSync.Controls.Add(this.btnImportPath);
            this.grpSync.Controls.Add(this.btnErrorPath);
            this.grpSync.Controls.Add(this.btnSuccessPath);
            this.grpSync.Controls.Add(this.txtSyncSuccessPath);
            this.grpSync.Controls.Add(this.label4);
            this.grpSync.Location = new System.Drawing.Point(13, 13);
            this.grpSync.Name = "grpSync";
            this.grpSync.Size = new System.Drawing.Size(457, 180);
            this.grpSync.TabIndex = 27;
            this.grpSync.TabStop = false;
            this.grpSync.Text = "Đồng bộ";
            // 
            // grpPrinting
            // 
            this.grpPrinting.Controls.Add(this.cboPrinters);
            this.grpPrinting.Controls.Add(this.label5);
            this.grpPrinting.Location = new System.Drawing.Point(13, 199);
            this.grpPrinting.Name = "grpPrinting";
            this.grpPrinting.Size = new System.Drawing.Size(457, 42);
            this.grpPrinting.TabIndex = 28;
            this.grpPrinting.TabStop = false;
            this.grpPrinting.Text = "In ấn";
            // 
            // grpSubStock
            // 
            this.grpSubStock.Controls.Add(this.cboDepartment);
            this.grpSubStock.Controls.Add(this.lblDepartment);
            this.grpSubStock.Location = new System.Drawing.Point(12, 247);
            this.grpSubStock.Name = "grpSubStock";
            this.grpSubStock.Size = new System.Drawing.Size(457, 53);
            this.grpSubStock.TabIndex = 29;
            this.grpSubStock.TabStop = false;
            this.grpSubStock.Text = "Kho phụ";
            // 
            // grpService
            // 
            this.grpService.Controls.Add(this.cboBinding);
            this.grpService.Controls.Add(this.label8);
            this.grpService.Location = new System.Drawing.Point(13, 307);
            this.grpService.Name = "grpService";
            this.grpService.Size = new System.Drawing.Size(456, 59);
            this.grpService.TabIndex = 30;
            this.grpService.TabStop = false;
            this.grpService.Text = "Dịch vụ";
            // 
            // cboBinding
            // 
            this.cboBinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBinding.FormattingEnabled = true;
            this.cboBinding.Items.AddRange(new object[] {
            "TcpBinding",
            "HttpBinding"});
            this.cboBinding.Location = new System.Drawing.Point(167, 19);
            this.cboBinding.Name = "cboBinding";
            this.cboBinding.Size = new System.Drawing.Size(173, 21);
            this.cboBinding.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Giao thức kết nối:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 408);
            this.Controls.Add(this.grpService);
            this.Controls.Add(this.grpSubStock);
            this.Controls.Add(this.grpPrinting);
            this.Controls.Add(this.grpSync);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDefault);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            this.grpSync.ResumeLayout(false);
            this.grpSync.PerformLayout();
            this.grpPrinting.ResumeLayout(false);
            this.grpPrinting.PerformLayout();
            this.grpSubStock.ResumeLayout(false);
            this.grpSubStock.PerformLayout();
            this.grpService.ResumeLayout(false);
            this.grpService.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.BindingSource masterDBBindingSource;
        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.GroupBox grpSync;
        private System.Windows.Forms.GroupBox grpPrinting;
        private System.Windows.Forms.GroupBox grpSubStock;
        private System.Windows.Forms.GroupBox grpService;
        private System.Windows.Forms.ComboBox cboBinding;
        private System.Windows.Forms.Label label8;
    }
}