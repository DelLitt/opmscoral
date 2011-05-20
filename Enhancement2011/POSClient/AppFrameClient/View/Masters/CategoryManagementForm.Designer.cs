namespace AppFrameClient.View.Masters
{
    partial class CategoryManagementForm
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
            this.dgvPopulateTypes = new System.Windows.Forms.DataGridView();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.masterDB = new AppFrameClient.MasterDB();
            this.producttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_typeTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter();
            this.tYPEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tYPENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dELFLGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masterDB1 = new AppFrameClient.MasterDB();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new AppFrameClient.MasterDBTableAdapters.categoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopulateTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopulateTypes
            // 
            this.dgvPopulateTypes.AllowUserToAddRows = false;
            this.dgvPopulateTypes.AllowUserToDeleteRows = false;
            this.dgvPopulateTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopulateTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvPopulateTypes.Location = new System.Drawing.Point(366, 63);
            this.dgvPopulateTypes.Name = "dgvPopulateTypes";
            this.dgvPopulateTypes.ReadOnly = true;
            this.dgvPopulateTypes.RowHeadersVisible = false;
            this.dgvPopulateTypes.Size = new System.Drawing.Size(240, 351);
            this.dgvPopulateTypes.TabIndex = 0;
            // 
            // cboCategory
            // 
            this.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategory.DataSource = this.categoryBindingSource;
            this.cboCategory.DisplayMember = "CATEGORY_NAME";
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(366, 36);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(240, 21);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.ValueMember = "CATEGORY_ID";
            // 
            // dgvTypes
            // 
            this.dgvTypes.AllowUserToAddRows = false;
            this.dgvTypes.AllowUserToDeleteRows = false;
            this.dgvTypes.AutoGenerateColumns = false;
            this.dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tYPEIDDataGridViewTextBoxColumn,
            this.tYPENAMEDataGridViewTextBoxColumn,
            this.cREATEDATEDataGridViewTextBoxColumn,
            this.cREATEIDDataGridViewTextBoxColumn,
            this.uPDATEDATEDataGridViewTextBoxColumn,
            this.uPDATEIDDataGridViewTextBoxColumn,
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn,
            this.dELFLGDataGridViewTextBoxColumn});
            this.dgvTypes.DataSource = this.producttypeBindingSource;
            this.dgvTypes.Location = new System.Drawing.Point(22, 63);
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.ReadOnly = true;
            this.dgvTypes.RowHeadersVisible = false;
            this.dgvTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypes.Size = new System.Drawing.Size(257, 351);
            this.dgvTypes.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(285, 63);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(54, 23);
            this.btnAddAll.TabIndex = 4;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(285, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(285, 121);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(54, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(285, 150);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(54, 23);
            this.btnRemoveAll.TabIndex = 7;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(450, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(531, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // producttypeBindingSource
            // 
            this.producttypeBindingSource.DataMember = "product_type";
            this.producttypeBindingSource.DataSource = this.masterDB;
            // 
            // product_typeTableAdapter
            // 
            this.product_typeTableAdapter.ClearBeforeFill = true;
            // 
            // tYPEIDDataGridViewTextBoxColumn
            // 
            this.tYPEIDDataGridViewTextBoxColumn.DataPropertyName = "TYPE_ID";
            this.tYPEIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.tYPEIDDataGridViewTextBoxColumn.Name = "tYPEIDDataGridViewTextBoxColumn";
            this.tYPEIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // tYPENAMEDataGridViewTextBoxColumn
            // 
            this.tYPENAMEDataGridViewTextBoxColumn.DataPropertyName = "TYPE_NAME";
            this.tYPENAMEDataGridViewTextBoxColumn.HeaderText = "Tên chủng loại";
            this.tYPENAMEDataGridViewTextBoxColumn.Name = "tYPENAMEDataGridViewTextBoxColumn";
            this.tYPENAMEDataGridViewTextBoxColumn.Width = 200;
            // 
            // cREATEDATEDataGridViewTextBoxColumn
            // 
            this.cREATEDATEDataGridViewTextBoxColumn.DataPropertyName = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn.HeaderText = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn.Name = "cREATEDATEDataGridViewTextBoxColumn";
            this.cREATEDATEDataGridViewTextBoxColumn.Visible = false;
            // 
            // cREATEIDDataGridViewTextBoxColumn
            // 
            this.cREATEIDDataGridViewTextBoxColumn.DataPropertyName = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn.HeaderText = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn.Name = "cREATEIDDataGridViewTextBoxColumn";
            this.cREATEIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // uPDATEDATEDataGridViewTextBoxColumn
            // 
            this.uPDATEDATEDataGridViewTextBoxColumn.DataPropertyName = "UPDATE_DATE";
            this.uPDATEDATEDataGridViewTextBoxColumn.HeaderText = "UPDATE_DATE";
            this.uPDATEDATEDataGridViewTextBoxColumn.Name = "uPDATEDATEDataGridViewTextBoxColumn";
            this.uPDATEDATEDataGridViewTextBoxColumn.Visible = false;
            // 
            // uPDATEIDDataGridViewTextBoxColumn
            // 
            this.uPDATEIDDataGridViewTextBoxColumn.DataPropertyName = "UPDATE_ID";
            this.uPDATEIDDataGridViewTextBoxColumn.HeaderText = "UPDATE_ID";
            this.uPDATEIDDataGridViewTextBoxColumn.Name = "uPDATEIDDataGridViewTextBoxColumn";
            this.uPDATEIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // eXCLUSIVEKEYDataGridViewTextBoxColumn
            // 
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn.DataPropertyName = "EXCLUSIVE_KEY";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn.HeaderText = "EXCLUSIVE_KEY";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn.Name = "eXCLUSIVEKEYDataGridViewTextBoxColumn";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn.Visible = false;
            // 
            // dELFLGDataGridViewTextBoxColumn
            // 
            this.dELFLGDataGridViewTextBoxColumn.DataPropertyName = "DEL_FLG";
            this.dELFLGDataGridViewTextBoxColumn.HeaderText = "DEL_FLG";
            this.dELFLGDataGridViewTextBoxColumn.Name = "dELFLGDataGridViewTextBoxColumn";
            this.dELFLGDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên chủng loại";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 180;
            // 
            // masterDB1
            // 
            this.masterDB1.DataSetName = "MasterDB";
            this.masterDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "category";
            this.categoryBindingSource.DataSource = this.masterDB1;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // CategoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 469);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvTypes);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.dgvPopulateTypes);
            this.Name = "CategoryManagementForm";
            this.Text = "CategoryManagementForm";
            this.Load += new System.EventHandler(this.CategoryManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopulateTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPopulateTypes;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.DataGridView dgvTypes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource producttypeBindingSource;
        private AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter product_typeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXCLUSIVEKEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private MasterDB masterDB1;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private AppFrameClient.MasterDBTableAdapters.categoryTableAdapter categoryTableAdapter;
    }
}