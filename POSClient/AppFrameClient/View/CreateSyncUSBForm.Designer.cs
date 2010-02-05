namespace AppFrameClient.View
{
    partial class CreateSyncUSBForm
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
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.dtpKHOCH = new System.Windows.Forms.DateTimePicker();
            this.dtpCHKHO = new System.Windows.Forms.DateTimePicker();
            this.btnExportFromDB = new System.Windows.Forms.Button();
            this.btnImportFromDB = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.departmentTableAdapter = new AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDepartment
            // 
            this.cboDepartment.DataSource = this.departmentBindingSource;
            this.cboDepartment.DisplayMember = "DEPARTMENT_NAME";
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(3, 43);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(392, 21);
            this.cboDepartment.TabIndex = 0;
            this.cboDepartment.ValueMember = "DEPARTMENT_ID";
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.masterDB;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpKHOCH
            // 
            this.dtpKHOCH.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpKHOCH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKHOCH.Location = new System.Drawing.Point(3, 129);
            this.dtpKHOCH.Name = "dtpKHOCH";
            this.dtpKHOCH.Size = new System.Drawing.Size(276, 20);
            this.dtpKHOCH.TabIndex = 1;
            // 
            // dtpCHKHO
            // 
            this.dtpCHKHO.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpCHKHO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCHKHO.Location = new System.Drawing.Point(3, 203);
            this.dtpCHKHO.Name = "dtpCHKHO";
            this.dtpCHKHO.Size = new System.Drawing.Size(275, 20);
            this.dtpCHKHO.TabIndex = 2;
            this.dtpCHKHO.ValueChanged += new System.EventHandler(this.dtpCHKHO_ValueChanged);
            // 
            // btnExportFromDB
            // 
            this.btnExportFromDB.Location = new System.Drawing.Point(295, 129);
            this.btnExportFromDB.Name = "btnExportFromDB";
            this.btnExportFromDB.Size = new System.Drawing.Size(100, 23);
            this.btnExportFromDB.TabIndex = 3;
            this.btnExportFromDB.Text = "Lấy từ DB";
            this.btnExportFromDB.UseVisualStyleBackColor = true;
            this.btnExportFromDB.Click += new System.EventHandler(this.btnExportFromDB_Click);
            // 
            // btnImportFromDB
            // 
            this.btnImportFromDB.Location = new System.Drawing.Point(295, 203);
            this.btnImportFromDB.Name = "btnImportFromDB";
            this.btnImportFromDB.Size = new System.Drawing.Size(100, 23);
            this.btnImportFromDB.TabIndex = 4;
            this.btnImportFromDB.Text = "Lấy từ DB";
            this.btnImportFromDB.UseVisualStyleBackColor = true;
            this.btnImportFromDB.Click += new System.EventHandler(this.btnImportFromDB_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(305, 305);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(161, 305);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(127, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Tạo USB đồng bộ";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Location = new System.Drawing.Point(3, 261);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(392, 20);
            this.txtStatus.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cửa hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "KHO-CH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "CH-KHO";
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // CreateSyncUSBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 330);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImportFromDB);
            this.Controls.Add(this.btnExportFromDB);
            this.Controls.Add(this.dtpCHKHO);
            this.Controls.Add(this.dtpKHOCH);
            this.Controls.Add(this.cboDepartment);
            this.Name = "CreateSyncUSBForm";
            this.Text = "Tạo USB đồng bộ";
            this.Load += new System.EventHandler(this.CreateSyncUSBForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.DateTimePicker dtpKHOCH;
        private System.Windows.Forms.DateTimePicker dtpCHKHO;
        private System.Windows.Forms.Button btnExportFromDB;
        private System.Windows.Forms.Button btnImportFromDB;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter departmentTableAdapter;
    }
}