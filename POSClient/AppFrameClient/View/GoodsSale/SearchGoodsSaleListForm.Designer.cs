namespace AppFrameClient.View.GoodsSale
{
    partial class SearchGoodsSaleListForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBillChoosing = new System.Windows.Forms.Button();
            this.systemHotkey1 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(832, 484);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.SetChildIndex(this.txtBillNumber, 0);
            this.groupBox2.Controls.SetChildIndex(this.lblCustomer, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtCustomer, 0);
            this.groupBox2.Controls.SetChildIndex(this.lblFromDate, 0);
            this.groupBox2.Controls.SetChildIndex(this.lblBillNumber, 0);
            this.groupBox2.Controls.SetChildIndex(this.label7, 0);
            this.groupBox2.Controls.SetChildIndex(this.lblToDate, 0);
            this.groupBox2.Controls.SetChildIndex(this.chkMorning, 0);
            this.groupBox2.Controls.SetChildIndex(this.chkEvening, 0);
            this.groupBox2.Controls.SetChildIndex(this.label8, 0);
            this.groupBox2.Controls.SetChildIndex(this.cboEmployee, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnSearch, 0);
            this.groupBox2.Controls.SetChildIndex(this.lblWorkingTime, 0);
            this.groupBox2.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.groupBox2.Controls.SetChildIndex(this.dtpToDate, 0);
            this.groupBox2.Controls.SetChildIndex(this.panel4, 0);
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.TextChanged += new System.EventHandler(this.txtBillNumber_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bdsPurchaseOrders
            // 
            this.bdsPurchaseOrders.DataSource = typeof(AppFrame.Collection.PurchaseOrderCollection);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(554, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 24);
            this.panel1.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(340, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 32);
            this.panel2.TabIndex = 49;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(12, 454);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 24);
            this.panel3.TabIndex = 50;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(389, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 24);
            this.panel4.TabIndex = 51;
            // 
            // btnBillChoosing
            // 
            this.btnBillChoosing.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillChoosing.Location = new System.Drawing.Point(714, 484);
            this.btnBillChoosing.Name = "btnBillChoosing";
            this.btnBillChoosing.Size = new System.Drawing.Size(112, 23);
            this.btnBillChoosing.TabIndex = 51;
            this.btnBillChoosing.Text = "Chọn hoá đơn";
            this.btnBillChoosing.UseVisualStyleBackColor = true;
            this.btnBillChoosing.Click += new System.EventHandler(this.btnBillChoosing_Click);
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // SearchGoodsSaleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 515);
            this.Controls.Add(this.btnBillChoosing);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SearchGoodsSaleListForm";
            this.Text = "SearchGoodsSaleListForm";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.chkMorningSort, 0);
            this.Controls.SetChildIndex(this.chkEveningSort, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.lblTotalAmount, 0);
            this.Controls.SetChildIndex(this.txtTotalAmount, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.btnBillChoosing, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPurchaseOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBillChoosing;
        private AppFrame.Controls.HotKey.SystemHotkey systemHotkey1;
    }
}