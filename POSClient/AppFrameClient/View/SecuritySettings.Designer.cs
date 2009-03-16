namespace AppFrameClient.View
{
    partial class SecuritySettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstEmployee = new System.Windows.Forms.ListView();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateFromEmployee = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstRight = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.bdsUserInfo = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUserInfo)).BeginInit();
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
            this.lstEmployee.Location = new System.Drawing.Point(12, 99);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(225, 364);
            this.lstEmployee.TabIndex = 1;
            this.lstEmployee.UseCompatibleStateImageBehavior = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(330, 195);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(330, 221);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên người dùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mật khẩu";
            // 
            // btnCreateFromEmployee
            // 
            this.btnCreateFromEmployee.Location = new System.Drawing.Point(246, 60);
            this.btnCreateFromEmployee.Name = "btnCreateFromEmployee";
            this.btnCreateFromEmployee.Size = new System.Drawing.Size(213, 23);
            this.btnCreateFromEmployee.TabIndex = 9;
            this.btnCreateFromEmployee.Text = "Tạo người dùng từ tên nhân viên";
            this.btnCreateFromEmployee.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(245, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(330, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(12, 59);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(225, 21);
            this.cboDepartment.TabIndex = 14;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(897, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
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
            this.lstRight.Location = new System.Drawing.Point(330, 256);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(121, 97);
            this.lstRight.TabIndex = 19;
            this.lstRight.UseCompatibleStateImageBehavior = false;
            this.lstRight.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Quyền hạn";
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(246, 89);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(213, 23);
            this.btnCreateNew.TabIndex = 21;
            this.btnCreateNew.Text = "Tạo người dùng với tên mới";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(483, 83);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(269, 21);
            this.comboBox2.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(480, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Xem người dùng theo:";
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo.Location = new System.Drawing.Point(483, 111);
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.Size = new System.Drawing.Size(489, 352);
            this.dgvUserInfo.TabIndex = 25;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(247, 118);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(212, 23);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Chỉnh sửa mật khẩu";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(483, 469);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(75, 23);
            this.btnSuspend.TabIndex = 27;
            this.btnSuspend.Text = "Tạm ngưng";
            this.btnSuspend.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(564, 469);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "Loại bỏ";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // SecuritySettings
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvUserInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstRight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreateFromEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lstEmployee);
            this.Controls.Add(this.label1);
            this.Name = "SecuritySettings";
            this.Load += new System.EventHandler(this.SecuritySettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUserInfo)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.BindingSource bdsUserInfo;
    }
}
