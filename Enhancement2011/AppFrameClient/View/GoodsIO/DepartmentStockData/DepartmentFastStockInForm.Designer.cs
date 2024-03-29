﻿namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentFastStockInForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnColor = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnSize = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtSumProduct = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoStockIn = new System.Windows.Forms.RadioButton();
            this.rdoFastStockIn = new System.Windows.Forms.RadioButton();
            this.txtInputDate = new System.Windows.Forms.TextBox();
            this.txtGoodsDescription = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.ctxShorcuts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemHotkey1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemHotkey2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportByFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ctxShorcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // bdsStockIn
            // 
            this.bdsStockIn.DataSource = typeof(AppFrame.Collection.DepartmentStockOutDetailCollection);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(11, 419);
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
            this.label7.Location = new System.Drawing.Point(424, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(341, 21);
            this.label7.TabIndex = 85;
            this.label7.Text = "NHẬP NHANH HÀNG HOÁ TRONG KHO ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(474, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 87;
            this.label8.Text = "Ngày nhập:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(11, 472);
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
            this.label6.Location = new System.Drawing.Point(504, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Tổng giá trị";
            this.label6.Visible = false;
            // 
            // txtSumValue
            // 
            this.txtSumValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumValue.Location = new System.Drawing.Point(580, 420);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.ReadOnly = true;
            this.txtSumValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumValue.Size = new System.Drawing.Size(158, 23);
            this.txtSumValue.TabIndex = 82;
            this.txtSumValue.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(484, 472);
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
            this.button1.Location = new System.Drawing.Point(721, 472);
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
            this.quantity,
            this.columnColor,
            this.columnSize,
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
            this.dgvDeptStockIn.Location = new System.Drawing.Point(11, 134);
            this.dgvDeptStockIn.Name = "dgvDeptStockIn";
            this.dgvDeptStockIn.Size = new System.Drawing.Size(785, 280);
            this.dgvDeptStockIn.TabIndex = 8;
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ProducType.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProducType.HeaderText = "Chủng loại";
            this.ProducType.Name = "ProducType";
            this.ProducType.ReadOnly = true;
            // 
            // columnProductId
            // 
            this.columnProductId.DataPropertyName = "Product.ProductId";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            this.columnProductId.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnProductId.HeaderText = "Mã vạch";
            this.columnProductId.Name = "columnProductId";
            this.columnProductId.ReadOnly = true;
            this.columnProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnProductName
            // 
            this.columnProductName.DataPropertyName = "Product.ProductMaster.ProductName";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver;
            this.columnProductName.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnProductName.HeaderText = "Tên sản phẩm";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.ReadOnly = true;
            this.columnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnProductName.Width = 200;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantity.HeaderText = "Số lượng";
            this.quantity.Name = "quantity";
            this.quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.quantity.Width = 140;
            // 
            // columnColor
            // 
            this.columnColor.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver;
            this.columnColor.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnColor.HeaderText = "Màu sắc";
            this.columnColor.Name = "columnColor";
            this.columnColor.ReadOnly = true;
            this.columnColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnSize
            // 
            this.columnSize.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver;
            this.columnSize.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnSize.HeaderText = "Kích cỡ";
            this.columnSize.Name = "columnSize";
            this.columnSize.ReadOnly = true;
            this.columnSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Good
            // 
            this.Good.DataPropertyName = "GoodQuantity";
            this.Good.HeaderText = "Tốt";
            this.Good.Name = "Good";
            this.Good.Visible = false;
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
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Silver;
            this.Unconfirm.DefaultCellStyle = dataGridViewCellStyle7;
            this.Unconfirm.HeaderText = "Không xác định";
            this.Unconfirm.Name = "Unconfirm";
            this.Unconfirm.Visible = false;
            this.Unconfirm.Width = 70;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Lý do";
            this.Desc.Name = "Desc";
            this.Desc.Visible = false;
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
            // colorBindingSource
            // 
            this.colorBindingSource.DataSource = typeof(AppFrame.Model.ProductColor);
            // 
            // sizeBindingSource
            // 
            this.sizeBindingSource.DataSource = typeof(AppFrame.Model.ProductSize);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(285, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 16);
            this.label13.TabIndex = 112;
            this.label13.Text = "Tổng sản phẩm";
            // 
            // txtSumProduct
            // 
            this.txtSumProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumProduct.Location = new System.Drawing.Point(383, 420);
            this.txtSumProduct.Name = "txtSumProduct";
            this.txtSumProduct.ReadOnly = true;
            this.txtSumProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumProduct.Size = new System.Drawing.Size(118, 23);
            this.txtSumProduct.TabIndex = 111;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoStockIn);
            this.groupBox1.Controls.Add(this.rdoFastStockIn);
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 50);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phương thức";
            // 
            // rdoStockIn
            // 
            this.rdoStockIn.AutoSize = true;
            this.rdoStockIn.Location = new System.Drawing.Point(107, 21);
            this.rdoStockIn.Name = "rdoStockIn";
            this.rdoStockIn.Size = new System.Drawing.Size(95, 20);
            this.rdoStockIn.TabIndex = 119;
            this.rdoStockIn.TabStop = true;
            this.rdoStockIn.Text = "Nhập từ chợ";
            this.rdoStockIn.UseVisualStyleBackColor = true;
            this.rdoStockIn.CheckedChanged += new System.EventHandler(this.rdoStockIn_CheckedChanged);
            // 
            // rdoFastStockIn
            // 
            this.rdoFastStockIn.AutoSize = true;
            this.rdoFastStockIn.Location = new System.Drawing.Point(6, 21);
            this.rdoFastStockIn.Name = "rdoFastStockIn";
            this.rdoFastStockIn.Size = new System.Drawing.Size(96, 20);
            this.rdoFastStockIn.TabIndex = 118;
            this.rdoFastStockIn.TabStop = true;
            this.rdoFastStockIn.Text = "Nhập từ C/H";
            this.rdoFastStockIn.UseVisualStyleBackColor = true;
            this.rdoFastStockIn.CheckedChanged += new System.EventHandler(this.rdoFastStockIn_CheckedChanged);
            // 
            // txtInputDate
            // 
            this.txtInputDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputDate.Location = new System.Drawing.Point(549, 33);
            this.txtInputDate.Name = "txtInputDate";
            this.txtInputDate.ReadOnly = true;
            this.txtInputDate.Size = new System.Drawing.Size(163, 23);
            this.txtInputDate.TabIndex = 122;
            // 
            // txtGoodsDescription
            // 
            this.txtGoodsDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoodsDescription.Location = new System.Drawing.Point(82, 103);
            this.txtGoodsDescription.Name = "txtGoodsDescription";
            this.txtGoodsDescription.ReadOnly = true;
            this.txtGoodsDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGoodsDescription.Size = new System.Drawing.Size(714, 23);
            this.txtGoodsDescription.TabIndex = 123;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(580, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 124;
            this.button2.Text = "Xóa trắng";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(383, 75);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(413, 24);
            this.cboDepartment.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 126;
            this.label2.Text = "Nơi nhập";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(138, 476);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(121, 16);
            this.lblMessage.TabIndex = 127;
            this.lblMessage.Text = "Đang chờ nhập ...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Navy;
            this.lblDescription.Location = new System.Drawing.Point(141, 531);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(205, 31);
            this.lblDescription.TabIndex = 128;
            this.lblDescription.Text = "Nhập hàng từ ...";
            // 
            // ctxShorcuts
            // 
            this.ctxShorcuts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemHotkey1ToolStripMenuItem,
            this.systemHotkey2ToolStripMenuItem,
            this.deleteStockToolStripMenuItem});
            this.ctxShorcuts.Name = "ctxShorcuts";
            this.ctxShorcuts.Size = new System.Drawing.Size(223, 76);
            // 
            // systemHotkey1ToolStripMenuItem
            // 
            this.systemHotkey1ToolStripMenuItem.Name = "systemHotkey1ToolStripMenuItem";
            this.systemHotkey1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.systemHotkey1ToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.systemHotkey1ToolStripMenuItem.Text = "systemHotkey1";
            this.systemHotkey1ToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // systemHotkey2ToolStripMenuItem
            // 
            this.systemHotkey2ToolStripMenuItem.Name = "systemHotkey2ToolStripMenuItem";
            this.systemHotkey2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.systemHotkey2ToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.systemHotkey2ToolStripMenuItem.Text = "systemHotkey2";
            this.systemHotkey2ToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // deleteStockToolStripMenuItem
            // 
            this.deleteStockToolStripMenuItem.Name = "deleteStockToolStripMenuItem";
            this.deleteStockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteStockToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.deleteStockToolStripMenuItem.Text = "deleteStock";
            this.deleteStockToolStripMenuItem.Click += new System.EventHandler(this.deleteStock_Pressed);
            // 
            // ImportByFile
            // 
            this.ImportByFile.Location = new System.Drawing.Point(290, 76);
            this.ImportByFile.Name = "ImportByFile";
            this.ImportByFile.Size = new System.Drawing.Size(26, 23);
            this.ImportByFile.TabIndex = 129;
            this.ImportByFile.Text = "...";
            this.ImportByFile.UseVisualStyleBackColor = true;
            this.ImportByFile.Click += new System.EventHandler(this.ImportByFile_Click);
            // 
            // DepartmentFastStockInForm
            // 
            this.ClientSize = new System.Drawing.Size(808, 616);
            this.ContextMenuStrip = this.ctxShorcuts;
            this.Controls.Add(this.ImportByFile);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtGoodsDescription);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInputDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSumProduct);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.dgvDeptStockIn);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepartmentFastStockInForm";
            this.Text = "Phân phối hàng hoá trong kho cửa hàng";
            this.Load += new System.EventHandler(this.DepartmentStockInExtra_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.dgvDeptStockIn, 0);
            this.Controls.SetChildIndex(this.txtSumValue, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.txtSumProduct, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtInputDate, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtGoodsDescription, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.cboDepartment, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.ImportByFile, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ctxShorcuts.ResumeLayout(false);
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
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource colorBindingSource;
        private System.Windows.Forms.BindingSource sizeBindingSource;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtSumProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoStockIn;
        private System.Windows.Forms.RadioButton rdoFastStockIn;
        private System.Windows.Forms.TextBox txtInputDate;
        public System.Windows.Forms.TextBox txtGoodsDescription;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboDepartment;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewButtonColumn SearchCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProducType;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductId;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnColor;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnSize;
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
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ContextMenuStrip ctxShorcuts;
        private System.Windows.Forms.ToolStripMenuItem systemHotkey1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemHotkey2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStockToolStripMenuItem;
        private System.Windows.Forms.Button ImportByFile;
    }
}
