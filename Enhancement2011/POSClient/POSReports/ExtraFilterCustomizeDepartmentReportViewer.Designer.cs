namespace POSReports
{
    partial class ExtraFilterCustomizeDepartmentReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ExtraFilterCustomizeDepartmentReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet = new POSReports.posDataSet();
            this.ExtraCustomizeDepartmentReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExtraCustomizeDepartmentColorReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExtraCustomizeDepartmentSizeReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomizeDepartmentDetailReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customizeReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSortOrder = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboIsolatedBy = new System.Windows.Forms.ComboBox();
            this.cboDepartments = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtColorFilter = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtSizeFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrdFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTypes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.producttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomizeDepartmentReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter1 = new POSReports.posDataSetTableAdapters.departmentTableAdapter();
            this.DepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomizeDepartmentReportTableAdapter = new POSReports.posDataSetTableAdapters.CustomizeDepartmentReportTableAdapter();
            this.CustomizeDepartmentDetailReportTableAdapter = new POSReports.posDataSetTableAdapters.CustomizeDepartmentDetailReportTableAdapter();
            this.ExtraCustomizeDepartmentReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentReportTableAdapter();
            this.ExtraCustomizeDepartmentColorReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentColorReportTableAdapter();
            this.ExtraCustomizeDepartmentSizeReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentSizeReportTableAdapter();
            this.ExtraFilterCustomizeDepartmentReportTableAdapter = new POSReports.posDataSetTableAdapters.ExtraFilterCustomizeDepartmentReportTableAdapter();
            this.product_typeTableAdapter = new POSReports.posDataSetTableAdapters.product_typeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraFilterCustomizeDepartmentReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentColorReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentSizeReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentDetailReportBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ExtraFilterCustomizeDepartmentReportBindingSource
            // 
            this.ExtraFilterCustomizeDepartmentReportBindingSource.DataMember = "ExtraFilterCustomizeDepartmentReport";
            this.ExtraFilterCustomizeDepartmentReportBindingSource.DataSource = this.posDataSet;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ExtraCustomizeDepartmentReportBindingSource
            // 
            this.ExtraCustomizeDepartmentReportBindingSource.DataMember = "ExtraCustomizeDepartmentReport";
            this.ExtraCustomizeDepartmentReportBindingSource.DataSource = this.posDataSet;
            // 
            // ExtraCustomizeDepartmentColorReportBindingSource
            // 
            this.ExtraCustomizeDepartmentColorReportBindingSource.DataMember = "ExtraCustomizeDepartmentColorReport";
            this.ExtraCustomizeDepartmentColorReportBindingSource.DataSource = this.posDataSet;
            // 
            // ExtraCustomizeDepartmentSizeReportBindingSource
            // 
            this.ExtraCustomizeDepartmentSizeReportBindingSource.DataMember = "ExtraCustomizeDepartmentSizeReport";
            this.ExtraCustomizeDepartmentSizeReportBindingSource.DataSource = this.posDataSet;
            // 
            // CustomizeDepartmentDetailReportBindingSource
            // 
            this.CustomizeDepartmentDetailReportBindingSource.DataMember = "CustomizeDepartmentDetailReport";
            this.CustomizeDepartmentDetailReportBindingSource.DataSource = this.posDataSet;
            // 
            // customizeReport
            // 
            this.customizeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "ECDRDataSet";
            reportDataSource2.Value = this.ExtraFilterCustomizeDepartmentReportBindingSource;
            this.customizeReport.LocalReport.DataSources.Add(reportDataSource2);
            this.customizeReport.LocalReport.ReportEmbeddedResource = "POSReports.ExtraFilterCustomizeDepartmentReport.rdlc";
            this.customizeReport.Location = new System.Drawing.Point(0, 129);
            this.customizeReport.Name = "customizeReport";
            this.customizeReport.Size = new System.Drawing.Size(929, 406);
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
            this.cboReportType.Location = new System.Drawing.Point(99, 3);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(134, 24);
            this.cboReportType.TabIndex = 1;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
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
            this.label2.Size = new System.Drawing.Size(591, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "BÁO CÁO HỖN HỢP  - TÌNH HÌNH TỪNG MẶT HÀNG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(99, 27);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(134, 23);
            this.dtpFromDate.TabIndex = 4;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(295, 27);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(162, 23);
            this.dtpToDate.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(750, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(147, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tạo báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Từ ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "đến ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cboSortOrder
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboSortOrder, 2);
            this.cboSortOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortOrder.Enabled = false;
            this.cboSortOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSortOrder.FormattingEnabled = true;
            this.cboSortOrder.Items.AddRange(new object[] {
            "Tất cả",
            "Chọn lọc"});
            this.cboSortOrder.Location = new System.Drawing.Point(239, 3);
            this.cboSortOrder.Name = "cboSortOrder";
            this.cboSortOrder.Size = new System.Drawing.Size(218, 24);
            this.cboSortOrder.TabIndex = 12;
            this.cboSortOrder.SelectedIndexChanged += new System.EventHandler(this.cboSortOrder_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.16667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
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
            this.tableLayoutPanel1.Controls.Add(this.cboDepartments, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtColorFilter, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtResult, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSizeFilter, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPrdFilter, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboTypes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(929, 100);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(494, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 24);
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
            this.cboIsolatedBy.Location = new System.Drawing.Point(530, 3);
            this.cboIsolatedBy.Name = "cboIsolatedBy";
            this.cboIsolatedBy.Size = new System.Drawing.Size(214, 24);
            this.cboIsolatedBy.TabIndex = 16;
            this.cboIsolatedBy.SelectedIndexChanged += new System.EventHandler(this.cboIsolatedBy_SelectedIndexChanged);
            // 
            // cboDepartments
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDepartments, 2);
            this.cboDepartments.DataSource = this.departmentBindingSource1;
            this.cboDepartments.DisplayMember = "DEPARTMENT_NAME";
            this.cboDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartments.Enabled = false;
            this.cboDepartments.FormattingEnabled = true;
            this.cboDepartments.Location = new System.Drawing.Point(530, 27);
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
            // txtColorFilter
            // 
            this.txtColorFilter.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorFilter.Location = new System.Drawing.Point(750, 51);
            this.txtColorFilter.Name = "txtColorFilter";
            this.txtColorFilter.Size = new System.Drawing.Size(164, 23);
            this.txtColorFilter.TabIndex = 22;
            this.txtColorFilter.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Control;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtResult, 7);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(99, 78);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(827, 20);
            this.txtResult.TabIndex = 23;
            // 
            // txtSizeFilter
            // 
            this.txtSizeFilter.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizeFilter.Location = new System.Drawing.Point(530, 51);
            this.txtSizeFilter.Name = "txtSizeFilter";
            this.txtSizeFilter.Size = new System.Drawing.Size(162, 23);
            this.txtSizeFilter.TabIndex = 21;
            this.txtSizeFilter.TextChanged += new System.EventHandler(this.txtSizeFilter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(486, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 27);
            this.label6.TabIndex = 25;
            this.label6.Text = "K.cỡ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(707, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 27);
            this.label8.TabIndex = 26;
            this.label8.Text = "Màu";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(36, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Lọc theo:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrdFilter
            // 
            this.txtPrdFilter.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrdFilter.Location = new System.Drawing.Point(295, 51);
            this.txtPrdFilter.Name = "txtPrdFilter";
            this.txtPrdFilter.Size = new System.Drawing.Size(162, 23);
            this.txtPrdFilter.TabIndex = 20;
            this.txtPrdFilter.TextChanged += new System.EventHandler(this.txtPrdFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 27);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTypes
            // 
            this.cboTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTypes.DisplayMember = "TYPE_NAME";
            this.cboTypes.DropDownWidth = 200;
            this.cboTypes.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTypes.FormattingEnabled = true;
            this.cboTypes.Location = new System.Drawing.Point(99, 51);
            this.cboTypes.Name = "cboTypes";
            this.cboTypes.Size = new System.Drawing.Size(134, 24);
            this.cboTypes.TabIndex = 28;
            this.cboTypes.ValueMember = "TYPE_NAME";
            this.cboTypes.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 27);
            this.label10.TabIndex = 29;
            this.label10.Text = "Chủng loại:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // producttypeBindingSource
            // 
            this.producttypeBindingSource.DataMember = "product_type";
            this.producttypeBindingSource.DataSource = this.posDataSet;
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
            // ExtraCustomizeDepartmentColorReportTableAdapter
            // 
            this.ExtraCustomizeDepartmentColorReportTableAdapter.ClearBeforeFill = true;
            // 
            // ExtraCustomizeDepartmentSizeReportTableAdapter
            // 
            this.ExtraCustomizeDepartmentSizeReportTableAdapter.ClearBeforeFill = true;
            // 
            // ExtraFilterCustomizeDepartmentReportTableAdapter
            // 
            this.ExtraFilterCustomizeDepartmentReportTableAdapter.ClearBeforeFill = true;
            // 
            // product_typeTableAdapter
            // 
            this.product_typeTableAdapter.ClearBeforeFill = true;
            // 
            // ExtraFilterCustomizeDepartmentReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 558);
            this.Controls.Add(this.customizeReport);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Name = "ExtraFilterCustomizeDepartmentReportViewer";
            this.Text = "CustomizeReportViewer";
            this.Load += new System.EventHandler(this.CustomizeReportViewer_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.customizeReport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ExtraFilterCustomizeDepartmentReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentColorReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCustomizeDepartmentSizeReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentDetailReportBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomizeDepartmentReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSortOrder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private POSReports.posDataSetTableAdapters.departmentTableAdapter departmentTableAdapter1;
        private System.Windows.Forms.BindingSource DepartmentBindingSource;
        private System.Windows.Forms.BindingSource CustomizeDepartmentReportBindingSource;
        private POSReports.posDataSetTableAdapters.CustomizeDepartmentReportTableAdapter CustomizeDepartmentReportTableAdapter;
        private System.Windows.Forms.BindingSource CustomizeDepartmentDetailReportBindingSource;
        private POSReports.posDataSetTableAdapters.CustomizeDepartmentDetailReportTableAdapter CustomizeDepartmentDetailReportTableAdapter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboIsolatedBy;
        private System.Windows.Forms.BindingSource ExtraCustomizeDepartmentReportBindingSource;
        private POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentReportTableAdapter ExtraCustomizeDepartmentReportTableAdapter;
        private System.Windows.Forms.ComboBox cboDepartments;
        private System.Windows.Forms.BindingSource departmentBindingSource1;
        private System.Windows.Forms.BindingSource ExtraCustomizeDepartmentColorReportBindingSource;
        private POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentColorReportTableAdapter ExtraCustomizeDepartmentColorReportTableAdapter;
        private System.Windows.Forms.BindingSource ExtraCustomizeDepartmentSizeReportBindingSource;
        private POSReports.posDataSetTableAdapters.ExtraCustomizeDepartmentSizeReportTableAdapter ExtraCustomizeDepartmentSizeReportTableAdapter;
        private System.Windows.Forms.TextBox txtColorFilter;
        private System.Windows.Forms.TextBox txtPrdFilter;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtSizeFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource ExtraFilterCustomizeDepartmentReportBindingSource;
        private POSReports.posDataSetTableAdapters.ExtraFilterCustomizeDepartmentReportTableAdapter ExtraFilterCustomizeDepartmentReportTableAdapter;
        private System.Windows.Forms.ComboBox cboTypes;
        private System.Windows.Forms.BindingSource producttypeBindingSource;
        private POSReports.posDataSetTableAdapters.product_typeTableAdapter product_typeTableAdapter;
        private System.Windows.Forms.Label label10;

    }
}