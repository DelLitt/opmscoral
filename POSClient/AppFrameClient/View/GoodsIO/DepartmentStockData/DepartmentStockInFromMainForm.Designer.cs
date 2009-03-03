namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentStockInFromMainForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtStockInId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSumValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDexcription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDeptStockIn = new System.Windows.Forms.DataGridView();
            this.SearchCreate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnProductId = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnProductName = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnColor = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnSize = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onStorePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxMenuDept = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCreateDupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsStockIn = new System.Windows.Forms.BindingSource(this.components);
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.bdsDept = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAndExport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSumProduct = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).BeginInit();
            this.ctxMenuDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDept)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(637, 457);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 73;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtStockInId
            // 
            this.txtStockInId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockInId.Location = new System.Drawing.Point(100, 45);
            this.txtStockInId.Name = "txtStockInId";
            this.txtStockInId.ReadOnly = true;
            this.txtStockInId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStockInId.Size = new System.Drawing.Size(122, 22);
            this.txtStockInId.TabIndex = 71;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(563, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 72;
            this.label3.Text = "Mã xuất hàng";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.Location = new System.Drawing.Point(506, 457);
            this.numericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown.Size = new System.Drawing.Size(51, 22);
            this.numericUpDown.TabIndex = 69;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 489);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 68;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(425, 457);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 67;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDate.Location = new System.Drawing.Point(788, 45);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(200, 22);
            this.dtpImportDate.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(708, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 14);
            this.label8.TabIndex = 65;
            this.label8.Text = "Ngày nhập:";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(9, 429);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 23);
            this.button6.TabIndex = 64;
            this.button6.Text = "Tạo mã vạch";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(377, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 19);
            this.label7.TabIndex = 63;
            this.label7.Text = "XUẤT HÀNG HÓA";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(9, 457);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 62;
            this.button4.Text = "Giúp đỡ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(681, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 61;
            this.label6.Text = "Tổng giá trị";
            // 
            // txtSumValue
            // 
            this.txtSumValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumValue.Location = new System.Drawing.Point(757, 430);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.ReadOnly = true;
            this.txtSumValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumValue.Size = new System.Drawing.Size(231, 22);
            this.txtSumValue.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 14);
            this.label5.TabIndex = 59;
            this.label5.Text = "Chi tiết lô hàng";
            // 
            // txtDexcription
            // 
            this.txtDexcription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDexcription.Location = new System.Drawing.Point(100, 70);
            this.txtDexcription.Name = "txtDexcription";
            this.txtDexcription.Size = new System.Drawing.Size(888, 22);
            this.txtDexcription.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "Diễn tả ";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(344, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(913, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDeptStockIn
            // 
            this.dgvDeptStockIn.AllowUserToAddRows = false;
            this.dgvDeptStockIn.AutoGenerateColumns = false;
            this.dgvDeptStockIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SearchCreate,
            this.columnProductId,
            this.columnProductName,
            this.columnColor,
            this.columnSize,
            this.quantityDataGridViewTextBoxColumn,
            this.StockQuantity,
            this.onStorePriceDataGridViewTextBoxColumn,
            this.sellPriceDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn,
            this.Product,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvDeptStockIn.ContextMenuStrip = this.ctxMenuDept;
            this.dgvDeptStockIn.DataSource = this.bdsStockIn;
            this.dgvDeptStockIn.Location = new System.Drawing.Point(9, 114);
            this.dgvDeptStockIn.MultiSelect = false;
            this.dgvDeptStockIn.Name = "dgvDeptStockIn";
            this.dgvDeptStockIn.Size = new System.Drawing.Size(979, 310);
            this.dgvDeptStockIn.TabIndex = 53;
            this.dgvDeptStockIn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptStockIn_CellEndEdit);
            this.dgvDeptStockIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptStockIn_CellClick);
            this.dgvDeptStockIn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDeptStockIn_EditingControlShowing);
            // 
            // SearchCreate
            // 
            this.SearchCreate.HeaderText = "......";
            this.SearchCreate.Name = "SearchCreate";
            this.SearchCreate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchCreate.Text = "......";
            this.SearchCreate.ToolTipText = "Tìm mặt hàng /Tạo mặt hàng mới";
            this.SearchCreate.UseColumnTextForButtonValue = true;
            this.SearchCreate.Width = 50;
            // 
            // columnProductId
            // 
            this.columnProductId.DataPropertyName = "Product.ProductMaster.ProductMasterId";
            this.columnProductId.HeaderText = "Mã sản phẩm";
            this.columnProductId.Name = "columnProductId";
            this.columnProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnProductName
            // 
            this.columnProductName.DataPropertyName = "Product.ProductMaster.ProductName";
            this.columnProductName.HeaderText = "Tên sản phẩm";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnProductName.Width = 200;
            // 
            // columnColor
            // 
            this.columnColor.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.columnColor.HeaderText = "Màu sắc";
            this.columnColor.Name = "columnColor";
            this.columnColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnSize
            // 
            this.columnSize.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.columnSize.HeaderText = "Kích cỡ";
            this.columnSize.Name = "columnSize";
            this.columnSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // StockQuantity
            // 
            this.StockQuantity.DataPropertyName = "StockQuantity";
            this.StockQuantity.HeaderText = "Tồn kho";
            this.StockQuantity.Name = "StockQuantity";
            this.StockQuantity.ReadOnly = true;
            // 
            // onStorePriceDataGridViewTextBoxColumn
            // 
            this.onStorePriceDataGridViewTextBoxColumn.HeaderText = "Giá nhập kho";
            this.onStorePriceDataGridViewTextBoxColumn.Name = "onStorePriceDataGridViewTextBoxColumn";
            this.onStorePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.onStorePriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.onStorePriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // sellPriceDataGridViewTextBoxColumn
            // 
            this.sellPriceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.sellPriceDataGridViewTextBoxColumn.HeaderText = "Giá bán";
            this.sellPriceDataGridViewTextBoxColumn.Name = "sellPriceDataGridViewTextBoxColumn";
            this.sellPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product.ProductMaster.Country.CountryName";
            this.Product.HeaderText = "Xuất xứ";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product.ProductMaster.Manufacturer.ManufacturerName";
            this.Column1.HeaderText = "Sản xuất";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Product.ProductMaster.Packager.PackagerName";
            this.Column2.HeaderText = "Đóng gói";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Product.ProductMaster.Distributor.DistributorName";
            this.Column3.HeaderText = "Phân phối";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // ctxMenuDept
            // 
            this.ctxMenuDept.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateDupItem,
            this.mnuCreateNewItem});
            this.ctxMenuDept.Name = "ctxMenuDept";
            this.ctxMenuDept.Size = new System.Drawing.Size(290, 48);
            this.ctxMenuDept.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuDept_Opening);
            // 
            // mnuCreateDupItem
            // 
            this.mnuCreateDupItem.Name = "mnuCreateDupItem";
            this.mnuCreateDupItem.Size = new System.Drawing.Size(289, 22);
            this.mnuCreateDupItem.Text = "Tạo dòng mới với nội dung từ dòng hiện tại";
            this.mnuCreateDupItem.Click += new System.EventHandler(this.nhToolStripMenuItem_Click);
            // 
            // mnuCreateNewItem
            // 
            this.mnuCreateNewItem.Name = "mnuCreateNewItem";
            this.mnuCreateNewItem.Size = new System.Drawing.Size(289, 22);
            this.mnuCreateNewItem.Text = "Tạo dòng mới với nội dung mới hoàn toàn";
            this.mnuCreateNewItem.Click += new System.EventHandler(this.mnuCreateNewItem_Click);
            // 
            // bdsStockIn
            // 
            this.bdsStockIn.DataSource = typeof(AppFrame.Collection.DepartmentStockInDetailCollection);
            // 
            // cbbDept
            // 
            this.cbbDept.DataSource = this.bdsDept;
            this.cbbDept.DisplayMember = "NameAddress";
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(296, 46);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(409, 21);
            this.cbbDept.TabIndex = 76;
            // 
            // bdsDept
            // 
            this.bdsDept.DataSource = typeof(AppFrame.Model.Department);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 75;
            this.label1.Text = "Cửa hàng";
            // 
            // btnSaveAndExport
            // 
            this.btnSaveAndExport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndExport.Location = new System.Drawing.Point(227, 457);
            this.btnSaveAndExport.Name = "btnSaveAndExport";
            this.btnSaveAndExport.Size = new System.Drawing.Size(111, 23);
            this.btnSaveAndExport.TabIndex = 77;
            this.btnSaveAndExport.Text = "Lưu và xuất file";
            this.btnSaveAndExport.UseVisualStyleBackColor = true;
            this.btnSaveAndExport.Click += new System.EventHandler(this.btnSaveAndExport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(368, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 79;
            this.label4.Text = "Tổng sản phẩm";
            // 
            // txtSumProduct
            // 
            this.txtSumProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumProduct.Location = new System.Drawing.Point(466, 430);
            this.txtSumProduct.Name = "txtSumProduct";
            this.txtSumProduct.ReadOnly = true;
            this.txtSumProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumProduct.Size = new System.Drawing.Size(209, 22);
            this.txtSumProduct.TabIndex = 78;
            // 
            // DepartmentStockInFromMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 485);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSumProduct);
            this.Controls.Add(this.btnSaveAndExport);
            this.Controls.Add(this.cbbDept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStockInId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpImportDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDexcription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDeptStockIn);
            this.Name = "DepartmentStockInFromMainForm";
            this.Text = "Xuất hàng đến cửa hàng";
            this.Load += new System.EventHandler(this.DepartmentStockInExtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).EndInit();
            this.ctxMenuDept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtStockInId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DateTimePicker dtpImportDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSumValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDexcription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvDeptStockIn;
        private System.Windows.Forms.ContextMenuStrip ctxMenuDept;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateDupItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateNewItem;
        private System.Windows.Forms.BindingSource bdsStockIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbbDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsDept;
        private System.Windows.Forms.Button btnSaveAndExport;
        private System.Windows.Forms.DataGridViewButtonColumn SearchCreate;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductId;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductName;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnColor;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn onStorePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSumProduct;
    }
}