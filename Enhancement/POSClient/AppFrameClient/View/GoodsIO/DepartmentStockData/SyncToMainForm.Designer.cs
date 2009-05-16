namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class SyncToMainForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSyncToMain = new System.Windows.Forms.Button();
            this.syncResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvSyncResult = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(14, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(189, 85);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Bắt đầu đồng bộ về kho";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSyncToMain
            // 
            this.btnSyncToMain.Location = new System.Drawing.Point(231, 13);
            this.btnSyncToMain.Name = "btnSyncToMain";
            this.btnSyncToMain.Size = new System.Drawing.Size(189, 85);
            this.btnSyncToMain.TabIndex = 1;
            this.btnSyncToMain.Text = "Bắt đầu đồng bộ từ của hàng";
            this.btnSyncToMain.UseVisualStyleBackColor = true;
            this.btnSyncToMain.Visible = false;
            this.btnSyncToMain.Click += new System.EventHandler(this.btnSyncToMain_Click);
            // 
            // syncResultBindingSource
            // 
            this.syncResultBindingSource.DataSource = typeof(AppFrame.Model.SyncResult);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kết quả";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(506, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.dgvSyncResult.Location = new System.Drawing.Point(14, 125);
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
            // SyncToMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 288);
            this.Controls.Add(this.dgvSyncResult);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSyncToMain);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SyncToMainForm";
            this.Text = "Đồng bộ về kho chính";
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSyncToMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource syncResultBindingSource;
        private System.Windows.Forms.DataGridView dgvSyncResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}