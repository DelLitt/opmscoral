namespace AppFrameClient.View
{
    partial class ExportDeptStockDefinitionForm
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
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.dgvDeptStock = new System.Windows.Forms.DataGridView();
            this.productmasteridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptstockdeffileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deptstock_def_fileTableAdapter = new AppFrameClient.MasterDBTableAdapters.deptstock_def_fileTableAdapter();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTypes = new System.Windows.Forms.ComboBox();
            this.lblLabel2 = new System.Windows.Forms.Label();
            this.departmentTableAdapter = new AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter();
            this.dgvMainStock = new System.Windows.Forms.DataGridView();
            this.typenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockdeffileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB1 = new AppFrameClient.MasterDB();
            this.stock_def_fileTableAdapter = new AppFrameClient.MasterDBTableAdapters.stock_def_fileTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptstockdeffileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockdeffileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDepartment
            // 
            this.cboDepartment.DataSource = this.departmentBindingSource1;
            this.cboDepartment.DisplayMember = "DepartmentName";
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(13, 41);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(305, 21);
            this.cboDepartment.TabIndex = 0;
            this.cboDepartment.ValueMember = "DepartmentId";
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // departmentBindingSource1
            // 
            this.departmentBindingSource1.DataSource = typeof(AppFrame.Model.Department);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.masterDB;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDeptStock
            // 
            this.dgvDeptStock.AllowUserToAddRows = false;
            this.dgvDeptStock.AllowUserToDeleteRows = false;
            this.dgvDeptStock.AutoGenerateColumns = false;
            this.dgvDeptStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productmasteridDataGridViewTextBoxColumn,
            this.productnameDataGridViewTextBoxColumn,
            this.productidDataGridViewTextBoxColumn});
            this.dgvDeptStock.DataSource = this.deptstockdeffileBindingSource;
            this.dgvDeptStock.Location = new System.Drawing.Point(13, 119);
            this.dgvDeptStock.Name = "dgvDeptStock";
            this.dgvDeptStock.RowHeadersVisible = false;
            this.dgvDeptStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeptStock.Size = new System.Drawing.Size(453, 306);
            this.dgvDeptStock.TabIndex = 1;
            // 
            // productmasteridDataGridViewTextBoxColumn
            // 
            this.productmasteridDataGridViewTextBoxColumn.DataPropertyName = "type_name";
            this.productmasteridDataGridViewTextBoxColumn.HeaderText = "Loại SP";
            this.productmasteridDataGridViewTextBoxColumn.Name = "productmasteridDataGridViewTextBoxColumn";
            this.productmasteridDataGridViewTextBoxColumn.Width = 150;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            this.productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            this.productnameDataGridViewTextBoxColumn.HeaderText = "Tên SP";
            this.productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            this.productnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // productidDataGridViewTextBoxColumn
            // 
            this.productidDataGridViewTextBoxColumn.DataPropertyName = "product_id";
            this.productidDataGridViewTextBoxColumn.HeaderText = "Mã vạch";
            this.productidDataGridViewTextBoxColumn.Name = "productidDataGridViewTextBoxColumn";
            this.productidDataGridViewTextBoxColumn.Width = 150;
            // 
            // deptstockdeffileBindingSource
            // 
            this.deptstockdeffileBindingSource.DataMember = "deptstock_def_file";
            this.deptstockdeffileBindingSource.DataSource = this.masterDB;
            // 
            // deptstock_def_fileTableAdapter
            // 
            this.deptstock_def_fileTableAdapter.ClearBeforeFill = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(333, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 72);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Xuất file định nghĩa";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cửa hàng";
            // 
            // cboTypes
            // 
            this.cboTypes.FormattingEnabled = true;
            this.cboTypes.Location = new System.Drawing.Point(13, 92);
            this.cboTypes.Name = "cboTypes";
            this.cboTypes.Size = new System.Drawing.Size(305, 21);
            this.cboTypes.TabIndex = 4;
            // 
            // lblLabel2
            // 
            this.lblLabel2.AutoSize = true;
            this.lblLabel2.Location = new System.Drawing.Point(16, 69);
            this.lblLabel2.Name = "lblLabel2";
            this.lblLabel2.Size = new System.Drawing.Size(66, 15);
            this.lblLabel2.TabIndex = 5;
            this.lblLabel2.Text = "Chủng loại";
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // dgvMainStock
            // 
            this.dgvMainStock.AllowUserToAddRows = false;
            this.dgvMainStock.AllowUserToDeleteRows = false;
            this.dgvMainStock.AutoGenerateColumns = false;
            this.dgvMainStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typenameDataGridViewTextBoxColumn,
            this.productnameDataGridViewTextBoxColumn1,
            this.productidDataGridViewTextBoxColumn1});
            this.dgvMainStock.DataSource = this.stockdeffileBindingSource;
            this.dgvMainStock.Location = new System.Drawing.Point(13, 119);
            this.dgvMainStock.Name = "dgvMainStock";
            this.dgvMainStock.ReadOnly = true;
            this.dgvMainStock.RowHeadersVisible = false;
            this.dgvMainStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainStock.Size = new System.Drawing.Size(452, 306);
            this.dgvMainStock.TabIndex = 6;
            this.dgvMainStock.Visible = false;
            // 
            // typenameDataGridViewTextBoxColumn
            // 
            this.typenameDataGridViewTextBoxColumn.DataPropertyName = "type_name";
            this.typenameDataGridViewTextBoxColumn.HeaderText = "Loại SP";
            this.typenameDataGridViewTextBoxColumn.Name = "typenameDataGridViewTextBoxColumn";
            this.typenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.typenameDataGridViewTextBoxColumn.Width = 150;
            // 
            // productnameDataGridViewTextBoxColumn1
            // 
            this.productnameDataGridViewTextBoxColumn1.DataPropertyName = "product_name";
            this.productnameDataGridViewTextBoxColumn1.HeaderText = "Tên SP";
            this.productnameDataGridViewTextBoxColumn1.Name = "productnameDataGridViewTextBoxColumn1";
            this.productnameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.productnameDataGridViewTextBoxColumn1.Width = 150;
            // 
            // productidDataGridViewTextBoxColumn1
            // 
            this.productidDataGridViewTextBoxColumn1.DataPropertyName = "product_id";
            this.productidDataGridViewTextBoxColumn1.HeaderText = "Ma vach";
            this.productidDataGridViewTextBoxColumn1.Name = "productidDataGridViewTextBoxColumn1";
            this.productidDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // stockdeffileBindingSource
            // 
            this.stockdeffileBindingSource.DataMember = "stock_def_file";
            this.stockdeffileBindingSource.DataSource = this.masterDB1;
            // 
            // masterDB1
            // 
            this.masterDB1.DataSetName = "MasterDB";
            this.masterDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stock_def_fileTableAdapter
            // 
            this.stock_def_fileTableAdapter.ClearBeforeFill = true;
            // 
            // ExportDeptStockDefinitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 437);
            this.Controls.Add(this.lblLabel2);
            this.Controls.Add(this.cboTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.dgvMainStock);
            this.Controls.Add(this.dgvDeptStock);
            this.Name = "ExportDeptStockDefinitionForm";
            this.Text = "ExportDeptStockDefinitionForm";
            this.Load += new System.EventHandler(this.ExportDeptStockDefinitionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptstockdeffileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockdeffileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.DataGridView dgvDeptStock;
        private System.Windows.Forms.BindingSource deptstockdeffileBindingSource;
        private MasterDB masterDB;
        private AppFrameClient.MasterDBTableAdapters.deptstock_def_fileTableAdapter deptstock_def_fileTableAdapter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTypes;
        private System.Windows.Forms.Label lblLabel2;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.DataGridView dgvMainStock;
        private MasterDB masterDB1;
        private System.Windows.Forms.BindingSource stockdeffileBindingSource;
        private AppFrameClient.MasterDBTableAdapters.stock_def_fileTableAdapter stock_def_fileTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn typenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmasteridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource departmentBindingSource1;
    }
}