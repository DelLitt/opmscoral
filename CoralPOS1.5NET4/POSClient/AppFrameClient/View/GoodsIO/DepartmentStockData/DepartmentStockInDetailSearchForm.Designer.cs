namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentStockInDetailSearchForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStockDateFrom = new System.Windows.Forms.DateTimePicker();
            this.chkStockDateFrom = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStockDateTo = new System.Windows.Forms.DateTimePicker();
            this.chkStockDateTo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.productMasterSearchControl = new AppFrameClient.View.GoodsIO.ProductMasterSearchControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSumInQuantity = new System.Windows.Forms.TextBox();
            this.txtSumRemainQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(343, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 19);
            this.label7.TabIndex = 42;
            this.label7.Text = "CHI TIẾT NHẬP HÀNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 44;
            this.label1.Text = "Nhập từ ngày";
            // 
            // dtpStockDateFrom
            // 
            this.dtpStockDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpStockDateFrom.Enabled = false;
            this.dtpStockDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStockDateFrom.Location = new System.Drawing.Point(103, 44);
            this.dtpStockDateFrom.Name = "dtpStockDateFrom";
            this.dtpStockDateFrom.Size = new System.Drawing.Size(164, 22);
            this.dtpStockDateFrom.TabIndex = 45;
            // 
            // chkStockDateFrom
            // 
            this.chkStockDateFrom.AutoSize = true;
            this.chkStockDateFrom.Location = new System.Drawing.Point(273, 48);
            this.chkStockDateFrom.Name = "chkStockDateFrom";
            this.chkStockDateFrom.Size = new System.Drawing.Size(15, 14);
            this.chkStockDateFrom.TabIndex = 46;
            this.chkStockDateFrom.UseVisualStyleBackColor = true;
            this.chkStockDateFrom.CheckedChanged += new System.EventHandler(this.chkStockDateFrom_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "đến ngày";
            // 
            // dtpStockDateTo
            // 
            this.dtpStockDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpStockDateTo.Enabled = false;
            this.dtpStockDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStockDateTo.Location = new System.Drawing.Point(387, 44);
            this.dtpStockDateTo.Name = "dtpStockDateTo";
            this.dtpStockDateTo.Size = new System.Drawing.Size(164, 22);
            this.dtpStockDateTo.TabIndex = 48;
            // 
            // chkStockDateTo
            // 
            this.chkStockDateTo.AutoSize = true;
            this.chkStockDateTo.Location = new System.Drawing.Point(557, 50);
            this.chkStockDateTo.Name = "chkStockDateTo";
            this.chkStockDateTo.Size = new System.Drawing.Size(15, 14);
            this.chkStockDateTo.TabIndex = 49;
            this.chkStockDateTo.UseVisualStyleBackColor = true;
            this.chkStockDateTo.CheckedChanged += new System.EventHandler(this.chkStockDateTo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 50;
            this.label3.Text = "Giá niêm yết";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Location = new System.Drawing.Point(675, 44);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(185, 22);
            this.txtSellPrice.TabIndex = 51;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(9, 190);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(851, 220);
            this.dgvProduct.TabIndex = 52;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(783, 161);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 53;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(783, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(702, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // productMasterSearchControl
            // 
            this.productMasterSearchControl.Location = new System.Drawing.Point(3, 64);
            this.productMasterSearchControl.Name = "productMasterSearchControl";
            this.productMasterSearchControl.Size = new System.Drawing.Size(918, 120);
            this.productMasterSearchControl.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 14);
            this.label4.TabIndex = 56;
            this.label4.Text = "Tổng lượng hàng đã nhập";
            // 
            // txtSumInQuantity
            // 
            this.txtSumInQuantity.Location = new System.Drawing.Point(167, 418);
            this.txtSumInQuantity.Name = "txtSumInQuantity";
            this.txtSumInQuantity.ReadOnly = true;
            this.txtSumInQuantity.Size = new System.Drawing.Size(259, 22);
            this.txtSumInQuantity.TabIndex = 57;
            // 
            // txtSumRemainQuantity
            // 
            this.txtSumRemainQuantity.Location = new System.Drawing.Point(600, 416);
            this.txtSumRemainQuantity.Name = "txtSumRemainQuantity";
            this.txtSumRemainQuantity.ReadOnly = true;
            this.txtSumRemainQuantity.Size = new System.Drawing.Size(258, 22);
            this.txtSumRemainQuantity.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 14);
            this.label5.TabIndex = 58;
            this.label5.Text = "Tổng lượng hàng còn lại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(661, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 60;
            this.label6.Text = "$";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DepartmentStockInDetailSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 472);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSumRemainQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSumInQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkStockDateTo);
            this.Controls.Add(this.dtpStockDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkStockDateFrom);
            this.Controls.Add(this.dtpStockDateFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productMasterSearchControl);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepartmentStockInDetailSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DepartmentStockInDetailSearchForm";
            this.Load += new System.EventHandler(this.DepartmentStockInDetailSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private ProductMasterSearchControl productMasterSearchControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStockDateFrom;
        private System.Windows.Forms.CheckBox chkStockDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStockDateTo;
        private System.Windows.Forms.CheckBox chkStockDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSumInQuantity;
        private System.Windows.Forms.TextBox txtSumRemainQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}