using System.Windows.Forms;

namespace AppFrameClient.View
{
    partial class SecuritySettingsForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "ANVT",
            "Vo Thi An"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Supervisor");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Manager");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Accountant");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lstEmployee = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.Name = new System.Windows.Forms.ColumnHeader();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateFromEmployee = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.bdsDepartment = new System.Windows.Forms.BindingSource(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstRight = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.cboWatchBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsUserInfo = new System.Windows.Forms.BindingSource(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.bdsEmployees = new System.Windows.Forms.BindingSource(this.components);
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.btnUnsuspend = new System.Windows.Forms.Button();
            this.btnUnremove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployees)).BeginInit();
            this.grpUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ NGƯỜI DÙNG VÀ MẬT KHẨU";
            // 
            // lstEmployee
            // 
            this.lstEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Name});
            this.lstEmployee.FullRowSelect = true;
            this.lstEmployee.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstEmployee.Location = new System.Drawing.Point(12, 99);
            this.lstEmployee.MultiSelect = false;
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(225, 364);
            this.lstEmployee.TabIndex = 1;
            this.lstEmployee.UseCompatibleStateImageBehavior = false;
            this.lstEmployee.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 70;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 150;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(99, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(99, 74);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên người dùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mật khẩu";
            // 
            // btnCreateFromEmployee
            // 
            this.btnCreateFromEmployee.Location = new System.Drawing.Point(246, 60);
            this.btnCreateFromEmployee.Name = "btnCreateFromEmployee";
            this.btnCreateFromEmployee.Size = new System.Drawing.Size(228, 23);
            this.btnCreateFromEmployee.TabIndex = 9;
            this.btnCreateFromEmployee.Text = "Tạo người dùng từ tên nhân viên";
            this.btnCreateFromEmployee.UseVisualStyleBackColor = true;
            this.btnCreateFromEmployee.Click += new System.EventHandler(this.btnCreateFromEmployee_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 234);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(99, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboDepartment
            // 
            this.cboDepartment.DataSource = this.bdsDepartment;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(12, 59);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(225, 21);
            this.cboDepartment.TabIndex = 14;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(897, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 522);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cửa hàng";
            // 
            // lstRight
            // 
            this.lstRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstRight.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lstRight.Location = new System.Drawing.Point(99, 100);
            this.lstRight.MultiSelect = false;
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(121, 106);
            this.lstRight.TabIndex = 19;
            this.lstRight.UseCompatibleStateImageBehavior = false;
            this.lstRight.View = System.Windows.Forms.View.Details;
            this.lstRight.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Quyền";
            this.columnHeader1.Width = 110;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Quyền hạn";
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(246, 89);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(231, 23);
            this.btnCreateNew.TabIndex = 21;
            this.btnCreateNew.Text = "Tạo người dùng với tên mới";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // cboWatchBy
            // 
            this.cboWatchBy.FormattingEnabled = true;
            this.cboWatchBy.Location = new System.Drawing.Point(488, 83);
            this.cboWatchBy.Name = "cboWatchBy";
            this.cboWatchBy.Size = new System.Drawing.Size(269, 21);
            this.cboWatchBy.TabIndex = 23;
            this.cboWatchBy.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Xem người dùng theo:";
            this.label7.Visible = false;
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.AllowUserToAddRows = false;
            this.dgvUserInfo.AllowUserToDeleteRows = false;
            this.dgvUserInfo.AutoGenerateColumns = false;
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usernameDataGridViewTextBoxColumn,
            this.Column4,
            this.passwordDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.EmployeeInfo,
            this.Column1,
            this.employeeInfoDataGridViewTextBoxColumn});
            this.dgvUserInfo.DataSource = this.bdsUserInfo;
            this.dgvUserInfo.Location = new System.Drawing.Point(483, 111);
            this.dgvUserInfo.MultiSelect = false;
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.RowHeadersVisible = false;
            this.dgvUserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserInfo.Size = new System.Drawing.Size(489, 352);
            this.dgvUserInfo.TabIndex = 25;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.Frozen = true;
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Tài khoản";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RoleType";
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Loại tài khoản";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            this.passwordDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Suspended";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tạm ngưng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Deleted";
            this.Column2.HeaderText = "Bị loại bỏ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // EmployeeInfo
            // 
            this.EmployeeInfo.DataPropertyName = "EmployeeInfo.EmployeeName";
            dataGridViewCellStyle1.NullValue = "Không";
            this.EmployeeInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeInfo.HeaderText = "Tên nhân viên";
            this.EmployeeInfo.Name = "EmployeeInfo";
            this.EmployeeInfo.ReadOnly = true;
            this.EmployeeInfo.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "EmployeeInfo.Department.DepartmentName";
            dataGridViewCellStyle2.NullValue = "Không";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Cửa hàng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 150;
            // 
            // employeeInfoDataGridViewTextBoxColumn
            // 
            this.employeeInfoDataGridViewTextBoxColumn.DataPropertyName = "EmployeeInfo";
            this.employeeInfoDataGridViewTextBoxColumn.HeaderText = "EmployeeInfo";
            this.employeeInfoDataGridViewTextBoxColumn.Name = "employeeInfoDataGridViewTextBoxColumn";
            this.employeeInfoDataGridViewTextBoxColumn.Visible = false;
            // 
            // bdsUserInfo
            // 
            this.bdsUserInfo.DataSource = typeof(AppFrame.Collection.LoginModelCollection);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(247, 118);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(230, 23);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Chỉnh sửa mật khẩu";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(483, 469);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(75, 23);
            this.btnSuspend.TabIndex = 27;
            this.btnSuspend.Text = "Tạm ngưng";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(692, 469);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "Loại bỏ";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.label6);
            this.grpUserInfo.Controls.Add(this.lstRight);
            this.grpUserInfo.Controls.Add(this.txtPassword);
            this.grpUserInfo.Controls.Add(this.txtUsername);
            this.grpUserInfo.Controls.Add(this.label2);
            this.grpUserInfo.Controls.Add(this.label3);
            this.grpUserInfo.Controls.Add(this.btnSave);
            this.grpUserInfo.Controls.Add(this.btnCancel);
            this.grpUserInfo.Location = new System.Drawing.Point(246, 147);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(231, 316);
            this.grpUserInfo.TabIndex = 29;
            this.grpUserInfo.TabStop = false;
            // 
            // btnUnsuspend
            // 
            this.btnUnsuspend.Location = new System.Drawing.Point(564, 469);
            this.btnUnsuspend.Name = "btnUnsuspend";
            this.btnUnsuspend.Size = new System.Drawing.Size(75, 23);
            this.btnUnsuspend.TabIndex = 30;
            this.btnUnsuspend.Text = "Tiếp tục";
            this.btnUnsuspend.UseVisualStyleBackColor = true;
            this.btnUnsuspend.Click += new System.EventHandler(this.btnUnsuspend_Click);
            // 
            // btnUnremove
            // 
            this.btnUnremove.Location = new System.Drawing.Point(773, 469);
            this.btnUnremove.Name = "btnUnremove";
            this.btnUnremove.Size = new System.Drawing.Size(75, 23);
            this.btnUnremove.TabIndex = 31;
            this.btnUnremove.Text = "Phục hồi";
            this.btnUnremove.UseVisualStyleBackColor = true;
            this.btnUnremove.Click += new System.EventHandler(this.btnUnremove_Click);
            // 
            // SecuritySettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnUnremove);
            this.Controls.Add(this.btnUnsuspend);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvUserInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboWatchBy);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.btnCreateFromEmployee);
            this.Controls.Add(this.lstEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpUserInfo);
            this.Name = "SecuritySettingsForm";
            this.Text = "Quản lý người dùng và mật khẩu";
            this.Load += new System.EventHandler(this.SecuritySettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployees)).EndInit();
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstEmployee;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateFromEmployee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lstRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.ComboBox cboWatchBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.BindingSource bdsUserInfo;
        private System.Windows.Forms.BindingSource bdsDepartment;
        private System.Windows.Forms.BindingSource bdsEmployees;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnUnsuspend;
        private System.Windows.Forms.Button btnUnremove;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn EmployeeInfo;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn employeeInfoDataGridViewTextBoxColumn;
    }
}
