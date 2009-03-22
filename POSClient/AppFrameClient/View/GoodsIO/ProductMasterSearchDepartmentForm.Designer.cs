namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class ProductMasterSearchDepartmentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.productMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvProductMaster = new System.Windows.Forms.DataGridView();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.deptStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productMasterSearchControl = new AppFrameClient.View.GoodsIO.ProductMasterSearchControl();
            this.productMasterIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productColorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distributorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productMasterIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTypeTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productColorColorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSizeSizeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryCategoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptStockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(338, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 19);
            this.label7.TabIndex = 24;
            this.label7.Text = "TÌM HÀNG HÓA TẠI CỬA HÀNG";
            // 
            // productMasterBindingSource
            // 
            this.productMasterBindingSource.DataSource = typeof(AppFrame.Model.ProductMaster);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(834, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Bỏ qua";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(753, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(177, 81);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(697, 498);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(131, 23);
            this.btnSelect.TabIndex = 27;
            this.btnSelect.Text = "Chọn mã vạch";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvProductMaster
            // 
            this.dgvProductMaster.AllowUserToAddRows = false;
            this.dgvProductMaster.AllowUserToDeleteRows = false;
            this.dgvProductMaster.AutoGenerateColumns = false;
            this.dgvProductMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productMasterIdDataGridViewTextBoxColumn1,
            this.productNameDataGridViewTextBoxColumn1,
            this.productTypeTypeNameDataGridViewTextBoxColumn,
            this.productColorColorNameDataGridViewTextBoxColumn,
            this.productSizeSizeNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn1,
            this.categoryCategoryNameDataGridViewTextBoxColumn});
            this.dgvProductMaster.DataSource = this.productMasterBindingSource;
            this.dgvProductMaster.Location = new System.Drawing.Point(7, 138);
            this.dgvProductMaster.MultiSelect = false;
            this.dgvProductMaster.Name = "dgvProductMaster";
            this.dgvProductMaster.ReadOnly = true;
            this.dgvProductMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductMaster.Size = new System.Drawing.Size(923, 210);
            this.dgvProductMaster.TabIndex = 25;
            this.dgvProductMaster.SelectionChanged += new System.EventHandler(this.dgvProductMaster_SelectionChanged);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.updateIdDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.CreateDate,
            this.createIdDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn});
            this.dgvProducts.DataSource = this.deptStockBindingSource;
            this.dgvProducts.Location = new System.Drawing.Point(7, 354);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(923, 138);
            this.dgvProducts.TabIndex = 30;
            // 
            // deptStockBindingSource
            // 
            this.deptStockBindingSource.DataSource = typeof(AppFrame.Collection.DepartmentStockCollection);
            // 
            // ProductMaster
            // 
            this.ProductMaster.DataPropertyName = "ProductMaster.ProductFullName";
            this.ProductMaster.Frozen = true;
            this.ProductMaster.HeaderText = "Tên hàng";
            this.ProductMaster.Name = "ProductMaster";
            this.ProductMaster.ReadOnly = true;
            this.ProductMaster.Width = 270;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DepartmentStockInDetailPK.ProductId";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Mã vạch";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // createDateDataGridViewTextBoxColumn1
            // 
            this.createDateDataGridViewTextBoxColumn1.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn1.HeaderText = "Ngày nhập cửa hàng";
            this.createDateDataGridViewTextBoxColumn1.Name = "createDateDataGridViewTextBoxColumn1";
            this.createDateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.createDateDataGridViewTextBoxColumn1.Width = 140;
            // 
            // createIdDataGridViewTextBoxColumn1
            // 
            this.createIdDataGridViewTextBoxColumn1.DataPropertyName = "CreateId";
            this.createIdDataGridViewTextBoxColumn1.HeaderText = "Người nhập";
            this.createIdDataGridViewTextBoxColumn1.Name = "createIdDataGridViewTextBoxColumn1";
            this.createIdDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product.CreateDate";
            this.Product.HeaderText = "Ngày nhập kho";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Product.CreateId";
            this.Column3.HeaderText = "Người nhập kho";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // delFlgDataGridViewTextBoxColumn1
            // 
            this.delFlgDataGridViewTextBoxColumn1.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn1.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn1.Name = "delFlgDataGridViewTextBoxColumn1";
            this.delFlgDataGridViewTextBoxColumn1.ReadOnly = true;
            this.delFlgDataGridViewTextBoxColumn1.Visible = false;
            // 
            // productMasterSearchControl
            // 
            this.productMasterSearchControl.Location = new System.Drawing.Point(7, 26);
            this.productMasterSearchControl.Name = "productMasterSearchControl";
            this.productMasterSearchControl.Size = new System.Drawing.Size(740, 120);
            this.productMasterSearchControl.TabIndex = 23;
            this.productMasterSearchControl.Load += new System.EventHandler(this.productMasterSearchControl_Load);
            // 
            // productMasterIdDataGridViewTextBoxColumn
            // 
            this.productMasterIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.productMasterIdDataGridViewTextBoxColumn.DataPropertyName = "ProductMasterId";
            this.productMasterIdDataGridViewTextBoxColumn.Frozen = true;
            this.productMasterIdDataGridViewTextBoxColumn.HeaderText = "Mã hàng";
            this.productMasterIdDataGridViewTextBoxColumn.Name = "productMasterIdDataGridViewTextBoxColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Tên hàng";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // productColorDataGridViewTextBoxColumn
            // 
            this.productColorDataGridViewTextBoxColumn.DataPropertyName = "ProductColor.ColorName";
            this.productColorDataGridViewTextBoxColumn.HeaderText = "Màu sắc";
            this.productColorDataGridViewTextBoxColumn.Name = "productColorDataGridViewTextBoxColumn";
            // 
            // productSizeDataGridViewTextBoxColumn
            // 
            this.productSizeDataGridViewTextBoxColumn.DataPropertyName = "ProductSize.SizeName";
            this.productSizeDataGridViewTextBoxColumn.HeaderText = "Kích cỡ";
            this.productSizeDataGridViewTextBoxColumn.Name = "productSizeDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Mô tả";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 250;
            // 
            // distributorDataGridViewTextBoxColumn
            // 
            this.distributorDataGridViewTextBoxColumn.DataPropertyName = "Distributor.DistributorName";
            this.distributorDataGridViewTextBoxColumn.HeaderText = "Phân phối";
            this.distributorDataGridViewTextBoxColumn.Name = "distributorDataGridViewTextBoxColumn";
            // 
            // productMasterIdDataGridViewTextBoxColumn1
            // 
            this.productMasterIdDataGridViewTextBoxColumn1.DataPropertyName = "ProductMasterId";
            this.productMasterIdDataGridViewTextBoxColumn1.Frozen = true;
            this.productMasterIdDataGridViewTextBoxColumn1.HeaderText = "Mã sản phẩm";
            this.productMasterIdDataGridViewTextBoxColumn1.Name = "productMasterIdDataGridViewTextBoxColumn1";
            this.productMasterIdDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn1
            // 
            this.productNameDataGridViewTextBoxColumn1.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn1.Frozen = true;
            this.productNameDataGridViewTextBoxColumn1.HeaderText = "Tên sản phẩm";
            this.productNameDataGridViewTextBoxColumn1.Name = "productNameDataGridViewTextBoxColumn1";
            this.productNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn1.Width = 300;
            // 
            // productTypeTypeNameDataGridViewTextBoxColumn
            // 
            this.productTypeTypeNameDataGridViewTextBoxColumn.DataPropertyName = "ProductType.TypeName";
            this.productTypeTypeNameDataGridViewTextBoxColumn.HeaderText = "Chủng loại";
            this.productTypeTypeNameDataGridViewTextBoxColumn.Name = "productTypeTypeNameDataGridViewTextBoxColumn";
            this.productTypeTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productColorColorNameDataGridViewTextBoxColumn
            // 
            this.productColorColorNameDataGridViewTextBoxColumn.DataPropertyName = "ProductColor.ColorName";
            this.productColorColorNameDataGridViewTextBoxColumn.HeaderText = "Màu sắc";
            this.productColorColorNameDataGridViewTextBoxColumn.Name = "productColorColorNameDataGridViewTextBoxColumn";
            this.productColorColorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productSizeSizeNameDataGridViewTextBoxColumn
            // 
            this.productSizeSizeNameDataGridViewTextBoxColumn.DataPropertyName = "ProductSize.SizeName";
            this.productSizeSizeNameDataGridViewTextBoxColumn.HeaderText = "Kích cỡ";
            this.productSizeSizeNameDataGridViewTextBoxColumn.Name = "productSizeSizeNameDataGridViewTextBoxColumn";
            this.productSizeSizeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Diễn giải";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn1.Width = 180;
            // 
            // categoryCategoryNameDataGridViewTextBoxColumn
            // 
            this.categoryCategoryNameDataGridViewTextBoxColumn.DataPropertyName = "Category.CategoryName";
            this.categoryCategoryNameDataGridViewTextBoxColumn.HeaderText = "Chủng loại";
            this.categoryCategoryNameDataGridViewTextBoxColumn.Name = "categoryCategoryNameDataGridViewTextBoxColumn";
            this.categoryCategoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryCategoryNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DepartmentStockPK.ProductId";
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Mã vạch";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // updateIdDataGridViewTextBoxColumn
            // 
            this.updateIdDataGridViewTextBoxColumn.DataPropertyName = "GoodQuantity";
            this.updateIdDataGridViewTextBoxColumn.Frozen = true;
            this.updateIdDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.updateIdDataGridViewTextBoxColumn.Name = "updateIdDataGridViewTextBoxColumn";
            this.updateIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Product.ProductMaster.ProductFullName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Diễn giải tên hàng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 330;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "UpdateDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreateDate.HeaderText = "Ngày cập nhật";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 150;
            // 
            // createIdDataGridViewTextBoxColumn
            // 
            this.createIdDataGridViewTextBoxColumn.DataPropertyName = "UpdateId";
            this.createIdDataGridViewTextBoxColumn.HeaderText = "Người cập nhật";
            this.createIdDataGridViewTextBoxColumn.Name = "createIdDataGridViewTextBoxColumn";
            this.createIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.createIdDataGridViewTextBoxColumn.Width = 200;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // ProductMasterSearchDepartmentForm
            // 
            this.ClientSize = new System.Drawing.Size(942, 531);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvProductMaster);
            this.Controls.Add(this.productMasterSearchControl);
            this.Name = "ProductMasterSearchDepartmentForm";
            this.Load += new System.EventHandler(this.ProductMasterSearchDepartmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptStockBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource productMasterBindingSource;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvProductMaster;
        private ProductMasterSearchControl productMasterSearchControl;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.BindingSource deptStockBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productMasterIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productColorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distributorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productMasterIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productColorColorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSizeSizeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryCategoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
    }
}
