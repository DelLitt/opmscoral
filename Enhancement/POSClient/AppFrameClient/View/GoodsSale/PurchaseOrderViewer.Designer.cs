namespace AppFrameClient.View.GoodsSale
{
    partial class PurchaseOrderViewer
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEvening = new System.Windows.Forms.CheckBox();
            this.chkMorning = new System.Windows.Forms.CheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 132);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(960, 374);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.lblWorkingTime);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.cboEmployee);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkEvening);
            this.groupBox2.Controls.Add(this.chkMorning);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblBillNumber);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Controls.Add(this.txtCustomer);
            this.groupBox2.Controls.Add(this.lblCustomer);
            this.groupBox2.Controls.Add(this.txtBillNumber);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 101);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm hóa đơn";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(614, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 22);
            this.dtpToDate.TabIndex = 45;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(374, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFromDate.TabIndex = 44;
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Location = new System.Drawing.Point(561, 47);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(47, 14);
            this.lblWorkingTime.TabIndex = 43;
            this.lblWorkingTime.Text = "Ca trực";
            this.lblWorkingTime.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(821, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(157, 73);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cboEmployee
            // 
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(98, 67);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(385, 22);
            this.cboEmployee.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 14);
            this.label8.TabIndex = 40;
            this.label8.Text = "Nhân viên";
            // 
            // chkEvening
            // 
            this.chkEvening.AutoSize = true;
            this.chkEvening.Location = new System.Drawing.Point(693, 46);
            this.chkEvening.Name = "chkEvening";
            this.chkEvening.Size = new System.Drawing.Size(56, 18);
            this.chkEvening.TabIndex = 38;
            this.chkEvening.Text = "Chiều";
            this.chkEvening.UseVisualStyleBackColor = true;
            this.chkEvening.Visible = false;
            // 
            // chkMorning
            // 
            this.chkMorning.AutoSize = true;
            this.chkMorning.Location = new System.Drawing.Point(614, 46);
            this.chkMorning.Name = "chkMorning";
            this.chkMorning.Size = new System.Drawing.Size(53, 18);
            this.chkMorning.TabIndex = 37;
            this.chkMorning.Text = "Sáng";
            this.chkMorning.UseVisualStyleBackColor = true;
            this.chkMorning.Visible = false;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(580, 19);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(28, 14);
            this.lblToDate.TabIndex = 36;
            this.lblToDate.Text = "đến";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 14);
            this.label7.TabIndex = 33;
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Location = new System.Drawing.Point(4, 19);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(74, 14);
            this.lblBillNumber.TabIndex = 6;
            this.lblBillNumber.Text = "Số hóa đơn:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(311, 19);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(57, 14);
            this.lblFromDate.TabIndex = 10;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(98, 42);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(369, 22);
            this.txtCustomer.TabIndex = 24;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(3, 45);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(69, 14);
            this.lblCustomer.TabIndex = 25;
            this.lblCustomer.Text = "Tên khách:";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(98, 16);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(194, 22);
            this.txtBillNumber.TabIndex = 2;
            // 
            // PurchaseOrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PurchaseOrderViewer";
            this.Text = "PurchaseOrderViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseOrderViewer_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        public System.Windows.Forms.Label lblWorkingTime;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.ComboBox cboEmployee;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.CheckBox chkEvening;
        public System.Windows.Forms.CheckBox chkMorning;
        public System.Windows.Forms.Label lblToDate;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblBillNumber;
        public System.Windows.Forms.Label lblFromDate;
        public System.Windows.Forms.TextBox txtCustomer;
        public System.Windows.Forms.Label lblCustomer;
        public System.Windows.Forms.TextBox txtBillNumber;
    }
}