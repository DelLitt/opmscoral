namespace AppFrameClient.View.GoodsIO.MainStock
{
    partial class BaseStockOutForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.bdsStockDefect = new System.Windows.Forms.BindingSource(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveTempStockOut = new System.Windows.Forms.Button();
            this.bdsProductMasters = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoadBarcode = new System.Windows.Forms.Button();
            this.cboProductMasters = new System.Windows.Forms.ComboBox();
            this.dgvStockDefect = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStockOut = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvTempStockOut = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsStockOut = new System.Windows.Forms.BindingSource(this.components);
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLoadDefect = new System.Windows.Forms.Button();
            this.rdoTamXuat = new System.Windows.Forms.RadioButton();
            this.rdoTraHang = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockOut)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(480, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 73);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Diễn giải";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(333, 15);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(141, 73);
            this.txtDescription.TabIndex = 24;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(66, 43);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(201, 22);
            this.txtProductName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tồn kho";
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.Location = new System.Drawing.Point(66, 68);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.ReadOnly = true;
            this.txtStockQuantity.Size = new System.Drawing.Size(97, 22);
            this.txtStockQuantity.TabIndex = 19;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(330, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(441, 23);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "TẠM XUẤT HÀNG - TRẢ HÀNG CHO NHÀ SẢN XUẤT";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStockQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductType);
            this.groupBox1.Location = new System.Drawing.Point(370, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 94);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Loại";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(66, 20);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(129, 22);
            this.txtProductType.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(76, 82);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(234, 22);
            this.txtBarcode.TabIndex = 29;
            this.txtBarcode.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(696, 527);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(898, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveTempStockOut
            // 
            this.btnSaveTempStockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTempStockOut.Location = new System.Drawing.Point(535, 527);
            this.btnSaveTempStockOut.Name = "btnSaveTempStockOut";
            this.btnSaveTempStockOut.Size = new System.Drawing.Size(138, 23);
            this.btnSaveTempStockOut.TabIndex = 26;
            this.btnSaveTempStockOut.Text = "Lưu";
            this.btnSaveTempStockOut.UseVisualStyleBackColor = true;
            this.btnSaveTempStockOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // bdsProductMasters
            // 
            this.bdsProductMasters.DataSource = typeof(AppFrameClient.ViewModel.StockViewCollection);
            // 
            // btnLoadBarcode
            // 
            this.btnLoadBarcode.Location = new System.Drawing.Point(316, 79);
            this.btnLoadBarcode.Name = "btnLoadBarcode";
            this.btnLoadBarcode.Size = new System.Drawing.Size(48, 23);
            this.btnLoadBarcode.TabIndex = 32;
            this.btnLoadBarcode.Text = "...";
            this.btnLoadBarcode.UseVisualStyleBackColor = true;
            this.btnLoadBarcode.Visible = false;
            // 
            // cboProductMasters
            // 
            this.cboProductMasters.DataSource = this.bdsProductMasters;
            this.cboProductMasters.DisplayMember = "ProductDisplayName";
            this.cboProductMasters.FormattingEnabled = true;
            this.cboProductMasters.Location = new System.Drawing.Point(76, 55);
            this.cboProductMasters.Name = "cboProductMasters";
            this.cboProductMasters.Size = new System.Drawing.Size(234, 22);
            this.cboProductMasters.TabIndex = 31;
            this.cboProductMasters.SelectedIndexChanged += new System.EventHandler(this.cboProductMasters_SelectedIndexChanged);
            // 
            // dgvStockDefect
            // 
            this.dgvStockDefect.AllowUserToAddRows = false;
            this.dgvStockDefect.AllowUserToDeleteRows = false;
            this.dgvStockDefect.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStockDefect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockDefect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.columnError,
            this.Column6});
            this.dgvStockDefect.DataSource = this.bdsStockDefect;
            this.dgvStockDefect.Location = new System.Drawing.Point(12, 148);
            this.dgvStockDefect.Name = "dgvStockDefect";
            this.dgvStockDefect.ReadOnly = true;
            this.dgvStockDefect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockDefect.Size = new System.Drawing.Size(960, 166);
            this.dgvStockDefect.TabIndex = 24;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Product.ProductId";
            this.Column8.HeaderText = "Mã vạch";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            this.Column1.HeaderText = "Loại hàng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Product.ProductMaster.ProductName";
            this.Column2.HeaderText = "Tên hàng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.Column3.HeaderText = "Màu ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.Column4.HeaderText = "Cỡ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // columnError
            // 
            this.columnError.DataPropertyName = "ErrorCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Format = "##,##0";
            this.columnError.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnError.HeaderText = "Lỗi";
            this.columnError.Name = "columnError";
            this.columnError.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 300;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Mã vạch:";
            this.label11.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Loại hàng:";
            // 
            // lblStockOut
            // 
            this.lblStockOut.AutoSize = true;
            this.lblStockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockOut.Location = new System.Drawing.Point(13, 338);
            this.lblStockOut.Name = "lblStockOut";
            this.lblStockOut.Size = new System.Drawing.Size(103, 13);
            this.lblStockOut.TabIndex = 35;
            this.lblStockOut.Text = "Tạm xuất - Trả hàng";
            this.lblStockOut.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Tình trạng hàng";
            // 
            // dgvTempStockOut
            // 
            this.dgvTempStockOut.AllowUserToAddRows = false;
            this.dgvTempStockOut.AllowUserToDeleteRows = false;
            this.dgvTempStockOut.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTempStockOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTempStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempStockOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column5,
            this.Column14});
            this.dgvTempStockOut.DataSource = this.bdsStockOut;
            this.dgvTempStockOut.Location = new System.Drawing.Point(13, 355);
            this.dgvTempStockOut.Name = "dgvTempStockOut";
            this.dgvTempStockOut.Size = new System.Drawing.Size(960, 166);
            this.dgvTempStockOut.TabIndex = 37;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "Product.ProductId";
            this.ProductId.HeaderText = "Mã vạch";
            this.ProductId.Name = "ProductId";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Loại hàng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Product.ProductMaster.ProductName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên hàng";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Màu";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cỡ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Quantity";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column5.HeaderText = "Số lượng ";
            this.Column5.Name = "Column5";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Description";
            this.Column14.HeaderText = "Ghi chú";
            this.Column14.Name = "Column14";
            this.Column14.Width = 300;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.Location = new System.Drawing.Point(12, 314);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAll.TabIndex = 38;
            this.btnCheckAll.Text = "Chọn hết";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheckAll.Location = new System.Drawing.Point(93, 314);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnUncheckAll.TabIndex = 39;
            this.btnUncheckAll.Text = "Bỏ chọn";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(12, 527);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(253, 314);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLoadDefect
            // 
            this.btnLoadDefect.Location = new System.Drawing.Point(317, 54);
            this.btnLoadDefect.Name = "btnLoadDefect";
            this.btnLoadDefect.Size = new System.Drawing.Size(47, 23);
            this.btnLoadDefect.TabIndex = 42;
            this.btnLoadDefect.Text = "Đọc";
            this.btnLoadDefect.UseVisualStyleBackColor = true;
            this.btnLoadDefect.Visible = false;
            this.btnLoadDefect.Click += new System.EventHandler(this.btnLoadDefect_Click);
            // 
            // rdoTamXuat
            // 
            this.rdoTamXuat.AutoSize = true;
            this.rdoTamXuat.Checked = true;
            this.rdoTamXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTamXuat.Location = new System.Drawing.Point(14, 108);
            this.rdoTamXuat.Name = "rdoTamXuat";
            this.rdoTamXuat.Size = new System.Drawing.Size(105, 17);
            this.rdoTamXuat.TabIndex = 43;
            this.rdoTamXuat.TabStop = true;
            this.rdoTamXuat.Text = "Tạm xuất để sửa";
            this.rdoTamXuat.UseVisualStyleBackColor = true;
            // 
            // rdoTraHang
            // 
            this.rdoTraHang.AutoSize = true;
            this.rdoTraHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTraHang.Location = new System.Drawing.Point(138, 108);
            this.rdoTraHang.Name = "rdoTraHang";
            this.rdoTraHang.Size = new System.Drawing.Size(153, 17);
            this.rdoTraHang.TabIndex = 44;
            this.rdoTraHang.Text = "Trả hàng cho nhà sản xuất";
            this.rdoTraHang.UseVisualStyleBackColor = true;
            // 
            // BaseStockOutForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.rdoTraHang);
            this.Controls.Add(this.rdoTamXuat);
            this.Controls.Add(this.btnLoadDefect);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUncheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblStockOut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLoadBarcode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSaveTempStockOut);
            this.Controls.Add(this.cboProductMasters);
            this.Controls.Add(this.dgvStockDefect);
            this.Controls.Add(this.dgvTempStockOut);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BaseStockOutForm";
            this.Load += new System.EventHandler(this.TemporaryStockOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtProductName;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtStockQuantity;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtProductType;
        public System.Windows.Forms.BindingSource bdsStockDefect;
        public System.Windows.Forms.TextBox txtBarcode;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnSaveTempStockOut;
        public System.Windows.Forms.BindingSource bdsProductMasters;
        public System.Windows.Forms.Button btnLoadBarcode;
        public System.Windows.Forms.ComboBox cboProductMasters;
        public System.Windows.Forms.DataGridView dgvStockDefect;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblStockOut;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView dgvTempStockOut;
        public System.Windows.Forms.Button btnCheckAll;
        public System.Windows.Forms.Button btnUncheckAll;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.BindingSource bdsStockOut;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnLoadDefect;
        public System.Windows.Forms.RadioButton rdoTamXuat;
        public System.Windows.Forms.RadioButton rdoTraHang;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.DataGridViewTextBoxColumn columnError;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}
