namespace AppFrameClient.View.GoodsIO.MainStock
{
    partial class MainStockInExtraForm
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
            this.barcodePrintDocument = new System.Drawing.Printing.PrintDocument();
            this.btnPreview = new System.Windows.Forms.Button();
            this.bdsStockIn = new System.Windows.Forms.BindingSource(this.components);
            this.mnuCreateNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDownBarcode = new System.Windows.Forms.NumericUpDown();
            this.mnuCreateDupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuDept = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtStockInId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.barcodePrintDialog = new System.Windows.Forms.PrintDialog();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSumValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDexcription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDeptStockIn = new System.Windows.Forms.DataGridView();
            this.cboProductMasters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewProductInput = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.lstColor = new System.Windows.Forms.ListBox();
            this.colorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstSize = new System.Windows.Forms.ListBox();
            this.sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPriceIn = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPriceOut = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSumProduct = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ctrlC = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.ctrlV = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.txtWSPriceOut = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPriceInput = new System.Windows.Forms.Button();
            this.SearchCreate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnProductId = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.ProducType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProductName = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnColor = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.columnSize = new AppFrame.Controls.DataGridViewEditComboBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onStorePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarcode)).BeginInit();
            this.ctxMenuDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barcodePrintDocument
            // 
            this.barcodePrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.barcodePrintDocument_PrintPage);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(161, 499);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 23);
            this.btnPreview.TabIndex = 97;
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // bdsStockIn
            // 
            this.bdsStockIn.DataSource = typeof(AppFrame.Collection.StockInDetailCollection);
            // 
            // mnuCreateNewItem
            // 
            this.mnuCreateNewItem.Name = "mnuCreateNewItem";
            this.mnuCreateNewItem.Size = new System.Drawing.Size(306, 22);
            this.mnuCreateNewItem.Text = "Tạo dòng mới với nội dung mới hoàn toàn";
            this.mnuCreateNewItem.Click += new System.EventHandler(this.mnuCreateNewItem_Click);
            // 
            // numericUpDownBarcode
            // 
            this.numericUpDownBarcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBarcode.Location = new System.Drawing.Point(104, 499);
            this.numericUpDownBarcode.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBarcode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBarcode.Name = "numericUpDownBarcode";
            this.numericUpDownBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDownBarcode.Size = new System.Drawing.Size(51, 22);
            this.numericUpDownBarcode.TabIndex = 96;
            this.numericUpDownBarcode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mnuCreateDupItem
            // 
            this.mnuCreateDupItem.Name = "mnuCreateDupItem";
            this.mnuCreateDupItem.Size = new System.Drawing.Size(306, 22);
            this.mnuCreateDupItem.Text = "Tạo dòng mới với nội dung từ dòng hiện tại";
            this.mnuCreateDupItem.Click += new System.EventHandler(this.nhToolStripMenuItem_Click);
            // 
            // ctxMenuDept
            // 
            this.ctxMenuDept.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateDupItem,
            this.mnuCreateNewItem});
            this.ctxMenuDept.Name = "ctxMenuDept";
            this.ctxMenuDept.Size = new System.Drawing.Size(307, 48);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(267, 527);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtStockInId
            // 
            this.txtStockInId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockInId.Location = new System.Drawing.Point(103, 42);
            this.txtStockInId.Name = "txtStockInId";
            this.txtStockInId.ReadOnly = true;
            this.txtStockInId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStockInId.Size = new System.Drawing.Size(122, 22);
            this.txtStockInId.TabIndex = 93;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 532);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 14);
            this.label9.TabIndex = 92;
            this.label9.Text = "sản phẩm";
            this.label9.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "Mã lô hàng";
            // 
            // barcodePrintDialog
            // 
            this.barcodePrintDialog.UseEXDialog = true;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.Location = new System.Drawing.Point(347, 527);
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
            this.numericUpDown.TabIndex = 91;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 559);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 14);
            this.lblStatus.TabIndex = 90;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(266, 527);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 89;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Visible = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.Location = new System.Drawing.Point(11, 499);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(87, 23);
            this.btnBarcode.TabIndex = 86;
            this.btnBarcode.Text = "Tạo mã vạch";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(292, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 19);
            this.label7.TabIndex = 85;
            this.label7.Text = "NHẬP HÀNG HÓA/ CHỈNH SỬA HÀNG HÓA";
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDate.Location = new System.Drawing.Point(321, 41);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(106, 22);
            this.dtpImportDate.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(241, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 14);
            this.label8.TabIndex = 87;
            this.label8.Text = "Ngày nhập:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(11, 527);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 84;
            this.button4.Text = "Giúp đỡ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(562, 501);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 83;
            this.label6.Text = "Tổng giá trị";
            // 
            // txtSumValue
            // 
            this.txtSumValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumValue.Location = new System.Drawing.Point(638, 498);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.ReadOnly = true;
            this.txtSumValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumValue.Size = new System.Drawing.Size(173, 22);
            this.txtSumValue.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 14);
            this.label5.TabIndex = 81;
            this.label5.Text = "Chi tiết lô hàng";
            // 
            // txtDexcription
            // 
            this.txtDexcription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDexcription.Location = new System.Drawing.Point(103, 70);
            this.txtDexcription.Name = "txtDexcription";
            this.txtDexcription.Size = new System.Drawing.Size(695, 22);
            this.txtDexcription.TabIndex = 2;
            this.txtDexcription.TextChanged += new System.EventHandler(this.txtDexcription_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 79;
            this.label2.Text = "Diễn tả lô hàng";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(185, 527);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(736, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
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
            this.ProducType,
            this.columnProductName,
            this.columnColor,
            this.columnSize,
            this.quantityDataGridViewTextBoxColumn,
            this.onStorePriceDataGridViewTextBoxColumn,
            this.SellPrice,
            this.Column4,
            this.delFlgDataGridViewTextBoxColumn,
            this.Product,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvDeptStockIn.ContextMenuStrip = this.ctxMenuDept;
            this.dgvDeptStockIn.DataSource = this.bdsStockIn;
            this.dgvDeptStockIn.Location = new System.Drawing.Point(11, 240);
            this.dgvDeptStockIn.Name = "dgvDeptStockIn";
            this.dgvDeptStockIn.Size = new System.Drawing.Size(800, 253);
            this.dgvDeptStockIn.TabIndex = 76;
            this.dgvDeptStockIn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptStockIn_CellEndEdit);
            this.dgvDeptStockIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptStockIn_CellClick);
            this.dgvDeptStockIn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDeptStockIn_KeyUp);
            // 
            // cboProductMasters
            // 
            this.cboProductMasters.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductMasters.FormattingEnabled = true;
            this.cboProductMasters.Location = new System.Drawing.Point(103, 98);
            this.cboProductMasters.Name = "cboProductMasters";
            this.cboProductMasters.Size = new System.Drawing.Size(217, 24);
            this.cboProductMasters.TabIndex = 3;
            this.cboProductMasters.SelectedIndexChanged += new System.EventHandler(this.cboProductMasters_SelectedIndexChanged);
            this.cboProductMasters.DropDown += new System.EventHandler(this.cboProductMasters_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 99;
            this.label1.Text = "Mặt hàng";
            // 
            // btnNewProductInput
            // 
            this.btnNewProductInput.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProductInput.Location = new System.Drawing.Point(652, 145);
            this.btnNewProductInput.Name = "btnNewProductInput";
            this.btnNewProductInput.Size = new System.Drawing.Size(146, 46);
            this.btnNewProductInput.TabIndex = 9;
            this.btnNewProductInput.Text = "Tạo định nghĩa mặt hàng mới";
            this.btnNewProductInput.UseVisualStyleBackColor = true;
            this.btnNewProductInput.Click += new System.EventHandler(this.btnNewProductInput_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(559, 527);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 101;
            this.button3.Text = "Bỏ qua";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInput.Location = new System.Drawing.Point(652, 97);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(146, 46);
            this.btnInput.TabIndex = 8;
            this.btnInput.Text = "Nhập";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // lstColor
            // 
            this.lstColor.DataSource = this.colorBindingSource;
            this.lstColor.DisplayMember = "ColorName";
            this.lstColor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstColor.FormattingEnabled = true;
            this.lstColor.ItemHeight = 14;
            this.lstColor.Location = new System.Drawing.Point(105, 128);
            this.lstColor.Name = "lstColor";
            this.lstColor.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstColor.Size = new System.Drawing.Size(151, 102);
            this.lstColor.TabIndex = 6;
            // 
            // colorBindingSource
            // 
            this.colorBindingSource.DataSource = typeof(AppFrame.Model.ProductColor);
            // 
            // lstSize
            // 
            this.lstSize.DataSource = this.sizeBindingSource;
            this.lstSize.DisplayMember = "SizeName";
            this.lstSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSize.FormattingEnabled = true;
            this.lstSize.ItemHeight = 14;
            this.lstSize.Location = new System.Drawing.Point(316, 128);
            this.lstSize.Name = "lstSize";
            this.lstSize.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSize.Size = new System.Drawing.Size(161, 102);
            this.lstSize.TabIndex = 7;
            // 
            // sizeBindingSource
            // 
            this.sizeBindingSource.DataSource = typeof(AppFrame.Model.ProductSize);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 105;
            this.label4.Text = "Màu sắc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(264, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 14);
            this.label10.TabIndex = 106;
            this.label10.Text = "Kích cỡ";
            // 
            // txtPriceIn
            // 
            this.txtPriceIn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceIn.Location = new System.Drawing.Point(380, 97);
            this.txtPriceIn.Name = "txtPriceIn";
            this.txtPriceIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceIn.Size = new System.Drawing.Size(97, 22);
            this.txtPriceIn.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(323, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 14);
            this.label11.TabIndex = 108;
            this.label11.Text = "Giá nhập";
            // 
            // txtPriceOut
            // 
            this.txtPriceOut.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceOut.Location = new System.Drawing.Point(538, 97);
            this.txtPriceOut.Name = "txtPriceOut";
            this.txtPriceOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceOut.Size = new System.Drawing.Size(81, 22);
            this.txtPriceOut.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(485, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 14);
            this.label12.TabIndex = 110;
            this.label12.Text = "Giá lẻ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(285, 501);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 14);
            this.label13.TabIndex = 112;
            this.label13.Text = "Tổng sản phẩm";
            // 
            // txtSumProduct
            // 
            this.txtSumProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumProduct.Location = new System.Drawing.Point(383, 498);
            this.txtSumProduct.Name = "txtSumProduct";
            this.txtSumProduct.ReadOnly = true;
            this.txtSumProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumProduct.Size = new System.Drawing.Size(173, 22);
            this.txtSumProduct.TabIndex = 111;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(652, 195);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(146, 28);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Chỉnh sửa mặt hàng";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ctrlC
            // 
            this.ctrlC.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.ctrlC.Pressed += new System.EventHandler(this.ctrlC_Pressed);
            // 
            // ctrlV
            // 
            this.ctrlV.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.ctrlV.Pressed += new System.EventHandler(this.ctrlV_Pressed);
            // 
            // txtWSPriceOut
            // 
            this.txtWSPriceOut.Location = new System.Drawing.Point(538, 131);
            this.txtWSPriceOut.Name = "txtWSPriceOut";
            this.txtWSPriceOut.Size = new System.Drawing.Size(81, 22);
            this.txtWSPriceOut.TabIndex = 113;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(485, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 14);
            this.label14.TabIndex = 114;
            this.label14.Text = "Giá sỉ";
            // 
            // btnPriceInput
            // 
            this.btnPriceInput.Location = new System.Drawing.Point(488, 162);
            this.btnPriceInput.Name = "btnPriceInput";
            this.btnPriceInput.Size = new System.Drawing.Size(130, 29);
            this.btnPriceInput.TabIndex = 115;
            this.btnPriceInput.Text = "Điền giá";
            this.btnPriceInput.UseVisualStyleBackColor = true;
            this.btnPriceInput.Click += new System.EventHandler(this.btnPriceInput_Click);
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
            // columnProductId
            // 
            this.columnProductId.DataPropertyName = "Product.ProductMaster.ProductMasterId";
            this.columnProductId.HeaderText = "Mã sản phẩm";
            this.columnProductId.Name = "columnProductId";
            this.columnProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnProductId.Visible = false;
            // 
            // ProducType
            // 
            this.ProducType.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            this.ProducType.HeaderText = "Chủng loại";
            this.ProducType.Name = "ProducType";
            this.ProducType.ReadOnly = true;
            this.ProducType.Visible = false;
            this.ProducType.Width = 80;
            // 
            // columnProductName
            // 
            this.columnProductName.DataPropertyName = "Product.ProductMaster.ProductName";
            this.columnProductName.HeaderText = "Tên sản phẩm";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnProductName.Width = 170;
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
            this.columnSize.Width = 80;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // onStorePriceDataGridViewTextBoxColumn
            // 
            this.onStorePriceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.onStorePriceDataGridViewTextBoxColumn.HeaderText = "Giá nhập kho";
            this.onStorePriceDataGridViewTextBoxColumn.Name = "onStorePriceDataGridViewTextBoxColumn";
            this.onStorePriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SellPrice
            // 
            this.SellPrice.DataPropertyName = "SellPrice";
            this.SellPrice.HeaderText = "Giá bán";
            this.SellPrice.Name = "SellPrice";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DepartmentPrice.WholeSalePrice";
            this.Column4.HeaderText = "Giá sỉ";
            this.Column4.Name = "Column4";
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
            // MainStockInExtraForm
            // 
            this.ClientSize = new System.Drawing.Size(816, 586);
            this.Controls.Add(this.btnPriceInput);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtWSPriceOut);
            this.Controls.Add(this.lstSize);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSumProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPriceOut);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtPriceIn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstColor);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtStockInId);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProductMasters);
            this.Controls.Add(this.numericUpDownBarcode);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNewProductInput);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.dtpImportDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.txtDexcription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvDeptStockIn);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainStockInExtraForm";
            this.Text = "Nhập hàng hoá";
            this.Load += new System.EventHandler(this.DepartmentStockInExtra_Load);
            this.Controls.SetChildIndex(this.dgvDeptStockIn, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDexcription, 0);
            this.Controls.SetChildIndex(this.txtSumValue, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dtpImportDate, 0);
            this.Controls.SetChildIndex(this.btnBarcode, 0);
            this.Controls.SetChildIndex(this.btnAddProduct, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.numericUpDown, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNewProductInput, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnInput, 0);
            this.Controls.SetChildIndex(this.numericUpDownBarcode, 0);
            this.Controls.SetChildIndex(this.cboProductMasters, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnPreview, 0);
            this.Controls.SetChildIndex(this.txtStockInId, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.lstColor, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtPriceIn, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.txtPriceOut, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtSumProduct, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lstSize, 0);
            this.Controls.SetChildIndex(this.txtWSPriceOut, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.btnPriceInput, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarcode)).EndInit();
            this.ctxMenuDept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Drawing.Printing.PrintDocument barcodePrintDocument;
        public System.Windows.Forms.Button btnPreview;
        public System.Windows.Forms.BindingSource bdsStockIn;
        public System.Windows.Forms.ToolStripMenuItem mnuCreateNewItem;
        public System.Windows.Forms.NumericUpDown numericUpDownBarcode;
        public System.Windows.Forms.ToolStripMenuItem mnuCreateDupItem;
        public System.Windows.Forms.ContextMenuStrip ctxMenuDept;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.TextBox txtStockInId;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.PrintDialog barcodePrintDialog;
        public System.Windows.Forms.NumericUpDown numericUpDown;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Button btnAddProduct;
        public System.Windows.Forms.Button btnBarcode;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dtpImportDate;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSumValue;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDexcription;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.HelpProvider helpProvider1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dgvDeptStockIn;
        private System.Windows.Forms.ComboBox cboProductMasters;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewProductInput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.ListBox lstColor;
        private System.Windows.Forms.ListBox lstSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource colorBindingSource;
        private System.Windows.Forms.BindingSource sizeBindingSource;
        public System.Windows.Forms.TextBox txtPriceIn;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtPriceOut;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtSumProduct;
        private System.Windows.Forms.Button btnEdit;
        private AppFrame.Controls.HotKey.SystemHotkey ctrlC;
        private AppFrame.Controls.HotKey.SystemHotkey ctrlV;
        private System.Windows.Forms.TextBox txtWSPriceOut;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPriceInput;
        private System.Windows.Forms.DataGridViewButtonColumn SearchCreate;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProducType;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnProductName;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnColor;
        private AppFrame.Controls.DataGridViewEditComboBoxColumn columnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onStorePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
