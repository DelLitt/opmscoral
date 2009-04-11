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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource57 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource58 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource59 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource60 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource61 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource62 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource63 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsSaleForm));
            this.ProductReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDetailIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productMasterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusiveKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsBill = new System.Windows.Forms.BindingSource(this.components);
            this.columnProductSearch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnProductId = new AppFrame.Controls.DataGridViewNumberTextBoxColumn();
            this.columnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new AppFrame.Controls.DataGridViewNumberTextBoxColumn();
            this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefPurchaseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.txtWorkingTime = new System.Windows.Forms.TextBox();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReturnOrder = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.txtTax = new AppFrame.Controls.NumberTextBox();
            this.txtCharge = new AppFrame.Controls.NumberTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPayment = new AppFrame.Controls.NumberTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new AppFrame.Controls.NumberTextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtBillDate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPOLookup = new System.Windows.Forms.Button();
            this.txtRefPurchaseOrder = new System.Windows.Forms.TextBox();
            this.txtRetPrice = new System.Windows.Forms.TextBox();
            this.txtRetQuantity = new System.Windows.Forms.TextBox();
            this.txtRetProductName = new System.Windows.Forms.TextBox();
            this.btnRetBarcodeLookup = new System.Windows.Forms.Button();
            this.txtRetBarCode = new System.Windows.Forms.TextBox();
            this.reportPurchaseOrder = new Microsoft.Reporting.WinForms.ReportViewer();
            this.printBillDialog = new System.Windows.Forms.PrintDialog();
            this.printBillDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.txtBarCodeShortcut = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.gdvBillDelRowShortcut = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.txtRetBarcodeShortcut = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.SaveOrderShortcut = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.QuickSaveOrderShortcut = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.dgvBillRow1 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.dgvBillRow2 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.dgvBillRow3 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.dgvBillRow4 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.dgvBillRow5 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.FindRetBarcode = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.FindRetOrder = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBindingSource)).BeginInit();
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
            // ReceiptBindingSource
            // 
            this.ReceiptBindingSource.DataSource = typeof(AppFrame.Model.Receipt);
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            this.dgvBill.AllowUserToResizeColumns = false;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.PowderBlue;
            this.dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            this.dgvBill.AutoGenerateColumns = false;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.dataGridViewTextBoxColumn2,
            this.quantityDataGridViewTextBoxColumn1,
            this.priceDataGridViewTextBoxColumn,
            this.Column1,
            this.noteDataGridViewTextBoxColumn,
            this.purchaseOrderDetailIdDataGridViewTextBoxColumn,
            this.productMasterDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.createDateDataGridViewTextBoxColumn,
            this.createIdDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.updateIdDataGridViewTextBoxColumn,
            this.exclusiveKeyDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn,
            this.purchaseOrderDataGridViewTextBoxColumn,
            this.taxDataGridViewTextBoxColumn});
            this.dgvBill.DataSource = this.bdsBill;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle42.Format = "##,##0";
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBill.DefaultCellStyle = dataGridViewCellStyle42;
            this.dgvBill.Location = new System.Drawing.Point(13, 240);
            this.dgvBill.MultiSelect = false;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.RowHeadersWidth = 30;
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.Black;
            this.dgvBill.RowsDefaultCellStyle = dataGridViewCellStyle43;
            this.dgvBill.Size = new System.Drawing.Size(985, 286);
            this.dgvBill.TabIndex = 20;
            this.dgvBill.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBill_RowPostPaint);
            this.dgvBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellEndEdit);
            this.dgvBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellClick);
            this.dgvBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellContentClick);
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product.ProductId";
            this.Product.Frozen = true;
            this.Product.HeaderText = "Mã vạch";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Product.ProductMaster.ProductName";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên hàng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.Width = 80;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Giá";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PurchaseOrderDetailPK.PurchaseOrderId";
            this.Column1.HeaderText = "Hóa đơn cũ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "Ghi chú";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.Width = 285;
            // 
            // purchaseOrderDetailIdDataGridViewTextBoxColumn
            // 
            this.purchaseOrderDetailIdDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderDetailId";
            this.purchaseOrderDetailIdDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderDetailId";
            this.purchaseOrderDetailIdDataGridViewTextBoxColumn.Name = "purchaseOrderDetailIdDataGridViewTextBoxColumn";
            this.purchaseOrderDetailIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productMasterDataGridViewTextBoxColumn
            // 
            this.productMasterDataGridViewTextBoxColumn.DataPropertyName = "ProductMaster";
            this.productMasterDataGridViewTextBoxColumn.HeaderText = "ProductMaster";
            this.productMasterDataGridViewTextBoxColumn.Name = "productMasterDataGridViewTextBoxColumn";
            this.productMasterDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PurchaseStatus";
            this.dataGridViewTextBoxColumn3.HeaderText = "PurchaseStatus";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PurchaseType";
            this.dataGridViewTextBoxColumn4.HeaderText = "PurchaseType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // createIdDataGridViewTextBoxColumn
            // 
            this.createIdDataGridViewTextBoxColumn.DataPropertyName = "CreateId";
            this.createIdDataGridViewTextBoxColumn.HeaderText = "CreateId";
            this.createIdDataGridViewTextBoxColumn.Name = "createIdDataGridViewTextBoxColumn";
            this.createIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            this.updateDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateIdDataGridViewTextBoxColumn
            // 
            this.updateIdDataGridViewTextBoxColumn.DataPropertyName = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.HeaderText = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.Name = "updateIdDataGridViewTextBoxColumn";
            this.updateIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // exclusiveKeyDataGridViewTextBoxColumn
            // 
            this.exclusiveKeyDataGridViewTextBoxColumn.DataPropertyName = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.HeaderText = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.Name = "exclusiveKeyDataGridViewTextBoxColumn";
            this.exclusiveKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // purchaseOrderDataGridViewTextBoxColumn
            // 
            this.purchaseOrderDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder";
            this.purchaseOrderDataGridViewTextBoxColumn.HeaderText = "PurchaseOrder";
            this.purchaseOrderDataGridViewTextBoxColumn.Name = "purchaseOrderDataGridViewTextBoxColumn";
            this.purchaseOrderDataGridViewTextBoxColumn.Visible = false;
            // 
            // taxDataGridViewTextBoxColumn
            // 
            this.taxDataGridViewTextBoxColumn.DataPropertyName = "Tax";
            this.taxDataGridViewTextBoxColumn.HeaderText = "Tax";
            this.taxDataGridViewTextBoxColumn.Name = "taxDataGridViewTextBoxColumn";
            this.taxDataGridViewTextBoxColumn.Visible = false;
            // 
            // bdsBill
            // 
            this.bdsBill.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailCollection);
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
            this.columnProductId.Width = 150;
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
            this.columnProductName.Width = 200;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.Format = "N0";
            dataGridViewCellStyle44.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle44;
            this.quantityDataGridViewTextBoxColumn.Frozen = true;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.MaxLength = 0;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.quantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // columnPrice
            // 
            this.columnPrice.DataPropertyName = "Price";
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.Format = "N0";
            dataGridViewCellStyle45.NullValue = null;
            this.columnPrice.DefaultCellStyle = dataGridViewCellStyle45;
            this.columnPrice.Frozen = true;
            this.columnPrice.HeaderText = "Giá";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.ReadOnly = true;
            this.columnPrice.Width = 80;
            // 
            // RefPurchaseOrder
            // 
            this.RefPurchaseOrder.DataPropertyName = "PurchaseOrderDetailPK.PurchaseOrderId";
            this.RefPurchaseOrder.Frozen = true;
            this.RefPurchaseOrder.HeaderText = "Hoá đơn cũ";
            this.RefPurchaseOrder.Name = "RefPurchaseOrder";
            this.RefPurchaseOrder.Width = 120;
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Ghi chú";
            this.Note.MaxInputLength = 200;
            this.Note.Name = "Note";
            this.Note.Width = 200;
            // 
            // columnColor
            // 
            this.columnColor.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.columnColor.HeaderText = "Màu sắc";
            this.columnColor.Name = "columnColor";
            this.columnColor.ReadOnly = true;
            this.columnColor.Width = 150;
            // 
            // columnSize
            // 
            this.columnSize.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.columnSize.HeaderText = "Kích cỡ";
            this.columnSize.Name = "columnSize";
            this.columnSize.ReadOnly = true;
            this.columnSize.Width = 195;
            // 
            // columnType
            // 
            this.columnType.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            this.columnType.HeaderText = "Phân loại";
            this.columnType.Name = "columnType";
            this.columnType.ReadOnly = true;
            this.columnType.Visible = false;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepartment.Location = new System.Drawing.Point(830, 14);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(151, 15);
            this.txtDepartment.TabIndex = 22;
            this.txtDepartment.TabStop = false;
            this.txtDepartment.Text = "A Chảy";
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(84, 71);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(211, 22);
            this.txtEmployee.TabIndex = 1;
            this.txtEmployee.TabStop = false;
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtBillNumber.Location = new System.Drawing.Point(84, 45);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.ReadOnly = true;
            this.txtBillNumber.Size = new System.Drawing.Size(211, 22);
            this.txtBillNumber.TabIndex = 22;
            this.txtBillNumber.TabStop = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(761, 14);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(63, 14);
            this.lblDepartment.TabIndex = 23;
            this.lblDepartment.Text = "Cửa hàng:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(16, 76);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(65, 14);
            this.lblEmployee.TabIndex = 5;
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Location = new System.Drawing.Point(7, 48);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(74, 14);
            this.lblBillNumber.TabIndex = 6;
            this.lblBillNumber.Text = "Số hóa đơn:";
            // 
            // txtWorkingTime
            // 
            this.txtWorkingTime.Location = new System.Drawing.Point(677, 0);
            this.txtWorkingTime.Name = "txtWorkingTime";
            this.txtWorkingTime.ReadOnly = true;
            this.txtWorkingTime.Size = new System.Drawing.Size(114, 20);
            this.txtWorkingTime.TabIndex = 27;
            this.txtWorkingTime.TabStop = false;
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Location = new System.Drawing.Point(626, 4);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(44, 13);
            this.lblWorkingTime.TabIndex = 8;
            this.lblWorkingTime.Text = "Ca trực:";
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Location = new System.Drawing.Point(824, 5);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(86, 13);
            this.lblBillDate.TabIndex = 10;
            this.lblBillDate.Text = "Ngày phát hành:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(364, 23);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(81, 14);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "Tổng số tiền:";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(382, 91);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(63, 14);
            this.lblPayment.TabIndex = 17;
            this.lblPayment.Text = "Khách trả:";
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Location = new System.Drawing.Point(396, 127);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(49, 14);
            this.lblCharge.TabIndex = 18;
            this.lblCharge.Text = "Thối lại:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(913, 33);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 31);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(830, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(77, 31);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(12, 532);
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
            this.btnPrint.Location = new System.Drawing.Point(735, 33);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 31);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Lưu hoá đơn";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(84, 97);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(211, 22);
            this.txtCustomer.TabIndex = 24;
            this.txtCustomer.TabStop = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 100);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(69, 14);
            this.lblCustomer.TabIndex = 25;
            this.lblCustomer.Text = "Tên khách:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(122, 532);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(203, 532);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReturnOrder);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtEmployee);
            this.groupBox1.Controls.Add(this.lblEmployee);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.lblTax);
            this.groupBox1.Controls.Add(this.txtGoodsName);
            this.groupBox1.Controls.Add(this.txtTax);
            this.groupBox1.Controls.Add(this.lblDepartment);
            this.groupBox1.Controls.Add(this.txtCharge);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPayment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.lblPayment);
            this.groupBox1.Controls.Add(this.lblCharge);
            this.groupBox1.Controls.Add(this.lblBillNumber);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.txtBillNumber);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 155);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // btnReturnOrder
            // 
            this.btnReturnOrder.Location = new System.Drawing.Point(735, 73);
            this.btnReturnOrder.Name = "btnReturnOrder";
            this.btnReturnOrder.Size = new System.Drawing.Size(89, 33);
            this.btnReturnOrder.TabIndex = 52;
            this.btnReturnOrder.Text = "Trả hàng";
            this.btnReturnOrder.UseVisualStyleBackColor = true;
            this.btnReturnOrder.Visible = false;
            this.btnReturnOrder.Click += new System.EventHandler(this.btnReturnOrder_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(156, 127);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 18);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "Có hoá đơn tài chính";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 50;
            this.label2.Text = "Chiết khấu:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(65, 22);
            this.textBox1.TabIndex = 49;
            this.textBox1.TabStop = false;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(653, 15);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(33, 22);
            this.txtQuantity.TabIndex = 22;
            this.txtQuantity.TabStop = false;
            this.txtQuantity.Text = "1";
            this.txtQuantity.Visible = false;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(405, 53);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(40, 14);
            this.lblTax.TabIndex = 41;
            this.lblTax.Text = "Thuế:";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(653, 42);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.ReadOnly = true;
            this.txtGoodsName.Size = new System.Drawing.Size(33, 22);
            this.txtGoodsName.TabIndex = 43;
            this.txtGoodsName.TabStop = false;
            this.txtGoodsName.Visible = false;
            // 
            // txtTax
            // 
            this.txtTax.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Format = null;
            this.txtTax.Location = new System.Drawing.Point(451, 48);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(196, 30);
            this.txtTax.TabIndex = 40;
            this.txtTax.TabStop = false;
            this.txtTax.Text = "0";
            // 
            // txtCharge
            // 
            this.txtCharge.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharge.Format = null;
            this.txtCharge.Location = new System.Drawing.Point(451, 114);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ReadOnly = true;
            this.txtCharge.Size = new System.Drawing.Size(196, 30);
            this.txtCharge.TabIndex = 39;
            this.txtCharge.TabStop = false;
            this.txtCharge.TextChanged += new System.EventHandler(this.txtCharge_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Format = null;
            this.txtPayment.Location = new System.Drawing.Point(451, 81);
            this.txtPayment.MaxLength = 10;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(196, 30);
            this.txtPayment.TabIndex = 5;
            this.txtPayment.Text = "0";
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 46;
            this.label1.Text = "Mã vạch:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Format = "###,###";
            this.txtTotalAmount.Location = new System.Drawing.Point(451, 15);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(196, 30);
            this.txtTotalAmount.TabIndex = 37;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Text = "0";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(84, 20);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(211, 22);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            // 
            // txtBillDate
            // 
            this.txtBillDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtBillDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillDate.Location = new System.Drawing.Point(928, 5);
            this.txtBillDate.Name = "txtBillDate";
            this.txtBillDate.Size = new System.Drawing.Size(73, 13);
            this.txtBillDate.TabIndex = 36;
            this.txtBillDate.TabStop = false;
            this.txtBillDate.Text = "12/12/2008";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Controls.Add(this.btnInput);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNote);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnPOLookup);
            this.groupBox2.Controls.Add(this.txtRefPurchaseOrder);
            this.groupBox2.Controls.Add(this.txtRetPrice);
            this.groupBox2.Controls.Add(this.txtRetQuantity);
            this.groupBox2.Controls.Add(this.txtRetProductName);
            this.groupBox2.Controls.Add(this.btnRetBarcodeLookup);
            this.groupBox2.Controls.Add(this.txtRetBarCode);
            this.groupBox2.Controls.Add(this.reportPurchaseOrder);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox2.Location = new System.Drawing.Point(12, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(986, 61);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trả hàng";
            // 
            // btnInput
            // 
            this.btnInput.BackColor = System.Drawing.SystemColors.Control;
            this.btnInput.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInput.Location = new System.Drawing.Point(808, 30);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(67, 23);
            this.btnInput.TabIndex = 16;
            this.btnInput.Text = "Nhập";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(695, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 14);
            this.label8.TabIndex = 65;
            this.label8.Text = "Ghi chú";
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Location = new System.Drawing.Point(698, 31);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(104, 22);
            this.txtNote.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 14);
            this.label7.TabIndex = 63;
            this.label7.Text = "Hoá đơn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 14);
            this.label6.TabIndex = 62;
            this.label6.Text = "Giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 61;
            this.label5.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 60;
            this.label4.Text = "Tên hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 59;
            this.label3.Text = "Mã vạch";
            // 
            // btnPOLookup
            // 
            this.btnPOLookup.BackColor = System.Drawing.SystemColors.Control;
            this.btnPOLookup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPOLookup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPOLookup.Location = new System.Drawing.Point(665, 31);
            this.btnPOLookup.Name = "btnPOLookup";
            this.btnPOLookup.Size = new System.Drawing.Size(27, 23);
            this.btnPOLookup.TabIndex = 14;
            this.btnPOLookup.Text = "...";
            this.btnPOLookup.UseVisualStyleBackColor = false;
            this.btnPOLookup.Click += new System.EventHandler(this.btnPOLookup_Click);
            // 
            // txtRefPurchaseOrder
            // 
            this.txtRefPurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefPurchaseOrder.Location = new System.Drawing.Point(548, 31);
            this.txtRefPurchaseOrder.MaxLength = 15;
            this.txtRefPurchaseOrder.Name = "txtRefPurchaseOrder";
            this.txtRefPurchaseOrder.Size = new System.Drawing.Size(110, 22);
            this.txtRefPurchaseOrder.TabIndex = 13;
            // 
            // txtRetPrice
            // 
            this.txtRetPrice.BackColor = System.Drawing.SystemColors.Control;
            this.txtRetPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetPrice.Location = new System.Drawing.Point(462, 31);
            this.txtRetPrice.Name = "txtRetPrice";
            this.txtRetPrice.ReadOnly = true;
            this.txtRetPrice.Size = new System.Drawing.Size(78, 22);
            this.txtRetPrice.TabIndex = 12;
            this.txtRetPrice.TextChanged += new System.EventHandler(this.txtRetPrice_TextChanged);
            this.txtRetPrice.Leave += new System.EventHandler(this.txtRetPrice_Leave);
            this.txtRetPrice.Enter += new System.EventHandler(this.txtRetPrice_Enter);
            // 
            // txtRetQuantity
            // 
            this.txtRetQuantity.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRetQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetQuantity.Location = new System.Drawing.Point(381, 31);
            this.txtRetQuantity.Name = "txtRetQuantity";
            this.txtRetQuantity.ReadOnly = true;
            this.txtRetQuantity.Size = new System.Drawing.Size(78, 22);
            this.txtRetQuantity.TabIndex = 55;
            this.txtRetQuantity.TabStop = false;
            this.txtRetQuantity.Text = "1";
            this.txtRetQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRetProductName
            // 
            this.txtRetProductName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRetProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetProductName.Location = new System.Drawing.Point(183, 31);
            this.txtRetProductName.Name = "txtRetProductName";
            this.txtRetProductName.ReadOnly = true;
            this.txtRetProductName.Size = new System.Drawing.Size(188, 22);
            this.txtRetProductName.TabIndex = 54;
            this.txtRetProductName.TabStop = false;
            // 
            // btnRetBarcodeLookup
            // 
            this.btnRetBarcodeLookup.BackColor = System.Drawing.SystemColors.Control;
            this.btnRetBarcodeLookup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetBarcodeLookup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRetBarcodeLookup.Location = new System.Drawing.Point(34, 30);
            this.btnRetBarcodeLookup.Name = "btnRetBarcodeLookup";
            this.btnRetBarcodeLookup.Size = new System.Drawing.Size(37, 23);
            this.btnRetBarcodeLookup.TabIndex = 10;
            this.btnRetBarcodeLookup.Text = "...";
            this.btnRetBarcodeLookup.UseVisualStyleBackColor = false;
            this.btnRetBarcodeLookup.Click += new System.EventHandler(this.btnRetBarcodeLookup_Click);
            // 
            // txtRetBarCode
            // 
            this.txtRetBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetBarCode.Location = new System.Drawing.Point(77, 31);
            this.txtRetBarCode.Name = "txtRetBarCode";
            this.txtRetBarCode.Size = new System.Drawing.Size(100, 22);
            this.txtRetBarCode.TabIndex = 11;
            this.txtRetBarCode.TextChanged += new System.EventHandler(this.txtRetBarCode_TextChanged);
            this.txtRetBarCode.Leave += new System.EventHandler(this.txtRetBarCode_Leave);
            this.txtRetBarCode.Enter += new System.EventHandler(this.txtRetBarCode_Enter);
            // 
            // reportPurchaseOrder
            // 
            reportDataSource57.Name = "AppFrame_Collection_ProductReportCollection";
            reportDataSource57.Value = this.ProductReportCollectionBindingSource;
            reportDataSource58.Name = "AppFrame_Collection_PurchaseOrderDetailReportCollection";
            reportDataSource58.Value = this.PurchaseOrderDetailReportCollectionBindingSource;
            reportDataSource59.Name = "AppFrame_Collection_PurchaseOrderDetailCollection";
            reportDataSource59.Value = this.PurchaseOrderDetailCollectionBindingSource;
            reportDataSource60.Name = "AppFrame_Model_PurchaseOrderDetail";
            reportDataSource60.Value = this.PurchaseOrderDetailBindingSource;
            reportDataSource61.Name = "AppFrame_Model_Department";
            reportDataSource61.Value = this.DepartmentBindingSource;
            reportDataSource62.Name = "AppFrame_Model_PurchaseOrder";
            reportDataSource62.Value = this.PurchaseOrderBindingSource;
            reportDataSource63.Name = "AppFrame_Model_Receipt";
            reportDataSource63.Value = this.ReceiptBindingSource;
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource57);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource58);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource59);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource60);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource61);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource62);
            this.reportPurchaseOrder.LocalReport.DataSources.Add(reportDataSource63);
            this.reportPurchaseOrder.LocalReport.ReportEmbeddedResource = "AppFrameClient.Report.PurchaseOrder.rdlc";
            this.reportPurchaseOrder.Location = new System.Drawing.Point(357, 532);
            this.reportPurchaseOrder.Margin = new System.Windows.Forms.Padding(0);
            this.reportPurchaseOrder.Name = "reportPurchaseOrder";
            this.reportPurchaseOrder.Size = new System.Drawing.Size(58, 33);
            this.reportPurchaseOrder.TabIndex = 37;
            this.reportPurchaseOrder.TabStop = false;
            this.reportPurchaseOrder.Visible = false;
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
            // txtBarCodeShortcut
            // 
            this.txtBarCodeShortcut.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.txtBarCodeShortcut.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // gdvBillDelRowShortcut
            // 
            this.gdvBillDelRowShortcut.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.gdvBillDelRowShortcut.Pressed += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // txtRetBarcodeShortcut
            // 
            this.txtRetBarcodeShortcut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.txtRetBarcodeShortcut.Pressed += new System.EventHandler(this.txtRetBarcodeShortcut_Pressed);
            // 
            // SaveOrderShortcut
            // 
            this.SaveOrderShortcut.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.SaveOrderShortcut.Pressed += new System.EventHandler(this.SaveOrderShortcut_Pressed);
            // 
            // QuickSaveOrderShortcut
            // 
            this.QuickSaveOrderShortcut.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.QuickSaveOrderShortcut.Pressed += new System.EventHandler(this.QuickSaveOrderShortcut_Pressed);
            // 
            // dgvBillRow1
            // 
            this.dgvBillRow1.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
            this.dgvBillRow1.Pressed += new System.EventHandler(this.dgvBillRow1_Pressed);
            // 
            // dgvBillRow2
            // 
            this.dgvBillRow2.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
            this.dgvBillRow2.Pressed += new System.EventHandler(this.dgvBillRow2_Pressed);
            // 
            // dgvBillRow3
            // 
            this.dgvBillRow3.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
            this.dgvBillRow3.Pressed += new System.EventHandler(this.dgvBillRow3_Pressed);
            // 
            // dgvBillRow4
            // 
            this.dgvBillRow4.Shortcut = System.Windows.Forms.Shortcut.Ctrl4;
            this.dgvBillRow4.Pressed += new System.EventHandler(this.dgvBillRow4_Pressed);
            // 
            // dgvBillRow5
            // 
            this.dgvBillRow5.Shortcut = System.Windows.Forms.Shortcut.Ctrl5;
            this.dgvBillRow5.Pressed += new System.EventHandler(this.dgvBillRow5_Pressed);
            // 
            // FindRetBarcode
            // 
            this.FindRetBarcode.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.FindRetBarcode.Pressed += new System.EventHandler(this.FindRetBarcode_Pressed);
            // 
            // FindRetOrder
            // 
            this.FindRetOrder.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.FindRetOrder.Pressed += new System.EventHandler(this.FindRetOrder_Pressed);
            // 
            // GoodsSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 567);
            this.Controls.Add(this.txtBillDate);
            this.Controls.Add(this.lblBillDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblWorkingTime);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtWorkingTime);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvBill);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Button btnClose;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtQuantity;
        private Microsoft.Reporting.WinForms.ReportViewer reportPurchaseOrder;
        private System.Windows.Forms.BindingSource ProductReportCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailReportCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailBindingSource;
        private System.Windows.Forms.BindingSource DepartmentBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderBindingSource;
        private AppFrame.Controls.HotKey.SystemHotkey txtBarCodeShortcut;
        private AppFrame.Controls.HotKey.SystemHotkey gdvBillDelRowShortcut;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource ReceiptBindingSource;
        private System.Windows.Forms.Button btnReturnOrder;
        private System.Windows.Forms.TextBox txtRetQuantity;
        private System.Windows.Forms.TextBox txtRetProductName;
        private System.Windows.Forms.Button btnRetBarcodeLookup;
        private System.Windows.Forms.TextBox txtRetBarCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPOLookup;
        private System.Windows.Forms.TextBox txtRefPurchaseOrder;
        private System.Windows.Forms.TextBox txtRetPrice;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNote;
        private AppFrame.Controls.HotKey.SystemHotkey txtRetBarcodeShortcut;
        private System.Windows.Forms.DataGridViewButtonColumn columnProductSearch;
        private AppFrame.Controls.DataGridViewNumberTextBoxColumn columnProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProductName;
        private AppFrame.Controls.DataGridViewNumberTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefPurchaseOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIdDataGridViewTextBoxColumn;
        private AppFrame.Controls.HotKey.SystemHotkey SaveOrderShortcut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderDetailIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productMasterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusiveKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxDataGridViewTextBoxColumn;
        private AppFrame.Controls.HotKey.SystemHotkey QuickSaveOrderShortcut;
        private AppFrame.Controls.HotKey.SystemHotkey dgvBillRow1;
        private AppFrame.Controls.HotKey.SystemHotkey dgvBillRow2;
        private AppFrame.Controls.HotKey.SystemHotkey dgvBillRow3;
        private AppFrame.Controls.HotKey.SystemHotkey dgvBillRow4;
        private AppFrame.Controls.HotKey.SystemHotkey dgvBillRow5;
        private AppFrame.Controls.HotKey.SystemHotkey FindRetBarcode;
        private AppFrame.Controls.HotKey.SystemHotkey FindRetOrder;
    }
}