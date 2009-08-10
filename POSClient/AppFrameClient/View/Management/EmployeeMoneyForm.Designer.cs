namespace AppFrameClient.View.Management
{
    partial class EmployeeMoneyForm
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
            this.txtMoney = new AppFrame.Controls.NumberTextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvMoney = new System.Windows.Forms.DataGridView();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsMoney = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.Format = null;
            this.txtMoney.Location = new System.Drawing.Point(15, 40);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(499, 26);
            this.txtMoney.TabIndex = 0;
            this.txtMoney.Text = "0";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(351, 166);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Tiếp tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(432, 166);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Bỏ qua";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tiền trong két khi ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(145, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 18);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "VÀO CA";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
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
                                                                                             this.InMoney,
                                                                                             this.OutMoney});
            this.dgvMoney.DataSource = this.bdsMoney;
            this.dgvMoney.Location = new System.Drawing.Point(15, 73);
            this.dgvMoney.MultiSelect = false;
            this.dgvMoney.Name = "dgvMoney";
            this.dgvMoney.ReadOnly = true;
            this.dgvMoney.RowHeadersVisible = false;
            this.dgvMoney.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMoney.Size = new System.Drawing.Size(499, 81);
            this.dgvMoney.TabIndex = 5;
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
            // InMoney
            // 
            this.InMoney.DataPropertyName = "InMoney";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.InMoney.DefaultCellStyle = dataGridViewCellStyle3;
            this.InMoney.HeaderText = "Số tiền đầu ca";
            this.InMoney.Name = "InMoney";
            this.InMoney.ReadOnly = true;
            this.InMoney.Width = 120;
            // 
            // OutMoney
            // 
            this.OutMoney.DataPropertyName = "OutMoney";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.OutMoney.DefaultCellStyle = dataGridViewCellStyle4;
            this.OutMoney.HeaderText = "Số tiền cuối ca";
            this.OutMoney.Name = "OutMoney";
            this.OutMoney.ReadOnly = true;
            this.OutMoney.Width = 120;
            // 
            // EmployeeMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 201);
            this.Controls.Add(this.dgvMoney);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtMoney);
            this.Name = "EmployeeMoneyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số tiền trong két";
            this.Load += new System.EventHandler(this.EmployeeMoneyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMoney)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AppFrame.Controls.NumberTextBox txtMoney;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMoney;
        private System.Windows.Forms.BindingSource bdsMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn InMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutMoney;
        public System.Windows.Forms.Label lblStatus;
    }
}