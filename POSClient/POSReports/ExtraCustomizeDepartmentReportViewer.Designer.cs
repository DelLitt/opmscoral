namespace POSReports
{
    partial class ExtraCustomizeDepartmentReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ExtraCustomizeDepartmentReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet = new POSReports.posDataSet();
            this.CustomizeDepartmentDetailReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customizeReport = new Microsoft.Reporting.WinForms.ReportViewer();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboIsolatedBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalRecord = new AppFrame.Controls.NumberTextBox();
            this.cboDepartments = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cboReportBy = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CustomizeDepartmentReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter1 = new POSReports.posDataSetTableAdapters.departmentTableAdapter();
            this.DepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomizeDepartmentReportTableAdapter = new POSReports.posDataSetTableAdapters.CustomizeDepartmentReportTableAdapter();
            this.CustomizeDepartmentDetailReportTableAdapter = new POSReports.posDataSetTableAdapters.CustomizeDepartmentDetailReportTableAdapter();
            this.ExtraCustomizeDepartmentReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentReportTableAdapter();
            this.customizeColorReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.customizeSizeReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ExtraCustomizeDepartmentColorReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExtraCustomizeDepartmentColorReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentColorReportTableAdapter();
            this.ExtraCustomizeDepartmentSizeReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExtraCustomizeDepartmentSizeReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentSizeReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentDetailReportBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentColorReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentSizeReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ExtraCustomizeDepartmentReportBindingSource
            // 
            this.ExtraCustomizeDepartmentReportBindingSource.DataMember = "ExtraCustomizeDepartmentReport";
            this.ExtraCustomizeDepartmentReportBindingSource.DataSource = this.posDataSet;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomizeDepartmentDetailReportBindingSource
            // 
            this.CustomizeDepartmentDetailReportBindingSource.DataMember = "CustomizeDepartmentDetailReport";
            this.CustomizeDepartmentDetailReportBindingSource.DataSource = this.posDataSet;
            // 
            // customizeReport
            // 
            this.customizeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ECDRDataSet";
            reportDataSource1.Value = this.ExtraCustomizeDepartmentReportBindingSource;
            this.customizeReport.LocalReport.DataSources.Add(reportDataSource1);
            this.customizeReport.LocalReport.ReportEmbeddedResource = "POSReports.ExtraCustomizeDepartmentReport.rdlc";
            this.customizeReport.Location = new System.Drawing.Point(0, 114);
            this.customizeReport.Name = "customizeReport";
            this.customizeReport.Size = new System.Drawing.Size(929, 422);
            this.customizeReport.TabIndex = 0;
            this.customizeReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.customizeReport.Load += new System.EventHandler(this.customizeReport_Load);
            // 
            // cboReportType
            // 
            this.cboReportType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.DropDownWidth = 250;
            this.cboReportType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Số hàng bán",
            "Số hàng nhập",
            "Số hàng xuất",
            "Số hàng bán rồi bị trả lại",
            "Số hàng tồn kho"});
            this.cboReportType.Location = new System.Drawing.Point(105, 3);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(141, 22);
            this.cboReportType.TabIndex = 1;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Báo cáo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(455, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "BÁO CÁO HỖN HỢP  - TÌNH HÌNH CỬA HÀNG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(105, 31);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(141, 22);
            this.dtpFromDate.TabIndex = 4;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(334, 31);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(136, 22);
            this.dtpToDate.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(763, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(147, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tạo báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 33);
            this.label3.TabIndex = 9;
            this.label3.Text = "Giới hạn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Từ ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "đến ngày";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cboSortOrder
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboSortOrder, 2);
            this.cboSortOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSortOrder.FormattingEnabled = true;
            this.cboSortOrder.Items.AddRange(new object[] {
            "Nhiều nhất",
            "Ít nhất"});
            this.cboSortOrder.Location = new System.Drawing.Point(252, 3);
            this.cboSortOrder.Name = "cboSortOrder";
            this.cboSortOrder.Size = new System.Drawing.Size(218, 22);
            this.cboSortOrder.TabIndex = 12;
            this.cboSortOrder.SelectedIndexChanged += new System.EventHandler(this.cboSortOrder_SelectedIndexChanged);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboReportType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFromDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpToDate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboIsolatedBy, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboSortOrder, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalRecord, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDepartments, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboReportBy, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(929, 89);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 28);
            this.label6.TabIndex = 21;
            this.label6.Text = "Từ ngày";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(509, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "của";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboIsolatedBy
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboIsolatedBy, 2);
            this.cboIsolatedBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboIsolatedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsolatedBy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIsolatedBy.FormattingEnabled = true;
            this.cboIsolatedBy.Items.AddRange(new object[] {
            "Tất cả cửa hàng",
            "Mỗi cửa hàng",
            "Cửa hàng có tên:"});
            this.cboIsolatedBy.Location = new System.Drawing.Point(543, 3);
            this.cboIsolatedBy.Name = "cboIsolatedBy";
            this.cboIsolatedBy.Size = new System.Drawing.Size(214, 22);
            this.cboIsolatedBy.TabIndex = 16;
            this.cboIsolatedBy.SelectedIndexChanged += new System.EventHandler(this.cboIsolatedBy_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(590, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 33);
            this.label8.TabIndex = 18;
            this.label8.Text = "sản phẩm";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalRecord
            // 
            this.txtTotalRecord.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalRecord.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRecord.Format = null;
            this.txtTotalRecord.Location = new System.Drawing.Point(543, 59);
            this.txtTotalRecord.Name = "txtTotalRecord";
            this.txtTotalRecord.Size = new System.Drawing.Size(41, 22);
            this.txtTotalRecord.TabIndex = 13;
            this.txtTotalRecord.Text = "5";
            // 
            // cboDepartments
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDepartments, 2);
            this.cboDepartments.DataSource = this.departmentBindingSource1;
            this.cboDepartments.DisplayMember = "DEPARTMENT_NAME";
            this.cboDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartments.Enabled = false;
            this.cboDepartments.FormattingEnabled = true;
            this.cboDepartments.Location = new System.Drawing.Point(543, 31);
            this.cboDepartments.Name = "cboDepartments";
            this.cboDepartments.Size = new System.Drawing.Size(214, 21);
            this.cboDepartments.TabIndex = 19;
            this.cboDepartments.ValueMember = "DEPARTMENT_ID";
            // 
            // departmentBindingSource1
            // 
            this.departmentBindingSource1.DataMember = "department";
            this.departmentBindingSource1.DataSource = this.posDataSet;
            // 
            // cboReportBy
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboReportBy, 2);
            this.cboReportBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportBy.FormattingEnabled = true;
            this.cboReportBy.Items.AddRange(new object[] {
            "Tên mặt hàng",
            "Loại kích cỡ",
            "Loại màu sắc"});
            this.cboReportBy.Location = new System.Drawing.Point(252, 59);
            this.cboReportBy.Name = "cboReportBy";
            this.cboReportBy.Size = new System.Drawing.Size(218, 21);
            this.cboReportBy.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.882353F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(125, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 33);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tạo báo cáo theo:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CustomizeDepartmentReportBindingSource
            // 
            this.CustomizeDepartmentReportBindingSource.DataMember = "CustomizeDepartmentReport";
            this.CustomizeDepartmentReportBindingSource.DataSource = this.posDataSet;
            // 
            // departmentTableAdapter1
            // 
            this.departmentTableAdapter1.ClearBeforeFill = true;
            // 
            // DepartmentBindingSource
            // 
            this.DepartmentBindingSource.DataMember = "department";
            this.DepartmentBindingSource.DataSource = this.posDataSet;
            // 
            // CustomizeDepartmentReportTableAdapter
            // 
            this.CustomizeDepartmentReportTableAdapter.ClearBeforeFill = true;
            // 
            // CustomizeDepartmentDetailReportTableAdapter
            // 
            this.CustomizeDepartmentDetailReportTableAdapter.ClearBeforeFill = true;
            // 
            // ExtraCustomizeDepartmentReportTableAdapter
            // 
            this.ExtraCustomizeDepartmentReportTableAdapter.ClearBeforeFill = true;
            // 
            // customizeColorReport
            // 
            this.customizeColorReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "ECDRDataSet";
            reportDataSource2.Value = this.ExtraCustomizeDepartmentColorReportBindingSource;
            this.customizeColorReport.LocalReport.DataSources.Add(reportDataSource2);
            this.customizeColorReport.LocalReport.ReportEmbeddedResource = "POSReports.ExtraCustomizeDepartmentColorReport.rdlc";
            this.customizeColorReport.Location = new System.Drawing.Point(0, 114);
            this.customizeColorReport.Name = "customizeColorReport";
            this.customizeColorReport.Size = new System.Drawing.Size(929, 422);
            this.customizeColorReport.TabIndex = 15;
            this.customizeColorReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // customizeSizeReport
            // 
            this.customizeSizeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "ECDRDataSet";
            reportDataSource3.Value = this.ExtraCustomizeDepartmentSizeReportBindingSource;
            this.customizeSizeReport.LocalReport.DataSources.Add(reportDataSource3);
            this.customizeSizeReport.LocalReport.ReportEmbeddedResource = "POSReports.ExtraCustomizeDepartmentSizeReport.rdlc";
            this.customizeSizeReport.Location = new System.Drawing.Point(0, 114);
            this.customizeSizeReport.Name = "customizeSizeReport";
            this.customizeSizeReport.Size = new System.Drawing.Size(929, 422);
            this.customizeSizeReport.TabIndex = 16;
            this.customizeSizeReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ExtraCustomizeDepartmentColorReportBindingSource
            // 
            this.ExtraCustomizeDepartmentColorReportBindingSource.DataMember = "ExtraCustomizeDepartmentColorReport";
            this.ExtraCustomizeDepartmentColorReportBindingSource.DataSource = this.posDataSet;
            // 
            // ExtraCustomizeDepartmentColorReportTableAdapter
            // 
            this.ExtraCustomizeDepartmentColorReportTableAdapter.ClearBeforeFill = true;
            // 
            // ExtraCustomizeDepartmentSizeReportBindingSource
            // 
            this.ExtraCustomizeDepartmentSizeReportBindingSource.DataMember = "ExtraCustomizeDepartmentSizeReport";
            this.ExtraCustomizeDepartmentSizeReportBindingSource.DataSource = this.posDataSet;
            // 
            // ExtraCustomizeDepartmentSizeReportTableAdapter
            // 
            this.ExtraCustomizeDepartmentSizeReportTableAdapter.ClearBeforeFill = true;
            // 
            // ExtraCustomizeDepartmentReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 558);
            this.Controls.Add(this.customizeColorReport);
            this.Controls.Add(this.customizeSizeReport);
            this.Controls.Add(this.customizeReport);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Name = "ExtraCustomizeDepartmentReportViewer";
            this.Text = "CustomizeReportViewer";
            this.Load += new System.EventHandler(this.CustomizeReportViewer_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.customizeReport, 0);
            this.Controls.SetChildIndex(this.customizeSizeReport, 0);
            this.Controls.SetChildIndex(this.customizeColorReport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentDetailReportBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentColorReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentSizeReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer customizeReport;
        private posDataSet posDataSet;
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
        private POSReports.posDataSetTableAdapters.departmentTableAdapter departmentTableAdapter1;
        private System.Windows.Forms.BindingSource DepartmentBindingSource;
        private System.Windows.Forms.BindingSource CustomizeDepartmentReportBindingSource;
        private POSReports.posDataSetTableAdapters.CustomizeDepartmentReportTableAdapter CustomizeDepartmentReportTableAdapter;
        private System.Windows.Forms.BindingSource CustomizeDepartmentDetailReportBindingSource;
        private POSReports.posDataSetTableAdapters.CustomizeDepartmentDetailReportTableAdapter CustomizeDepartmentDetailReportTableAdapter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboIsolatedBy;
        private System.Windows.Forms.BindingSource ExtraCustomizeDepartmentReportBindingSource;
        private POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentReportTableAdapter ExtraCustomizeDepartmentReportTableAdapter;
        private System.Windows.Forms.ComboBox cboDepartments;
        private System.Windows.Forms.BindingSource departmentBindingSource1;
        private System.Windows.Forms.ComboBox cboReportBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private Microsoft.Reporting.WinForms.ReportViewer customizeColorReport;
        private System.Windows.Forms.BindingSource ExtraCustomizeDepartmentColorReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer customizeSizeReport;
        private POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentColorReportTableAdapter ExtraCustomizeDepartmentColorReportTableAdapter;
        private System.Windows.Forms.BindingSource ExtraCustomizeDepartmentSizeReportBindingSource;
        private POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentSizeReportTableAdapter ExtraCustomizeDepartmentSizeReportTableAdapter;

    }
}