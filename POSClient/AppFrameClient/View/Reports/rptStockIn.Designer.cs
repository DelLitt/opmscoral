namespace AppFrameClient.View.Reports
{
    partial class frmStockinStatistic
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dgvStockProducts = new System.Windows.Forms.DataGridView();
            this.bdsStockInResultPM = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockProductsDetail = new System.Windows.Forms.DataGridView();
            this.bdsStockInResultDetail = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.view_group = new System.Windows.Forms.Button();
            this.view_detail = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockInTotalAmountsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockInResultPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockProductsDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockInResultDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO NHẬP HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đến ngày";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(178, 57);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(452, 56);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // dgvStockProducts
            // 
            this.dgvStockProducts.AutoGenerateColumns = false;
            this.dgvStockProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.ProductName,
            this.Category,
            this.receipt,
            this.amount,
            this.stockInTotalAmountsDataGridViewTextBoxColumn});
            this.dgvStockProducts.DataSource = this.bdsStockInResultPM;
            this.dgvStockProducts.Location = new System.Drawing.Point(13, 115);
            this.dgvStockProducts.MultiSelect = false;
            this.dgvStockProducts.Name = "dgvStockProducts";
            this.dgvStockProducts.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockProducts.Size = new System.Drawing.Size(849, 150);
            this.dgvStockProducts.TabIndex = 3;
            this.dgvStockProducts.SelectionChanged += new System.EventHandler(this.dgvStockProducts_SelectionChanged);
            // 
            // bdsStockInResultPM
            // 
            this.bdsStockInResultPM.DataSource = typeof(AppFrameClient.ViewModel.StockInResultDetailCollection);
            // 
            // dgvStockProductsDetail
            // 
            this.dgvStockProductsDetail.AutoGenerateColumns = false;
            this.dgvStockProductsDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockProductsDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.receipt_date,
            this.quantity,
            this.total,
            this.color,
            this.size,
            this.delFlgDataGridViewTextBoxColumn,
            this.CreateId});
            this.dgvStockProductsDetail.DataSource = this.bdsStockInResultDetail;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockProductsDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockProductsDetail.Location = new System.Drawing.Point(13, 306);
            this.dgvStockProductsDetail.MultiSelect = false;
            this.dgvStockProductsDetail.Name = "dgvStockProductsDetail";
            this.dgvStockProductsDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockProductsDetail.Size = new System.Drawing.Size(849, 203);
            this.dgvStockProductsDetail.TabIndex = 4;
            this.dgvStockProductsDetail.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvStockProductsDetail_RowPrePaint);
            // 
            // bdsStockInResultDetail
            // 
            this.bdsStockInResultDetail.DataSource = typeof(AppFrame.Collection.StockInDetailCollection);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chi tiết hàng nhập";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(687, 53);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(98, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "Xem thông tin";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // view_group
            // 
            this.view_group.Location = new System.Drawing.Point(606, 527);
            this.view_group.Name = "view_group";
            this.view_group.Size = new System.Drawing.Size(85, 25);
            this.view_group.TabIndex = 7;
            this.view_group.Text = "In tổng hợp";
            this.view_group.UseVisualStyleBackColor = true;
            // 
            // view_detail
            // 
            this.view_detail.Location = new System.Drawing.Point(697, 527);
            this.view_detail.Name = "view_detail";
            this.view_detail.Size = new System.Drawing.Size(78, 25);
            this.view_detail.TabIndex = 8;
            this.view_detail.Text = "Ịn chi tiết";
            this.view_detail.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 529);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Xem trước";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(781, 527);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductMasterGlobal.ProductMaster.ProductType.TypeName";
            this.ProductName.HeaderText = "Tên hàng";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "ProductMasterGlobal.ProductName";
            this.Category.HeaderText = "Loại hàng";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 250;
            // 
            // receipt
            // 
            this.receipt.DataPropertyName = "StockInQuantities";
            this.receipt.HeaderText = "Tổng số nhập";
            this.receipt.Name = "receipt";
            this.receipt.ReadOnly = true;
            this.receipt.Width = 200;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "StockInTotalAmounts";
            this.amount.HeaderText = "Tổng giá nhập";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 205;
            // 
            // stockInTotalAmountsDataGridViewTextBoxColumn
            // 
            this.stockInTotalAmountsDataGridViewTextBoxColumn.DataPropertyName = "StockInTotalAmounts";
            this.stockInTotalAmountsDataGridViewTextBoxColumn.HeaderText = "StockInTotalAmounts";
            this.stockInTotalAmountsDataGridViewTextBoxColumn.Name = "stockInTotalAmountsDataGridViewTextBoxColumn";
            this.stockInTotalAmountsDataGridViewTextBoxColumn.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "STT";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // receipt_date
            // 
            this.receipt_date.DataPropertyName = "CreateDate";
            this.receipt_date.HeaderText = "Ngày nhập";
            this.receipt_date.Name = "receipt_date";
            this.receipt_date.ReadOnly = true;
            this.receipt_date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.receipt_date.Width = 120;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "Quantity";
            this.quantity.HeaderText = "Số lương nhập";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 150;
            // 
            // total
            // 
            this.total.DataPropertyName = "Price";
            this.total.HeaderText = "Giá nhập";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 195;
            // 
            // color
            // 
            this.color.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.color.HeaderText = "Màu";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 120;
            // 
            // size
            // 
            this.size.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.size.HeaderText = "Kích cỡ";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 120;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // CreateId
            // 
            this.CreateId.DataPropertyName = "CreateId";
            this.CreateId.HeaderText = "CreateId";
            this.CreateId.Name = "CreateId";
            this.CreateId.Visible = false;
            // 
            // frmStockinStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 562);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.view_detail);
            this.Controls.Add(this.view_group);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvStockProductsDetail);
            this.Controls.Add(this.dgvStockProducts);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmStockinStatistic";
            this.Text = "Báo cáo nhập hàng";
            this.Load += new System.EventHandler(this.frmStockinStatistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockInResultPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockProductsDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockInResultDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dgvStockProducts;
        private System.Windows.Forms.DataGridView dgvStockProductsDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button view_group;
        private System.Windows.Forms.Button view_detail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bdsStockInResultPM;
        private System.Windows.Forms.BindingSource bdsStockInResultDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockInTotalAmountsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateId;
    }
}