namespace AppFrameClient.View.GoodsIO
{
    partial class StockOutConfirmForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgvStockOutDetail = new System.Windows.Forms.DataGridView();
            this.confirmstockoutdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.bdsDeptStockOutDetail = new System.Windows.Forms.BindingSource(this.components);
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtGrandTotalCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvStockOut = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKOUTDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEPARTMENTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dELFLGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEPARTMENTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEFECTSTATUSNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmstockoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownBarcode = new System.Windows.Forms.NumericUpDown();
            this.chkPricePrint = new System.Windows.Forms.CheckBox();
            this.chkContinuePrint = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.barcodePrintDocument = new System.Drawing.Printing.PrintDocument();
            this.barcodePrintDialog = new System.Windows.Forms.PrintDialog();
            this.confirm_stock_outTableAdapter = new AppFrameClient.MasterDBTableAdapters.confirm_stock_outTableAdapter();
            this.confirm_stock_out_detailTableAdapter = new AppFrameClient.MasterDBTableAdapters.confirm_stock_out_detailTableAdapter();
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLORNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIZENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOCKOUTIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPTIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gOODQUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dELFLGDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eRRORQUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dAMAGEQUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOSTQUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uNCONFIRMQUANTITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOutDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockoutdetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOutDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockoutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarcode)).BeginInit();
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
            // dgvStockOutDetail
            // 
            this.dgvStockOutDetail.AllowUserToAddRows = false;
            this.dgvStockOutDetail.AllowUserToDeleteRows = false;
            this.dgvStockOutDetail.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockOutDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockOutDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockOutDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn,
            this.pRODUCTIDDataGridViewTextBoxColumn,
            this.pRODUCTNAMEDataGridViewTextBoxColumn,
            this.cOLORNAMEDataGridViewTextBoxColumn,
            this.sIZENAMEDataGridViewTextBoxColumn,
            this.qUANTITYDataGridViewTextBoxColumn,
            this.sTOCKOUTIDDataGridViewTextBoxColumn1,
            this.dESCRIPTIONDataGridViewTextBoxColumn,
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1,
            this.cREATEDATEDataGridViewTextBoxColumn1,
            this.uPDATEDATEDataGridViewTextBoxColumn1,
            this.uPDATEIDDataGridViewTextBoxColumn1,
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn,
            this.cREATEIDDataGridViewTextBoxColumn1,
            this.gOODQUANTITYDataGridViewTextBoxColumn,
            this.dELFLGDataGridViewTextBoxColumn1,
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn1,
            this.eRRORQUANTITYDataGridViewTextBoxColumn,
            this.dAMAGEQUANTITYDataGridViewTextBoxColumn,
            this.lOSTQUANTITYDataGridViewTextBoxColumn,
            this.uNCONFIRMQUANTITYDataGridViewTextBoxColumn});
            this.dgvStockOutDetail.DataSource = this.confirmstockoutdetailBindingSource;
            this.dgvStockOutDetail.Location = new System.Drawing.Point(12, 269);
            this.dgvStockOutDetail.Name = "dgvStockOutDetail";
            this.dgvStockOutDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockOutDetail.Size = new System.Drawing.Size(800, 223);
            this.dgvStockOutDetail.TabIndex = 38;
            this.dgvStockOutDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockOutDetail_CellContentClick);
            // 
            // confirmstockoutdetailBindingSource
            // 
            this.confirmstockoutdetailBindingSource.DataMember = "confirm_stock_out_detail";
            this.confirmstockoutdetailBindingSource.DataSource = this.masterDB;
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
            // dgvStockOut
            // 
            this.dgvStockOut.AllowUserToAddRows = false;
            this.dgvStockOut.AllowUserToDeleteRows = false;
            this.dgvStockOut.AutoGenerateColumns = false;
            this.dgvStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.sTOCKOUTDATEDataGridViewTextBoxColumn,
            this.dEPARTMENTIDDataGridViewTextBoxColumn,
            this.cREATEDATEDataGridViewTextBoxColumn,
            this.cREATEIDDataGridViewTextBoxColumn,
            this.uPDATEDATEDataGridViewTextBoxColumn,
            this.uPDATEIDDataGridViewTextBoxColumn,
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn,
            this.dELFLGDataGridViewTextBoxColumn,
            this.sTOCKIDDataGridViewTextBoxColumn,
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn,
            this.totalQuantityDataGridViewTextBoxColumn,
            this.dEPARTMENTNAMEDataGridViewTextBoxColumn,
            this.dEFECTSTATUSNAMEDataGridViewTextBoxColumn});
            this.dgvStockOut.DataSource = this.confirmstockoutBindingSource;
            this.dgvStockOut.Location = new System.Drawing.Point(38, 109);
            this.dgvStockOut.Name = "dgvStockOut";
            this.dgvStockOut.RowHeadersVisible = false;
            this.dgvStockOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockOut.Size = new System.Drawing.Size(744, 141);
            this.dgvStockOut.TabIndex = 29;
            this.dgvStockOut.SelectionChanged += new System.EventHandler(this.dgvStockOut_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StockOutID";
            this.Column1.HeaderText = "Số";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DEPARTMENT_NAME";
            this.Column2.HeaderText = "Nơi đến";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CREATE_DATE";
            this.Column3.HeaderText = "Ngày xuất";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TotalQuantity";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DEFECT_STATUS_NAME";
            this.Column5.HeaderText = "Lý do";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // sTOCKOUTDATEDataGridViewTextBoxColumn
            // 
            this.sTOCKOUTDATEDataGridViewTextBoxColumn.DataPropertyName = "STOCK_OUT_DATE";
            this.sTOCKOUTDATEDataGridViewTextBoxColumn.HeaderText = "STOCK_OUT_DATE";
            this.sTOCKOUTDATEDataGridViewTextBoxColumn.Name = "sTOCKOUTDATEDataGridViewTextBoxColumn";
            this.sTOCKOUTDATEDataGridViewTextBoxColumn.Visible = false;
            // 
            // dEPARTMENTIDDataGridViewTextBoxColumn
            // 
            this.dEPARTMENTIDDataGridViewTextBoxColumn.DataPropertyName = "DEPARTMENT_ID";
            this.dEPARTMENTIDDataGridViewTextBoxColumn.HeaderText = "DEPARTMENT_ID";
            this.dEPARTMENTIDDataGridViewTextBoxColumn.Name = "dEPARTMENTIDDataGridViewTextBoxColumn";
            this.dEPARTMENTIDDataGridViewTextBoxColumn.Visible = false;
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
            // sTOCKIDDataGridViewTextBoxColumn
            // 
            this.sTOCKIDDataGridViewTextBoxColumn.DataPropertyName = "STOCK_ID";
            this.sTOCKIDDataGridViewTextBoxColumn.HeaderText = "STOCK_ID";
            this.sTOCKIDDataGridViewTextBoxColumn.Name = "sTOCKIDDataGridViewTextBoxColumn";
            this.sTOCKIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // dEFECTSTATUSIDDataGridViewTextBoxColumn
            // 
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn.DataPropertyName = "DEFECT_STATUS_ID";
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn.HeaderText = "DEFECT_STATUS_ID";
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn.Name = "dEFECTSTATUSIDDataGridViewTextBoxColumn";
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalQuantityDataGridViewTextBoxColumn
            // 
            this.totalQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalQuantity";
            this.totalQuantityDataGridViewTextBoxColumn.HeaderText = "TotalQuantity";
            this.totalQuantityDataGridViewTextBoxColumn.Name = "totalQuantityDataGridViewTextBoxColumn";
            this.totalQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // dEPARTMENTNAMEDataGridViewTextBoxColumn
            // 
            this.dEPARTMENTNAMEDataGridViewTextBoxColumn.DataPropertyName = "DEPARTMENT_NAME";
            this.dEPARTMENTNAMEDataGridViewTextBoxColumn.HeaderText = "DEPARTMENT_NAME";
            this.dEPARTMENTNAMEDataGridViewTextBoxColumn.Name = "dEPARTMENTNAMEDataGridViewTextBoxColumn";
            this.dEPARTMENTNAMEDataGridViewTextBoxColumn.Visible = false;
            // 
            // dEFECTSTATUSNAMEDataGridViewTextBoxColumn
            // 
            this.dEFECTSTATUSNAMEDataGridViewTextBoxColumn.DataPropertyName = "DEFECT_STATUS_NAME";
            this.dEFECTSTATUSNAMEDataGridViewTextBoxColumn.HeaderText = "DEFECT_STATUS_NAME";
            this.dEFECTSTATUSNAMEDataGridViewTextBoxColumn.Name = "dEFECTSTATUSNAMEDataGridViewTextBoxColumn";
            this.dEFECTSTATUSNAMEDataGridViewTextBoxColumn.Visible = false;
            // 
            // confirmstockoutBindingSource
            // 
            this.confirmstockoutBindingSource.DataMember = "confirm_stock_out";
            this.confirmstockoutBindingSource.DataSource = this.masterDB;
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
            this.btnSave.Location = new System.Drawing.Point(396, 529);
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
            this.label1.Size = new System.Drawing.Size(358, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "DANH SÁCH PHIẾU XUẤT KHO";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 500);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Số lượng";
            this.label7.Visible = false;
            // 
            // numericUpDownBarcode
            // 
            this.numericUpDownBarcode.Location = new System.Drawing.Point(76, 498);
            this.numericUpDownBarcode.Name = "numericUpDownBarcode";
            this.numericUpDownBarcode.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownBarcode.TabIndex = 45;
            this.numericUpDownBarcode.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownBarcode.Visible = false;
            // 
            // chkPricePrint
            // 
            this.chkPricePrint.AutoSize = true;
            this.chkPricePrint.Location = new System.Drawing.Point(325, 501);
            this.chkPricePrint.Name = "chkPricePrint";
            this.chkPricePrint.Size = new System.Drawing.Size(52, 17);
            this.chkPricePrint.TabIndex = 44;
            this.chkPricePrint.Text = "In giá";
            this.chkPricePrint.UseVisualStyleBackColor = true;
            this.chkPricePrint.Visible = false;
            // 
            // chkContinuePrint
            // 
            this.chkContinuePrint.AutoSize = true;
            this.chkContinuePrint.Location = new System.Drawing.Point(234, 501);
            this.chkContinuePrint.Name = "chkContinuePrint";
            this.chkContinuePrint.Size = new System.Drawing.Size(74, 17);
            this.chkContinuePrint.TabIndex = 43;
            this.chkContinuePrint.Text = "In liên tiếp";
            this.chkContinuePrint.UseVisualStyleBackColor = true;
            this.chkContinuePrint.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(141, 498);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPrint.TabIndex = 42;
            this.btnPrint.Text = "In mã vạch";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // barcodePrintDocument
            // 
            this.barcodePrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.barcodePrintDocument_PrintPage);
            // 
            // barcodePrintDialog
            // 
            this.barcodePrintDialog.UseEXDialog = true;
            // 
            // confirm_stock_outTableAdapter
            // 
            this.confirm_stock_outTableAdapter.ClearBeforeFill = true;
            // 
            // confirm_stock_out_detailTableAdapter
            // 
            this.confirm_stock_out_detailTableAdapter.ClearBeforeFill = true;
            // 
            // sTOCKOUTDETAILIDDataGridViewTextBoxColumn
            // 
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn.DataPropertyName = "STOCK_OUT_DETAIL_ID";
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn.HeaderText = "STOCK_OUT_DETAIL_ID";
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn.Name = "sTOCKOUTDETAILIDDataGridViewTextBoxColumn";
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.sTOCKOUTDETAILIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // pRODUCTIDDataGridViewTextBoxColumn
            // 
            this.pRODUCTIDDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_ID";
            this.pRODUCTIDDataGridViewTextBoxColumn.HeaderText = "Mã vạch";
            this.pRODUCTIDDataGridViewTextBoxColumn.Name = "pRODUCTIDDataGridViewTextBoxColumn";
            this.pRODUCTIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pRODUCTNAMEDataGridViewTextBoxColumn
            // 
            this.pRODUCTNAMEDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_NAME";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.HeaderText = "Tên hàng";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.Name = "pRODUCTNAMEDataGridViewTextBoxColumn";
            this.pRODUCTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
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
            // sTOCKOUTIDDataGridViewTextBoxColumn1
            // 
            this.sTOCKOUTIDDataGridViewTextBoxColumn1.DataPropertyName = "STOCKOUT_ID";
            this.sTOCKOUTIDDataGridViewTextBoxColumn1.HeaderText = "Số lô";
            this.sTOCKOUTIDDataGridViewTextBoxColumn1.Name = "sTOCKOUTIDDataGridViewTextBoxColumn1";
            this.sTOCKOUTIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dESCRIPTIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPTIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPTION";
            this.dESCRIPTIONDataGridViewTextBoxColumn.HeaderText = "Diễn giải";
            this.dESCRIPTIONDataGridViewTextBoxColumn.Name = "dESCRIPTIONDataGridViewTextBoxColumn";
            this.dESCRIPTIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eXCLUSIVEKEYDataGridViewTextBoxColumn1
            // 
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.DataPropertyName = "EXCLUSIVE_KEY";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.HeaderText = "EXCLUSIVE_KEY";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.Name = "eXCLUSIVEKEYDataGridViewTextBoxColumn1";
            this.eXCLUSIVEKEYDataGridViewTextBoxColumn1.Visible = false;
            // 
            // cREATEDATEDataGridViewTextBoxColumn1
            // 
            this.cREATEDATEDataGridViewTextBoxColumn1.DataPropertyName = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn1.HeaderText = "CREATE_DATE";
            this.cREATEDATEDataGridViewTextBoxColumn1.Name = "cREATEDATEDataGridViewTextBoxColumn1";
            this.cREATEDATEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // uPDATEDATEDataGridViewTextBoxColumn1
            // 
            this.uPDATEDATEDataGridViewTextBoxColumn1.DataPropertyName = "UPDATE_DATE";
            this.uPDATEDATEDataGridViewTextBoxColumn1.HeaderText = "UPDATE_DATE";
            this.uPDATEDATEDataGridViewTextBoxColumn1.Name = "uPDATEDATEDataGridViewTextBoxColumn1";
            this.uPDATEDATEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // uPDATEIDDataGridViewTextBoxColumn1
            // 
            this.uPDATEIDDataGridViewTextBoxColumn1.DataPropertyName = "UPDATE_ID";
            this.uPDATEIDDataGridViewTextBoxColumn1.HeaderText = "UPDATE_ID";
            this.uPDATEIDDataGridViewTextBoxColumn1.Name = "uPDATEIDDataGridViewTextBoxColumn1";
            this.uPDATEIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // pRODUCTMASTERIDDataGridViewTextBoxColumn
            // 
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.DataPropertyName = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.HeaderText = "PRODUCT_MASTER_ID";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.Name = "pRODUCTMASTERIDDataGridViewTextBoxColumn";
            this.pRODUCTMASTERIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cREATEIDDataGridViewTextBoxColumn1
            // 
            this.cREATEIDDataGridViewTextBoxColumn1.DataPropertyName = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn1.HeaderText = "CREATE_ID";
            this.cREATEIDDataGridViewTextBoxColumn1.Name = "cREATEIDDataGridViewTextBoxColumn1";
            this.cREATEIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // gOODQUANTITYDataGridViewTextBoxColumn
            // 
            this.gOODQUANTITYDataGridViewTextBoxColumn.DataPropertyName = "GOOD_QUANTITY";
            this.gOODQUANTITYDataGridViewTextBoxColumn.HeaderText = "GOOD_QUANTITY";
            this.gOODQUANTITYDataGridViewTextBoxColumn.Name = "gOODQUANTITYDataGridViewTextBoxColumn";
            this.gOODQUANTITYDataGridViewTextBoxColumn.Visible = false;
            // 
            // dELFLGDataGridViewTextBoxColumn1
            // 
            this.dELFLGDataGridViewTextBoxColumn1.DataPropertyName = "DEL_FLG";
            this.dELFLGDataGridViewTextBoxColumn1.HeaderText = "DEL_FLG";
            this.dELFLGDataGridViewTextBoxColumn1.Name = "dELFLGDataGridViewTextBoxColumn1";
            this.dELFLGDataGridViewTextBoxColumn1.Visible = false;
            // 
            // dEFECTSTATUSIDDataGridViewTextBoxColumn1
            // 
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn1.DataPropertyName = "DEFECT_STATUS_ID";
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn1.HeaderText = "DEFECT_STATUS_ID";
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn1.Name = "dEFECTSTATUSIDDataGridViewTextBoxColumn1";
            this.dEFECTSTATUSIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // eRRORQUANTITYDataGridViewTextBoxColumn
            // 
            this.eRRORQUANTITYDataGridViewTextBoxColumn.DataPropertyName = "ERROR_QUANTITY";
            this.eRRORQUANTITYDataGridViewTextBoxColumn.HeaderText = "ERROR_QUANTITY";
            this.eRRORQUANTITYDataGridViewTextBoxColumn.Name = "eRRORQUANTITYDataGridViewTextBoxColumn";
            this.eRRORQUANTITYDataGridViewTextBoxColumn.Visible = false;
            // 
            // dAMAGEQUANTITYDataGridViewTextBoxColumn
            // 
            this.dAMAGEQUANTITYDataGridViewTextBoxColumn.DataPropertyName = "DAMAGE_QUANTITY";
            this.dAMAGEQUANTITYDataGridViewTextBoxColumn.HeaderText = "DAMAGE_QUANTITY";
            this.dAMAGEQUANTITYDataGridViewTextBoxColumn.Name = "dAMAGEQUANTITYDataGridViewTextBoxColumn";
            this.dAMAGEQUANTITYDataGridViewTextBoxColumn.Visible = false;
            // 
            // lOSTQUANTITYDataGridViewTextBoxColumn
            // 
            this.lOSTQUANTITYDataGridViewTextBoxColumn.DataPropertyName = "LOST_QUANTITY";
            this.lOSTQUANTITYDataGridViewTextBoxColumn.HeaderText = "LOST_QUANTITY";
            this.lOSTQUANTITYDataGridViewTextBoxColumn.Name = "lOSTQUANTITYDataGridViewTextBoxColumn";
            this.lOSTQUANTITYDataGridViewTextBoxColumn.Visible = false;
            // 
            // uNCONFIRMQUANTITYDataGridViewTextBoxColumn
            // 
            this.uNCONFIRMQUANTITYDataGridViewTextBoxColumn.DataPropertyName = "UNCONFIRM_QUANTITY";
            this.uNCONFIRMQUANTITYDataGridViewTextBoxColumn.HeaderText = "UNCONFIRM_QUANTITY";
            this.uNCONFIRMQUANTITYDataGridViewTextBoxColumn.Name = "uNCONFIRMQUANTITYDataGridViewTextBoxColumn";
            this.uNCONFIRMQUANTITYDataGridViewTextBoxColumn.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(315, 528);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 47;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // StockOutConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 581);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownBarcode);
            this.Controls.Add(this.chkPricePrint);
            this.Controls.Add(this.chkContinuePrint);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvStockOutDetail);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.txtGrandTotalCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvStockOut);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoToday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoThisWeek);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "StockOutConfirmForm";
            this.Text = "Xác nhận xuất hàng";
            this.Load += new System.EventHandler(this.DepartmentStockOutConfirmForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.rdoThisWeek, 0);
            this.Controls.SetChildIndex(this.rdoAll, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rdoToday, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.dgvStockOut, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtGrandTotalCount, 0);
            this.Controls.SetChildIndex(this.dtpFrom, 0);
            this.Controls.SetChildIndex(this.dtpTo, 0);
            this.Controls.SetChildIndex(this.dgvStockOutDetail, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.chkContinuePrint, 0);
            this.Controls.SetChildIndex(this.chkPricePrint, 0);
            this.Controls.SetChildIndex(this.numericUpDownBarcode, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOutDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockoutdetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOutDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmstockoutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvStockOutDetail;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox txtGrandTotalCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvStockOut;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownBarcode;
        private System.Windows.Forms.CheckBox chkPricePrint;
        private System.Windows.Forms.CheckBox chkContinuePrint;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument barcodePrintDocument;
        private System.Windows.Forms.PrintDialog barcodePrintDialog;
        private System.Windows.Forms.BindingSource confirmstockoutBindingSource;
        private MasterDB masterDB;
        private AppFrameClient.MasterDBTableAdapters.confirm_stock_outTableAdapter confirm_stock_outTableAdapter;
        private System.Windows.Forms.BindingSource confirmstockoutdetailBindingSource;
        private AppFrameClient.MasterDBTableAdapters.confirm_stock_out_detailTableAdapter confirm_stock_out_detailTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKOUTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKOUTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEPARTMENTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXCLUSIVEKEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEFECTSTATUSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEPARTMENTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEFECTSTATUSNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKOUTDETAILIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLORNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIZENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTOCKOUTIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPTIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXCLUSIVEKEYDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEDATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTMASTERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gOODQUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dELFLGDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEFECTSTATUSIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eRRORQUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dAMAGEQUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOSTQUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNCONFIRMQUANTITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnEdit;
    }
}