namespace POSReports
{
    partial class CustomizeReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.customizeReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.posDataSet = new POSReports.posDataSet();
            this.CustomizeReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomizeReportTableAdapter = new POSReports.posDataSetTableAdapters.CustomizeReportTableAdapter();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSortOrder = new System.Windows.Forms.ComboBox();
            this.txtTotalRecord = new AppFrame.Controls.NumberTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customizeReport
            // 
            reportDataSource1.Name = "posDataSet_CustomizeReport";
            reportDataSource1.Value = this.CustomizeReportBindingSource;
            this.customizeReport.LocalReport.DataSources.Add(reportDataSource1);
            this.customizeReport.LocalReport.ReportEmbeddedResource = "POSReports.CustomizeReport.rdlc";
            this.customizeReport.Location = new System.Drawing.Point(12, 115);
            this.customizeReport.Name = "customizeReport";
            this.customizeReport.Size = new System.Drawing.Size(905, 383);
            this.customizeReport.TabIndex = 0;
            this.customizeReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomizeReportBindingSource
            // 
            this.CustomizeReportBindingSource.DataMember = "CustomizeReport";
            this.CustomizeReportBindingSource.DataSource = this.posDataSet;
            // 
            // CustomizeReportTableAdapter
            // 
            this.CustomizeReportTableAdapter.ClearBeforeFill = true;
            // 
            // cboReportType
            // 
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Số hàng bán",
            "Số hàng nhập",
            "Số hàng xuất",
            "Số hàng bị trả lại",
            "Số hàng trong kho chính",
            "Số hàng trong kho cửa hàng"});
            this.cboReportType.Location = new System.Drawing.Point(92, 41);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(174, 21);
            this.cboReportType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại báo cáo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "BÁO CÁO HỖN HỢP";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/mm/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(92, 73);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(157, 20);
            this.dtpFromDate.TabIndex = 4;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/mm/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(322, 73);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(138, 20);
            this.dtpToDate.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(786, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 68);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tạo báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Số record";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Từ ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "đến ngày";
            // 
            // cboSortOrder
            // 
            this.cboSortOrder.FormattingEnabled = true;
            this.cboSortOrder.Items.AddRange(new object[] {
            "Nhiều nhất",
            "Ít nhất"});
            this.cboSortOrder.Location = new System.Drawing.Point(272, 41);
            this.cboSortOrder.Name = "cboSortOrder";
            this.cboSortOrder.Size = new System.Drawing.Size(121, 21);
            this.cboSortOrder.TabIndex = 12;
            // 
            // txtTotalRecord
            // 
            this.txtTotalRecord.Format = null;
            this.txtTotalRecord.Location = new System.Drawing.Point(530, 72);
            this.txtTotalRecord.Name = "txtTotalRecord";
            this.txtTotalRecord.Size = new System.Drawing.Size(56, 20);
            this.txtTotalRecord.TabIndex = 13;
            this.txtTotalRecord.Text = "10";
            // 
            // CustomizeReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 510);
            this.Controls.Add(this.txtTotalRecord);
            this.Controls.Add(this.cboSortOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.customizeReport);
            this.Name = "CustomizeReportViewer";
            this.Text = "CustomizeReportViewer";
            this.Load += new System.EventHandler(this.CustomizeReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer customizeReport;
        private System.Windows.Forms.BindingSource CustomizeReportBindingSource;
        private posDataSet posDataSet;
        private POSReports.posDataSetTableAdapters.CustomizeReportTableAdapter CustomizeReportTableAdapter;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSortOrder;
        private AppFrame.Controls.NumberTextBox txtTotalRecord;

    }
}