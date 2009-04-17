namespace AppFrameClient.View.GoodsSale
{
    partial class DayGoodsSaleListForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkEveningSort = new System.Windows.Forms.CheckBox();
            this.chkMorningSort = new System.Windows.Forms.CheckBox();
            this.dgvSaleList = new System.Windows.Forms.DataGridView();
            this.bdsPurchaseOrders = new System.Windows.Forms.BindingSource(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDepartmentId = new System.Windows.Forms.Label();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.txtDepartmentId = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(AppFrame.Model.PurchaseOrder);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(497, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "In ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(382, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "Xuất ra Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkEveningSort
            // 
            this.chkEveningSort.AutoSize = true;
            this.chkEveningSort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEveningSort.Location = new System.Drawing.Point(106, 497);
            this.chkEveningSort.Name = "chkEveningSort";
            this.chkEveningSort.Size = new System.Drawing.Size(56, 18);
            this.chkEveningSort.TabIndex = 50;
            this.chkEveningSort.Text = "Chiều";
            this.chkEveningSort.UseVisualStyleBackColor = true;
            this.chkEveningSort.Visible = false;
            // 
            // chkMorningSort
            // 
            this.chkMorningSort.AutoSize = true;
            this.chkMorningSort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMorningSort.Location = new System.Drawing.Point(8, 497);
            this.chkMorningSort.Name = "chkMorningSort";
            this.chkMorningSort.Size = new System.Drawing.Size(53, 18);
            this.chkMorningSort.TabIndex = 49;
            this.chkMorningSort.Text = "Sáng";
            this.chkMorningSort.UseVisualStyleBackColor = true;
            this.chkMorningSort.Visible = false;
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
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.ReturnDescription,
            this.purchaseOrderIdDataGridViewTextBoxColumn,
            this.purchaseOrderDataGridViewTextBoxColumn,
            this.sellDescriptionDataGridViewTextBoxColumn,
            this.sellAmountDataGridViewTextBoxColumn,
            this.returnAmountDataGridViewTextBoxColumn,
            this.returnDescriptionDataGridViewTextBoxColumn});
            this.dgvSaleList.DataSource = this.bdsPurchaseOrders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "##,#00";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSaleList.Location = new System.Drawing.Point(8, 98);
            this.dgvSaleList.Name = "dgvSaleList";
            this.dgvSaleList.ReadOnly = true;
            this.dgvSaleList.Size = new System.Drawing.Size(984, 361);
            this.dgvSaleList.TabIndex = 45;
            // 
            // bdsPurchaseOrders
            // 
            this.bdsPurchaseOrders.DataSource = typeof(AppFrameClient.ViewModel.PurchaseOrderView);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(8, 531);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 47;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(926, 531);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblDepartmentId);
            this.groupBox2.Controls.Add(this.txtDepartmentName);
            this.groupBox2.Controls.Add(this.lblDepartmentName);
            this.groupBox2.Controls.Add(this.txtDepartmentId);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 80);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin ";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(489, 16);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(164, 22);
            this.txtDate.TabIndex = 35;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(449, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 14);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = "Ngày";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 14);
            this.label7.TabIndex = 33;
            // 
            // lblDepartmentId
            // 
            this.lblDepartmentId.AutoSize = true;
            this.lblDepartmentId.Location = new System.Drawing.Point(4, 19);
            this.lblDepartmentId.Name = "lblDepartmentId";
            this.lblDepartmentId.Size = new System.Drawing.Size(81, 14);
            this.lblDepartmentId.TabIndex = 6;
            this.lblDepartmentId.Text = "Mã cửa hàng:";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(98, 42);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(369, 22);
            this.txtDepartmentName.TabIndex = 24;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Location = new System.Drawing.Point(3, 45);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(88, 14);
            this.lblDepartmentName.TabIndex = 25;
            this.lblDepartmentName.Text = "Tên cửa hàng:";
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.Location = new System.Drawing.Point(98, 16);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.ReadOnly = true;
            this.txtDepartmentId.Size = new System.Drawing.Size(194, 22);
            this.txtDepartmentId.TabIndex = 2;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(681, 465);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(320, 22);
            this.txtTotalAmount.TabIndex = 54;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(612, 467);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(63, 14);
            this.lblTotalAmount.TabIndex = 53;
            this.lblTotalAmount.Text = "Tổng thu:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "PurchaseOrder";
            reportDataSource1.Value = this.BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AppFrameClient.Report.PurchaseOrderList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(400, 250);
            this.reportViewer1.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Report (*.xls)|*.xls";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PurchaseOrderId";
            this.Column1.HeaderText = "Số hóa đơn";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SellDescription";
            this.Column2.HeaderText = "Hàng bán";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SellAmount";
            this.Column3.HeaderText = "Tiền bán";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ReturnDescription";
            this.Column4.HeaderText = "Hàng trả";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ReturnAmount";
            this.Column5.HeaderText = "Tổng tiền trả";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
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
            // purchaseOrderIdDataGridViewTextBoxColumn
            // 
            this.purchaseOrderIdDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn.Name = "purchaseOrderIdDataGridViewTextBoxColumn";
            this.purchaseOrderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseOrderIdDataGridViewTextBoxColumn.Visible = false;
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
            this.sellDescriptionDataGridViewTextBoxColumn.HeaderText = "SellDescription";
            this.sellDescriptionDataGridViewTextBoxColumn.Name = "sellDescriptionDataGridViewTextBoxColumn";
            this.sellDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellDescriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // sellAmountDataGridViewTextBoxColumn
            // 
            this.sellAmountDataGridViewTextBoxColumn.DataPropertyName = "SellAmount";
            this.sellAmountDataGridViewTextBoxColumn.HeaderText = "SellAmount";
            this.sellAmountDataGridViewTextBoxColumn.Name = "sellAmountDataGridViewTextBoxColumn";
            this.sellAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellAmountDataGridViewTextBoxColumn.Visible = false;
            // 
            // returnAmountDataGridViewTextBoxColumn
            // 
            this.returnAmountDataGridViewTextBoxColumn.DataPropertyName = "ReturnAmount";
            this.returnAmountDataGridViewTextBoxColumn.HeaderText = "ReturnAmount";
            this.returnAmountDataGridViewTextBoxColumn.Name = "returnAmountDataGridViewTextBoxColumn";
            this.returnAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnAmountDataGridViewTextBoxColumn.Visible = false;
            // 
            // returnDescriptionDataGridViewTextBoxColumn
            // 
            this.returnDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ReturnDescription";
            this.returnDescriptionDataGridViewTextBoxColumn.HeaderText = "ReturnDescription";
            this.returnDescriptionDataGridViewTextBoxColumn.Name = "returnDescriptionDataGridViewTextBoxColumn";
            this.returnDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnDescriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // DayGoodsSaleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 567);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkEveningSort);
            this.Controls.Add(this.chkMorningSort);
            this.Controls.Add(this.dgvSaleList);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Name = "DayGoodsSaleListForm";
            this.Text = "Doanh thu của cửa hàng trong ngày";
            this.Load += new System.EventHandler(this.DayGoodsSaleListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkEveningSort;
        private System.Windows.Forms.CheckBox chkMorningSort;
        private System.Windows.Forms.DataGridView dgvSaleList;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDepartmentId;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.TextBox txtDepartmentId;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.BindingSource bdsPurchaseOrders;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDescriptionDataGridViewTextBoxColumn;
    }
}