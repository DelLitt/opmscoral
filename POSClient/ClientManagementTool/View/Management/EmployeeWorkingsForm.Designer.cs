namespace ClientManagementTool.View.Management
{
    partial class EmployeeWorkingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.dgvEmployeeWorking = new System.Windows.Forms.DataGridView();
            this.bdsEmployeeWorking = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusiveKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeWorking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployeeWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.Location = new System.Drawing.Point(15, 61);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(182, 20);
            this.txtEmployeeId.TabIndex = 0;
            this.txtEmployeeId.TextChanged += new System.EventHandler(this.txtEmployeeId_TextChanged);
            this.txtEmployeeId.Leave += new System.EventHandler(this.txtEmployeeId_Leave);
            this.txtEmployeeId.Enter += new System.EventHandler(this.txtEmployeeId_Enter);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhân viên";
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTime.Location = new System.Drawing.Point(437, 12);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(127, 20);
            this.txtTime.TabIndex = 2;
            // 
            // dgvEmployeeWorking
            // 
            this.dgvEmployeeWorking.AllowUserToAddRows = false;
            this.dgvEmployeeWorking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            this.dgvEmployeeWorking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeWorking.AutoGenerateColumns = false;
            this.dgvEmployeeWorking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeWorking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Employee,
            this.WorkingDay,
            this.StartTime,
            this.EndTime,
            this.Period,
            this.periodDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.createIdDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.updateIdDataGridViewTextBoxColumn,
            this.exclusiveKeyDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.dgvEmployeeWorking.DataSource = this.bdsEmployeeWorking;
            this.dgvEmployeeWorking.Location = new System.Drawing.Point(12, 87);
            this.dgvEmployeeWorking.Name = "dgvEmployeeWorking";
            this.dgvEmployeeWorking.ReadOnly = true;
            this.dgvEmployeeWorking.Size = new System.Drawing.Size(575, 250);
            this.dgvEmployeeWorking.TabIndex = 3;
            this.dgvEmployeeWorking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeWorking_CellContentClick);
            // 
            // bdsEmployeeWorking
            // 
            this.bdsEmployeeWorking.DataSource = typeof(AppFrame.Collection.EmployeeWorkingDaysCollection);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(516, 343);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(408, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày xem";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(203, 61);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 7;
            this.btnInput.Text = "Nhập";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "EmployeeWorkingDayPK.EmployeeId";
            this.Column1.HeaderText = "Mã NV";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Employee
            // 
            this.Employee.DataPropertyName = "Employee.EmployeeInfo.EmployeeName";
            this.Employee.HeaderText = "Tên nhân viên";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.Width = 150;
            // 
            // WorkingDay
            // 
            this.WorkingDay.DataPropertyName = "EmployeeWorkingDayPK.WorkingDay";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.WorkingDay.DefaultCellStyle = dataGridViewCellStyle2;
            this.WorkingDay.HeaderText = "Ngày";
            this.WorkingDay.Name = "WorkingDay";
            this.WorkingDay.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "DisplayStartTime";
            dataGridViewCellStyle3.Format = "HH:mm:ss";
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.StartTime.HeaderText = "Bắt đầu";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "DisplayEndTime";
            dataGridViewCellStyle4.Format = "HH:mm:ss";
            this.EndTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.EndTime.HeaderText = "Kết thúc";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.DataPropertyName = "EmployeeWorkingDayPK.Period";
            this.Period.HeaderText = "Số tiếng";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            this.Period.Visible = false;
            // 
            // periodDataGridViewTextBoxColumn
            // 
            this.periodDataGridViewTextBoxColumn.DataPropertyName = "Period";
            this.periodDataGridViewTextBoxColumn.HeaderText = "Thời gian";
            this.periodDataGridViewTextBoxColumn.Name = "periodDataGridViewTextBoxColumn";
            this.periodDataGridViewTextBoxColumn.ReadOnly = true;
            this.periodDataGridViewTextBoxColumn.Visible = false;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.createDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // createIdDataGridViewTextBoxColumn
            // 
            this.createIdDataGridViewTextBoxColumn.DataPropertyName = "CreateId";
            this.createIdDataGridViewTextBoxColumn.HeaderText = "CreateId";
            this.createIdDataGridViewTextBoxColumn.Name = "createIdDataGridViewTextBoxColumn";
            this.createIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.createIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            this.updateDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateIdDataGridViewTextBoxColumn
            // 
            this.updateIdDataGridViewTextBoxColumn.DataPropertyName = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.HeaderText = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.Name = "updateIdDataGridViewTextBoxColumn";
            this.updateIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // exclusiveKeyDataGridViewTextBoxColumn
            // 
            this.exclusiveKeyDataGridViewTextBoxColumn.DataPropertyName = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.HeaderText = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.Name = "exclusiveKeyDataGridViewTextBoxColumn";
            this.exclusiveKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.exclusiveKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // EmployeeWorkingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 372);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvEmployeeWorking);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmployeeId);
            this.Name = "EmployeeWorkingsForm";
            this.Text = "Chấm công";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EmployeeWorkingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeWorking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployeeWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.DataGridView dgvEmployeeWorking;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bdsEmployeeWorking;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeWorkingDayPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workingDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusiveKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
    }
}