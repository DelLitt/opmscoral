namespace AppFrameClient.View.Management
{
    partial class ClosedPeriodForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMoney = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bdsMoney = new System.Windows.Forms.BindingSource(this.components);
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMoney
            // 
            this.dgvMoney.AllowUserToAddRows = false;
            this.dgvMoney.AllowUserToDeleteRows = false;
            this.dgvMoney.AutoGenerateColumns = false;
            this.dgvMoney.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoney.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                                                                             this.EmployeeId,
                                                                                             this.WorkingDay,
                                                                                             this.Column1,
                                                                                             this.InMoney,
                                                                                             this.Column2,
                                                                                             this.OutMoney});
            this.dgvMoney.DataSource = this.bdsMoney;
            this.dgvMoney.Location = new System.Drawing.Point(12, 83);
            this.dgvMoney.MultiSelect = false;
            this.dgvMoney.Name = "dgvMoney";
            this.dgvMoney.ReadOnly = true;
            this.dgvMoney.RowHeadersVisible = false;
            this.dgvMoney.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMoney.Size = new System.Drawing.Size(759, 236);
            this.dgvMoney.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(80, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(146, 20);
            this.dtpFrom.TabIndex = 7;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(332, 28);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(151, 20);
            this.dtpTo.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(696, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmployeeId
            // 
            this.EmployeeId.DataPropertyName = "EmployeeMoneyPK.EmployeeId";
            this.EmployeeId.HeaderText = "Nhân viên";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            this.EmployeeId.Width = 150;
            // 
            // WorkingDay
            // 
            this.WorkingDay.DataPropertyName = "EmployeeMoneyPK.WorkingDay";
            this.WorkingDay.HeaderText = "Ngày làm việc";
            this.WorkingDay.Name = "WorkingDay";
            this.WorkingDay.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DateLogin";
            this.Column1.HeaderText = "Giờ vào ca";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // InMoney
            // 
            this.InMoney.DataPropertyName = "InMoney";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.InMoney.DefaultCellStyle = dataGridViewCellStyle3;
            this.InMoney.HeaderText = "Số tiền đầu ca";
            this.InMoney.Name = "InMoney";
            this.InMoney.ReadOnly = true;
            this.InMoney.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DateLogout";
            this.Column2.HeaderText = "Giờ thoát ca";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // OutMoney
            // 
            this.OutMoney.DataPropertyName = "OutMoney";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.OutMoney.DefaultCellStyle = dataGridViewCellStyle4;
            this.OutMoney.HeaderText = "Số tiền cuối ca";
            this.OutMoney.Name = "OutMoney";
            this.OutMoney.ReadOnly = true;
            this.OutMoney.Width = 120;
            // 
            // ClosedPeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 367);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dgvMoney);
            this.Name = "ClosedPeriodForm";
            this.Text = "EmployeeMoneyListForm";
            this.Load += new System.EventHandler(this.ClosedPeriodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMoney)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMoney;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bdsMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutMoney;
    }
}