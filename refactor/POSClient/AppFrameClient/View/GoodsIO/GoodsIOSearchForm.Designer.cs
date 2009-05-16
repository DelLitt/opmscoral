namespace AppFrameClient.View.GoodsIO
{
    partial class GoodsIOSearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBlockInDetailId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpImportDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpImportDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvBlockInDetail = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkImportDateFrom = new System.Windows.Forms.CheckBox();
            this.chkImportDateTo = new System.Windows.Forms.CheckBox();
            this.BlockDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockInDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlockDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã lô";
            // 
            // txtBlockInDetailId
            // 
            this.txtBlockInDetailId.Location = new System.Drawing.Point(56, 36);
            this.txtBlockInDetailId.Name = "txtBlockInDetailId";
            this.txtBlockInDetailId.Size = new System.Drawing.Size(163, 22);
            this.txtBlockInDetailId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập kho từ ngày";
            // 
            // dtpImportDateFrom
            // 
            this.dtpImportDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateFrom.Enabled = false;
            this.dtpImportDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateFrom.Location = new System.Drawing.Point(358, 34);
            this.dtpImportDateFrom.Name = "dtpImportDateFrom";
            this.dtpImportDateFrom.Size = new System.Drawing.Size(113, 22);
            this.dtpImportDateFrom.TabIndex = 3;
            // 
            // dtpImportDateTo
            // 
            this.dtpImportDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDateTo.Enabled = false;
            this.dtpImportDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDateTo.Location = new System.Drawing.Point(358, 62);
            this.dtpImportDateTo.Name = "dtpImportDateTo";
            this.dtpImportDateTo.Size = new System.Drawing.Size(113, 22);
            this.dtpImportDateTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập kho đến ngày";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(396, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 25);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvBlockInDetail
            // 
            this.dgvBlockInDetail.AllowUserToAddRows = false;
            this.dgvBlockInDetail.AllowUserToDeleteRows = false;
            this.dgvBlockInDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlockInDetail.Location = new System.Drawing.Point(14, 122);
            this.dgvBlockInDetail.Name = "dgvBlockInDetail";
            this.dgvBlockInDetail.ReadOnly = true;
            this.dgvBlockInDetail.Size = new System.Drawing.Size(812, 271);
            this.dgvBlockInDetail.TabIndex = 7;
            this.dgvBlockInDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBlockInDetail_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(738, 400);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 25);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(644, 400);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(87, 25);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(56, 62);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(127, 18);
            this.chkDelete.TabIndex = 10;
            this.chkDelete.Text = "Bao gồm lô đã xóa";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkImportDateFrom
            // 
            this.chkImportDateFrom.AutoSize = true;
            this.chkImportDateFrom.Location = new System.Drawing.Point(477, 38);
            this.chkImportDateFrom.Name = "chkImportDateFrom";
            this.chkImportDateFrom.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateFrom.TabIndex = 11;
            this.chkImportDateFrom.UseVisualStyleBackColor = true;
            this.chkImportDateFrom.CheckedChanged += new System.EventHandler(this.chkImportDateFrom_CheckedChanged);
            // 
            // chkImportDateTo
            // 
            this.chkImportDateTo.AutoSize = true;
            this.chkImportDateTo.Location = new System.Drawing.Point(477, 62);
            this.chkImportDateTo.Name = "chkImportDateTo";
            this.chkImportDateTo.Size = new System.Drawing.Size(15, 14);
            this.chkImportDateTo.TabIndex = 12;
            this.chkImportDateTo.UseVisualStyleBackColor = true;
            this.chkImportDateTo.CheckedChanged += new System.EventHandler(this.chkImportDateTo_CheckedChanged);
            // 
            // BlockDetailBindingSource
            // 
            this.BlockDetailBindingSource.DataSource = typeof(AppFrame.Model.BlockInDetail);
            // 
            // GoodsIOSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 437);
            this.Controls.Add(this.chkImportDateTo);
            this.Controls.Add(this.chkImportDateFrom);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvBlockInDetail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpImportDateTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpImportDateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBlockInDetailId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GoodsIOSearchForm";
            this.Text = "GoodsIOSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockInDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlockDetailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBlockInDetailId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpImportDateFrom;
        private System.Windows.Forms.DateTimePicker dtpImportDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBlockInDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.BindingSource BlockDetailBindingSource;
        private System.Windows.Forms.CheckBox chkImportDateFrom;
        private System.Windows.Forms.CheckBox chkImportDateTo;
    }
}