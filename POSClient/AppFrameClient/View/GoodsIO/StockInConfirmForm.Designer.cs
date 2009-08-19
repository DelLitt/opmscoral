namespace AppFrameClient.View.GoodsIO
{
    partial class StockInConfirmForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgvStockInDetail = new System.Windows.Forms.DataGridView();
            this.sTOCKINIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLORNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIZENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRICEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dELFLGDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKINTYPEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmstockindetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.bdsDeptStockOutDetail = new System.Windows.Forms.BindingSource(this.components);
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtGrandTotalCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvStockIn = new System.Windows.Forms.DataGridView();
            this.sTOCKINIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKINDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPTIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dELFLGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKINCOSTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKINTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cONFIRMFLGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmstockinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDeptStockOut = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoToday = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoThisWeek = new System.Windows.Forms.RadioButton();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.barcodePrintDocument = new System.Drawing.Printing.PrintDocument();
            this.barcodePrintDialog = new System.Windows.Forms.PrintDialog();
            this.confirm_stock_inTableAdapter = new AppFrameClient.MasterDBTableAdapters.confirm_stock_inTableAdapter();
            this.confirm_stock_in_detailTableAdapter = new AppFrameClient.MasterDBTableAdapters.confirm_stock_in_detailTableAdapter();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockindetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOutDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOut)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 498);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Tổng cộng:";
            // 
            // dgvStockInDetail
            // 
            this.dgvStockInDetail.AllowUserToAddRows = false;
            this.dgvStockInDetail.AllowUserToDeleteRows = false;
            this.dgvStockInDetail.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockInDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockInDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockInDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sTOCKINIDDataGridViewTextBoxColumn1,
            this.pRODUCTIDDataGridViewTextBoxColumn,
            this.pRODUCTNAMEDataGridViewTextBoxColumn,
            this.cOLORNAMEDataGridViewTextBoxColumn,
            this.sIZENAMEDataGridViewTextBoxColumn,
            this.qUANTITYDataGridViewTextBoxColumn,
            this.pRICEDataGridViewTextBoxColumn,
            this.cREATEDATEDataGridViewTextBoxColumn1,
            this.cREATEIDDataGridViewTextBoxColumn1,
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1,
            this.dELFLGDataGridViewTextBoxColumn1,
            this.sTOCKINTYPEDataGridViewTextBoxColumn1,
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn});
            this.dgvStockInDetail.DataSource = this.confirmstockindetailBindingSource;
            this.dgvStockInDetail.Location = new System.Drawing.Point(12, 269);
            this.dgvStockInDetail.Name = "dgvStockInDetail";
            this.dgvStockInDetail.RowHeadersVisible = false;
            this.dgvStockInDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockInDetail.Size = new System.Drawing.Size(800, 223);
            this.dgvStockInDetail.TabIndex = 38;
            this.dgvStockInDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockOutDetail_CellContentClick);
            // 
            // sTOCKINIDDataGridViewTextBoxColumn1
            // 
            this.sTOCKINIDDataGridViewTextBoxColumn1.DataPropertyName = "STOCK_IN_ID";
            this.sTOCKINIDDataGridViewTextBoxColumn1.HeaderText = "Mã nhập kho";
            this.sTOCKINIDDataGridViewTextBoxColumn1.Name = "sTOCKINIDDataGridViewTextBoxColumn1";
            this.sTOCKINIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.sTOCKINIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // pRODUCTIDDataGridViewTextBoxColumn
            // 
            this.pRODUCTIDDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_ID";
            this.pRODUCTIDDataGridViewTextBoxColumn.HeaderText = "Mã vạch";
            this.pRODUCTIDDataGridViewTextBoxColumn.Name = "pRODUCTIDDataGridViewTextBoxColumn";
            this.pRODUCTIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRODUCTIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // pRODUCTNAMEDataGridViewTextBoxColumn
            // 
            this.pRODUCTNAMEDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_NAME";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.HeaderText = "Tên hàng";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.Name = "pRODUCTNAMEDataGridViewTextBoxColumn";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRODUCTNAMEDataGridViewTextBoxColumn.Width = 180;
            // 
            // cOLORNAMEDataGridViewTextBoxColumn
            // 
            this.cOLORNAMEDataGridViewTextBoxColumn.DataPropertyName = "COLOR_NAME";
            this.cOLORNAMEDataGridViewTextBoxColumn.HeaderText = "Màu sắc";
            this.cOLORNAMEDataGridViewTextBoxColumn.Name = "cOLORNAMEDataGridViewTextBoxColumn";
            this.cOLORNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sIZENAMEDataGridViewTextBoxColumn
            // 
            this.sIZENAMEDataGridViewTextBoxColumn.DataPropertyName = "SIZE_NAME";
            this.sIZENAMEDataGridViewTextBoxColumn.HeaderText = "Kích cỡ";
            this.sIZENAMEDataGridViewTextBoxColumn.Name = "sIZENAMEDataGridViewTextBoxColumn";
            this.sIZENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qUANTITYDataGridViewTextBoxColumn
            // 
            this.qUANTITYDataGridViewTextBoxColumn.DataPropertyName = "QUANTITY";
            this.qUANTITYDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.qUANTITYDataGridViewTextBoxColumn.Name = "qUANTITYDataGridViewTextBoxColumn";
            this.qUANTITYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pRICEDataGridViewTextBoxColumn
            // 
            this.pRICEDataGridViewTextBoxColumn.DataPropertyName = "PRICE";
            this.pRICEDataGridViewTextBoxColumn.HeaderText = "Giá vốn";
            this.pRICEDataGridViewTextBoxColumn.Name = "pRICEDataGridViewTextBoxColumn";
            this.pRICEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cREATEDATEDataGridViewTextBoxColumn1
            // 
            this.cREATEDATEDataGridViewTextBoxColumn1.DataPropertyName = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn1.HeaderText = "Ngày nhập";
            this.cREATEDATEDataGridViewTextBoxColumn1.Name = "cREATEDATEDataGridViewTextBoxColumn1";
            this.cREATEDATEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cREATEDATEDataGridViewTextBoxColumn1.Width = 90;
            // 
            // cREATEIDDataGridViewTextBoxColumn1
            // 
            this.cREATEIDDataGridViewTextBoxColumn1.DataPropertyName = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn1.HeaderText = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn1.Name = "cREATEIDDataGridViewTextBoxColumn1";
            this.cREATEIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // eXCLUSIVEKEYDataGridViewTextBoxColumn1
            // 
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.DataPropertyName = "EXCLUSIVE_KEY";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.HeaderText = "EXCLUSIVE_KEY";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.Name = "eXCLUSIVEKEYDataGridViewTextBoxColumn1";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.Visible = false;
            // 
            // dELFLGDataGridViewTextBoxColumn1
            // 
            this.dELFLGDataGridViewTextBoxColumn1.DataPropertyName = "DEL_FLG";
            this.dELFLGDataGridViewTextBoxColumn1.HeaderText = "DEL_FLG";
            this.dELFLGDataGridViewTextBoxColumn1.Name = "dELFLGDataGridViewTextBoxColumn1";
            this.dELFLGDataGridViewTextBoxColumn1.Visible = false;
            // 
            // sTOCKINTYPEDataGridViewTextBoxColumn1
            // 
            this.sTOCKINTYPEDataGridViewTextBoxColumn1.DataPropertyName = "STOCK_IN_TYPE";
            this.sTOCKINTYPEDataGridViewTextBoxColumn1.HeaderText = "STOCK_IN_TYPE";
            this.sTOCKINTYPEDataGridViewTextBoxColumn1.Name = "sTOCKINTYPEDataGridViewTextBoxColumn1";
            this.sTOCKINTYPEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // pRODUCTMASTERIDDataGridViewTextBoxColumn
            // 
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.HeaderText = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.Name = "pRODUCTMASTERIDDataGridViewTextBoxColumn";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // confirmstockindetailBindingSource
            // 
            this.confirmstockindetailBindingSource.DataMember = "confirm_stock_in_detail";
            this.confirmstockindetailBindingSource.DataSource = this.masterDB;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(412, 66);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 37;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(164, 66);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 36;
            // 
            // txtGrandTotalCount
            // 
            this.txtGrandTotalCount.Location = new System.Drawing.Point(618, 495);
            this.txtGrandTotalCount.Name = "txtGrandTotalCount";
            this.txtGrandTotalCount.Size = new System.Drawing.Size(94, 20);
            this.txtGrandTotalCount.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Chi tiết";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Liệt kê";
            // 
            // dgvStockIn
            // 
            this.dgvStockIn.AllowUserToAddRows = false;
            this.dgvStockIn.AllowUserToDeleteRows = false;
            this.dgvStockIn.AutoGenerateColumns = false;
            this.dgvStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sTOCKINIDDataGridViewTextBoxColumn,
            this.sTOCKINDATEDataGridViewTextBoxColumn,
            this.cREATEDATEDataGridViewTextBoxColumn,
            this.dESCRIPTIONDataGridViewTextBoxColumn,
            this.cREATEIDDataGridViewTextBoxColumn,
            this.uPDATEDATEDataGridViewTextBoxColumn,
            this.uPDATEIDDataGridViewTextBoxColumn,
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn,
            this.dELFLGDataGridViewTextBoxColumn,
            this.sTOCKINCOSTDataGridViewTextBoxColumn,
            this.sTOCKINTYPEDataGridViewTextBoxColumn,
            this.cONFIRMFLGDataGridViewTextBoxColumn});
            this.dgvStockIn.DataSource = this.confirmstockinBindingSource;
            this.dgvStockIn.Location = new System.Drawing.Point(49, 108);
            this.dgvStockIn.Name = "dgvStockIn";
            this.dgvStockIn.RowHeadersVisible = false;
            this.dgvStockIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockIn.Size = new System.Drawing.Size(696, 141);
            this.dgvStockIn.TabIndex = 29;
            this.dgvStockIn.SelectionChanged += new System.EventHandler(this.dgvStockOut_SelectionChanged);
            // 
            // sTOCKINIDDataGridViewTextBoxColumn
            // 
            this.sTOCKINIDDataGridViewTextBoxColumn.DataPropertyName = "STOCK_IN_ID";
            this.sTOCKINIDDataGridViewTextBoxColumn.HeaderText = "Mã nhập kho";
            this.sTOCKINIDDataGridViewTextBoxColumn.Name = "sTOCKINIDDataGridViewTextBoxColumn";
            this.sTOCKINIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sTOCKINDATEDataGridViewTextBoxColumn
            // 
            this.sTOCKINDATEDataGridViewTextBoxColumn.DataPropertyName = "STOCK_IN_DATE";
            this.sTOCKINDATEDataGridViewTextBoxColumn.HeaderText = "Ngày nhập kho";
            this.sTOCKINDATEDataGridViewTextBoxColumn.Name = "sTOCKINDATEDataGridViewTextBoxColumn";
            this.sTOCKINDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sTOCKINDATEDataGridViewTextBoxColumn.Width = 150;
            // 
            // cREATEDATEDataGridViewTextBoxColumn
            // 
            this.cREATEDATEDataGridViewTextBoxColumn.DataPropertyName = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn.HeaderText = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn.Name = "cREATEDATEDataGridViewTextBoxColumn";
            this.cREATEDATEDataGridViewTextBoxColumn.Visible = false;
            // 
            // dESCRIPTIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPTIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPTION";
            this.dESCRIPTIONDataGridViewTextBoxColumn.HeaderText = "Diễn giải";
            this.dESCRIPTIONDataGridViewTextBoxColumn.Name = "dESCRIPTIONDataGridViewTextBoxColumn";
            this.dESCRIPTIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCRIPTIONDataGridViewTextBoxColumn.Width = 250;
            // 
            // cREATEIDDataGridViewTextBoxColumn
            // 
            this.cREATEIDDataGridViewTextBoxColumn.DataPropertyName = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn.HeaderText = "Người nhập";
            this.cREATEIDDataGridViewTextBoxColumn.Name = "cREATEIDDataGridViewTextBoxColumn";
            this.cREATEIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cREATEIDDataGridViewTextBoxColumn.Width = 150;
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
            // sTOCKINCOSTDataGridViewTextBoxColumn
            // 
            this.sTOCKINCOSTDataGridViewTextBoxColumn.DataPropertyName = "STOCK_IN_COST";
            this.sTOCKINCOSTDataGridViewTextBoxColumn.HeaderText = "STOCK_IN_COST";
            this.sTOCKINCOSTDataGridViewTextBoxColumn.Name = "sTOCKINCOSTDataGridViewTextBoxColumn";
            this.sTOCKINCOSTDataGridViewTextBoxColumn.Visible = false;
            // 
            // sTOCKINTYPEDataGridViewTextBoxColumn
            // 
            this.sTOCKINTYPEDataGridViewTextBoxColumn.DataPropertyName = "STOCK_IN_TYPE";
            this.sTOCKINTYPEDataGridViewTextBoxColumn.HeaderText = "STOCK_IN_TYPE";
            this.sTOCKINTYPEDataGridViewTextBoxColumn.Name = "sTOCKINTYPEDataGridViewTextBoxColumn";
            this.sTOCKINTYPEDataGridViewTextBoxColumn.Visible = false;
            // 
            // cONFIRMFLGDataGridViewTextBoxColumn
            // 
            this.cONFIRMFLGDataGridViewTextBoxColumn.DataPropertyName = "CONFIRM_FLG";
            this.cONFIRMFLGDataGridViewTextBoxColumn.HeaderText = "CONFIRM_FLG";
            this.cONFIRMFLGDataGridViewTextBoxColumn.Name = "cONFIRMFLGDataGridViewTextBoxColumn";
            this.cONFIRMFLGDataGridViewTextBoxColumn.Visible = false;
            // 
            // confirmstockinBindingSource
            // 
            this.confirmstockinBindingSource.DataMember = "confirm_stock_in";
            this.confirmstockinBindingSource.DataSource = this.masterDB;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(618, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 54);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "đến";
            // 
            // rdoToday
            // 
            this.rdoToday.AutoSize = true;
            this.rdoToday.Location = new System.Drawing.Point(259, 43);
            this.rdoToday.Name = "rdoToday";
            this.rdoToday.Size = new System.Drawing.Size(93, 17);
            this.rdoToday.TabIndex = 23;
            this.rdoToday.TabStop = true;
            this.rdoToday.Text = "Ngày hôm nay";
            this.rdoToday.UseVisualStyleBackColor = true;
            this.rdoToday.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Từ";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(496, 43);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(55, 17);
            this.rdoAll.TabIndex = 25;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "Bất kỳ";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Visible = false;
            // 
            // rdoThisWeek
            // 
            this.rdoThisWeek.AutoSize = true;
            this.rdoThisWeek.Location = new System.Drawing.Point(368, 43);
            this.rdoThisWeek.Name = "rdoThisWeek";
            this.rdoThisWeek.Size = new System.Drawing.Size(93, 17);
            this.rdoThisWeek.TabIndex = 24;
            this.rdoThisWeek.TabStop = true;
            this.rdoThisWeek.Text = "Tuần hôm nay";
            this.rdoThisWeek.UseVisualStyleBackColor = true;
            this.rdoThisWeek.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 529);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 33;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(737, 529);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(618, 529);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(396, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Xác nhận";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "DANH SÁCH PHIẾU NHẬP KHO";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Không xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // barcodePrintDocument
            // 
            this.barcodePrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.barcodePrintDocument_PrintPage);
            // 
            // barcodePrintDialog
            // 
            this.barcodePrintDialog.UseEXDialog = true;
            // 
            // confirm_stock_inTableAdapter
            // 
            this.confirm_stock_inTableAdapter.ClearBeforeFill = true;
            // 
            // confirm_stock_in_detailTableAdapter
            // 
            this.confirm_stock_in_detailTableAdapter.ClearBeforeFill = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(315, 528);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 42;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // StockInConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 583);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvStockInDetail);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.txtGrandTotalCount);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvStockIn);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rdoToday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoThisWeek);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "StockInConfirmForm";
            this.Text = "Xác nhận xuất hàng";
            this.Load += new System.EventHandler(this.DepartmentStockOutConfirmForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.rdoThisWeek, 0);
            this.Controls.SetChildIndex(this.rdoAll, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rdoToday, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.dgvStockIn, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dtpFrom, 0);
            this.Controls.SetChildIndex(this.txtGrandTotalCount, 0);
            this.Controls.SetChildIndex(this.dtpTo, 0);
            this.Controls.SetChildIndex(this.dgvStockInDetail, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockindetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOutDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvStockInDetail;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox txtGrandTotalCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvStockIn;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoToday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoThisWeek;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bdsDeptStockOutDetail;
        private System.Windows.Forms.BindingSource bdsDeptStockOut;
        private System.Drawing.Printing.PrintDocument barcodePrintDocument;
        private System.Windows.Forms.PrintDialog barcodePrintDialog;
        private System.Windows.Forms.BindingSource confirmstockinBindingSource;
        private MasterDB masterDB;
        private AppFrameClient.MasterDBTableAdapters.confirm_stock_inTableAdapter confirm_stock_inTableAdapter;
        private System.Windows.Forms.BindingSource confirmstockindetailBindingSource;
        private AppFrameClient.MasterDBTableAdapters.confirm_stock_in_detailTableAdapter confirm_stock_in_detailTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKINIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLORNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIZENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRICEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXCLUSIVEKEYDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLGDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKINTYPEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTMASTERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKINIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKINDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPTIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXCLUSIVEKEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKINCOSTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKINTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cONFIRMFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnEdit;
    }
}