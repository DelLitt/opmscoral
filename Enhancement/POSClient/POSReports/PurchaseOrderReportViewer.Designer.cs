namespace POSReports
{
    partial class PurchaseOrderReportViewer
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
            this.PurchaseOrderReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet = new POSReports.posDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.departmentId = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter = new POSReports.posDataSetTableAdapters.departmentTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.purchaseOrderReportTableAdapter1 = new POSReports.posDataSetTableAdapters.PurchaseOrderReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PurchaseOrderReportBindingSource
            // 
            this.PurchaseOrderReportBindingSource.DataMember = "PurchaseOrderReport";
            this.PurchaseOrderReportBindingSource.DataSource = this.posDataSet;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpFrom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpTo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.departmentId, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 68);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(103, 37);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpFrom.Size = new System.Drawing.Size(194, 26);
            this.dtpFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "đến ngày:";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(403, 37);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(194, 26);
            this.dtpTo.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(603, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tạo báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "XEM BÁO CÁO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(303, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cửa hàng";
            // 
            // departmentId
            // 
            this.departmentId.DataSource = this.departmentBindingSource;
            this.departmentId.DisplayMember = "DEPARTMENT_NAME";
            this.departmentId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentId.FormattingEnabled = true;
            this.departmentId.Location = new System.Drawing.Point(403, 3);
            this.departmentId.Name = "departmentId";
            this.departmentId.Size = new System.Drawing.Size(121, 27);
            this.departmentId.TabIndex = 7;
            this.departmentId.ValueMember = "DEPARTMENT_ID";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "department";
            this.departmentBindingSource.DataSource = this.posDataSet;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "posDataSet_PurchaseOrderReport";
            reportDataSource1.Value = this.PurchaseOrderReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POSReports.GoodsPurchaseOrders.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 68);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 574);
            this.reportViewer1.TabIndex = 7;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // purchaseOrderReportTableAdapter1
            // 
            this.purchaseOrderReportTableAdapter1.ClearBeforeFill = true;
            // 
            // PurchaseOrderReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 642);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PurchaseOrderReportViewer";
            this.Text = "BÁO CÁO BÁN HÀNG";
            this.Load += new System.EventHandler(this.PurchaseOrrderReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private posDataSet posDataSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox departmentId;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private POSReports.posDataSetTableAdapters.departmentTableAdapter departmentTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PurchaseOrderReportBindingSource;
        private POSReports.posDataSetTableAdapters.PurchaseOrderReportTableAdapter purchaseOrderReportTableAdapter1;
    }
}