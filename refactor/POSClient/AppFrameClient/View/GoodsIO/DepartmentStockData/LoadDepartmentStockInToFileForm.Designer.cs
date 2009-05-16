namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class LoadDepartmentStockInToFileForm
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
            this.syncResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSyncToMain = new System.Windows.Forms.Button();
            this.dgvSyncResult = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).BeginInit();
            this.SuspendLayout();
            // 
            // syncResultBindingSource
            // 
            this.syncResultBindingSource.DataSource = typeof(AppFrame.Model.SyncResult);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(504, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Kết quả";
            // 
            // btnSyncToMain
            // 
            this.btnSyncToMain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncToMain.Location = new System.Drawing.Point(12, 12);
            this.btnSyncToMain.Name = "btnSyncToMain";
            this.btnSyncToMain.Size = new System.Drawing.Size(189, 85);
            this.btnSyncToMain.TabIndex = 53;
            this.btnSyncToMain.Text = "Bắt đầu đồng bộ ";
            this.btnSyncToMain.UseVisualStyleBackColor = true;
            this.btnSyncToMain.Click += new System.EventHandler(this.btnSyncToMain_Click);
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
            this.dgvSyncResult.Location = new System.Drawing.Point(12, 123);
            this.dgvSyncResult.Name = "dgvSyncResult";
            this.dgvSyncResult.Size = new System.Drawing.Size(567, 129);
            this.dgvSyncResult.TabIndex = 56;
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
            // LoadDepartmentStockInToFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 290);
            this.Controls.Add(this.dgvSyncResult);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSyncToMain);
            this.Name = "LoadDepartmentStockInToFileForm";
            this.Text = "LoadDepartmentStockInToFileForm";
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource syncResultBindingSource;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSyncToMain;
        private System.Windows.Forms.DataGridView dgvSyncResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}