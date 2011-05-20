namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class SyncDatabaseImageForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
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
            this.btnSyncToMain.Click += new System.EventHandler(this.btnSyncFromMain_Click);
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
            // SyncDatabaseImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 325);
            this.Controls.Add(this.dgvSyncResult);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSyncToMain);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SyncDatabaseImageForm";
            this.Text = "Dong bo hinh anh du lieu";
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnRun, 0);
            this.Controls.SetChildIndex(this.btnSyncToMain, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.dgvSyncResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.syncResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSyncToMain;
        private System.Windows.Forms.BindingSource syncResultBindingSource;
        private System.Windows.Forms.DataGridView dgvSyncResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}