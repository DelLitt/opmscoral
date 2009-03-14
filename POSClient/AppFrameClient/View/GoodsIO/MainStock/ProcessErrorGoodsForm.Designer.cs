namespace AppFrameClient.View.GoodsIO.MainStock
{
    partial class ProcessErrorGoodsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bdsStockDefect = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockDefect = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnError = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvReturnStockOut = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsReturnGoods = new System.Windows.Forms.BindingSource(this.components);
            this.lblReturnGoods = new System.Windows.Forms.Label();
            this.lblTempStockOut = new System.Windows.Forms.Label();
            this.lblDestroyGoods = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvTempStockOut = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsTempStockOut = new System.Windows.Forms.BindingSource(this.components);
            this.dgvGoodsDestroy = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsDestroyGoods = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.bdsProductMasters = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsReturnGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTempStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsDestroy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDestroyGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMasters)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(748, 527);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "Bỏ qua";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(897, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(473, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Lưu kết quả xử lý sau kiểm kê";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "KIỂM KÊ HÀNG HÓA TẠI KHO";
            // 
            // dgvStockDefect
            // 
            this.dgvStockDefect.AllowUserToAddRows = false;
            this.dgvStockDefect.AllowUserToDeleteRows = false;
            this.dgvStockDefect.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockDefect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockDefect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Quantity,
            this.columnGood,
            this.columnError,
            this.columnDamage,
            this.columnLost,
            this.Column7});
            this.dgvStockDefect.DataSource = this.bdsStockDefect;
            this.dgvStockDefect.Location = new System.Drawing.Point(12, 44);
            this.dgvStockDefect.Name = "dgvStockDefect";
            this.dgvStockDefect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockDefect.Size = new System.Drawing.Size(960, 187);
            this.dgvStockDefect.TabIndex = 26;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product.ProductId";
            this.Column1.HeaderText = "Mã vạch";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Product.ProductMaster.ProductFullName";
            this.Column2.HeaderText = "Tên hàng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Product.ProductMaster.ProductColor.ColorName";
            this.Column3.HeaderText = "Màu sắc";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Product.ProductMaster.ProductSize.SizeName";
            this.Column4.HeaderText = "Kích cỡ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "##,##0";
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "Tổng";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 60;
            // 
            // columnGood
            // 
            this.columnGood.DataPropertyName = "GoodQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle3.Format = "##,##0";
            this.columnGood.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnGood.HeaderText = "Tốt";
            this.columnGood.Name = "columnGood";
            this.columnGood.Width = 60;
            // 
            // columnError
            // 
            this.columnError.DataPropertyName = "ErrorQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle4.Format = "##,##0";
            this.columnError.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnError.HeaderText = "Lỗi";
            this.columnError.Name = "columnError";
            this.columnError.Width = 60;
            // 
            // columnDamage
            // 
            this.columnDamage.DataPropertyName = "DamageQuantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle5.Format = "##,##0";
            this.columnDamage.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnDamage.HeaderText = "Hư";
            this.columnDamage.Name = "columnDamage";
            this.columnDamage.Width = 60;
            // 
            // columnLost
            // 
            this.columnLost.DataPropertyName = "LostQuantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle6.Format = "##,##0";
            this.columnLost.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnLost.HeaderText = "Mất";
            this.columnLost.Name = "columnLost";
            this.columnLost.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UnconfirmQuantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle7.Format = "##,##0";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column7.HeaderText = "Không xác định";
            this.Column7.Name = "Column7";
            this.Column7.Width = 144;
            // 
            // btnError
            // 
            this.btnError.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnError.Location = new System.Drawing.Point(12, 237);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(204, 23);
            this.btnError.TabIndex = 31;
            this.btnError.Text = "Trả hàng lỗi cho nhà sản xuất";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(446, 237);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 23);
            this.button4.TabIndex = 32;
            this.button4.Text = "Huỷ hàng hư mất";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvReturnStockOut
            // 
            this.dgvReturnStockOut.AllowUserToAddRows = false;
            this.dgvReturnStockOut.AllowUserToDeleteRows = false;
            this.dgvReturnStockOut.AutoGenerateColumns = false;
            this.dgvReturnStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnStockOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.ErrorCount});
            this.dgvReturnStockOut.DataSource = this.bdsReturnGoods;
            this.dgvReturnStockOut.Location = new System.Drawing.Point(12, 299);
            this.dgvReturnStockOut.Name = "dgvReturnStockOut";
            this.dgvReturnStockOut.Size = new System.Drawing.Size(316, 185);
            this.dgvReturnStockOut.TabIndex = 34;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Product.ProductId";
            this.Column5.HeaderText = "Mã vạch";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Product.ProductMaster.ProductFullName";
            this.Column6.HeaderText = "Tên hàng";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 110;
            // 
            // ErrorCount
            // 
            this.ErrorCount.DataPropertyName = "ErrorQuantity";
            this.ErrorCount.HeaderText = "Số lượng";
            this.ErrorCount.Name = "ErrorCount";
            this.ErrorCount.Width = 80;
            // 
            // lblReturnGoods
            // 
            this.lblReturnGoods.AutoSize = true;
            this.lblReturnGoods.Location = new System.Drawing.Point(12, 283);
            this.lblReturnGoods.Name = "lblReturnGoods";
            this.lblReturnGoods.Size = new System.Drawing.Size(148, 13);
            this.lblReturnGoods.TabIndex = 38;
            this.lblReturnGoods.Text = "Trả hàng lỗi cho nhà sản xuất";
            // 
            // lblTempStockOut
            // 
            this.lblTempStockOut.AutoSize = true;
            this.lblTempStockOut.Location = new System.Drawing.Point(331, 283);
            this.lblTempStockOut.Name = "lblTempStockOut";
            this.lblTempStockOut.Size = new System.Drawing.Size(87, 13);
            this.lblTempStockOut.TabIndex = 39;
            this.lblTempStockOut.Text = "Tạm xuất để sửa";
            // 
            // lblDestroyGoods
            // 
            this.lblDestroyGoods.AutoSize = true;
            this.lblDestroyGoods.Location = new System.Drawing.Point(657, 283);
            this.lblDestroyGoods.Name = "lblDestroyGoods";
            this.lblDestroyGoods.Size = new System.Drawing.Size(74, 13);
            this.lblDestroyGoods.TabIndex = 40;
            this.lblDestroyGoods.Text = "Hàng chờ huỷ";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(263, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Tạm xuất để sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvTempStockOut
            // 
            this.dgvTempStockOut.AllowUserToAddRows = false;
            this.dgvTempStockOut.AllowUserToDeleteRows = false;
            this.dgvTempStockOut.AutoGenerateColumns = false;
            this.dgvTempStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempStockOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvTempStockOut.DataSource = this.bdsTempStockOut;
            this.dgvTempStockOut.Location = new System.Drawing.Point(334, 299);
            this.dgvTempStockOut.Name = "dgvTempStockOut";
            this.dgvTempStockOut.Size = new System.Drawing.Size(316, 185);
            this.dgvTempStockOut.TabIndex = 42;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Product.ProductId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã vạch";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Product.ProductMaster.ProductFullName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên hàng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ErrorQuantity";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dgvGoodsDestroy
            // 
            this.dgvGoodsDestroy.AllowUserToAddRows = false;
            this.dgvGoodsDestroy.AllowUserToDeleteRows = false;
            this.dgvGoodsDestroy.AutoGenerateColumns = false;
            this.dgvGoodsDestroy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsDestroy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvGoodsDestroy.DataSource = this.bdsDestroyGoods;
            this.dgvGoodsDestroy.Location = new System.Drawing.Point(656, 299);
            this.dgvGoodsDestroy.Name = "dgvGoodsDestroy";
            this.dgvGoodsDestroy.Size = new System.Drawing.Size(316, 185);
            this.dgvGoodsDestroy.TabIndex = 43;
            this.dgvGoodsDestroy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoodsDestroy_CellContentClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Product.ProductId";
            this.dataGridViewTextBoxColumn4.HeaderText = "Mã vạch";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Product.ProductMaster.ProductFullName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tên hàng";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn6.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 491);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 44;
            this.button5.Text = "Xoá";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(334, 490);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 45;
            this.button6.Text = "Xoá";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(656, 490);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 46;
            this.button7.Text = "Xoá";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // ProcessErrorGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dgvGoodsDestroy);
            this.Controls.Add(this.dgvTempStockOut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblDestroyGoods);
            this.Controls.Add(this.lblTempStockOut);
            this.Controls.Add(this.lblReturnGoods);
            this.Controls.Add(this.dgvReturnStockOut);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStockDefect);
            this.Name = "ProcessErrorGoodsForm";
            this.Text = "ProcessErrorGoodsForm";
            this.Load += new System.EventHandler(this.ProcessErrorGoodsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsReturnGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTempStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsDestroy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDestroyGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductMasters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bdsProductMasters;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsStockDefect;
        private System.Windows.Forms.DataGridView dgvStockDefect;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvReturnStockOut;
        private System.Windows.Forms.Label lblReturnGoods;
        private System.Windows.Forms.Label lblTempStockOut;
        private System.Windows.Forms.Label lblDestroyGoods;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvTempStockOut;
        private System.Windows.Forms.DataGridView dgvGoodsDestroy;
        private System.Windows.Forms.BindingSource bdsReturnGoods;
        private System.Windows.Forms.BindingSource bdsTempStockOut;
        private System.Windows.Forms.BindingSource bdsDestroyGoods;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGood;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDamage;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}