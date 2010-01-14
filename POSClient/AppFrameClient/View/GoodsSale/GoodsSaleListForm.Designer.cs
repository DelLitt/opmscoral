namespace AppFrameClient.View.GoodsSale
{
    partial class GoodsSaleListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEvening = new System.Windows.Forms.CheckBox();
            this.chkMorning = new System.Windows.Forms.CheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.dgvSaleList = new System.Windows.Forms.DataGridView();
            this.purchaseOrderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsPurchaseOrders = new System.Windows.Forms.BindingSource(this.components);
            this.chkMorningSort = new System.Windows.Forms.CheckBox();
            this.chkEveningSort = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRetQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSellQty = new System.Windows.Forms.TextBox();
            this.DepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdsBill = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(11, 484);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 37;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(742, 484);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.lblWorkingTime);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.cboEmployee);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkEvening);
            this.groupBox2.Controls.Add(this.chkMorning);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblBillNumber);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Controls.Add(this.txtCustomer);
            this.groupBox2.Controls.Add(this.lblCustomer);
            this.groupBox2.Controls.Add(this.txtBillNumber);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 101);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm hóa đơn";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(552, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(135, 23);
            this.dtpToDate.TabIndex = 45;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(374, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(141, 23);
            this.dtpFromDate.TabIndex = 44;
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Location = new System.Drawing.Point(386, 47);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(50, 16);
            this.lblWorkingTime.TabIndex = 43;
            this.lblWorkingTime.Text = "Ca trực";
            this.lblWorkingTime.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(693, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 73);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboEmployee
            // 
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(98, 67);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(270, 24);
            this.cboEmployee.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 40;
            this.label8.Text = "Nhân viên";
            // 
            // chkEvening
            // 
            this.chkEvening.AutoSize = true;
            this.chkEvening.Location = new System.Drawing.Point(518, 46);
            this.chkEvening.Name = "chkEvening";
            this.chkEvening.Size = new System.Drawing.Size(59, 20);
            this.chkEvening.TabIndex = 38;
            this.chkEvening.Text = "Chiều";
            this.chkEvening.UseVisualStyleBackColor = true;
            this.chkEvening.Visible = false;
            // 
            // chkMorning
            // 
            this.chkMorning.AutoSize = true;
            this.chkMorning.Location = new System.Drawing.Point(439, 46);
            this.chkMorning.Name = "chkMorning";
            this.chkMorning.Size = new System.Drawing.Size(56, 20);
            this.chkMorning.TabIndex = 37;
            this.chkMorning.Text = "Sáng";
            this.chkMorning.UseVisualStyleBackColor = true;
            this.chkMorning.Visible = false;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(518, 19);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(29, 16);
            this.lblToDate.TabIndex = 36;
            this.lblToDate.Text = "đến";
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Location = new System.Drawing.Point(4, 19);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(78, 16);
            this.lblBillNumber.TabIndex = 6;
            this.lblBillNumber.Text = "Số hóa đơn:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(311, 19);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(60, 16);
            this.lblFromDate.TabIndex = 10;
            this.lblFromDate.Text = "Từ ngày:";
            this.lblFromDate.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(98, 42);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(270, 23);
            this.txtCustomer.TabIndex = 24;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(3, 45);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(72, 16);
            this.lblCustomer.TabIndex = 25;
            this.lblCustomer.Text = "Tên khách:";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(98, 16);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(194, 23);
            this.txtBillNumber.TabIndex = 2;
            // 
            // dgvSaleList
            // 
            this.dgvSaleList.AllowUserToAddRows = false;
            this.dgvSaleList.AllowUserToDeleteRows = false;
            this.dgvSaleList.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseOrderIdDataGridViewTextBoxColumn,
            this.purchaseOrderDataGridViewTextBoxColumn,
            this.sellDescriptionDataGridViewTextBoxColumn,
            this.sellAmountDataGridViewTextBoxColumn,
            this.returnDescriptionDataGridViewTextBoxColumn,
            this.returnAmountDataGridViewTextBoxColumn,
            this.ReturnDescription});
            this.dgvSaleList.DataSource = this.bdsPurchaseOrders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "##,##0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSaleList.Location = new System.Drawing.Point(17, 124);
            this.dgvSaleList.Name = "dgvSaleList";
            this.dgvSaleList.ReadOnly = true;
            this.dgvSaleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleList.Size = new System.Drawing.Size(800, 330);
            this.dgvSaleList.TabIndex = 3;
            this.dgvSaleList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // purchaseOrderIdDataGridViewTextBoxColumn
            // 
            this.purchaseOrderIdDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn.HeaderText = "Số hóa đơn";
            this.purchaseOrderIdDataGridViewTextBoxColumn.Name = "purchaseOrderIdDataGridViewTextBoxColumn";
            this.purchaseOrderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseOrderIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // purchaseOrderDataGridViewTextBoxColumn
            // 
            this.purchaseOrderDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder";
            this.purchaseOrderDataGridViewTextBoxColumn.HeaderText = "PurchaseOrder";
            this.purchaseOrderDataGridViewTextBoxColumn.Name = "purchaseOrderDataGridViewTextBoxColumn";
            this.purchaseOrderDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseOrderDataGridViewTextBoxColumn.Visible = false;
            // 
            // sellDescriptionDataGridViewTextBoxColumn
            // 
            this.sellDescriptionDataGridViewTextBoxColumn.DataPropertyName = "SellDescription";
            this.sellDescriptionDataGridViewTextBoxColumn.HeaderText = "Hàng bán ra";
            this.sellDescriptionDataGridViewTextBoxColumn.Name = "sellDescriptionDataGridViewTextBoxColumn";
            this.sellDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellDescriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // sellAmountDataGridViewTextBoxColumn
            // 
            this.sellAmountDataGridViewTextBoxColumn.DataPropertyName = "SellAmount";
            this.sellAmountDataGridViewTextBoxColumn.HeaderText = "Tiền bán";
            this.sellAmountDataGridViewTextBoxColumn.Name = "sellAmountDataGridViewTextBoxColumn";
            this.sellAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellAmountDataGridViewTextBoxColumn.Width = 120;
            // 
            // returnDescriptionDataGridViewTextBoxColumn
            // 
            this.returnDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ReturnDescription";
            this.returnDescriptionDataGridViewTextBoxColumn.HeaderText = "Hàng trả";
            this.returnDescriptionDataGridViewTextBoxColumn.Name = "returnDescriptionDataGridViewTextBoxColumn";
            this.returnDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnDescriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // returnAmountDataGridViewTextBoxColumn
            // 
            this.returnAmountDataGridViewTextBoxColumn.DataPropertyName = "ReturnAmount";
            this.returnAmountDataGridViewTextBoxColumn.HeaderText = "Tiền trả";
            this.returnAmountDataGridViewTextBoxColumn.Name = "returnAmountDataGridViewTextBoxColumn";
            this.returnAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnAmountDataGridViewTextBoxColumn.Width = 120;
            // 
            // ReturnDescription
            // 
            this.ReturnDescription.DataPropertyName = "IssueDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm:ss";
            this.ReturnDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReturnDescription.HeaderText = "Ngày phát hành";
            this.ReturnDescription.Name = "ReturnDescription";
            this.ReturnDescription.ReadOnly = true;
            this.ReturnDescription.Width = 150;
            // 
            // bdsPurchaseOrders
            // 
            this.bdsPurchaseOrders.DataSource = typeof(AppFrameClient.ViewModel.PurchaseOrderView);
            // 
            // chkMorningSort
            // 
            this.chkMorningSort.AutoSize = true;
            this.chkMorningSort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMorningSort.Location = new System.Drawing.Point(11, 460);
            this.chkMorningSort.Name = "chkMorningSort";
            this.chkMorningSort.Size = new System.Drawing.Size(56, 20);
            this.chkMorningSort.TabIndex = 41;
            this.chkMorningSort.Text = "Sáng";
            this.chkMorningSort.UseVisualStyleBackColor = true;
            this.chkMorningSort.Visible = false;
            // 
            // chkEveningSort
            // 
            this.chkEveningSort.AutoSize = true;
            this.chkEveningSort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEveningSort.Location = new System.Drawing.Point(109, 460);
            this.chkEveningSort.Name = "chkEveningSort";
            this.chkEveningSort.Size = new System.Drawing.Size(59, 20);
            this.chkEveningSort.TabIndex = 42;
            this.chkEveningSort.Text = "Chiều";
            this.chkEveningSort.UseVisualStyleBackColor = true;
            this.chkEveningSort.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(385, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Xuất ra Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(500, 484);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 44;
            this.btnPrint.Text = "In ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(572, 460);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(64, 16);
            this.lblTotalAmount.TabIndex = 46;
            this.lblTotalAmount.Text = "Tổng thu:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(641, 457);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(176, 23);
            this.txtTotalAmount.TabIndex = 47;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Report (*.xls)|*.xls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 460);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 66;
            this.label3.Text = "Số lượng trả :";
            // 
            // txtRetQty
            // 
            this.txtRetQty.Location = new System.Drawing.Point(466, 457);
            this.txtRetQty.Name = "txtRetQty";
            this.txtRetQty.ReadOnly = true;
            this.txtRetQty.Size = new System.Drawing.Size(100, 20);
            this.txtRetQty.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(172, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "Số lượng bán :";
            // 
            // txtSellQty
            // 
            this.txtSellQty.Location = new System.Drawing.Point(266, 457);
            this.txtSellQty.Name = "txtSellQty";
            this.txtSellQty.ReadOnly = true;
            this.txtSellQty.Size = new System.Drawing.Size(100, 20);
            this.txtSellQty.TabIndex = 63;
            // 
            // DepartmentBindingSource
            // 
            this.DepartmentBindingSource.DataSource = typeof(AppFrame.Model.Department);
            // 
            // PurchaseOrderDetailBindingSource
            // 
            this.PurchaseOrderDetailBindingSource.DataSource = typeof(AppFrame.Model.PurchaseOrderDetail);
            // 
            // ProductReportCollectionBindingSource
            // 
            this.ProductReportCollectionBindingSource.DataSource = typeof(AppFrame.Collection.ProductReportCollection);
            // 
            // ReceiptBindingSource
            // 
            this.ReceiptBindingSource.DataSource = typeof(AppFrame.Model.Receipt);
            // 
            // bdsBill
            // 
            this.bdsBill.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailCollection);
            // 
            // PurchaseOrderBindingSource
            // 
            this.PurchaseOrderBindingSource.DataSource = typeof(AppFrame.Model.PurchaseOrder);
            // 
            // PurchaseOrderDetailReportCollectionBindingSource
            // 
            this.PurchaseOrderDetailReportCollectionBindingSource.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailReportCollection);
            // 
            // PurchaseOrderDetailCollectionBindingSource
            // 
            this.PurchaseOrderDetailCollectionBindingSource.DataSource = typeof(AppFrame.Collection.PurchaseOrderDetailCollection);
            // 
            // GoodsSaleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 520);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRetQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSellQty);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkEveningSort);
            this.Controls.Add(this.chkMorningSort);
            this.Controls.Add(this.dgvSaleList);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Name = "GoodsSaleListForm";
            this.Text = "Báo cáo doanh thu";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.dgvSaleList, 0);
            this.Controls.SetChildIndex(this.chkMorningSort, 0);
            this.Controls.SetChildIndex(this.chkEveningSort, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.lblTotalAmount, 0);
            this.Controls.SetChildIndex(this.txtTotalAmount, 0);
            this.Controls.SetChildIndex(this.txtSellQty, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRetQty, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailReportCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnHelp;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgvSaleList;
        public System.Windows.Forms.Label lblBillNumber;
        public System.Windows.Forms.Label lblFromDate;
        public System.Windows.Forms.TextBox txtCustomer;
        public System.Windows.Forms.Label lblCustomer;
        public System.Windows.Forms.TextBox txtBillNumber;
        public System.Windows.Forms.ComboBox cboEmployee;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.CheckBox chkEvening;
        public System.Windows.Forms.CheckBox chkMorning;
        public System.Windows.Forms.Label lblToDate;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.CheckBox chkMorningSort;
        public System.Windows.Forms.CheckBox chkEveningSort;
        public System.Windows.Forms.Label lblWorkingTime;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.BindingSource bdsPurchaseOrders;
        public System.Windows.Forms.Label lblTotalAmount;
        public System.Windows.Forms.TextBox txtTotalAmount;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRetQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSellQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDescription;
        private System.Windows.Forms.BindingSource DepartmentBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailBindingSource;
        private System.Windows.Forms.BindingSource ProductReportCollectionBindingSource;
        private System.Windows.Forms.BindingSource ReceiptBindingSource;
        private System.Windows.Forms.BindingSource bdsBill;
        private System.Windows.Forms.BindingSource PurchaseOrderBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailReportCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailCollectionBindingSource;




    }
}