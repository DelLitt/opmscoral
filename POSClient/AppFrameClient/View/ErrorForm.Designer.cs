namespace AppFrameClient.View
{
    partial class ErrorForm
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
            this.txtErrorString = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstErrorDetails = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtErrorString
            // 
            this.txtErrorString.Location = new System.Drawing.Point(13, 13);
            this.txtErrorString.Name = "txtErrorString";
            this.txtErrorString.Size = new System.Drawing.Size(346, 20);
            this.txtErrorString.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstErrorDetails
            // 
            this.lstErrorDetails.FormattingEnabled = true;
            this.lstErrorDetails.Location = new System.Drawing.Point(13, 40);
            this.lstErrorDetails.Name = "lstErrorDetails";
            this.lstErrorDetails.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstErrorDetails.Size = new System.Drawing.Size(346, 316);
            this.lstErrorDetails.TabIndex = 3;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 408);
            this.Controls.Add(this.lstErrorDetails);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtErrorString);
            this.Name = "ErrorForm";
            this.Text = "Lỗi";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtErrorString;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstErrorDetails;
    }
}