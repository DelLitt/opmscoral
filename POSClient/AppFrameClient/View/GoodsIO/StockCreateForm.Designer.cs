namespace AppFrameClient.View.GoodsIO
{
    partial class StockCreateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpImportDateFrom = new System.Windows.Forms.DateTimePicker();
            this.chkImportDateFrom = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpImportDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvStockInDetail = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkImportDateTo = new System.Windows.Forms.CheckBox();
            this.btnAcceptAll = new System.Windows.Forms.Button();
            this.btnRejectAll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập kho từ ngày";
            // 
            // dtpImportDateFrom
            // 
            this.dtpImportDateFrom.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateFrom.Enabled = false;
            this.dtpImportDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateFrom.Location = new System.Drawing.Point(145, 38);
            this.dtpImportDateFrom.Name = "dtpImportDateFrom";
            this.dtpImportDateFrom.Size = new System.Drawing.Size(107, 22);
            this.dtpImportDateFrom.TabIndex = 1;
            // 
            // chkImportDateFrom
            // 
            this.chkImportDateFrom.AutoSize = true;
            this.chkImportDateFrom.Location = new System.Drawing.Point(259, 41);
            this.chkImportDateFrom.Name = "chkImportDateFrom";
            this.chkImportDateFrom.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateFrom.TabIndex = 2;
            this.chkImportDateFrom.UseVisualStyleBackColor = true;
            this.chkImportDateFrom.CheckedChanged += new System.EventHandler(this.chkImportDateFrom_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "đến ngày";
            // 
            // dtpImportDateTo
            // 
            this.dtpImportDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateTo.Enabled = false;
            this.dtpImportDateTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateTo.Location = new System.Drawing.Point(386, 37);
            this.dtpImportDateTo.Name = "dtpImportDateTo";
            this.dtpImportDateTo.Size = new System.Drawing.Size(112, 22);
            this.dtpImportDateTo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trạng thái";
            // 
            // cbbStatus
            // 
            this.cbbStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Items.AddRange(new object[] {
            "Mới nhập về",
            "Trả từ cửa hàng"});
            this.cbbStatus.Location = new System.Drawing.Point(145, 66);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(125, 22);
            this.cbbStatus.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(436, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 25);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvStockInDetail
            // 
            this.dgvStockInDetail.AllowUserToAddRows = false;
            this.dgvStockInDetail.AllowUserToDeleteRows = false;
            this.dgvStockInDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockInDetail.Location = new System.Drawing.Point(17, 95);
            this.dgvStockInDetail.Name = "dgvStockInDetail";
            this.dgvStockInDetail.Size = new System.Drawing.Size(969, 334);
            this.dgvStockInDetail.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(899, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkImportDateTo
            // 
            this.chkImportDateTo.AutoSize = true;
            this.chkImportDateTo.Location = new System.Drawing.Point(506, 41);
            this.chkImportDateTo.Name = "chkImportDateTo";
            this.chkImportDateTo.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateTo.TabIndex = 10;
            this.chkImportDateTo.UseVisualStyleBackColor = true;
            this.chkImportDateTo.CheckedChanged += new System.EventHandler(this.chkImportDateTo_CheckedChanged);
            // 
            // btnAcceptAll
            // 
            this.btnAcceptAll.Location = new System.Drawing.Point(778, 435);
            this.btnAcceptAll.Name = "btnAcceptAll";
            this.btnAcceptAll.Size = new System.Drawing.Size(115, 25);
            this.btnAcceptAll.TabIndex = 11;
            this.btnAcceptAll.Text = "Chấp nhận tất cả";
            this.btnAcceptAll.UseVisualStyleBackColor = true;
            this.btnAcceptAll.Click += new System.EventHandler(this.btnAcceptAll_Click);
            // 
            // btnRejectAll
            // 
            this.btnRejectAll.Location = new System.Drawing.Point(684, 435);
            this.btnRejectAll.Name = "btnRejectAll";
            this.btnRejectAll.Size = new System.Drawing.Size(88, 25);
            this.btnRejectAll.TabIndex = 12;
            this.btnRejectAll.Text = "Trả lại tất cả";
            this.btnRejectAll.UseVisualStyleBackColor = true;
            this.btnRejectAll.Click += new System.EventHandler(this.btnRejectAll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(603, 435);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // StockCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 463);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRejectAll);
            this.Controls.Add(this.btnAcceptAll);
            this.Controls.Add(this.chkImportDateTo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvStockInDetail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpImportDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkImportDateFrom);
            this.Controls.Add(this.dtpImportDateFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StockCreateForm";
            this.Text = "StockCreateForm";
            this.Load += new System.EventHandler(this.StockCreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpImportDateFrom;
        private System.Windows.Forms.CheckBox chkImportDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpImportDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvStockInDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkImportDateTo;
        private System.Windows.Forms.Button btnAcceptAll;
        private System.Windows.Forms.Button btnRejectAll;
        private System.Windows.Forms.Button btnReset;
    }
}