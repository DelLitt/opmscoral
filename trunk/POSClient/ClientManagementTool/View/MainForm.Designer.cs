﻿namespace ClientManagementTool.View
{
    partial class MainForm
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
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 520);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(731, 22);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.employeeManagementMenu,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginMenu,
            this.logoutMenu,
            this.exitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(54, 20);
            this.fileMenu.Text = "Tác vụ";
            // 
            // loginMenu
            // 
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.Size = new System.Drawing.Size(132, 22);
            this.loginMenu.Text = "Đăng nhập";
            this.loginMenu.Click += new System.EventHandler(this.loginMenu_Click);
            // 
            // logoutMenu
            // 
            this.logoutMenu.Name = "logoutMenu";
            this.logoutMenu.Size = new System.Drawing.Size(132, 22);
            this.logoutMenu.Text = "Đăng xuất";
            this.logoutMenu.Click += new System.EventHandler(this.logoutMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(132, 22);
            this.exitMenu.Text = "Thoát";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // employeeManagementMenu
            // 
            this.employeeManagementMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeWorkingMenu,
            this.employeeWorkingSearchMenu,
            this.employeeWorkingReport});
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 542);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}