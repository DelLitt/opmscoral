namespace AppFrameClient.View.GoodsSale
{
    partial class GoodsSaleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsSaleForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource12 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ProductReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.columnProductSearch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnProductId = new AppFrame.Controls.DataGridViewNumberTextBoxColumn();
            this.columnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new AppFrame.Controls.DataGridViewNumberTextBoxColumn();
            this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsBill = new System.Windows.Forms.BindingSource(this.components);
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.txtWorkingTime = new System.Windows.Forms.TextBox();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBillDate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new AppFrame.Controls.NumberTextBox();
            this.txtCharge = new AppFrame.Controls.NumberTextBox();
            this.txtPayment = new AppFrame.Controls.NumberTextBox();
            this.txtTotalAmount = new AppFrame.Controls.NumberTextBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.printBillDialog = new System.Windows.Forms.PrintDialog();
            this.printBillDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.reportPurchaseOrder = new Microsoft.Reporting.WinForms.ReportViewer();
            this.systemHotkey1 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.systemHotkey2 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBill)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductReportCollectionBindingSource
            // 
            this.ProductReportCollectionBindingSource.DataSource = typeof(AppFrame.Collection.ProductReportCollection);
            // 
            // PurchaseOrderDetailReportCollectionBindingSource
            // 
            this.PurchaseOrderDetailReportCollectionBindingSource.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailReportCollection);
            // 
            // PurchaseOrderDetailCollectionBindingSource
            // 
            this.PurchaseOrderDetailCollectionBindingSource.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailCollection);
            // 
            // PurchaseOrderDetailBindingSource
            // 
            this.PurchaseOrderDetailBindingSource.DataSource = typeof(AppFrame.Model.PurchaseOrderDetail);
            // 
            // DepartmentBindingSource
            // 
            this.DepartmentBindingSource.DataSource = typeof(AppFrame.Model.Department);
            // 
            // PurchaseOrderBindingSource
            // 
            this.PurchaseOrderBindingSource.DataSource = typeof(AppFrame.Model.PurchaseOrder);
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            this.dgvBill.AllowUserToResizeColumns = false;
            this.dgvBill.AutoGenerateColumns = false;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnProductSearch,
            this.columnProductId,
            this.columnProductName,
            this.quantityDataGridViewTextBoxColumn,
            this.columnPrice,
            this.columnColor,
            this.columnSize,
            this.columnType});
            this.dgvBill.DataSource = this.bdsBill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "##,##0";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBill.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBill.Location = new System.Drawing.Point(1, 65);
            this.dgvBill.MultiSelect = false;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.Size = new System.Drawing.Size(974, 265);
            this.dgvBill.TabIndex = 2;
            this.dgvBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellEndEdit);
            this.dgvBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellClick);
            // 
            // columnProductSearch
            // 
            this.columnProductSearch.Frozen = true;
            this.columnProductSearch.HeaderText = "...";
            this.columnProductSearch.Name = "columnProductSearch";
            this.columnProductSearch.ReadOnly = true;
            this.columnProductSearch.Text = "...";
            this.columnProductSearch.ToolTipText = "...";
            this.columnProductSearch.UseColumnTextForButtonValue = true;
            this.columnProductSearch.Visible = false;
            this.columnProductSearch.Width = 30;
            // 
            // columnProductId
            // 
            this.columnProductId.DataPropertyName = "Product.ProductId";
            this.columnProductId.Frozen = true;
            this.columnProductId.HeaderText = "Mã vạch";
            this.columnProductId.MaxLength = 0;
            this.columnProductId.Name = "columnProductId";
            this.columnProductId.ReadOnly = true;
            this.columnProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnProductId.ToolTipText = "Nhấn F3 để tìm kiếm mã hàng";
            this.columnProductId.Width = 200;
            // 
            // columnProductName
            // 
            this.columnProductName.DataPropertyName = "Product.ProductMaster.ProductName";
            this.columnProductName.Frozen = true;
            this.columnProductName.HeaderText = "Tên hàng";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.ReadOnly = true;
            this.columnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductName.ToolTipText = "Nhấn F3 để tìm kiếm tên hàng";
            this.columnProductName.Width = 400;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.MaxLength = 0;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnPrice
            // 
            this.columnPrice.DataPropertyName = "Price";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.columnPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnPrice.HeaderText = "Giá";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.ReadOnly = true;
            this.columnPrice.Width = 200;
            // 
            // columnColor
            // 
            this.columnColor.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.columnColor.HeaderText = "Màu sắc";
            this.columnColor.Name = "columnColor";
            this.columnColor.ReadOnly = true;
            // 
            // columnSize
            // 
            this.columnSize.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.columnSize.HeaderText = "Kích cỡ";
            this.columnSize.Name = "columnSize";
            this.columnSize.ReadOnly = true;
            // 
            // columnType
            // 
            this.columnType.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            this.columnType.HeaderText = "Phân loại";
            this.columnType.Name = "columnType";
            this.columnType.ReadOnly = true;
            this.columnType.Visible = false;
            // 
            // bdsBill
            // 
            this.bdsBill.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailCollection);
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(84, 21);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(275, 22);
            this.txtDepartment.TabIndex = 22;
            this.txtDepartment.TabStop = false;
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(439, 21);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(219, 22);
            this.txtEmployee.TabIndex = 1;
            this.txtEmployee.TabStop = false;
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtBillNumber.Location = new System.Drawing.Point(84, 50);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.ReadOnly = true;
            this.txtBillNumber.Size = new System.Drawing.Size(274, 22);
            this.txtBillNumber.TabIndex = 22;
            this.txtBillNumber.TabStop = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(4, 24);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(63, 14);
            this.lblDepartment.TabIndex = 23;
            this.lblDepartment.Text = "Cửa hàng:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(368, 24);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(65, 14);
            this.lblEmployee.TabIndex = 5;
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Location = new System.Drawing.Point(4, 52);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(74, 14);
            this.lblBillNumber.TabIndex = 6;
            this.lblBillNumber.Text = "Số hóa đơn:";
            // 
            // txtWorkingTime
            // 
            this.txtWorkingTime.Location = new System.Drawing.Point(833, 21);
            this.txtWorkingTime.Name = "txtWorkingTime";
            this.txtWorkingTime.ReadOnly = true;
            this.txtWorkingTime.Size = new System.Drawing.Size(153, 22);
            this.txtWorkingTime.TabIndex = 27;
            this.txtWorkingTime.TabStop = false;
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Location = new System.Drawing.Point(776, 24);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(51, 14);
            this.lblWorkingTime.TabIndex = 8;
            this.lblWorkingTime.Text = "Ca trực:";
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Location = new System.Drawing.Point(729, 52);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(98, 14);
            this.lblBillDate.TabIndex = 10;
            this.lblBillDate.Text = "Ngày phát hành:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-5, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Chi tiết hóa đơn:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(688, 345);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(81, 14);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "Tổng số tiền:";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(371, 373);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(105, 14);
            this.lblPayment.TabIndex = 17;
            this.lblPayment.Text = "Số tiền khách trả:";
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Location = new System.Drawing.Point(720, 373);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(49, 14);
            this.lblCharge.TabIndex = 18;
            this.lblCharge.Text = "Thối lại:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(929, 531);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(501, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu hóa đơn";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(567, 531);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(12, 531);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(426, 531);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Lưu và In hóa đơn";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(439, 49);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(219, 22);
            this.txtCustomer.TabIndex = 24;
            this.txtCustomer.TabStop = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(364, 52);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(69, 14);
            this.lblCustomer.TabIndex = 25;
            this.lblCustomer.Text = "Tên khách:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 336);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(88, 336);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmployee);
            this.groupBox1.Controls.Add(this.lblEmployee);
            this.groupBox1.Controls.Add(this.lblDepartment);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.txtWorkingTime);
            this.groupBox1.Controls.Add(this.lblWorkingTime);
            this.groupBox1.Controls.Add(this.txtBillNumber);
            this.groupBox1.Controls.Add(this.lblBillNumber);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.txtBillDate);
            this.groupBox1.Controls.Add(this.lblBillDate);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(992, 80);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtBillDate
            // 
            this.txtBillDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtBillDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillDate.Location = new System.Drawing.Point(833, 52);
            this.txtBillDate.Name = "txtBillDate";
            this.txtBillDate.Size = new System.Drawing.Size(88, 15);
            this.txtBillDate.TabIndex = 36;
            this.txtBillDate.TabStop = false;
            this.txtBillDate.Text = "12/12/2008";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtGoodsName);
            this.groupBox2.Controls.Add(this.txtBarcode);
            this.groupBox2.Controls.Add(this.lblTax);
            this.groupBox2.Controls.Add(this.txtTax);
            this.groupBox2.Controls.Add(this.txtCharge);
            this.groupBox2.Controls.Add(this.txtPayment);
            this.groupBox2.Controls.Add(this.txtTotalAmount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.lblTotalAmount);
            this.groupBox2.Controls.Add(this.dgvBill);
            this.groupBox2.Controls.Add(this.lblPayment);
            this.groupBox2.Controls.Add(this.lblCharge);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(992, 399);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(833, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 44);
            this.button2.TabIndex = 99;
            this.button2.TabStop = false;
            this.button2.Text = "Nhập";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 50;
            this.label3.Text = "Số lượng";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(397, 22);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(79, 22);
            this.txtQuantity.TabIndex = 22;
            this.txtQuantity.TabStop = false;
            this.txtQuantity.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 48;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "Tên hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 46;
            this.label1.Text = "Mã vạch:";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(555, 22);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.ReadOnly = true;
            this.txtGoodsName.Size = new System.Drawing.Size(263, 22);
            this.txtGoodsName.TabIndex = 43;
            this.txtGoodsName.TabStop = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(79, 21);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(188, 22);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(436, 342);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(40, 14);
            this.lblTax.TabIndex = 41;
            this.lblTax.Text = "Thuế:";
            // 
            // txtTax
            // 
            this.txtTax.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Format = null;
            this.txtTax.Location = new System.Drawing.Point(482, 335);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(186, 30);
            this.txtTax.TabIndex = 40;
            this.txtTax.TabStop = false;
            // 
            // txtCharge
            // 
            this.txtCharge.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharge.Format = null;
            this.txtCharge.Location = new System.Drawing.Point(779, 364);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ReadOnly = true;
            this.txtCharge.Size = new System.Drawing.Size(196, 30);
            this.txtCharge.TabIndex = 39;
            this.txtCharge.TabStop = false;
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Format = null;
            this.txtPayment.Location = new System.Drawing.Point(482, 365);
            this.txtPayment.MaxLength = 10;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(186, 30);
            this.txtPayment.TabIndex = 3;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Format = "###,###";
            this.txtTotalAmount.Location = new System.Drawing.Point(779, 333);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(196, 30);
            this.txtTotalAmount.TabIndex = 37;
            this.txtTotalAmount.TabStop = false;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(370, 503);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 33;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Visible = false;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(451, 503);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 34;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(533, 503);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 35;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(616, 503);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 36;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Visible = false;
            // 
            // printBillDialog
            // 
            this.printBillDialog.Document = this.printBillDocument;
            this.printBillDialog.UseEXDialog = true;
            // 
            // printBillDocument
            // 
            this.printBillDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printBillDocument_PrintPage);
            this.printBillDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printBillDocument_EndPrint);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printBillDocument;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // reportPurchaseOrder
            // 
            reportDataSource7.Name = "AppFrame_Collection_ProductReportCollection";
            reportDataSource7.Value = this.ProductReportCollectionBindingSource;
            reportDataSource8.Name = "AppFrame_Collection_PurchaseOrderDetailReportCollection";
            reportDataSource8.Value = this.PurchaseOrderDetailReportCollectionBindingSource;
            reportDataSource9.Name = "AppFrame_Collection_PurchaseOrderDetailCollection";
            reportDataSource9.Value = this.PurchaseOrderDetailCollectionBindingSource;
            reportDataSource10.Name = "AppFrame_Model_PurchaseOrderDetail";
            reportDataSource10.Value = this.PurchaseOrderDetailBindingSource;
            reportDataSource11.Name = "AppFrame_Model_Department";
            reportDataSource11.Value = this.DepartmentBindingSource;
            reportDataSource12.Name = "AppFrame_Model_PurchaseOrder";
            reportDataSource12.Value = this.PurchaseOrderBindingSource;
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource7);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource8);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource9);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource10);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource11);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource12);
            this.reportPurchaseOrder.LocalReport.ReportEmbeddedResource = "AppFrameClient.Report.PurchaseOrder.rdlc";
            this.reportPurchaseOrder.Location = new System.Drawing.Point(175, 503);
            this.reportPurchaseOrder.Margin = new System.Windows.Forms.Padding(0);
            this.reportPurchaseOrder.Name = "reportPurchaseOrder";
            this.reportPurchaseOrder.Size = new System.Drawing.Size(104, 55);
            this.reportPurchaseOrder.TabIndex = 37;
            this.reportPurchaseOrder.Visible = false;
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // systemHotkey2
            // 
            this.systemHotkey2.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.systemHotkey2.Pressed += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // GoodsSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 567);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reportPurchaseOrder);
            this.Name = "GoodsSaleForm";
            this.Text = "Nhập hoá đơn bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GoodsSaleForm_Load);
            this.Shown += new System.EventHandler(this.GoodsSaleForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoodsSaleForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.TextBox txtWorkingTime;
        private System.Windows.Forms.Label lblWorkingTime;
        private System.Windows.Forms.Label lblBillDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.TextBox txtBillDate;



        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.BindingSource bdsBill;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn purchaseOrderDetailPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onStorePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseTypeDataGridViewTextBoxColumn;
        private AppFrame.Controls.NumberTextBox txtTax;
        private AppFrame.Controls.NumberTextBox txtCharge;
        private AppFrame.Controls.NumberTextBox txtPayment;
        private AppFrame.Controls.NumberTextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.PrintDialog printBillDialog;
        private System.Drawing.Printing.PrintDocument printBillDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private Microsoft.Reporting.WinForms.ReportViewer reportPurchaseOrder;
        private System.Windows.Forms.BindingSource ProductReportCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailReportCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailBindingSource;
        private System.Windows.Forms.BindingSource DepartmentBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderBindingSource;
        private AppFrame.Controls.HotKey.SystemHotkey systemHotkey1;
        private System.Windows.Forms.DataGridViewButtonColumn columnProductSearch;
        private AppFrame.Controls.DataGridViewNumberTextBoxColumn columnProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProductName;
        private AppFrame.Controls.DataGridViewNumberTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnType;
        private AppFrame.Controls.HotKey.SystemHotkey systemHotkey2;
    }
}