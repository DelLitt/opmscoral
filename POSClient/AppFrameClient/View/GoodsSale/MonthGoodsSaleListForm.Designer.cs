namespace AppFrameClient.View.GoodsSale
{
    partial class MonthGoodsSaleListForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkEveningSort = new System.Windows.Forms.CheckBox();
            this.chkMorningSort = new System.Windows.Forms.CheckBox();
            this.dgvSaleList = new System.Windows.Forms.DataGridView();
            this.bdsPurchaseOrders = new System.Windows.Forms.BindingSource(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDepartmentId = new System.Windows.Forms.Label();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.txtDepartmentId = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.purchaseOrderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvSaleList.Location = new System.Drawing.Point(8, 98);
            this.dgvSaleList.Name = "dgvSaleList";
            this.dgvSaleList.ReadOnly = true;
            this.dgvSaleList.Size = new System.Drawing.Size(993, 357);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDepartmentId);
            this.groupBox1.Controls.Add(this.txtDepartmentName);
            this.groupBox1.Controls.Add(this.lblDepartmentName);
            this.groupBox1.Controls.Add(this.txtDepartmentId);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 80);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "đến";
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(750, 16);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.ReadOnly = true;
            this.txtDateTo.Size = new System.Drawing.Size(164, 22);
            this.txtDateTo.TabIndex = 36;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(527, 16);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.ReadOnly = true;
            this.txtDateFrom.Size = new System.Drawing.Size(164, 22);
            this.txtDateFrom.TabIndex = 35;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(468, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 14);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 33;
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
            this.txtTotalAmount.Location = new System.Drawing.Point(681, 461);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(320, 22);
            this.txtTotalAmount.TabIndex = 54;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(612, 463);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(63, 14);
            this.lblTotalAmount.TabIndex = 53;
            this.lblTotalAmount.Text = "Tổng thu:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Report (*.xls)|*.xls";
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
            this.sellAmountDataGridViewTextBoxColumn.Width = 150;
            // 
            // returnDescriptionDataGridViewTextBoxColumn
            // 
            this.returnDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ReturnDescription";
            this.returnDescriptionDataGridViewTextBoxColumn.HeaderText = "Hàng trả lại";
            this.returnDescriptionDataGridViewTextBoxColumn.Name = "returnDescriptionDataGridViewTextBoxColumn";
            this.returnDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnDescriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // returnAmountDataGridViewTextBoxColumn
            // 
            this.returnAmountDataGridViewTextBoxColumn.DataPropertyName = "ReturnAmount";
            this.returnAmountDataGridViewTextBoxColumn.HeaderText = "Tiền trả lại";
            this.returnAmountDataGridViewTextBoxColumn.Name = "returnAmountDataGridViewTextBoxColumn";
            this.returnAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnAmountDataGridViewTextBoxColumn.Width = 150;
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
            // MonthGoodsSaleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 567);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkEveningSort);
            this.Controls.Add(this.chkMorningSort);
            this.Controls.Add(this.dgvSaleList);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Name = "MonthGoodsSaleListForm";
            this.Text = "Doanh thu của cửa hàng trong tháng";
            this.Load += new System.EventHandler(this.MonthGoodsSaleListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDepartmentId;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.TextBox txtDepartmentId;
        private System.Windows.Forms.BindingSource bdsPurchaseOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDescription;
    }
}