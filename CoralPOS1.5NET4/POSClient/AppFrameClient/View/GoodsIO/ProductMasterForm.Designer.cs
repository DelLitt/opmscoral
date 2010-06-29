namespace AppFrameClient.View.GoodsIO
{
    partial class ProductMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMasterForm));
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.barcodePrintDialog = new System.Windows.Forms.PrintDialog();
            this.barcodePrintDocument = new System.Drawing.Printing.PrintDocument();
            this.barcodePrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.productMasterControl = new AppFrameClient.View.GoodsIO.ProductMasterControl();
            this.productMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(190, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "CHI TIẾT SẢN PHẨM";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(460, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(367, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(311, 524);
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
            this.productMasterControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productMasterControl.Location = new System.Drawing.Point(14, 28);
            this.productMasterControl.Name = "productMasterControl";
            this.productMasterControl.Size = new System.Drawing.Size(535, 489);
            this.productMasterControl.TabIndex = 0;
            // 
            // productMasterBindingSource
            // 
            this.productMasterBindingSource.DataSource = typeof(AppFrame.Model.ProductMaster);
            // 
            // ProductMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 552);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productMasterControl);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProductMasterForm";
            this.Text = "ProductMasterForm";
            this.Load += new System.EventHandler(this.ProductMasterForm_Load);
            this.Controls.SetChildIndex(this.productMasterControl, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProductMasterControl productMasterControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PrintDialog barcodePrintDialog;
        private System.Drawing.Printing.PrintDocument barcodePrintDocument;
        private System.Windows.Forms.PrintPreviewDialog barcodePrintPreviewDialog;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource productMasterBindingSource;
    }
}