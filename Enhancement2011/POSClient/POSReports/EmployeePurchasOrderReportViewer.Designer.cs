namespace POSReports
{
    partial class EmployeePurchaseOrderReportViewer
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
            this.EmployeePurchaseOrderDetailReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet = new POSReports.posDataSet();
            this.PurchaseOrderDetailReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.departments = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.purchaseOrderDetailReportTableAdapter1 = new POSReports.posDataSetTableAdapters.PurchaseOrderDetailReportTableAdapter();
            this.departmentTableAdapter1 = new POSReports.posDataSetTableAdapters.departmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePurchaseOrderDetailReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderReportBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeePurchaseOrderDetailReportBindingSource
            // 
            this.EmployeePurchaseOrderDetailReportBindingSource.DataMember = "EmployeePurchaseOrderDetailReport";
            this.EmployeePurchaseOrderDetailReportBindingSource.DataSource = this.posDataSet;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PurchaseOrderDetailReportBindingSource
            // 
            this.PurchaseOrderDetailReportBindingSource.DataMember = "PurchaseOrderDetailReport";
            this.PurchaseOrderDetailReportBindingSource.DataSource = this.posDataSet;
            // 
            // PurchaseOrderReportBindingSource
            // 
            this.PurchaseOrderReportBindingSource.DataMember = "PurchaseOrderDetailReport";
            this.PurchaseOrderReportBindingSource.DataSource = this.posDataSet;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fromDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.toDate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.departments, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 74);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "XEM BÁO CÁO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày:";
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd/MM/yyyyy";
            this.fromDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(107, 39);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(194, 27);
            this.fromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày:";
            // 
            // toDate
            // 
            this.toDate.CustomFormat = "dd/MM/yyyy";
            this.toDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.Location = new System.Drawing.Point(411, 39);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(194, 27);
            this.toDate.TabIndex = 4;
            // 
            // departments
            // 
            this.departments.DataSource = this.departmentBindingSource;
            this.departments.DisplayMember = "DEPARTMENT_NAME";
            this.departments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departments.FormattingEnabled = true;
            this.departments.Location = new System.Drawing.Point(411, 5);
            this.departments.Name = "departments";
            this.departments.Size = new System.Drawing.Size(194, 28);
            this.departments.TabIndex = 6;
            this.departments.ValueMember = "DEPARTMENT_ID";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "department";
            this.departmentBindingSource.DataSource = this.posDataSet;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(613, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "Xem báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "posDataSet_EmployeePurchaseOrderDetailReport";
            reportDataSource1.Value = this.EmployeePurchaseOrderDetailReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POSReports.EmployeePurchaseOrder.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 74);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 545);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // purchaseOrderDetailReportTableAdapter1
            // 
            this.purchaseOrderDetailReportTableAdapter1.ClearBeforeFill = true;
            // 
            // departmentTableAdapter1
            // 
            this.departmentTableAdapter1.ClearBeforeFill = true;
            // 
            // EmployeePurchaseOrderReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 642);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EmployeePurchaseOrderReportViewer";
            this.Text = "PurchaseDetailsReportViewer";
            this.Load += new System.EventHandler(this.PurchaseDetailsReportViewer_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePurchaseOrderDetailReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderReportBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private posDataSet posDataSet;
        private System.Windows.Forms.BindingSource PurchaseOrderReportBindingSource;
        private POSReports.posDataSetTableAdapters.PurchaseOrderDetailReportTableAdapter purchaseOrderDetailReportTableAdapter1;
        private System.Windows.Forms.ComboBox departments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private POSReports.posDataSetTableAdapters.departmentTableAdapter departmentTableAdapter1;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailReportBindingSource;
        private System.Windows.Forms.BindingSource EmployeePurchaseOrderDetailReportBindingSource;
    }
}