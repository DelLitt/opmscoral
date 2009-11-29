namespace AppFrameClient.View
{
    partial class DeptStockEvaluationComparingForm
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
            this.cboDepartments = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboTypes = new System.Windows.Forms.ComboBox();
            this.cboTypeBds = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDeptStock = new System.Windows.Forms.DataGridView();
            this.tYPEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tYPENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLORNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIZENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLThucColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockqtyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB1 = new AppFrameClient.MasterDB();
            this.btnImportResult = new System.Windows.Forms.Button();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.tYPEIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tYPENAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTNAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLORNAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIZENAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainSLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainSLThucColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainstkqtyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB3 = new AppFrameClient.MasterDB();
            this.masterDB = new AppFrameClient.MasterDB();
            this.deptBS_Master = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter = new AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter();
            this.chkDifferent = new System.Windows.Forms.CheckBox();
            this.stockqtyTableAdapter = new AppFrameClient.MasterDBTableAdapters.stockqtyTableAdapter();
            this.masterDB2 = new AppFrameClient.MasterDB();
            this.producttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_typeTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter();
            this.typeViewObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainstkqtyTableAdapter = new AppFrameClient.MasterDBTableAdapters.mainstkqtyTableAdapter();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtSLThuc = new System.Windows.Forms.TextBox();
            this.chkSLEquals = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stockevaluationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB4 = new AppFrameClient.MasterDB();
            this.stock_evaluationTableAdapter = new AppFrameClient.MasterDBTableAdapters.stock_evaluationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTypeBds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockqtyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainstkqtyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptBS_Master)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeViewObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockevaluationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB4)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDepartments
            // 
            this.cboDepartments.DataSource = this.departmentBindingSource;
            this.cboDepartments.DisplayMember = "DepartmentName";
            this.cboDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartments.FormattingEnabled = true;
            this.cboDepartments.Location = new System.Drawing.Point(12, 25);
            this.cboDepartments.Name = "cboDepartments";
            this.cboDepartments.Size = new System.Drawing.Size(252, 21);
            this.cboDepartments.TabIndex = 0;
            this.cboDepartments.ValueMember = "DepartmentId";
            this.cboDepartments.SelectedIndexChanged += new System.EventHandler(this.cboDepartments_SelectedIndexChanged);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(AppFrame.Model.Department);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cửa hàng";
            // 
            // cboTypes
            // 
            this.cboTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTypes.DataSource = this.cboTypeBds;
            this.cboTypes.DisplayMember = "TypeName";
            this.cboTypes.FormattingEnabled = true;
            this.cboTypes.Location = new System.Drawing.Point(300, 26);
            this.cboTypes.Name = "cboTypes";
            this.cboTypes.Size = new System.Drawing.Size(252, 21);
            this.cboTypes.TabIndex = 2;
            this.cboTypes.ValueMember = "TypeId";
            this.cboTypes.SelectedIndexChanged += new System.EventHandler(this.cboTypes_SelectedIndexChanged);
            // 
            // cboTypeBds
            // 
            this.cboTypeBds.DataSource = typeof(AppFrame.Model.ProductType);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chủng loại";
            // 
            // dgvDeptStock
            // 
            this.dgvDeptStock.AllowUserToAddRows = false;
            this.dgvDeptStock.AutoGenerateColumns = false;
            this.dgvDeptStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tYPEIDDataGridViewTextBoxColumn,
            this.tYPENAMEDataGridViewTextBoxColumn,
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn,
            this.pRODUCTNAMEDataGridViewTextBoxColumn,
            this.cOLORNAMEDataGridViewTextBoxColumn,
            this.sIZENAMEDataGridViewTextBoxColumn,
            this.pRODUCTIDDataGridViewTextBoxColumn,
            this.SLColumn,
            this.SLThucColumn});
            this.dgvDeptStock.DataSource = this.stockqtyBindingSource;
            this.dgvDeptStock.Location = new System.Drawing.Point(12, 127);
            this.dgvDeptStock.Name = "dgvDeptStock";
            this.dgvDeptStock.RowHeadersVisible = false;
            this.dgvDeptStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeptStock.Size = new System.Drawing.Size(765, 306);
            this.dgvDeptStock.TabIndex = 4;
            // 
            // tYPEIDDataGridViewTextBoxColumn
            // 
            this.tYPEIDDataGridViewTextBoxColumn.DataPropertyName = "TYPE_ID";
            this.tYPEIDDataGridViewTextBoxColumn.HeaderText = "TYPE_ID";
            this.tYPEIDDataGridViewTextBoxColumn.Name = "tYPEIDDataGridViewTextBoxColumn";
            this.tYPEIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // tYPENAMEDataGridViewTextBoxColumn
            // 
            this.tYPENAMEDataGridViewTextBoxColumn.DataPropertyName = "TYPE_NAME";
            this.tYPENAMEDataGridViewTextBoxColumn.HeaderText = "Loại";
            this.tYPENAMEDataGridViewTextBoxColumn.Name = "tYPENAMEDataGridViewTextBoxColumn";
            // 
            // pRODUCTMASTERIDDataGridViewTextBoxColumn
            // 
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.HeaderText = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.Name = "pRODUCTMASTERIDDataGridViewTextBoxColumn";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // pRODUCTNAMEDataGridViewTextBoxColumn
            // 
            this.pRODUCTNAMEDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_NAME";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.HeaderText = "Tên SP";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.Name = "pRODUCTNAMEDataGridViewTextBoxColumn";
            // 
            // cOLORNAMEDataGridViewTextBoxColumn
            // 
            this.cOLORNAMEDataGridViewTextBoxColumn.DataPropertyName = "COLOR_NAME";
            this.cOLORNAMEDataGridViewTextBoxColumn.HeaderText = "Màu";
            this.cOLORNAMEDataGridViewTextBoxColumn.Name = "cOLORNAMEDataGridViewTextBoxColumn";
            // 
            // sIZENAMEDataGridViewTextBoxColumn
            // 
            this.sIZENAMEDataGridViewTextBoxColumn.DataPropertyName = "SIZE_NAME";
            this.sIZENAMEDataGridViewTextBoxColumn.HeaderText = "K.cỡ";
            this.sIZENAMEDataGridViewTextBoxColumn.Name = "sIZENAMEDataGridViewTextBoxColumn";
            // 
            // pRODUCTIDDataGridViewTextBoxColumn
            // 
            this.pRODUCTIDDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_ID";
            this.pRODUCTIDDataGridViewTextBoxColumn.HeaderText = "Mã vạch";
            this.pRODUCTIDDataGridViewTextBoxColumn.Name = "pRODUCTIDDataGridViewTextBoxColumn";
            this.pRODUCTIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // SLColumn
            // 
            this.SLColumn.DataPropertyName = "quantity";
            this.SLColumn.HeaderText = "SL";
            this.SLColumn.Name = "SLColumn";
            this.SLColumn.Width = 90;
            // 
            // SLThucColumn
            // 
            this.SLThucColumn.DataPropertyName = "realquantity";
            dataGridViewCellStyle1.NullValue = "0";
            this.SLThucColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SLThucColumn.HeaderText = "SL THUC";
            this.SLThucColumn.Name = "SLThucColumn";
            this.SLThucColumn.Width = 90;
            // 
            // stockqtyBindingSource
            // 
            this.stockqtyBindingSource.DataMember = "stockqty";
            this.stockqtyBindingSource.DataSource = this.masterDB1;
            // 
            // masterDB1
            // 
            this.masterDB1.DataSetName = "MasterDB";
            this.masterDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnImportResult
            // 
            this.btnImportResult.Location = new System.Drawing.Point(625, 7);
            this.btnImportResult.Name = "btnImportResult";
            this.btnImportResult.Size = new System.Drawing.Size(152, 57);
            this.btnImportResult.TabIndex = 6;
            this.btnImportResult.Text = "Nhập kết quả";
            this.btnImportResult.UseVisualStyleBackColor = true;
            this.btnImportResult.Click += new System.EventHandler(this.btnImportResult_Click);
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoGenerateColumns = false;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tYPEIDDataGridViewTextBoxColumn1,
            this.tYPENAMEDataGridViewTextBoxColumn1,
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn1,
            this.pRODUCTNAMEDataGridViewTextBoxColumn1,
            this.cOLORNAMEDataGridViewTextBoxColumn1,
            this.sIZENAMEDataGridViewTextBoxColumn1,
            this.pRODUCTIDDataGridViewTextBoxColumn1,
            this.quantityDataGridViewTextBoxColumn1,
            this.MainSLColumn,
            this.MainSLThucColumn});
            this.dgvStock.DataSource = this.mainstkqtyBindingSource;
            this.dgvStock.Location = new System.Drawing.Point(12, 127);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(765, 306);
            this.dgvStock.TabIndex = 7;
            this.dgvStock.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStock_DataError);
            // 
            // tYPEIDDataGridViewTextBoxColumn1
            // 
            this.tYPEIDDataGridViewTextBoxColumn1.DataPropertyName = "TYPE_ID";
            this.tYPEIDDataGridViewTextBoxColumn1.HeaderText = "TYPE_ID";
            this.tYPEIDDataGridViewTextBoxColumn1.Name = "tYPEIDDataGridViewTextBoxColumn1";
            this.tYPEIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // tYPENAMEDataGridViewTextBoxColumn1
            // 
            this.tYPENAMEDataGridViewTextBoxColumn1.DataPropertyName = "TYPE_NAME";
            this.tYPENAMEDataGridViewTextBoxColumn1.HeaderText = "Loại";
            this.tYPENAMEDataGridViewTextBoxColumn1.Name = "tYPENAMEDataGridViewTextBoxColumn1";
            // 
            // pRODUCTMASTERIDDataGridViewTextBoxColumn1
            // 
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn1.DataPropertyName = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn1.HeaderText = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn1.Name = "pRODUCTMASTERIDDataGridViewTextBoxColumn1";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // pRODUCTNAMEDataGridViewTextBoxColumn1
            // 
            this.pRODUCTNAMEDataGridViewTextBoxColumn1.DataPropertyName = "PRODUCT_NAME";
            this.pRODUCTNAMEDataGridViewTextBoxColumn1.HeaderText = "Tên hàng";
            this.pRODUCTNAMEDataGridViewTextBoxColumn1.Name = "pRODUCTNAMEDataGridViewTextBoxColumn1";
            // 
            // cOLORNAMEDataGridViewTextBoxColumn1
            // 
            this.cOLORNAMEDataGridViewTextBoxColumn1.DataPropertyName = "COLOR_NAME";
            this.cOLORNAMEDataGridViewTextBoxColumn1.HeaderText = "Màu";
            this.cOLORNAMEDataGridViewTextBoxColumn1.Name = "cOLORNAMEDataGridViewTextBoxColumn1";
            // 
            // sIZENAMEDataGridViewTextBoxColumn1
            // 
            this.sIZENAMEDataGridViewTextBoxColumn1.DataPropertyName = "SIZE_NAME";
            this.sIZENAMEDataGridViewTextBoxColumn1.HeaderText = "K.cỡ";
            this.sIZENAMEDataGridViewTextBoxColumn1.Name = "sIZENAMEDataGridViewTextBoxColumn1";
            // 
            // pRODUCTIDDataGridViewTextBoxColumn1
            // 
            this.pRODUCTIDDataGridViewTextBoxColumn1.DataPropertyName = "PRODUCT_ID";
            this.pRODUCTIDDataGridViewTextBoxColumn1.HeaderText = "Mã vạch";
            this.pRODUCTIDDataGridViewTextBoxColumn1.Name = "pRODUCTIDDataGridViewTextBoxColumn1";
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "SL máy";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.Width = 120;
            // 
            // MainSLColumn
            // 
            this.MainSLColumn.DataPropertyName = "goodquantity";
            this.MainSLColumn.HeaderText = "SL";
            this.MainSLColumn.Name = "MainSLColumn";
            this.MainSLColumn.Visible = false;
            // 
            // MainSLThucColumn
            // 
            this.MainSLThucColumn.DataPropertyName = "realquantity";
            dataGridViewCellStyle2.NullValue = "0";
            this.MainSLThucColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.MainSLThucColumn.HeaderText = "SL Thực";
            this.MainSLThucColumn.Name = "MainSLThucColumn";
            this.MainSLThucColumn.Width = 120;
            // 
            // mainstkqtyBindingSource
            // 
            this.mainstkqtyBindingSource.DataMember = "mainstkqty";
            this.mainstkqtyBindingSource.DataSource = this.masterDB3;
            // 
            // masterDB3
            // 
            this.masterDB3.DataSetName = "MasterDB";
            this.masterDB3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // deptBS_Master
            // 
            this.deptBS_Master.DataMember = "Department";
            this.deptBS_Master.DataSource = this.masterDB;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // chkDifferent
            // 
            this.chkDifferent.AutoSize = true;
            this.chkDifferent.Location = new System.Drawing.Point(12, 102);
            this.chkDifferent.Name = "chkDifferent";
            this.chkDifferent.Size = new System.Drawing.Size(181, 19);
            this.chkDifferent.TabIndex = 8;
            this.chkDifferent.Text = "Xem những dòng khác nhau";
            this.chkDifferent.UseVisualStyleBackColor = true;
            this.chkDifferent.CheckedChanged += new System.EventHandler(this.chkDifferent_CheckedChanged);
            // 
            // stockqtyTableAdapter
            // 
            this.stockqtyTableAdapter.ClearBeforeFill = true;
            // 
            // masterDB2
            // 
            this.masterDB2.DataSetName = "MasterDB";
            this.masterDB2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // producttypeBindingSource
            // 
            this.producttypeBindingSource.DataMember = "product_type";
            this.producttypeBindingSource.DataSource = this.masterDB2;
            // 
            // product_typeTableAdapter
            // 
            this.product_typeTableAdapter.ClearBeforeFill = true;
            // 
            // typeViewObjectBindingSource
            // 
            this.typeViewObjectBindingSource.DataSource = typeof(AppFrameClient.View.TypeViewObject);
            // 
            // mainstkqtyTableAdapter
            // 
            this.mainstkqtyTableAdapter.ClearBeforeFill = true;
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.11765F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtSL.Location = new System.Drawing.Point(528, 439);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(100, 30);
            this.txtSL.TabIndex = 9;
            this.txtSL.Text = "0";
            // 
            // txtSLThuc
            // 
            this.txtSLThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.11765F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLThuc.ForeColor = System.Drawing.Color.Maroon;
            this.txtSLThuc.Location = new System.Drawing.Point(647, 439);
            this.txtSLThuc.Name = "txtSLThuc";
            this.txtSLThuc.Size = new System.Drawing.Size(100, 30);
            this.txtSLThuc.TabIndex = 10;
            this.txtSLThuc.Text = "0";
            // 
            // chkSLEquals
            // 
            this.chkSLEquals.AutoSize = true;
            this.chkSLEquals.Location = new System.Drawing.Point(13, 439);
            this.chkSLEquals.Name = "chkSLEquals";
            this.chkSLEquals.Size = new System.Drawing.Size(214, 19);
            this.chkSLEquals.TabIndex = 11;
            this.chkSLEquals.Text = "Điền số lượng thực = số lượng máy";
            this.chkSLEquals.UseVisualStyleBackColor = true;
            this.chkSLEquals.CheckedChanged += new System.EventHandler(this.chkSLEquals_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(263, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu vào CSDL";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(397, 439);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Xuất CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "Xóa kết quả";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stockevaluationBindingSource
            // 
            this.stockevaluationBindingSource.DataMember = "stock_evaluation";
            this.stockevaluationBindingSource.DataSource = this.masterDB4;
            // 
            // masterDB4
            // 
            this.masterDB4.DataSetName = "MasterDB";
            this.masterDB4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stock_evaluationTableAdapter
            // 
            this.stock_evaluationTableAdapter.ClearBeforeFill = true;
            // 
            // DeptStockEvaluationComparingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkSLEquals);
            this.Controls.Add(this.txtSLThuc);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.chkDifferent);
            this.Controls.Add(this.btnImportResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDepartments);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.dgvDeptStock);
            this.Name = "DeptStockEvaluationComparingForm";
            this.Text = "DeptStockEvaluationComparingForm";
            this.Load += new System.EventHandler(this.DeptStockEvaluationComparingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTypeBds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockqtyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainstkqtyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptBS_Master)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeViewObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockevaluationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDepartments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDeptStock;
        private System.Windows.Forms.Button btnImportResult;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.DataGridView dgvStock;
        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource deptBS_Master;
        private AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.CheckBox chkDifferent;
        private System.Windows.Forms.BindingSource stockqtyBindingSource;
        private MasterDB masterDB1;
        private AppFrameClient.MasterDBTableAdapters.stockqtyTableAdapter stockqtyTableAdapter;
        private MasterDB masterDB2;
        private System.Windows.Forms.BindingSource producttypeBindingSource;
        private AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter product_typeTableAdapter;
        private System.Windows.Forms.BindingSource cboTypeBds;
        private System.Windows.Forms.BindingSource typeViewObjectBindingSource;
        private MasterDB masterDB3;
        private System.Windows.Forms.BindingSource mainstkqtyBindingSource;
        private AppFrameClient.MasterDBTableAdapters.mainstkqtyTableAdapter mainstkqtyTableAdapter;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtSLThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPEIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPENAMEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTMASTERIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTNAMEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLORNAMEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIZENAMEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainSLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainSLThucColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTMASTERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLORNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIZENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLThucColumn;
        private System.Windows.Forms.CheckBox chkSLEquals;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button1;
        private MasterDB masterDB4;
        private System.Windows.Forms.BindingSource stockevaluationBindingSource;
        private AppFrameClient.MasterDBTableAdapters.stock_evaluationTableAdapter stock_evaluationTableAdapter;
    }
}