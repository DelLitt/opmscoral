namespace AppFrameClient.View.SalePoints
{
    partial class EmployeeListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusiveKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.AutoGenerateColumns = false;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.employeeNameDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.salaryDataGridViewTextBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.birthdayDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.contractIdDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.createIdDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.updateIdDataGridViewTextBoxColumn,
            this.exclusiveKeyDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn});
            this.dgvEmployee.DataSource = this.bdsEmployee;
            this.dgvEmployee.Location = new System.Drawing.Point(13, 13);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.Size = new System.Drawing.Size(807, 407);
            this.dgvEmployee.TabIndex = 0;
            this.dgvEmployee.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentDoubleClick);
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "EmployeePK.EmployeeId";
            this.Column1.HeaderText = "Mã nhân viên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "Tên nhân viên";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            this.employeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.startDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Ngày bắt đầu";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Địa chỉ";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            this.salaryDataGridViewTextBoxColumn.DataPropertyName = "Salary";
            this.salaryDataGridViewTextBoxColumn.HeaderText = "Lương";
            this.salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            this.salaryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Mã vạch";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.Visible = false;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.Visible = false;
            // 
            // contractIdDataGridViewTextBoxColumn
            // 
            this.contractIdDataGridViewTextBoxColumn.DataPropertyName = "ContractId";
            this.contractIdDataGridViewTextBoxColumn.HeaderText = "ContractId";
            this.contractIdDataGridViewTextBoxColumn.Name = "contractIdDataGridViewTextBoxColumn";
            this.contractIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // createIdDataGridViewTextBoxColumn
            // 
            this.createIdDataGridViewTextBoxColumn.DataPropertyName = "CreateId";
            this.createIdDataGridViewTextBoxColumn.HeaderText = "CreateId";
            this.createIdDataGridViewTextBoxColumn.Name = "createIdDataGridViewTextBoxColumn";
            this.createIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            this.updateDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateIdDataGridViewTextBoxColumn
            // 
            this.updateIdDataGridViewTextBoxColumn.DataPropertyName = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.HeaderText = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.Name = "updateIdDataGridViewTextBoxColumn";
            this.updateIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // exclusiveKeyDataGridViewTextBoxColumn
            // 
            this.exclusiveKeyDataGridViewTextBoxColumn.DataPropertyName = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.HeaderText = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.Name = "exclusiveKeyDataGridViewTextBoxColumn";
            this.exclusiveKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.Visible = false;
            // 
            // bdsEmployee
            // 
            this.bdsEmployee.DataSource = typeof(AppFrame.Collection.EmployeeInfoCollection);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(745, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 430);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "In mã vạch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(249, 430);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Xóa nhân viên";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // EmployeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 465);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvEmployee);
            this.Name = "EmployeeListForm";
            this.Text = "EmployeeListForm";
            this.Load += new System.EventHandler(this.EmployeeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bdsEmployee;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusiveKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
    }
}