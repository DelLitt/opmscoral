namespace AppFrameClient.View
{
    partial class ProductMasterChoosingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.producttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.dgvProductMasters = new System.Windows.Forms.DataGridView();
            this.productnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmasternameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB1 = new AppFrameClient.MasterDB();
            this.dgvSelectedProductMaster = new System.Windows.Forms.DataGridView();
            this.productNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsProductMaster = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.masterDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_typeTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter();
            this.product_master_nameTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_master_nameTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productmasternameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProductMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProductType
            // 
            this.cboProductType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProductType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProductType.DataSource = this.producttypeBindingSource;
            this.cboProductType.DisplayMember = "TYPE_NAME";
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(29, 12);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(226, 21);
            this.cboProductType.TabIndex = 1;
            this.cboProductType.ValueMember = "TYPE_ID";
            // 
            // producttypeBindingSource
            // 
            this.producttypeBindingSource.DataMember = "product_type";
            this.producttypeBindingSource.DataSource = this.masterDB;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvProductMasters
            // 
            this.dgvProductMasters.AllowUserToAddRows = false;
            this.dgvProductMasters.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvProductMasters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductMasters.AutoGenerateColumns = false;
            this.dgvProductMasters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProductMasters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductMasters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productnameDataGridViewTextBoxColumn});
            this.dgvProductMasters.DataSource = this.productmasternameBindingSource;
            this.dgvProductMasters.Location = new System.Drawing.Point(29, 39);
            this.dgvProductMasters.Name = "dgvProductMasters";
            this.dgvProductMasters.ReadOnly = true;
            this.dgvProductMasters.RowHeadersVisible = false;
            this.dgvProductMasters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductMasters.Size = new System.Drawing.Size(226, 293);
            this.dgvProductMasters.TabIndex = 2;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            this.productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            this.productnameDataGridViewTextBoxColumn.HeaderText = "Tên sản phẩm";
            this.productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            this.productnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productnameDataGridViewTextBoxColumn.Width = 210;
            // 
            // productmasternameBindingSource
            // 
            this.productmasternameBindingSource.DataMember = "product_master_name";
            this.productmasternameBindingSource.DataSource = this.masterDB1;
            // 
            // masterDB1
            // 
            this.masterDB1.DataSetName = "MasterDB";
            this.masterDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvSelectedProductMaster
            // 
            this.dgvSelectedProductMaster.AllowUserToAddRows = false;
            this.dgvSelectedProductMaster.AllowUserToDeleteRows = false;
            this.dgvSelectedProductMaster.AutoGenerateColumns = false;
            this.dgvSelectedProductMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedProductMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn1});
            this.dgvSelectedProductMaster.DataSource = this.bdsProductMaster;
            this.dgvSelectedProductMaster.Location = new System.Drawing.Point(340, 39);
            this.dgvSelectedProductMaster.Name = "dgvSelectedProductMaster";
            this.dgvSelectedProductMaster.ReadOnly = true;
            this.dgvSelectedProductMaster.RowHeadersVisible = false;
            this.dgvSelectedProductMaster.Size = new System.Drawing.Size(218, 293);
            this.dgvSelectedProductMaster.TabIndex = 3;
            this.dgvSelectedProductMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedProductMaster_CellContentClick);
            // 
            // productNameDataGridViewTextBoxColumn1
            // 
            this.productNameDataGridViewTextBoxColumn1.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn1.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn1.Name = "productNameDataGridViewTextBoxColumn1";
            this.productNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn1.Width = 210;
            // 
            // bdsProductMaster
            // 
            this.bdsProductMaster.DataSource = typeof(AppFrame.Model.ProductMaster);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(413, 371);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Chọn";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(505, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(261, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "-->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAll.Location = new System.Drawing.Point(262, 106);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(72, 23);
            this.btnAddAll.TabIndex = 7;
            this.btnAddAll.Text = "-->>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(261, 144);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(72, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "<--";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAll.Location = new System.Drawing.Point(261, 173);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(72, 23);
            this.btnRemoveAll.TabIndex = 9;
            this.btnRemoveAll.Text = "<<--";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // masterDBBindingSource
            // 
            this.masterDBBindingSource.DataSource = this.masterDB;
            this.masterDBBindingSource.Position = 0;
            // 
            // product_typeTableAdapter
            // 
            this.product_typeTableAdapter.ClearBeforeFill = true;
            // 
            // product_master_nameTableAdapter
            // 
            this.product_master_nameTableAdapter.ClearBeforeFill = true;
            // 
            // ProductMasterChoosingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 424);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboProductType);
            this.Controls.Add(this.dgvSelectedProductMaster);
            this.Controls.Add(this.dgvProductMasters);
            this.Name = "ProductMasterChoosingForm";
            this.Text = "Chọn sản phẩm cần xuất";
            this.Load += new System.EventHandler(this.ProductMasterChoosingForm_Load);
            this.Controls.SetChildIndex(this.dgvProductMasters, 0);
            this.Controls.SetChildIndex(this.dgvSelectedProductMaster, 0);
            this.Controls.SetChildIndex(this.cboProductType, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnAddAll, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.btnRemoveAll, 0);
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productmasternameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProductMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.DataGridView dgvProductMasters;
        private System.Windows.Forms.DataGridView dgvSelectedProductMaster;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.BindingSource masterDBBindingSource;
        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource producttypeBindingSource;
        private AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter product_typeTableAdapter;
        private System.Windows.Forms.BindingSource productmasternameBindingSource;
        private MasterDB masterDB1;
        private AppFrameClient.MasterDBTableAdapters.product_master_nameTableAdapter product_master_nameTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bdsProductMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn1;
    }
}