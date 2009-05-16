namespace AppFrameClient.View.GoodsIO.MainStock
{
    partial class MainStockInSearchReportForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onStorePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsStockIn = new System.Windows.Forms.BindingSource(this.components);
            this.chkImportDateTo = new System.Windows.Forms.CheckBox();
            this.chkImportDateFrom = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpImportDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpImportDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlockInDetailId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(336, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 19);
            this.label7.TabIndex = 56;
            this.label7.Text = "BÁO CÁO NHẬP HÀNG";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(718, 406);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(132, 23);
            this.btnSelect.TabIndex = 55;
            this.btnSelect.Text = "Xuất ra Excel";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(856, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Column1,
            this.Column2,
            this.Column3,
            this.quantityDataGridViewTextBoxColumn,
            this.onStorePriceDataGridViewTextBoxColumn,
            this.createIdDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.DelFlg});
            this.dgvProduct.DataSource = this.bdsStockIn;
            this.dgvProduct.Location = new System.Drawing.Point(14, 90);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(917, 310);
            this.dgvProduct.TabIndex = 53;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product.ProductMaster.ProductName";
            this.Product.Frozen = true;
            this.Product.HeaderText = "Tên sản phẩm";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 200;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.Column1.HeaderText = "Màu sắc";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.Column2.HeaderText = "Kích cỡ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Product.ProductMaster.ProductType.TypeName";
            this.Column3.HeaderText = "Chủng loại";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // onStorePriceDataGridViewTextBoxColumn
            // 
            this.onStorePriceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.onStorePriceDataGridViewTextBoxColumn.HeaderText = "Giá nhập vào";
            this.onStorePriceDataGridViewTextBoxColumn.Name = "onStorePriceDataGridViewTextBoxColumn";
            this.onStorePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createIdDataGridViewTextBoxColumn
            // 
            this.createIdDataGridViewTextBoxColumn.DataPropertyName = "CreateId";
            this.createIdDataGridViewTextBoxColumn.HeaderText = "Người nhập";
            this.createIdDataGridViewTextBoxColumn.Name = "createIdDataGridViewTextBoxColumn";
            this.createIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "Ngày nhập";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DelFlg
            // 
            this.DelFlg.DataPropertyName = "DelFlg";
            this.DelFlg.HeaderText = "DelFlg";
            this.DelFlg.Name = "DelFlg";
            this.DelFlg.ReadOnly = true;
            this.DelFlg.Visible = false;
            // 
            // bdsStockIn
            // 
            this.bdsStockIn.DataSource = typeof(AppFrame.Collection.DepartmentStockInDetailCollection);
            // 
            // chkImportDateTo
            // 
            this.chkImportDateTo.AutoSize = true;
            this.chkImportDateTo.Location = new System.Drawing.Point(478, 64);
            this.chkImportDateTo.Name = "chkImportDateTo";
            this.chkImportDateTo.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateTo.TabIndex = 52;
            this.chkImportDateTo.UseVisualStyleBackColor = true;
            this.chkImportDateTo.CheckedChanged += new System.EventHandler(this.chkImportDateTo_CheckedChanged);
            // 
            // chkImportDateFrom
            // 
            this.chkImportDateFrom.AutoSize = true;
            this.chkImportDateFrom.Location = new System.Drawing.Point(478, 40);
            this.chkImportDateFrom.Name = "chkImportDateFrom";
            this.chkImportDateFrom.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateFrom.TabIndex = 51;
            this.chkImportDateFrom.UseVisualStyleBackColor = true;
            this.chkImportDateFrom.CheckedChanged += new System.EventHandler(this.chkImportDateFrom_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(541, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 49);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpImportDateTo
            // 
            this.dtpImportDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateTo.Enabled = false;
            this.dtpImportDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateTo.Location = new System.Drawing.Point(359, 64);
            this.dtpImportDateTo.Name = "dtpImportDateTo";
            this.dtpImportDateTo.Size = new System.Drawing.Size(113, 20);
            this.dtpImportDateTo.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Nhập kho đến ngày";
            // 
            // dtpImportDateFrom
            // 
            this.dtpImportDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateFrom.Enabled = false;
            this.dtpImportDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateFrom.Location = new System.Drawing.Point(359, 36);
            this.dtpImportDateFrom.Name = "dtpImportDateFrom";
            this.dtpImportDateFrom.Size = new System.Drawing.Size(113, 20);
            this.dtpImportDateFrom.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Nhập kho từ ngày";
            // 
            // txtBlockInDetailId
            // 
            this.txtBlockInDetailId.Location = new System.Drawing.Point(57, 38);
            this.txtBlockInDetailId.Name = "txtBlockInDetailId";
            this.txtBlockInDetailId.Size = new System.Drawing.Size(163, 20);
            this.txtBlockInDetailId.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Mã lô";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Report (*.xls)|*.xls";
            // 
            // MainStockInSearchReportForm
            // 
            this.ClientSize = new System.Drawing.Size(942, 433);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.chkImportDateTo);
            this.Controls.Add(this.chkImportDateFrom);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpImportDateTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpImportDateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBlockInDetailId);
            this.Controls.Add(this.label1);
            this.Name = "MainStockInSearchReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.CheckBox chkImportDateTo;
        private System.Windows.Forms.CheckBox chkImportDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpImportDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpImportDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlockInDetailId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsStockIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentStockInDetailPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onStorePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelFlg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
