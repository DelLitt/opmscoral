namespace AppFrameClient.View.GoodsSale
{
    partial class TrackingReturnGoodsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackingReturnGoodsForm));
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.printForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this.components);
            this.dataRepeater1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeater1
            // 
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(952, 106);
            this.dataRepeater1.Location = new System.Drawing.Point(12, 12);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(960, 471);
            this.dataRepeater1.TabIndex = 2;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // printForm1
            // 
            this.printForm1.DocumentName = "document";
            this.printForm1.Form = this;
            this.printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter;
            this.printForm1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("printForm1.PrinterSettings")));
            this.printForm1.PrintFileName = null;
            // 
            // TrackingReturnGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.dataRepeater1);
            this.Name = "TrackingReturnGoodsForm";
            this.Text = "TrackingReturnGoodsForm";
            this.dataRepeater1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;


    }
}