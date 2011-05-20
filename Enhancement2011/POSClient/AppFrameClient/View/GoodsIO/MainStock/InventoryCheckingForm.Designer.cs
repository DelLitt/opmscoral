namespace AppFrameClient.View.GoodsIO.MainStock
{
    partial class InventoryCheckingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.countRealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsStockDefect = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cboProductMasters = new System.Windows.Forms.ComboBox();
            this.bdsProductMasters = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.systemHotkey1 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.btnTempSave = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cboTypeList = new System.Windows.Forms.ComboBox();
            this.lstProductsList = new System.Windows.Forms.TreeView();
            this.btnLoadTemp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtRealitySum = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMasters)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "KIỂM KÊ HÀNG HÓA TẠI KHO";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Quantity,
            this.columnGood,
            this.columnError,
            this.columnDamage,
            this.columnLost,
            this.Column7});
            this.dgvStock.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvStock.DataSource = this.bdsStockDefect;
            this.dgvStock.Location = new System.Drawing.Point(12, 184);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(737, 293);
            this.dgvStock.TabIndex = 1;
            this.dgvStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellEndEdit);
            this.dgvStock.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStock_DataError);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product.ProductId";
            this.Column1.HeaderText = "Mã vạch";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
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
            this.Column3.HeaderText = "Màu sắc";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.Column4.HeaderText = "K.cỡ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "##,##0";
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantity.HeaderText = "Tổng";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 60;
            // 
            // columnGood
            // 
            this.columnGood.DataPropertyName = "GoodQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle4.Format = "##,##0";
            this.columnGood.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnGood.HeaderText = "Tốt";
            this.columnGood.Name = "columnGood";
            this.columnGood.Width = 60;
            // 
            // columnError
            // 
            this.columnError.DataPropertyName = "ErrorQuantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle5.Format = "##,##0";
            this.columnError.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnError.HeaderText = "Lỗi";
            this.columnError.Name = "columnError";
            this.columnError.Width = 60;
            // 
            // columnDamage
            // 
            this.columnDamage.DataPropertyName = "DamageQuantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle6.Format = "##,##0";
            this.columnDamage.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnDamage.HeaderText = "Hư";
            this.columnDamage.Name = "columnDamage";
            this.columnDamage.Width = 60;
            // 
            // columnLost
            // 
            this.columnLost.DataPropertyName = "LostQuantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle7.Format = "##,##0";
            this.columnLost.DefaultCellStyle = dataGridViewCellStyle7;
            this.columnLost.HeaderText = "Mất";
            this.columnLost.Name = "columnLost";
            this.columnLost.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UnconfirmQuantity";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle8.Format = "##,##0";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column7.HeaderText = "KXD";
            this.Column7.Name = "Column7";
            this.Column7.Width = 60;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countRealToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 28);
            // 
            // countRealToolStripMenuItem
            // 
            this.countRealToolStripMenuItem.Name = "countRealToolStripMenuItem";
            this.countRealToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.countRealToolStripMenuItem.Text = "Tính toán số lượng";
            this.countRealToolStripMenuItem.Click += new System.EventHandler(this.countRealToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStockQuantity);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductType);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(435, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 66);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Diễn giải";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(288, 11);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(141, 66);
            this.txtDescription.TabIndex = 24;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(64, 34);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(218, 20);
            this.txtProductName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tồn kho";
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.Location = new System.Drawing.Point(64, 59);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.ReadOnly = true;
            this.txtStockQuantity.Size = new System.Drawing.Size(97, 20);
            this.txtStockQuantity.TabIndex = 19;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(557, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(173, 60);
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "XÁC NHẬN";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Loại";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(64, 11);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(129, 20);
            this.txtProductType.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboProductMasters
            // 
            this.cboProductMasters.DataSource = this.bdsProductMasters;
            this.cboProductMasters.DisplayMember = "ProductDisplayName";
            this.cboProductMasters.FormattingEnabled = true;
            this.cboProductMasters.Location = new System.Drawing.Point(12, 9);
            this.cboProductMasters.Name = "cboProductMasters";
            this.cboProductMasters.Size = new System.Drawing.Size(32, 21);
            this.cboProductMasters.TabIndex = 21;
            this.cboProductMasters.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(345, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Lưu kết quả kiểm kê";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(674, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(588, 513);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Bỏ qua";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(96, 78);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(259, 20);
            this.txtBarcode.TabIndex = 18;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "Nhập mã vạch:";
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // btnTempSave
            // 
            this.btnTempSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempSave.Location = new System.Drawing.Point(175, 514);
            this.btnTempSave.Name = "btnTempSave";
            this.btnTempSave.Size = new System.Drawing.Size(83, 23);
            this.btnTempSave.TabIndex = 23;
            this.btnTempSave.Text = "Lưu tạm";
            this.btnTempSave.UseVisualStyleBackColor = true;
            this.btnTempSave.Click += new System.EventHandler(this.btnTempSave_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(21, 514);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 23);
            this.button5.TabIndex = 24;
            this.button5.Text = "Xuất ra Excel";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // cboTypeList
            // 
            this.cboTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeList.FormattingEnabled = true;
            this.cboTypeList.Location = new System.Drawing.Point(756, 127);
            this.cboTypeList.Name = "cboTypeList";
            this.cboTypeList.Size = new System.Drawing.Size(176, 21);
            this.cboTypeList.TabIndex = 25;
            // 
            // lstProductsList
            // 
            this.lstProductsList.Location = new System.Drawing.Point(756, 155);
            this.lstProductsList.Name = "lstProductsList";
            this.lstProductsList.Size = new System.Drawing.Size(176, 351);
            this.lstProductsList.TabIndex = 26;
            // 
            // btnLoadTemp
            // 
            this.btnLoadTemp.Location = new System.Drawing.Point(264, 514);
            this.btnLoadTemp.Name = "btnLoadTemp";
            this.btnLoadTemp.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTemp.TabIndex = 27;
            this.btnLoadTemp.Text = "Đọc tạm";
            this.btnLoadTemp.UseVisualStyleBackColor = true;
            this.btnLoadTemp.Click += new System.EventHandler(this.btnLoadTemp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Tổng số lượng";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(597, 484);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(26, 15);
            this.lblStatus.TabIndex = 39;
            this.lblStatus.Text = "N/A";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(507, 513);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Xoa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtRealitySum
            // 
            this.txtRealitySum.AutoSize = true;
            this.txtRealitySum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealitySum.ForeColor = System.Drawing.Color.Red;
            this.txtRealitySum.Location = new System.Drawing.Point(507, 481);
            this.txtRealitySum.Name = "txtRealitySum";
            this.txtRealitySum.Size = new System.Drawing.Size(19, 20);
            this.txtRealitySum.TabIndex = 41;
            this.txtRealitySum.Text = "0";
            // 
            // txtSum
            // 
            this.txtSum.AutoSize = true;
            this.txtSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSum.ForeColor = System.Drawing.Color.Blue;
            this.txtSum.Location = new System.Drawing.Point(447, 481);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(19, 20);
            this.txtSum.TabIndex = 42;
            this.txtSum.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(445, 478);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(54, 27);
            this.textBox1.TabIndex = 43;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(505, 478);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(54, 27);
            this.textBox2.TabIndex = 44;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(96, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(259, 23);
            this.button4.TabIndex = 45;
            this.button4.Text = "Nhập mã vạch từ file text";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // InventoryCheckingForm
            // 
            this.ClientSize = new System.Drawing.Size(944, 562);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.txtRealitySum);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstProductsList);
            this.Controls.Add(this.btnLoadTemp);
            this.Controls.Add(this.cboTypeList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnTempSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.cboProductMasters);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Name = "InventoryCheckingForm";
            this.Load += new System.EventHandler(this.InventoryCheckingForm_Load);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvStock, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cboProductMasters, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.btnTempSave, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cboTypeList, 0);
            this.Controls.SetChildIndex(this.btnLoadTemp, 0);
            this.Controls.SetChildIndex(this.lstProductsList, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.txtRealitySum, 0);
            this.Controls.SetChildIndex(this.txtSum, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMasters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.ComboBox cboProductMasters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.BindingSource bdsProductMasters;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bdsStockDefect;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn defectStatusDataGridViewTextBoxColumn;
        private AppFrame.Controls.HotKey.SystemHotkey systemHotkey1;
        private System.Windows.Forms.Button btnTempSave;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cboTypeList;
        private System.Windows.Forms.TreeView lstProductsList;
        private System.Windows.Forms.Button btnLoadTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGood;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDamage;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripMenuItem countRealToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label txtRealitySum;
        private System.Windows.Forms.Label txtSum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
    }
}
