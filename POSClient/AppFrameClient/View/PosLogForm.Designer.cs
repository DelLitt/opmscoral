namespace AppFrameClient.View
{
    partial class PosLogForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpImportDateFrom = new System.Windows.Forms.DateTimePicker();
            this.chkImportDateFrom = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpImportDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvStockInDetail = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loggerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exceptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkImportDateTo = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posLogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lưu vết từ ngày";
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
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên người dùng";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(434, 63);
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
            this.dgvStockInDetail.AutoGenerateColumns = false;
            this.dgvStockInDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockInDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.threadDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn,
            this.loggerDataGridViewTextBoxColumn,
            this.posUserDataGridViewTextBoxColumn,
            this.posActionDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.exceptionDataGridViewTextBoxColumn});
            this.dgvStockInDetail.DataSource = this.posLogBindingSource;
            this.dgvStockInDetail.Location = new System.Drawing.Point(17, 95);
            this.dgvStockInDetail.Name = "dgvStockInDetail";
            this.dgvStockInDetail.Size = new System.Drawing.Size(969, 334);
            this.dgvStockInDetail.TabIndex = 8;
            this.dgvStockInDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockInDetail_CellDoubleClick);
            this.dgvStockInDetail.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockInDetail_CellContentDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy hh:mm:ss";
            dataGridViewCellStyle4.NullValue = null;
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Ngày lưu vết";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // threadDataGridViewTextBoxColumn
            // 
            this.threadDataGridViewTextBoxColumn.DataPropertyName = "Thread";
            this.threadDataGridViewTextBoxColumn.HeaderText = "Thread";
            this.threadDataGridViewTextBoxColumn.Name = "threadDataGridViewTextBoxColumn";
            this.threadDataGridViewTextBoxColumn.Visible = false;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "Level";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.Visible = false;
            // 
            // loggerDataGridViewTextBoxColumn
            // 
            this.loggerDataGridViewTextBoxColumn.DataPropertyName = "Logger";
            this.loggerDataGridViewTextBoxColumn.HeaderText = "Logger";
            this.loggerDataGridViewTextBoxColumn.Name = "loggerDataGridViewTextBoxColumn";
            this.loggerDataGridViewTextBoxColumn.Visible = false;
            // 
            // posUserDataGridViewTextBoxColumn
            // 
            this.posUserDataGridViewTextBoxColumn.DataPropertyName = "PosUser";
            this.posUserDataGridViewTextBoxColumn.HeaderText = "Người dùng";
            this.posUserDataGridViewTextBoxColumn.Name = "posUserDataGridViewTextBoxColumn";
            this.posUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // posActionDataGridViewTextBoxColumn
            // 
            this.posActionDataGridViewTextBoxColumn.DataPropertyName = "PosAction";
            this.posActionDataGridViewTextBoxColumn.HeaderText = "Hành động";
            this.posActionDataGridViewTextBoxColumn.Name = "posActionDataGridViewTextBoxColumn";
            this.posActionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Chi tiết";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn.Width = 600;
            // 
            // exceptionDataGridViewTextBoxColumn
            // 
            this.exceptionDataGridViewTextBoxColumn.DataPropertyName = "Exception";
            this.exceptionDataGridViewTextBoxColumn.HeaderText = "Exception";
            this.exceptionDataGridViewTextBoxColumn.Name = "exceptionDataGridViewTextBoxColumn";
            this.exceptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // posLogBindingSource
            // 
            this.posLogBindingSource.DataSource = typeof(AppFrame.Model.PosLog);
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(911, 435);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(145, 66);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(107, 22);
            this.txtUsername.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(352, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "NHẬT KÝ LƯU VẾT";
            // 
            // PosLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 463);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkImportDateTo);
            this.Controls.Add(this.dgvStockInDetail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpImportDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkImportDateFrom);
            this.Controls.Add(this.dtpImportDateFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PosLogForm";
            this.Text = "Lưu vết";
            this.Load += new System.EventHandler(this.StockCreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posLogBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvStockInDetail;
        private System.Windows.Forms.CheckBox chkImportDateTo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.BindingSource posLogBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loggerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exceptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label7;
    }
}