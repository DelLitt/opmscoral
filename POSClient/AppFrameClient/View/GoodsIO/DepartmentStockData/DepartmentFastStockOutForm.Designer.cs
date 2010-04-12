namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentFastStockOutForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bdsStockIn = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSumValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDeptStockIn = new System.Windows.Forms.DataGridView();
            this.SearchCreate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProducType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProductId = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnProductName = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnColor = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnSize = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Good = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unconfirm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboProductMasters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.lstColor = new System.Windows.Forms.ListBox();
            this.colorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstSize = new System.Windows.Forms.ListBox();
            this.sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSumProduct = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbbStockOutType = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartments = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoStockOut = new System.Windows.Forms.RadioButton();
            this.rdoFastStockOut = new System.Windows.Forms.RadioButton();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblInformation = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCommandDescription = new System.Windows.Forms.Label();
            this.rdoRetail = new System.Windows.Forms.RadioButton();
            this.rdoWholesale = new System.Windows.Forms.RadioButton();
            this.grpPriceKind = new System.Windows.Forms.GroupBox();
            this.ctxShortcuts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportByFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpPriceKind.SuspendLayout();
            this.ctxShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // bdsStockIn
            // 
            this.bdsStockIn.DataSource = typeof(AppFrame.Collection.DepartmentStockOutDetailCollection);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(266, 511);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(82, 75);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBarcode.Size = new System.Drawing.Size(204, 23);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 94;
            this.label3.Text = "Mã vạch";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 559);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(418, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(322, 21);
            this.label7.TabIndex = 85;
            this.label7.Text = "PHÂN PHỐI HÀNG HOÁ TRONG KHO ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(442, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 87;
            this.label8.Text = "Ngày nhập:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(11, 511);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Giúp đỡ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(562, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Tổng giá trị";
            this.label6.Visible = false;
            // 
            // txtSumValue
            // 
            this.txtSumValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumValue.Location = new System.Drawing.Point(638, 467);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.ReadOnly = true;
            this.txtSumValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumValue.Size = new System.Drawing.Size(173, 23);
            this.txtSumValue.TabIndex = 82;
            this.txtSumValue.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(185, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(736, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
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
            this.ProducType,
            this.columnProductId,
            this.columnProductName,
            this.columnColor,
            this.columnSize,
            this.quantity,
            this.Good,
            this.Damage,
            this.error,
            this.Lost,
            this.Unconfirm,
            this.Desc,
            this.delFlgDataGridViewTextBoxColumn,
            this.Product,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvDeptStockIn.DataSource = this.bdsStockIn;
            this.dgvDeptStockIn.Location = new System.Drawing.Point(11, 213);
            this.dgvDeptStockIn.Name = "dgvDeptStockIn";
            this.dgvDeptStockIn.Size = new System.Drawing.Size(800, 248);
            this.dgvDeptStockIn.TabIndex = 8;
            this.dgvDeptStockIn.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDeptStockIn_RowPostPaint);
            this.dgvDeptStockIn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptStockIn_CellEndEdit);
            this.dgvDeptStockIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptStockIn_CellClick);
            this.dgvDeptStockIn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDeptStockIn_KeyUp);
            // 
            // SearchCreate
            // 
            this.SearchCreate.HeaderText = "......";
            this.SearchCreate.Name = "SearchCreate";
            this.SearchCreate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchCreate.Text = "......";
            this.SearchCreate.ToolTipText = "Tìm mặt hàng /Tạo mặt hàng mới";
            this.SearchCreate.UseColumnTextForButtonValue = true;
            this.SearchCreate.Visible = false;
            this.SearchCreate.Width = 50;
            // 
            // ProducType
            // 
            this.ProducType.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ProducType.DefaultCellStyle = dataGridViewCellStyle8;
            this.ProducType.HeaderText = "Chủng loại";
            this.ProducType.Name = "ProducType";
            this.ProducType.ReadOnly = true;
            this.ProducType.Visible = false;
            // 
            // columnProductId
            // 
            this.columnProductId.DataPropertyName = "Product.ProductId";
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Silver;
            this.columnProductId.DefaultCellStyle = dataGridViewCellStyle9;
            this.columnProductId.HeaderText = "Mã vạch";
            this.columnProductId.Name = "columnProductId";
            this.columnProductId.ReadOnly = true;
            this.columnProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnProductName
            // 
            this.columnProductName.DataPropertyName = "Product.ProductMaster.ProductName";
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Silver;
            this.columnProductName.DefaultCellStyle = dataGridViewCellStyle10;
            this.columnProductName.HeaderText = "Tên sản phẩm";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.ReadOnly = true;
            this.columnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnProductName.Width = 200;
            // 
            // columnColor
            // 
            this.columnColor.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Silver;
            this.columnColor.DefaultCellStyle = dataGridViewCellStyle11;
            this.columnColor.HeaderText = "Màu sắc";
            this.columnColor.Name = "columnColor";
            this.columnColor.ReadOnly = true;
            this.columnColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnSize
            // 
            this.columnSize.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Silver;
            this.columnSize.DefaultCellStyle = dataGridViewCellStyle12;
            this.columnSize.HeaderText = "Kích cỡ";
            this.columnSize.Name = "columnSize";
            this.columnSize.ReadOnly = true;
            this.columnSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Silver;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle13;
            this.quantity.HeaderText = "Tồn";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.quantity.Width = 70;
            // 
            // Good
            // 
            this.Good.DataPropertyName = "GoodQuantity";
            this.Good.HeaderText = "SL xuất";
            this.Good.Name = "Good";
            this.Good.Width = 70;
            // 
            // Damage
            // 
            this.Damage.DataPropertyName = "ErrorQuantity";
            this.Damage.HeaderText = "Lỗi";
            this.Damage.Name = "Damage";
            this.Damage.Visible = false;
            this.Damage.Width = 70;
            // 
            // error
            // 
            this.error.DataPropertyName = "DamageQuantity";
            this.error.HeaderText = "Hư";
            this.error.Name = "error";
            this.error.Visible = false;
            this.error.Width = 70;
            // 
            // Lost
            // 
            this.Lost.DataPropertyName = "LostQuantity";
            this.Lost.HeaderText = "Mất";
            this.Lost.Name = "Lost";
            this.Lost.Visible = false;
            this.Lost.Width = 70;
            // 
            // Unconfirm
            // 
            this.Unconfirm.DataPropertyName = "UnconfirmQuantity";
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Silver;
            this.Unconfirm.DefaultCellStyle = dataGridViewCellStyle14;
            this.Unconfirm.HeaderText = "Không xác định";
            this.Unconfirm.Name = "Unconfirm";
            this.Unconfirm.Visible = false;
            this.Unconfirm.Width = 70;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Lý do";
            this.Desc.Name = "Desc";
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
            this.Product.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product.ProductMaster.Manufacturer.ManufacturerName";
            this.Column1.HeaderText = "Sản xuất";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Product.ProductMaster.Packager.PackagerName";
            this.Column2.HeaderText = "Đóng gói";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Product.ProductMaster.Distributor.DistributorName";
            this.Column3.HeaderText = "Phân phối";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // cboProductMasters
            // 
            this.cboProductMasters.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductMasters.FormattingEnabled = true;
            this.cboProductMasters.Location = new System.Drawing.Point(82, 104);
            this.cboProductMasters.Name = "cboProductMasters";
            this.cboProductMasters.Size = new System.Drawing.Size(204, 25);
            this.cboProductMasters.TabIndex = 3;
            this.cboProductMasters.SelectedIndexChanged += new System.EventHandler(this.cboProductMasters_SelectedIndexChanged);
            this.cboProductMasters.DropDown += new System.EventHandler(this.cboProductMasters_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 99;
            this.label1.Text = "Mặt hàng";
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInput.Location = new System.Drawing.Point(700, 75);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(111, 69);
            this.btnInput.TabIndex = 7;
            this.btnInput.Text = "Xác nhận";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // lstColor
            // 
            this.lstColor.DataSource = this.colorBindingSource;
            this.lstColor.DisplayMember = "ColorName";
            this.lstColor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstColor.FormattingEnabled = true;
            this.lstColor.Location = new System.Drawing.Point(354, 75);
            this.lstColor.Name = "lstColor";
            this.lstColor.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstColor.Size = new System.Drawing.Size(154, 69);
            this.lstColor.TabIndex = 4;
            // 
            // colorBindingSource
            // 
            this.colorBindingSource.DataSource = typeof(AppFrame.Model.ProductColor);
            // 
            // lstSize
            // 
            this.lstSize.DataSource = this.sizeBindingSource;
            this.lstSize.DisplayMember = "SizeName";
            this.lstSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSize.FormattingEnabled = true;
            this.lstSize.Location = new System.Drawing.Point(565, 75);
            this.lstSize.Name = "lstSize";
            this.lstSize.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSize.Size = new System.Drawing.Size(129, 69);
            this.lstSize.TabIndex = 5;
            // 
            // sizeBindingSource
            // 
            this.sizeBindingSource.DataSource = typeof(AppFrame.Model.ProductSize);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 105;
            this.label4.Text = "Màu sắc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(514, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 106;
            this.label10.Text = "Kích cỡ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(285, 470);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 16);
            this.label13.TabIndex = 112;
            this.label13.Text = "Tổng sản phẩm";
            // 
            // txtSumProduct
            // 
            this.txtSumProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumProduct.Location = new System.Drawing.Point(383, 467);
            this.txtSumProduct.Name = "txtSumProduct";
            this.txtSumProduct.ReadOnly = true;
            this.txtSumProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumProduct.Size = new System.Drawing.Size(173, 23);
            this.txtSumProduct.TabIndex = 111;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 114;
            this.label11.Text = "Lý do xuất";
            // 
            // cbbStockOutType
            // 
            this.cbbStockOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStockOutType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStockOutType.FormattingEnabled = true;
            this.cbbStockOutType.Location = new System.Drawing.Point(82, 134);
            this.cbbStockOutType.Name = "cbbStockOutType";
            this.cbbStockOutType.Size = new System.Drawing.Size(204, 25);
            this.cbbStockOutType.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(82, 164);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 23);
            this.btnReset.TabIndex = 115;
            this.btnReset.Text = "Tạo lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(354, 185);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(340, 24);
            this.cboDepartment.TabIndex = 116;
            // 
            // lblDepartments
            // 
            this.lblDepartments.AutoSize = true;
            this.lblDepartments.Location = new System.Drawing.Point(295, 188);
            this.lblDepartments.Name = "lblDepartments";
            this.lblDepartments.Size = new System.Drawing.Size(56, 16);
            this.lblDepartments.TabIndex = 117;
            this.lblDepartments.Text = "Nơi đến:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoStockOut);
            this.groupBox1.Controls.Add(this.rdoFastStockOut);
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 50);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phương thức";
            // 
            // rdoStockOut
            // 
            this.rdoStockOut.AutoSize = true;
            this.rdoStockOut.Location = new System.Drawing.Point(87, 21);
            this.rdoStockOut.Name = "rdoStockOut";
            this.rdoStockOut.Size = new System.Drawing.Size(92, 20);
            this.rdoStockOut.TabIndex = 119;
            this.rdoStockOut.TabStop = true;
            this.rdoStockOut.Text = "Xuất ra chợ";
            this.rdoStockOut.UseVisualStyleBackColor = true;
            this.rdoStockOut.CheckedChanged += new System.EventHandler(this.rdoStockOut_CheckedChanged);
            // 
            // rdoFastStockOut
            // 
            this.rdoFastStockOut.AutoSize = true;
            this.rdoFastStockOut.Location = new System.Drawing.Point(6, 21);
            this.rdoFastStockOut.Name = "rdoFastStockOut";
            this.rdoFastStockOut.Size = new System.Drawing.Size(77, 20);
            this.rdoFastStockOut.TabIndex = 118;
            this.rdoFastStockOut.TabStop = true;
            this.rdoFastStockOut.Text = "Xuất 142";
            this.rdoFastStockOut.UseVisualStyleBackColor = true;
            this.rdoFastStockOut.Click += new System.EventHandler(this.rdoFastStockOut_Click);
            this.rdoFastStockOut.CheckedChanged += new System.EventHandler(this.rdoFastStockOut_CheckedChanged);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(517, 34);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(177, 23);
            this.txtTime.TabIndex = 122;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInformation.Location = new System.Drawing.Point(365, 515);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(79, 16);
            this.lblInformation.TabIndex = 123;
            this.lblInformation.Text = "Chờ lệnh ...";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(354, 157);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(340, 23);
            this.txtCustomerName.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 125;
            this.label2.Text = "Tên khách:";
            // 
            // lblCommandDescription
            // 
            this.lblCommandDescription.AutoSize = true;
            this.lblCommandDescription.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblCommandDescription.Location = new System.Drawing.Point(192, 559);
            this.lblCommandDescription.Name = "lblCommandDescription";
            this.lblCommandDescription.Size = new System.Drawing.Size(189, 24);
            this.lblCommandDescription.TabIndex = 126;
            this.lblCommandDescription.Text = "XUẤT HÀNG RA ...";
            // 
            // rdoRetail
            // 
            this.rdoRetail.AutoSize = true;
            this.rdoRetail.Location = new System.Drawing.Point(64, 21);
            this.rdoRetail.Name = "rdoRetail";
            this.rdoRetail.Size = new System.Drawing.Size(58, 20);
            this.rdoRetail.TabIndex = 127;
            this.rdoRetail.TabStop = true;
            this.rdoRetail.Text = "Giá lẻ";
            this.rdoRetail.UseVisualStyleBackColor = true;
            this.rdoRetail.CheckedChanged += new System.EventHandler(this.rdoRetail_CheckedChanged);
            // 
            // rdoWholesale
            // 
            this.rdoWholesale.AutoSize = true;
            this.rdoWholesale.Location = new System.Drawing.Point(6, 21);
            this.rdoWholesale.Name = "rdoWholesale";
            this.rdoWholesale.Size = new System.Drawing.Size(57, 20);
            this.rdoWholesale.TabIndex = 128;
            this.rdoWholesale.TabStop = true;
            this.rdoWholesale.Text = "Giá sỉ";
            this.rdoWholesale.UseVisualStyleBackColor = true;
            this.rdoWholesale.CheckedChanged += new System.EventHandler(this.rdoWholesale_CheckedChanged);
            // 
            // grpPriceKind
            // 
            this.grpPriceKind.Controls.Add(this.rdoRetail);
            this.grpPriceKind.Controls.Add(this.rdoWholesale);
            this.grpPriceKind.Location = new System.Drawing.Point(199, 10);
            this.grpPriceKind.Name = "grpPriceKind";
            this.grpPriceKind.Size = new System.Drawing.Size(136, 49);
            this.grpPriceKind.TabIndex = 129;
            this.grpPriceKind.TabStop = false;
            this.grpPriceKind.Text = "Kiểu giá";
            // 
            // ctxShortcuts
            // 
            this.ctxShortcuts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveShortcutToolStripMenuItem,
            this.inputBarcodeToolStripMenuItem,
            this.deleteStockToolStripMenuItem});
            this.ctxShortcuts.Name = "ctxShortcuts";
            this.ctxShortcuts.Size = new System.Drawing.Size(210, 76);
            // 
            // saveShortcutToolStripMenuItem
            // 
            this.saveShortcutToolStripMenuItem.Name = "saveShortcutToolStripMenuItem";
            this.saveShortcutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveShortcutToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.saveShortcutToolStripMenuItem.Text = "SaveShortcut";
            this.saveShortcutToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // inputBarcodeToolStripMenuItem
            // 
            this.inputBarcodeToolStripMenuItem.Name = "inputBarcodeToolStripMenuItem";
            this.inputBarcodeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.inputBarcodeToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.inputBarcodeToolStripMenuItem.Text = "InputBarcode";
            this.inputBarcodeToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // deleteStockToolStripMenuItem
            // 
            this.deleteStockToolStripMenuItem.Name = "deleteStockToolStripMenuItem";
            this.deleteStockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteStockToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.deleteStockToolStripMenuItem.Text = "deleteStock";
            this.deleteStockToolStripMenuItem.Click += new System.EventHandler(this.deleteStock_Pressed);
            // 
            // ImportByFile
            // 
            this.ImportByFile.Location = new System.Drawing.Point(288, 104);
            this.ImportByFile.Name = "ImportByFile";
            this.ImportByFile.Size = new System.Drawing.Size(47, 23);
            this.ImportByFile.TabIndex = 130;
            this.ImportByFile.Text = "...";
            this.ImportByFile.UseVisualStyleBackColor = true;
            this.ImportByFile.Click += new System.EventHandler(this.ImportByFile_Click);
            // 
            // DepartmentFastStockOutForm
            // 
            this.ClientSize = new System.Drawing.Size(818, 616);
            this.ContextMenuStrip = this.ctxShortcuts;
            this.Controls.Add(this.ImportByFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCommandDescription);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.lblDepartments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSumProduct);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lstSize);
            this.Controls.Add(this.lstColor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.cbbStockOutType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProductMasters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.dgvDeptStockIn);
            this.Controls.Add(this.grpPriceKind);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepartmentFastStockOutForm";
            this.Text = "Phân phối hàng hoá trong kho cửa hàng";
            this.Load += new System.EventHandler(this.DepartmentStockInExtra_Load);
            this.Controls.SetChildIndex(this.grpPriceKind, 0);
            this.Controls.SetChildIndex(this.dgvDeptStockIn, 0);
            this.Controls.SetChildIndex(this.txtSumValue, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboProductMasters, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.cbbStockOutType, 0);
            this.Controls.SetChildIndex(this.btnInput, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lstColor, 0);
            this.Controls.SetChildIndex(this.lstSize, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.txtSumProduct, 0);
            this.Controls.SetChildIndex(this.btnReset, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblDepartments, 0);
            this.Controls.SetChildIndex(this.cboDepartment, 0);
            this.Controls.SetChildIndex(this.lblInformation, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtTime, 0);
            this.Controls.SetChildIndex(this.lblCommandDescription, 0);
            this.Controls.SetChildIndex(this.txtCustomerName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.ImportByFile, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPriceKind.ResumeLayout(false);
            this.grpPriceKind.PerformLayout();
            this.ctxShortcuts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.BindingSource bdsStockIn;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.TextBox txtBarcode;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSumValue;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.HelpProvider helpProvider1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dgvDeptStockIn;
        private System.Windows.Forms.ComboBox cboProductMasters;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.ListBox lstColor;
        private System.Windows.Forms.ListBox lstSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource colorBindingSource;
        private System.Windows.Forms.BindingSource sizeBindingSource;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtSumProduct;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbStockOutType;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblDepartments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoStockOut;
        private System.Windows.Forms.RadioButton rdoFastStockOut;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewButtonColumn SearchCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProducType;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductId;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductName;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnColor;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Good;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unconfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCommandDescription;
        private System.Windows.Forms.RadioButton rdoRetail;
        private System.Windows.Forms.RadioButton rdoWholesale;
        private System.Windows.Forms.GroupBox grpPriceKind;
        public System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.ContextMenuStrip ctxShortcuts;
        private System.Windows.Forms.ToolStripMenuItem saveShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStockToolStripMenuItem;
        private System.Windows.Forms.Button ImportByFile;
    }
}
