namespace AppFrameClient.View.GoodsIO
{
    partial class GoodsInput
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
            this.txtBlockId = new System.Windows.Forms.TextBox();
            this.cbbSupplier = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.SearchCreate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDexcription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSumValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productColorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productSizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productColorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSizeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBlockId
            // 
            this.txtBlockId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlockId.Location = new System.Drawing.Point(103, 45);
            this.txtBlockId.Name = "txtBlockId";
            this.txtBlockId.ReadOnly = true;
            this.txtBlockId.Size = new System.Drawing.Size(92, 22);
            this.txtBlockId.TabIndex = 0;
            // 
            // cbbSupplier
            // 
            this.cbbSupplier.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.supplierBindingSource, "SupplierId", true));
            this.cbbSupplier.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.supplierBindingSource, "SupplierName", true));
            this.cbbSupplier.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupplierName", true));
            this.cbbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSupplier.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSupplier.FormattingEnabled = true;
            this.cbbSupplier.Location = new System.Drawing.Point(103, 96);
            this.cbbSupplier.Name = "cbbSupplier";
            this.cbbSupplier.Size = new System.Drawing.Size(348, 22);
            this.cbbSupplier.TabIndex = 1;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(AppFrame.Model.Supplier);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(103, 123);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 22);
            this.textBox2.TabIndex = 2;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SearchCreate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduct.Location = new System.Drawing.Point(12, 175);
            this.dgvProduct.MultiSelect = false;
            this.dgvProduct.Name = "dgvProduct";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduct.Size = new System.Drawing.Size(746, 189);
            this.dgvProduct.TabIndex = 3;
            this.dgvProduct.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellLeave);
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick);
            // 
            // SearchCreate
            // 
            this.SearchCreate.HeaderText = "Search/Create";
            this.SearchCreate.Name = "SearchCreate";
            this.SearchCreate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchCreate.Text = "Search/Create";
            this.SearchCreate.ToolTipText = "Search/Create";
            this.SearchCreate.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(683, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(186, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lô hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Diễn tả lô hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nhà phân phối";
            // 
            // txtDexcription
            // 
            this.txtDexcription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDexcription.Location = new System.Drawing.Point(103, 70);
            this.txtDexcription.Name = "txtDexcription";
            this.txtDexcription.Size = new System.Drawing.Size(494, 22);
            this.txtDexcription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Xuất xứ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chi tiết lô hàng";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSumValue
            // 
            this.txtSumValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumValue.Location = new System.Drawing.Point(587, 372);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.ReadOnly = true;
            this.txtSumValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSumValue.Size = new System.Drawing.Size(171, 22);
            this.txtSumValue.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(511, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tổng giá trị";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(12, 422);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Giúp đỡ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(182, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "NHẬP HÀNG HÓA/ CHỈNH SỬA HÀNG HÓA";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(12, 370);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "Tạo mã vạch";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(247, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ngày nhập:";
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDate.Location = new System.Drawing.Point(315, 44);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(200, 22);
            this.dtpImportDate.TabIndex = 20;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(267, 422);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 21;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 454);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 23;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(AppFrame.Model.Product);
            // 
            // productTypeBindingSource
            // 
            this.productTypeBindingSource.DataSource = typeof(AppFrame.Model.ProductType);
            // 
            // productColorBindingSource
            // 
            this.productColorBindingSource.DataSource = typeof(AppFrame.Model.ProductColor);
            // 
            // productSizeBindingSource
            // 
            this.productSizeBindingSource.DataSource = typeof(AppFrame.Model.ProductSize);
            // 
            // supplierBindingSource1
            // 
            this.supplierBindingSource1.DataSource = typeof(AppFrame.Model.Supplier);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.Location = new System.Drawing.Point(348, 422);
            this.numericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown.Size = new System.Drawing.Size(51, 22);
            this.numericUpDown.TabIndex = 24;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(405, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "sản phẩm";
            // 
            // GoodsInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(770, 469);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dtpImportDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDexcription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.cbbSupplier);
            this.Controls.Add(this.txtBlockId);
            this.Name = "GoodsInput";
            this.Text = "GoodsInput";
            this.Load += new System.EventHandler(this.GoodsInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productColorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSizeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBlockId;
        private System.Windows.Forms.ComboBox cbbSupplier;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDexcription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSumValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.DateTimePicker dtpImportDate;
        private System.Windows.Forms.BindingSource productTypeBindingSource;
        private System.Windows.Forms.BindingSource supplierBindingSource1;
        private System.Windows.Forms.BindingSource productColorBindingSource;
        private System.Windows.Forms.BindingSource productSizeBindingSource;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewButtonColumn SearchCreate;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label9;
    }
}