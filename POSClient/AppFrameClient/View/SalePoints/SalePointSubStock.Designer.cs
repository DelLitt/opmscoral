namespace AppFrameClient.View.SalePoints
{
    partial class SalePointSubStock
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
            this.bdsEmployeeSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartmentId = new System.Windows.Forms.TextBox();
            this.lblDepartmentCost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.txtDeparmentCost = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetMainSalePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblStartingDay = new System.Windows.Forms.Label();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.cboDepartments = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployeeSource)).BeginInit();
            this.cmnEmployees.SuspendLayout();
            this.SuspendLayout();
            // 
            // bdsEmployeeSource
            // 
            this.bdsEmployeeSource.DataSource = typeof(AppFrame.Model.EmployeeInfo);
            this.bdsEmployeeSource.Filter = "DelFlg = 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 52;
            this.label1.Text = "Mã kho phụ";
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartmentId.Enabled = false;
            this.txtDepartmentId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentId.Location = new System.Drawing.Point(130, 51);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.Size = new System.Drawing.Size(285, 22);
            this.txtDepartmentId.TabIndex = 51;
            // 
            // lblDepartmentCost
            // 
            this.lblDepartmentCost.AutoSize = true;
            this.lblDepartmentCost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentCost.Location = new System.Drawing.Point(45, 135);
            this.lblDepartmentCost.Name = "lblDepartmentCost";
            this.lblDepartmentCost.Size = new System.Drawing.Size(73, 14);
            this.lblDepartmentCost.TabIndex = 47;
            this.lblDepartmentCost.Text = "Chi phí thuê";
            this.lblDepartmentCost.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(329, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 48;
            this.label8.Text = "đồng";
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreateDate.Location = new System.Drawing.Point(636, 131);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(123, 22);
            this.dtpCreateDate.TabIndex = 53;
            // 
            // txtDeparmentCost
            // 
            this.txtDeparmentCost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeparmentCost.Location = new System.Drawing.Point(130, 131);
            this.txtDeparmentCost.Name = "txtDeparmentCost";
            this.txtDeparmentCost.Size = new System.Drawing.Size(193, 22);
            this.txtDeparmentCost.TabIndex = 46;
            this.txtDeparmentCost.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(535, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(228, 22);
            this.mnuDelete.Text = "Xóa";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(620, 183);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 50;
            this.btnReset.Text = "Bỏ qua";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(47, 183);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 45;
            this.btnHelp.Text = "Giúp đỡ";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(772, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(228, 22);
            this.mnuEdit.Text = "Sửa";
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(228, 22);
            this.mnuAdd.Text = "Thêm";
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
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(71, 107);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.TabIndex = 33;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentName.Location = new System.Drawing.Point(40, 80);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(78, 14);
            this.lblDepartmentName.TabIndex = 32;
            this.lblDepartmentName.Text = "Tên kho phụ";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(130, 104);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(500, 22);
            this.txtAddress.TabIndex = 30;
            // 
            // lblStartingDay
            // 
            this.lblStartingDay.AutoSize = true;
            this.lblStartingDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingDay.Location = new System.Drawing.Point(489, 135);
            this.lblStartingDay.Name = "lblStartingDay";
            this.lblStartingDay.Size = new System.Drawing.Size(141, 14);
            this.lblStartingDay.TabIndex = 34;
            this.lblStartingDay.Text = "Ngày bắt đầu hoạt động";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentName.Location = new System.Drawing.Point(130, 77);
            this.txtDepartmentName.MaxLength = 30;
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(500, 22);
            this.txtDepartmentName.TabIndex = 29;
            // 
            // cboDepartments
            // 
            this.cboDepartments.FormattingEnabled = true;
            this.cboDepartments.Location = new System.Drawing.Point(130, 24);
            this.cboDepartments.Name = "cboDepartments";
            this.cboDepartments.Size = new System.Drawing.Size(285, 21);
            this.cboDepartments.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 56;
            this.label3.Text = "Cửa hàng";
            // 
            // SalePointSubStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 240);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDepartments);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDepartmentId);
            this.Controls.Add(this.lblDepartmentCost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpCreateDate);
            this.Controls.Add(this.txtDeparmentCost);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblDepartmentName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblStartingDay);
            this.Name = "SalePointSubStock";
            this.Text = "Kho phụ thuộc cửa hàng";
            this.Load += new System.EventHandler(this.SalePointSubStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployeeSource)).EndInit();
            this.cmnEmployees.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bdsEmployeeSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartmentId;
        private System.Windows.Forms.Label lblDepartmentCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private System.Windows.Forms.TextBox txtDeparmentCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ContextMenuStrip cmnEmployees;
        private System.Windows.Forms.ToolStripMenuItem mnuSetMainSalePoint;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblStartingDay;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.ComboBox cboDepartments;
        private System.Windows.Forms.Label label3;
    }
}