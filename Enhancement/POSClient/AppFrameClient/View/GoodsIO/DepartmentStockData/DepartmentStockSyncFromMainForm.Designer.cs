namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentStockSyncFromMainForm
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSyncToDept = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSyncToMain = new System.Windows.Forms.Button();
            this.syncResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSyncResult = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(476, 31);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(344, 22);
            this.txtFilePath.TabIndex = 15;
            this.txtFilePath.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(560, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 19);
            this.label7.TabIndex = 45;
            this.label7.Text = "ĐỒNG BỘ DỮ LIỆU";
            this.label7.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 44;
            this.label1.Text = "File đồng bộ";
            this.label1.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(826, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(45, 25);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(665, 59);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(103, 25);
            this.btnRun.TabIndex = 47;
            this.btnRun.Text = "Đồng bộ dữ liệu";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Visible = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSyncToDept
            // 
            this.btnSyncToDept.Location = new System.Drawing.Point(520, 59);
            this.btnSyncToDept.Name = "btnSyncToDept";
            this.btnSyncToDept.Size = new System.Drawing.Size(103, 25);
            this.btnSyncToDept.TabIndex = 48;
            this.btnSyncToDept.Text = "Xuất dữ liệu đi cửa hàng";
            this.btnSyncToDept.UseVisualStyleBackColor = true;
            this.btnSyncToDept.Visible = false;
            this.btnSyncToDept.Click += new System.EventHandler(this.btnSyncToDept_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(504, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 50;
            this.label2.Text = "Kết quả";
            // 
            // btnSyncToMain
            // 
            this.btnSyncToMain.Location = new System.Drawing.Point(12, 12);
            this.btnSyncToMain.Name = "btnSyncToMain";
            this.btnSyncToMain.Size = new System.Drawing.Size(189, 85);
            this.btnSyncToMain.TabIndex = 49;
            this.btnSyncToMain.Text = "Bắt đầu đồng bộ ";
            this.btnSyncToMain.UseVisualStyleBackColor = true;
            this.btnSyncToMain.Click += new System.EventHandler(this.btnSyncToMain_Click);
            // 
            // syncResultBindingSource
            // 
            this.syncResultBindingSource.DataSource = typeof(AppFrame.Model.SyncResult);
            // 
            // dgvSyncResult
            // 
            this.dgvSyncResult.AllowUserToAddRows = false;
            this.dgvSyncResult.AllowUserToDeleteRows = false;
            this.dgvSyncResult.AutoGenerateColumns = false;
            this.dgvSyncResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSyncResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvSyncResult.DataSource = this.syncResultBindingSource;
            this.dgvSyncResult.Location = new System.Drawing.Point(15, 124);
            this.dgvSyncResult.Name = "dgvSyncResult";
            this.dgvSyncResult.Size = new System.Drawing.Size(567, 129);
            this.dgvSyncResult.TabIndex = 53;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Tên file";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 400;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Trạng thái";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // DepartmentStockSyncFromMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 291);
            this.Controls.Add(this.dgvSyncResult);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSyncToMain);
            this.Controls.Add(this.btnSyncToDept);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepartmentStockSyncFromMainForm";
            this.Text = "DepartmentStockSyncFromMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSyncToDept;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSyncToMain;
        private System.Windows.Forms.BindingSource syncResultBindingSource;
        private System.Windows.Forms.DataGridView dgvSyncResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}