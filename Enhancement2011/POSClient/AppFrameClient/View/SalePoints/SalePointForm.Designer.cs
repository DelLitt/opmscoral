namespace AppFrameClient.View.SalePoints
{
    partial class SalePointForm
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
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmployeesNumber = new System.Windows.Forms.TextBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblStartingDay = new System.Windows.Forms.Label();
            this.lblEmployeesNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmployeesList = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new AppFrame.Controls.DataGridViewCalendarColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetMainSalePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsEmployeeSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtDeparmentCost = new System.Windows.Forms.TextBox();
            this.lblDepartmentCost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtDepartmentId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.lblActiveDepartment = new System.Windows.Forms.Label();
            this.txtActiveDepartment = new System.Windows.Forms.TextBox();
            this.btnActive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.cmnEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployeeSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentName.Location = new System.Drawing.Point(106, 43);
            this.txtDepartmentName.MaxLength = 30;
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(500, 22);
            this.txtDepartmentName.TabIndex = 0;
            this.txtDepartmentName.TextChanged += new System.EventHandler(this.txtDepartmentName_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(106, 70);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(500, 22);
            this.txtAddress.TabIndex = 1;
            // 
            // txtEmployeesNumber
            // 
            this.txtEmployeesNumber.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEmployeesNumber.Enabled = false;
            this.txtEmployeesNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeesNumber.Location = new System.Drawing.Point(106, 123);
            this.txtEmployeesNumber.Name = "txtEmployeesNumber";
            this.txtEmployeesNumber.Size = new System.Drawing.Size(90, 22);
            this.txtEmployeesNumber.TabIndex = 3;
            this.txtEmployeesNumber.Visible = false;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentName.Location = new System.Drawing.Point(16, 46);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(84, 14);
            this.lblDepartmentName.TabIndex = 4;
            this.lblDepartmentName.Text = "Tên cửa hàng";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(16, 73);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // lblStartingDay
            // 
            this.lblStartingDay.AutoSize = true;
            this.lblStartingDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingDay.Location = new System.Drawing.Point(465, 101);
            this.lblStartingDay.Name = "lblStartingDay";
            this.lblStartingDay.Size = new System.Drawing.Size(141, 14);
            this.lblStartingDay.TabIndex = 6;
            this.lblStartingDay.Text = "Ngày bắt đầu hoạt động";
            // 
            // lblEmployeesNumber
            // 
            this.lblEmployeesNumber.AutoSize = true;
            this.lblEmployeesNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeesNumber.Location = new System.Drawing.Point(16, 126);
            this.lblEmployeesNumber.Name = "lblEmployeesNumber";
            this.lblEmployeesNumber.Size = new System.Drawing.Size(61, 14);
            this.lblEmployeesNumber.TabIndex = 7;
            this.lblEmployeesNumber.Text = "Nhân viên";
            this.lblEmployeesNumber.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "người";
            this.label5.Visible = false;
            // 
            // lblEmployeesList
            // 
            this.lblEmployeesList.AutoSize = true;
            this.lblEmployeesList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeesList.Location = new System.Drawing.Point(9, 182);
            this.lblEmployeesList.Name = "lblEmployeesList";
            this.lblEmployeesList.Size = new System.Drawing.Size(120, 14);
            this.lblEmployeesList.TabIndex = 9;
            this.lblEmployeesList.Text = "Danh sách nhân viên";
            this.lblEmployeesList.Visible = false;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Salary,
            this.StartDate,
            this.delFlgDataGridViewTextBoxColumn});
            this.dgvEmployees.ContextMenuStrip = this.cmnEmployees;
            this.dgvEmployees.DataSource = this.bdsEmployeeSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 201);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(811, 65);
            this.dgvEmployees.TabIndex = 10;
            this.dgvEmployees.Visible = false;
            this.dgvEmployees.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvEmployees_RowPrePaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EmployeeName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên nhân viên";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 492;
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "Lương";
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            this.Salary.Width = 200;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "Ngày bắt đầu làm";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StartDate.Width = 300;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // cmnEmployees
            // 
            this.cmnEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetMainSalePoint,
            this.toolStripMenuItem1,
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete});
            this.cmnEmployees.Name = "contextMenuStrip1";
            this.cmnEmployees.Size = new System.Drawing.Size(229, 98);
            // 
            // mnuSetMainSalePoint
            // 
            this.mnuSetMainSalePoint.Name = "mnuSetMainSalePoint";
            this.mnuSetMainSalePoint.Size = new System.Drawing.Size(228, 22);
            this.mnuSetMainSalePoint.Text = "Thiết lập làm cửa hàng chính";
            this.mnuSetMainSalePoint.Click += new System.EventHandler(this.mnuSetMainSalePoint_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(228, 22);
            this.mnuAdd.Text = "Thêm";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(228, 22);
            this.mnuEdit.Text = "Sửa";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(228, 22);
            this.mnuDelete.Text = "Xóa";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // bdsEmployeeSource
            // 
            this.bdsEmployeeSource.DataSource = typeof(AppFrame.Model.EmployeeInfo);
            this.bdsEmployeeSource.Filter = "DelFlg = 1";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.Location = new System.Drawing.Point(12, 272);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAll.TabIndex = 11;
            this.btnCheckAll.Text = "Chọn hết";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Visible = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheckAll.Location = new System.Drawing.Point(96, 272);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnUncheckAll.TabIndex = 12;
            this.btnUncheckAll.Text = "Bỏ chọn";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Visible = false;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(500, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(660, 272);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(581, 272);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(731, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(12, 149);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // txtDeparmentCost
            // 
            this.txtDeparmentCost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeparmentCost.Location = new System.Drawing.Point(106, 97);
            this.txtDeparmentCost.Name = "txtDeparmentCost";
            this.txtDeparmentCost.Size = new System.Drawing.Size(193, 22);
            this.txtDeparmentCost.TabIndex = 18;
            this.txtDeparmentCost.Visible = false;
            // 
            // lblDepartmentCost
            // 
            this.lblDepartmentCost.AutoSize = true;
            this.lblDepartmentCost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentCost.Location = new System.Drawing.Point(16, 97);
            this.lblDepartmentCost.Name = "lblDepartmentCost";
            this.lblDepartmentCost.Size = new System.Drawing.Size(73, 14);
            this.lblDepartmentCost.TabIndex = 19;
            this.lblDepartmentCost.Text = "Chi phí thuê";
            this.lblDepartmentCost.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(305, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "đồng";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(500, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(585, 149);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartmentId.Enabled = false;
            this.txtDepartmentId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentId.Location = new System.Drawing.Point(106, 17);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.Size = new System.Drawing.Size(200, 22);
            this.txtDepartmentId.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mã cửa hàng";
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreateDate.Location = new System.Drawing.Point(612, 97);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(123, 22);
            this.dtpCreateDate.TabIndex = 25;
            // 
            // lblActiveDepartment
            // 
            this.lblActiveDepartment.AutoSize = true;
            this.lblActiveDepartment.Location = new System.Drawing.Point(338, 17);
            this.lblActiveDepartment.Name = "lblActiveDepartment";
            this.lblActiveDepartment.Size = new System.Drawing.Size(229, 13);
            this.lblActiveDepartment.TabIndex = 26;
            this.lblActiveDepartment.Text = "Cửa hàng này không phải là cửa hàng ACTIVE";
            // 
            // txtActiveDepartment
            // 
            this.txtActiveDepartment.Location = new System.Drawing.Point(765, 43);
            this.txtActiveDepartment.Name = "txtActiveDepartment";
            this.txtActiveDepartment.Size = new System.Drawing.Size(23, 20);
            this.txtActiveDepartment.TabIndex = 27;
            this.txtActiveDepartment.Text = "0";
            this.txtActiveDepartment.Visible = false;
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(612, 14);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(176, 23);
            this.btnActive.TabIndex = 28;
            this.btnActive.Text = "Thiết lập làm cửa hàng chính";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // SalePointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 181);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.lblActiveDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.txtDepartmentId);
            this.Controls.Add(this.txtActiveDepartment);
            this.Controls.Add(this.lblDepartmentCost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpCreateDate);
            this.Controls.Add(this.txtDeparmentCost);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblEmployeesList);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEmployeesNumber);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnUncheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.lblDepartmentName);
            this.Controls.Add(this.txtEmployeesNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblStartingDay);
            this.Controls.Add(this.txtDepartmentName);
            this.Name = "SalePointForm";
            this.Text = "SalePoint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalePointForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalePointForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.cmnEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployeeSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmployeesNumber;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblStartingDay;
        private System.Windows.Forms.Label lblEmployeesNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEmployeesList;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtDeparmentCost;
        private System.Windows.Forms.Label lblDepartmentCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtDepartmentId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private System.Windows.Forms.BindingSource bdsEmployeeSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip cmnEmployees;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSetMainSalePoint;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label lblActiveDepartment;
        private System.Windows.Forms.TextBox txtActiveDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private AppFrame.Controls.DataGridViewCalendarColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
    }
}