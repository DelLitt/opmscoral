namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentStockSearchForm
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
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.productMasterSearchControl = new AppFrameClient.View.GoodsIO.ProductMasterSearchControl();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToOrderColumns = true;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(7, 164);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(963, 290);
            this.dgvProduct.TabIndex = 1;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(780, 124);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // productMasterSearchControl
            // 
            this.productMasterSearchControl.Location = new System.Drawing.Point(0, 27);
            this.productMasterSearchControl.Name = "productMasterSearchControl";
            this.productMasterSearchControl.Size = new System.Drawing.Size(953, 120);
            this.productMasterSearchControl.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(364, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 19);
            this.label7.TabIndex = 44;
            this.label7.Text = "TÌM KIẾM KHO";
            // 
            // DepartmentStockSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 466);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.productMasterSearchControl);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepartmentStockSearchForm";
            this.Text = "DepartmentStockSearchForm";
            this.Load += new System.EventHandler(this.DepartmentStockSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProductMasterSearchControl productMasterSearchControl;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
    }
}