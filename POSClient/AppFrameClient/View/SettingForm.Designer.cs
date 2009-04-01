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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSyncExportPath = new System.Windows.Forms.TextBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSyncImportPath = new System.Windows.Forms.TextBox();
            this.txtSyncErrorPath = new System.Windows.Forms.TextBox();
            this.txtSyncSuccessPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn xuất file:";
            // 
            // txtSyncExportPath
            // 
            this.txtSyncExportPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "SyncImportPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSyncExportPath.Location = new System.Drawing.Point(117, 33);
            this.txtSyncExportPath.Name = "txtSyncExportPath";
            this.txtSyncExportPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncExportPath.TabIndex = 1;
            this.txtSyncExportPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncImportPath;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(236, 252);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Mặc định";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(317, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(155, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSyncImportPath
            // 
            this.txtSyncImportPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "SyncExportPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSyncImportPath.Location = new System.Drawing.Point(117, 59);
            this.txtSyncImportPath.Name = "txtSyncImportPath";
            this.txtSyncImportPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncImportPath.TabIndex = 5;
            this.txtSyncImportPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncExportPath;
            // 
            // txtSyncErrorPath
            // 
            this.txtSyncErrorPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "SyncErrorPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSyncErrorPath.Location = new System.Drawing.Point(117, 85);
            this.txtSyncErrorPath.Name = "txtSyncErrorPath";
            this.txtSyncErrorPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncErrorPath.TabIndex = 6;
            this.txtSyncErrorPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncErrorPath;
            // 
            // txtSyncSuccessPath
            // 
            this.txtSyncSuccessPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AppFrameClient.Properties.Settings.Default, "SyncSuccessPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSyncSuccessPath.Location = new System.Drawing.Point(117, 111);
            this.txtSyncSuccessPath.Name = "txtSyncSuccessPath";
            this.txtSyncSuccessPath.Size = new System.Drawing.Size(172, 20);
            this.txtSyncSuccessPath.TabIndex = 7;
            this.txtSyncSuccessPath.Text = global::AppFrameClient.Properties.Settings.Default.SyncSuccessPath;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Đường dẫn nhập file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lưu file lỗi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lưu file thành công:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Máy in hoá đơn:";
            // 
            // cboPrinters
            // 
            this.cboPrinters.DataBindings.Add(new System.Windows.Forms.Binding("Name", global::AppFrameClient.Properties.Settings.Default, "PrinterName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(117, 142);
            this.cboPrinters.Name = global::AppFrameClient.Properties.Settings.Default.PrinterName;
            this.cboPrinters.Size = new System.Drawing.Size(172, 21);
            this.cboPrinters.TabIndex = 12;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 287);
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
            this.Text = "Cấu hình";
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
        private System.Windows.Forms.TextBox txtSyncSuccessPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPrinters;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}