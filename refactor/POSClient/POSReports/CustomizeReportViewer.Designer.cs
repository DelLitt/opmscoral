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
            this.CustomizeReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet = new POSReports.posDataSet();
            this.customizeReport = new Microsoft.Reporting.WinForms.ReportViewer();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomizeReportBindingSource
            // 
            this.CustomizeReportBindingSource.DataMember = "CustomizeReport";
            this.CustomizeReportBindingSource.DataSource = this.posDataSet;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customizeReport
            // 
            this.customizeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "posDataSet_CustomizeReport";
            reportDataSource1.Value = this.CustomizeReportBindingSource;
            this.customizeReport.LocalReport.DataSources.Add(reportDataSource1);
            this.customizeReport.LocalReport.ReportEmbeddedResource = "POSReports.CustomizeReport.rdlc";
            this.customizeReport.Location = new System.Drawing.Point(0, 126);
            this.customizeReport.Name = "customizeReport";
            this.customizeReport.Size = new System.Drawing.Size(929, 384);
            this.customizeReport.TabIndex = 0;
            this.customizeReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.customizeReport.Load += new System.EventHandler(this.customizeReport_Load);
            // 
            // CustomizeReportTableAdapter
            // 
            this.CustomizeReportTableAdapter.ClearBeforeFill = true;
            // 
            // cboReportType
            // 
            this.cboReportType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboReportType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Số hàng bán",
            "Số hàng nhập",
            "Số hàng xuất",
            "Số hàng bị trả lại",
            "Số hàng trong kho chính",
            "Số hàng trong kho cửa hàng"});
            this.cboReportType.Location = new System.Drawing.Point(120, 3);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(164, 22);
            this.cboReportType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại báo cáo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "BÁO CÁO HỖN HỢP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 34);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(145, 22);
            this.dtpFromDate.TabIndex = 4;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(372, 34);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(136, 22);
            this.dtpToDate.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(801, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(122, 54);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tạo báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kết quả";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Từ ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(306, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "đến ngày";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cboSortOrder
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboSortOrder, 2);
            this.cboSortOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboSortOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSortOrder.FormattingEnabled = true;
            this.cboSortOrder.Items.AddRange(new object[] {
            "Nhiều nhất",
            "Ít nhất"});
            this.cboSortOrder.Location = new System.Drawing.Point(290, 3);
            this.cboSortOrder.Name = "cboSortOrder";
            this.cboSortOrder.Size = new System.Drawing.Size(121, 22);
            this.cboSortOrder.TabIndex = 12;
            // 
            // txtTotalRecord
            // 
            this.txtTotalRecord.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalRecord.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRecord.Format = null;
            this.txtTotalRecord.Location = new System.Drawing.Point(581, 34);
            this.txtTotalRecord.Name = "txtTotalRecord";
            this.txtTotalRecord.Size = new System.Drawing.Size(41, 22);
            this.txtTotalRecord.TabIndex = 13;
            this.txtTotalRecord.Text = "10";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.16667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalRecord, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboReportType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboSortOrder, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFromDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpToDate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(929, 101);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // CustomizeReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 510);
            this.Controls.Add(this.customizeReport);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Name = "CustomizeReportViewer";
            this.Text = "CustomizeReportViewer";
            this.Load += new System.EventHandler(this.CustomizeReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}