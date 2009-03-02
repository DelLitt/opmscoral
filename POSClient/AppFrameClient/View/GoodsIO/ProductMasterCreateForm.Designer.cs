using System;
using AppFrame.Presenter.GoodsIO;

namespace AppFrameClient.View.GoodsIO
{
    partial class ProductMasterCreateForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.productMasterControl = new AppFrameClient.View.GoodsIO.ProductMasterCreateControl();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(208, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "TẠO SẢN PHẨM";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(355, 627);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 27);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(462, 627);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 27);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Hình ảnh";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(118, 505);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(368, 22);
            this.txtImagePath.TabIndex = 26;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(492, 505);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(38, 23);
            this.btnSelect.TabIndex = 27;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // picProduct
            // 
            this.picProduct.Location = new System.Drawing.Point(118, 533);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(290, 88);
            this.picProduct.TabIndex = 28;
            this.picProduct.TabStop = false;
            // 
            // productMasterControl
            // 
            this.productMasterControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productMasterControl.Location = new System.Drawing.Point(5, 24);
            this.productMasterControl.Name = "productMasterControl";
            this.productMasterControl.Size = new System.Drawing.Size(577, 481);
            this.productMasterControl.TabIndex = 0;
            this.productMasterControl.Load += new System.EventHandler(this.productMasterUserControl_Load);
            // 
            // ProductMasterCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 670);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productMasterControl);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProductMasterCreateForm";
            this.Text = "ProductMasterCreateForm";
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ProductMasterCreateControl productMasterControl;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtImagePath;
        public System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.PictureBox picProduct;

        public event EventHandler<ProductMasterEventArgs> DeleteProductMasterEvent;
    }
}