namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class SyncToMainForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSyncToMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(162, 79);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Bắt đầu đồng bộ về kho";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSyncToMain
            // 
            this.btnSyncToMain.Location = new System.Drawing.Point(198, 12);
            this.btnSyncToMain.Name = "btnSyncToMain";
            this.btnSyncToMain.Size = new System.Drawing.Size(162, 79);
            this.btnSyncToMain.TabIndex = 1;
            this.btnSyncToMain.Text = "Bắt đầu đồng bộ từ của hàng";
            this.btnSyncToMain.UseVisualStyleBackColor = true;
            this.btnSyncToMain.Click += new System.EventHandler(this.btnSyncToMain_Click);
            // 
            // SyncToMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 111);
            this.Controls.Add(this.btnSyncToMain);
            this.Controls.Add(this.btnStart);
            this.Name = "SyncToMainForm";
            this.Text = "Đồng bộ về kho chính";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSyncToMain;
    }
}