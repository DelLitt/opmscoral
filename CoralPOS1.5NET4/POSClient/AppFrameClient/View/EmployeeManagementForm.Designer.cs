﻿namespace AppFrameClient.View
{
    partial class EmployeeManagementForm
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeManagementMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeWorkingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeWorkingSearchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeWorkingReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.enterPeriodMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.leavePeriodMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 520);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(891, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(54, 20);
            this.fileMenu.Text = "Tác vụ";
            // 
            // loginMenu
            // 
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.Size = new System.Drawing.Size(152, 22);
            this.loginMenu.Text = "Đăng nhập";
            this.loginMenu.Click += new System.EventHandler(this.loginMenu_Click);
            // 
            // logoutMenu
            // 
            this.logoutMenu.Name = "logoutMenu";
            this.logoutMenu.Size = new System.Drawing.Size(152, 22);
            this.logoutMenu.Text = "Đăng xuất";
            this.logoutMenu.Click += new System.EventHandler(this.logoutMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(152, 22);
            this.exitMenu.Text = "Thoát";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // employeeManagementMenu
            // 
            this.employeeManagementMenu.Name = "employeeManagementMenu";
            this.employeeManagementMenu.Size = new System.Drawing.Size(115, 20);
            this.employeeManagementMenu.Text = "Quản lý nhân viên";
            // 
            // employeeWorkingMenu
            // 
            this.employeeWorkingMenu.Name = "employeeWorkingMenu";
            this.employeeWorkingMenu.Size = new System.Drawing.Size(209, 22);
            this.employeeWorkingMenu.Text = "Chấm công";
            this.employeeWorkingMenu.Click += new System.EventHandler(this.employeeWorkingMenu_Click);
            // 
            // employeeWorkingSearchMenu
            // 
            this.employeeWorkingSearchMenu.Name = "employeeWorkingSearchMenu";
            this.employeeWorkingSearchMenu.Size = new System.Drawing.Size(209, 22);
            this.employeeWorkingSearchMenu.Text = "Xem thông tin ngày công";
            // 
            // employeeWorkingReport
            // 
            this.employeeWorkingReport.Name = "employeeWorkingReport";
            this.employeeWorkingReport.Size = new System.Drawing.Size(209, 22);
            this.employeeWorkingReport.Text = "Báo cáo ngày công";
            this.employeeWorkingReport.Click += new System.EventHandler(this.employeeWorkingReport_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(206, 6);
            // 
            // enterPeriodMenu
            // 
            this.enterPeriodMenu.Name = "enterPeriodMenu";
            this.enterPeriodMenu.Size = new System.Drawing.Size(209, 22);
            this.enterPeriodMenu.Text = "Vào ca";
            this.enterPeriodMenu.Click += new System.EventHandler(this.mnuEnterPeriod_Click);
            // 
            // leavePeriodMenu
            // 
            this.leavePeriodMenu.Name = "leavePeriodMenu";
            this.leavePeriodMenu.Size = new System.Drawing.Size(209, 22);
            this.leavePeriodMenu.Text = "Kết thúc ca";
            this.leavePeriodMenu.Click += new System.EventHandler(this.mnuLeavePeriod_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                              this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(61, 20);
            this.menuHelp.Text = "Giúp đỡ";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(107, 22);
            this.menuAbout.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 542);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem logoutMenu;
        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem employeeManagementMenu;
        private System.Windows.Forms.ToolStripMenuItem employeeWorkingMenu;
        private System.Windows.Forms.ToolStripMenuItem employeeWorkingSearchMenu;
        private System.Windows.Forms.ToolStripMenuItem employeeWorkingReport;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enterPeriodMenu;
        private System.Windows.Forms.ToolStripMenuItem leavePeriodMenu;
    }
}