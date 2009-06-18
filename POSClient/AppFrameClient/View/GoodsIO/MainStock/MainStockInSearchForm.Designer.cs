namespace AppFrameClient.View.GoodsIO.MainStock
{
    partial class MainStockInSearchForm
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
            this.chkImportDateTo = new System.Windows.Forms.CheckBox();
            this.chkImportDateFrom = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpImportDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpImportDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlockInDetailId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // chkImportDateTo
            // 
            this.chkImportDateTo.AutoSize = true;
            this.chkImportDateTo.Location = new System.Drawing.Point(477, 66);
            this.chkImportDateTo.Name = "chkImportDateTo";
            this.chkImportDateTo.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateTo.TabIndex = 22;
            this.chkImportDateTo.UseVisualStyleBackColor = true;
            this.chkImportDateTo.CheckedChanged += new System.EventHandler(this.chkImportDateTo_CheckedChanged);
            // 
            // chkImportDateFrom
            // 
            this.chkImportDateFrom.AutoSize = true;
            this.chkImportDateFrom.Location = new System.Drawing.Point(477, 42);
            this.chkImportDateFrom.Name = "chkImportDateFrom";
            this.chkImportDateFrom.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateFrom.TabIndex = 21;
            this.chkImportDateFrom.UseVisualStyleBackColor = true;
            this.chkImportDateFrom.CheckedChanged += new System.EventHandler(this.chkImportDateFrom_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(396, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 25);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpImportDateTo
            // 
            this.dtpImportDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateTo.Enabled = false;
            this.dtpImportDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateTo.Location = new System.Drawing.Point(358, 66);
            this.dtpImportDateTo.Name = "dtpImportDateTo";
            this.dtpImportDateTo.Size = new System.Drawing.Size(113, 22);
            this.dtpImportDateTo.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nhập kho đến ngày";
            // 
            // dtpImportDateFrom
            // 
            this.dtpImportDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateFrom.Enabled = false;
            this.dtpImportDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateFrom.Location = new System.Drawing.Point(358, 38);
            this.dtpImportDateFrom.Name = "dtpImportDateFrom";
            this.dtpImportDateFrom.Size = new System.Drawing.Size(113, 22);
            this.dtpImportDateFrom.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nhập kho từ ngày";
            // 
            // txtBlockInDetailId
            // 
            this.txtBlockInDetailId.Location = new System.Drawing.Point(56, 40);
            this.txtBlockInDetailId.Name = "txtBlockInDetailId";
            this.txtBlockInDetailId.Size = new System.Drawing.Size(163, 22);
            this.txtBlockInDetailId.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã lô";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(13, 132);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(800, 270);
            this.dgvProduct.TabIndex = 23;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellDoubleClick);
            this.dgvProduct.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(738, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(657, 408);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 25;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(335, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 19);
            this.label7.TabIndex = 43;
            this.label7.Text = "TÌM KIẾM NHẬP HÀNG";
            // 
            // MainStockInSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 433);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.chkImportDateTo);
            this.Controls.Add(this.chkImportDateFrom);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpImportDateTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpImportDateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBlockInDetailId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainStockInSearchForm";
            this.Text = "DepartmentStockInSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkImportDateTo;
        private System.Windows.Forms.CheckBox chkImportDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpImportDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpImportDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlockInDetailId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label7;
    }
}