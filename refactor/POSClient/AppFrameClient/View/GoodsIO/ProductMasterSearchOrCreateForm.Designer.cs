namespace AppFrameClient.View.GoodsIO
{
    partial class ProductMasterSearchOrCreateForm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.productMasterTabControl = new System.Windows.Forms.TabControl();
            this.productMasterSearchTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvProductMaster = new System.Windows.Forms.DataGridView();
            this.productMasterIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusiveKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productColorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distributorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productMasterSearchControl = new AppFrameClient.View.GoodsIO.ProductMasterSearchControl();
            this.productMasterTabControl.SuspendLayout();
            this.productMasterSearchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 503);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // productMasterTabControl
            // 
            this.productMasterTabControl.Controls.Add(this.productMasterSearchTab);
            this.productMasterTabControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productMasterTabControl.Location = new System.Drawing.Point(0, 0);
            this.productMasterTabControl.Name = "productMasterTabControl";
            this.productMasterTabControl.SelectedIndex = 0;
            this.productMasterTabControl.Size = new System.Drawing.Size(996, 503);
            this.productMasterTabControl.TabIndex = 2;
            // 
            // productMasterSearchTab
            // 
            this.productMasterSearchTab.Controls.Add(this.label8);
            this.productMasterSearchTab.Controls.Add(this.btnSelect);
            this.productMasterSearchTab.Controls.Add(this.btnCancel);
            this.productMasterSearchTab.Controls.Add(this.btnSearch);
            this.productMasterSearchTab.Controls.Add(this.dgvProductMaster);
            this.productMasterSearchTab.Controls.Add(this.productMasterSearchControl);
            this.productMasterSearchTab.Location = new System.Drawing.Point(4, 23);
            this.productMasterSearchTab.Name = "productMasterSearchTab";
            this.productMasterSearchTab.Padding = new System.Windows.Forms.Padding(3);
            this.productMasterSearchTab.Size = new System.Drawing.Size(988, 476);
            this.productMasterSearchTab.TabIndex = 0;
            this.productMasterSearchTab.Text = "Tìm kiếm mặt hàng";
            this.productMasterSearchTab.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(285, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "CHI TIẾT SẢN PHẨM";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(823, 453);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(910, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(790, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvProductMaster
            // 
            this.dgvProductMaster.AllowUserToAddRows = false;
            this.dgvProductMaster.AllowUserToDeleteRows = false;
            this.dgvProductMaster.AllowUserToOrderColumns = true;
            this.dgvProductMaster.AutoGenerateColumns = false;
            this.dgvProductMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productMasterIdDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.supplierIdDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.createIdDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.updateIdDataGridViewTextBoxColumn,
            this.exclusiveKeyDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn,
            this.productTypeDataGridViewTextBoxColumn,
            this.productColorDataGridViewTextBoxColumn,
            this.productSizeDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.distributorDataGridViewTextBoxColumn,
            this.packagerDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.Column1});
            this.dgvProductMaster.DataSource = this.productMasterBindingSource;
            this.dgvProductMaster.Location = new System.Drawing.Point(9, 150);
            this.dgvProductMaster.MultiSelect = false;
            this.dgvProductMaster.Name = "dgvProductMaster";
            this.dgvProductMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductMaster.Size = new System.Drawing.Size(976, 297);
            this.dgvProductMaster.TabIndex = 1;
            this.dgvProductMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductMaster_CellDoubleClick);
            // 
            // productMasterIdDataGridViewTextBoxColumn
            // 
            this.productMasterIdDataGridViewTextBoxColumn.DataPropertyName = "ProductMasterId";
            this.productMasterIdDataGridViewTextBoxColumn.HeaderText = "Mã hàng";
            this.productMasterIdDataGridViewTextBoxColumn.Name = "productMasterIdDataGridViewTextBoxColumn";
            this.productMasterIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Tên hàng";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // supplierIdDataGridViewTextBoxColumn
            // 
            this.supplierIdDataGridViewTextBoxColumn.DataPropertyName = "SupplierId";
            this.supplierIdDataGridViewTextBoxColumn.HeaderText = "SupplierId";
            this.supplierIdDataGridViewTextBoxColumn.Name = "supplierIdDataGridViewTextBoxColumn";
            this.supplierIdDataGridViewTextBoxColumn.Visible = false;
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
            // productTypeDataGridViewTextBoxColumn
            // 
            this.productTypeDataGridViewTextBoxColumn.DataPropertyName = "ProductType.TypeName";
            this.productTypeDataGridViewTextBoxColumn.HeaderText = "Chủng loại";
            this.productTypeDataGridViewTextBoxColumn.Name = "productTypeDataGridViewTextBoxColumn";
            this.productTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productColorDataGridViewTextBoxColumn
            // 
            this.productColorDataGridViewTextBoxColumn.DataPropertyName = "ProductColor.ColorName";
            this.productColorDataGridViewTextBoxColumn.HeaderText = "Màu sắc";
            this.productColorDataGridViewTextBoxColumn.Name = "productColorDataGridViewTextBoxColumn";
            this.productColorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productSizeDataGridViewTextBoxColumn
            // 
            this.productSizeDataGridViewTextBoxColumn.DataPropertyName = "ProductSize.SizeName";
            this.productSizeDataGridViewTextBoxColumn.HeaderText = "Kích cỡ";
            this.productSizeDataGridViewTextBoxColumn.Name = "productSizeDataGridViewTextBoxColumn";
            this.productSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer.ManufacturerName";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Sản xuất";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country.CountryName";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Xuất xứ";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // distributorDataGridViewTextBoxColumn
            // 
            this.distributorDataGridViewTextBoxColumn.DataPropertyName = "Distributor.DistributorName";
            this.distributorDataGridViewTextBoxColumn.HeaderText = "Phân phối";
            this.distributorDataGridViewTextBoxColumn.Name = "distributorDataGridViewTextBoxColumn";
            this.distributorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packagerDataGridViewTextBoxColumn
            // 
            this.packagerDataGridViewTextBoxColumn.DataPropertyName = "Packager.PackagerName";
            this.packagerDataGridViewTextBoxColumn.HeaderText = "Đóng gói";
            this.packagerDataGridViewTextBoxColumn.Name = "packagerDataGridViewTextBoxColumn";
            this.packagerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // productMasterBindingSource
            // 
            this.productMasterBindingSource.DataSource = typeof(AppFrame.Model.ProductMaster);
            // 
            // productMasterSearchControl
            // 
            this.productMasterSearchControl.Location = new System.Drawing.Point(9, 24);
            this.productMasterSearchControl.Name = "productMasterSearchControl";
            this.productMasterSearchControl.Size = new System.Drawing.Size(976, 120);
            this.productMasterSearchControl.TabIndex = 0;
            // 
            // ProductMasterSearchOrCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 503);
            this.Controls.Add(this.productMasterTabControl);
            this.Controls.Add(this.splitter1);
            this.Name = "ProductMasterSearchOrCreateForm";
            this.Text = "ProductMasterSearchOrCreateForm";
            this.Load += new System.EventHandler(this.ProductMasterSearchOrCreateForm_Load);
            this.productMasterTabControl.ResumeLayout(false);
            this.productMasterSearchTab.ResumeLayout(false);
            this.productMasterSearchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl productMasterTabControl;
        private System.Windows.Forms.TabPage productMasterSearchTab;
        private System.Windows.Forms.DataGridView dgvProductMaster;
        private ProductMasterSearchControl productMasterSearchControl;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource productMasterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productMasterIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusiveKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productColorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distributorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
    }
}