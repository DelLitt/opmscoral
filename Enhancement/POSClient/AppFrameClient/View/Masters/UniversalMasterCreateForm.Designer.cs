namespace AppFrameClient.View.Masters
{
    partial class UniversalMasterCreateForm
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
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.Location = new System.Drawing.Point(143, 9);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(101, 19);
            this.lblLabel.TabIndex = 17;
            this.lblLabel.Text = "NHẬP KIỂU";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 68);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 14);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Tên";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 22);
            this.textBox1.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(214, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mã";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(61, 39);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(100, 22);
            this.txtId.TabIndex = 23;
            // 
            // UniversalMasterCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 119);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UniversalMasterCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniversalMasterCreateForm";
            this.Load += new System.EventHandler(this.UniversalMasterCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
    }
}