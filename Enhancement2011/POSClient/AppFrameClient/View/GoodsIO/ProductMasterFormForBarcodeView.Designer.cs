namespace AppFrameClient.View.GoodsIO
{
    partial class ProductMasterFormForBarcodeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMasterForm));
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblMaVach = new System.Windows.Forms.Label();
            this.barcodePrintDialog = new System.Windows.Forms.PrintDialog();
            this.barcodePrintDocument = new System.Drawing.Printing.PrintDocument();
            this.barcodePrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.productMasterControl = new AppFrameClient.View.GoodsIO.ProductMasterControl();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(190, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "CHI TIẾT SẢN PHẨM";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(376, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(28, 324);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(528, 85);
            this.picBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBarcode.TabIndex = 24;
            this.picBarcode.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã vạch";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(119, 296);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(184, 22);
            this.txtBarcode.TabIndex = 26;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(283, 415);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 25);
            this.btnPreview.TabIndex = 27;
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(110, 415);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 25);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(166, 418);
            this.numericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(49, 22);
            this.numericUpDown.TabIndex = 29;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaVach
            // 
            this.lblMaVach.AutoSize = true;
            this.lblMaVach.Location = new System.Drawing.Point(221, 420);
            this.lblMaVach.Name = "lblMaVach";
            this.lblMaVach.Size = new System.Drawing.Size(52, 14);
            this.lblMaVach.TabIndex = 30;
            this.lblMaVach.Text = "mã vạch";
            // 
            // barcodePrintDialog
            // 
            this.barcodePrintDialog.UseEXDialog = true;
            // 
            // barcodePrintDocument
            // 
            this.barcodePrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.barcodePrintDocument_PrintPage);
            // 
            // barcodePrintPreviewDialog
            // 
            this.barcodePrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.barcodePrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.barcodePrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.barcodePrintPreviewDialog.Enabled = true;
            this.barcodePrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("barcodePrintPreviewDialog.Icon")));
            this.barcodePrintPreviewDialog.Name = "barcodePrintPreviewDialog";
            this.barcodePrintPreviewDialog.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(54, 415);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 25);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // productMasterControl
            // 
            this.productMasterControl.Location = new System.Drawing.Point(14, 28);
            this.productMasterControl.Name = "productMasterControl";
            this.productMasterControl.Size = new System.Drawing.Size(535, 269);
            this.productMasterControl.TabIndex = 0;
            // 
            // ProductMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 447);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblMaVach);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productMasterControl);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProductMasterForm";
            this.Text = "ProductMasterForm";
            this.Load += new System.EventHandler(this.ProductMasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProductMasterControl productMasterControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label lblMaVach;
        private System.Windows.Forms.PrintDialog barcodePrintDialog;
        private System.Drawing.Printing.PrintDocument barcodePrintDocument;
        private System.Windows.Forms.PrintPreviewDialog barcodePrintPreviewDialog;
        private System.Windows.Forms.Button btnDelete;
    }
}