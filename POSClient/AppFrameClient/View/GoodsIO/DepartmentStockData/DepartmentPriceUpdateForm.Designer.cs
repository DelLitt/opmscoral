namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentPriceUpdateForm
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
            this.productMasterSearchControl = new AppFrameClient.View.GoodsIO.ProductMasterSearchControl();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtWholeSalePrice = new System.Windows.Forms.TextBox();
            this.btnPutPrice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAbsoluteFinding = new System.Windows.Forms.CheckBox();
            this.chkZeroPrice = new System.Windows.Forms.CheckBox();
            this.chkZeroWholeSalePrice = new System.Windows.Forms.CheckBox();
            this.ctxShortcuts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemHotkey1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemHotkey2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemHotkey3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.ctxShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // productMasterSearchControl
            // 
            this.productMasterSearchControl.Location = new System.Drawing.Point(0, 12);
            this.productMasterSearchControl.Name = "productMasterSearchControl";
            this.productMasterSearchControl.Size = new System.Drawing.Size(751, 128);
            this.productMasterSearchControl.TabIndex = 0;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToOrderColumns = true;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(6, 151);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.Size = new System.Drawing.Size(800, 279);
            this.dgvProduct.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(731, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(650, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(671, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(135, 52);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(365, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 19);
            this.label7.TabIndex = 43;
            this.label7.Text = "GIÁ HÀNG HÓA";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(313, 122);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 44;
            // 
            // txtWholeSalePrice
            // 
            this.txtWholeSalePrice.Location = new System.Drawing.Point(474, 122);
            this.txtWholeSalePrice.Name = "txtWholeSalePrice";
            this.txtWholeSalePrice.Size = new System.Drawing.Size(100, 22);
            this.txtWholeSalePrice.TabIndex = 45;
            // 
            // btnPutPrice
            // 
            this.btnPutPrice.Location = new System.Drawing.Point(580, 122);
            this.btnPutPrice.Name = "btnPutPrice";
            this.btnPutPrice.Size = new System.Drawing.Size(75, 23);
            this.btnPutPrice.TabIndex = 46;
            this.btnPutPrice.Text = "Áp giá";
            this.btnPutPrice.UseVisualStyleBackColor = true;
            this.btnPutPrice.Click += new System.EventHandler(this.btnPutPrice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 14);
            this.label1.TabIndex = 47;
            this.label1.Text = "Giá lẻ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "Giá sỉ";
            // 
            // chkAbsoluteFinding
            // 
            this.chkAbsoluteFinding.AutoSize = true;
            this.chkAbsoluteFinding.Location = new System.Drawing.Point(671, 20);
            this.chkAbsoluteFinding.Name = "chkAbsoluteFinding";
            this.chkAbsoluteFinding.Size = new System.Drawing.Size(101, 18);
            this.chkAbsoluteFinding.TabIndex = 49;
            this.chkAbsoluteFinding.Text = "Tìm chính xác";
            this.chkAbsoluteFinding.UseVisualStyleBackColor = true;
            // 
            // chkZeroPrice
            // 
            this.chkZeroPrice.AutoSize = true;
            this.chkZeroPrice.Location = new System.Drawing.Point(671, 45);
            this.chkZeroPrice.Name = "chkZeroPrice";
            this.chkZeroPrice.Size = new System.Drawing.Size(102, 18);
            this.chkZeroPrice.TabIndex = 50;
            this.chkZeroPrice.Text = "Tìm giá lẻ = 0";
            this.chkZeroPrice.UseVisualStyleBackColor = true;
            // 
            // chkZeroWholeSalePrice
            // 
            this.chkZeroWholeSalePrice.AutoSize = true;
            this.chkZeroWholeSalePrice.Location = new System.Drawing.Point(671, 69);
            this.chkZeroWholeSalePrice.Name = "chkZeroWholeSalePrice";
            this.chkZeroWholeSalePrice.Size = new System.Drawing.Size(100, 18);
            this.chkZeroWholeSalePrice.TabIndex = 51;
            this.chkZeroWholeSalePrice.Text = "Tìm giá sỉ = 0";
            this.chkZeroWholeSalePrice.UseVisualStyleBackColor = true;
            // 
            // ctxShortcuts
            // 
            this.ctxShortcuts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemHotkey1ToolStripMenuItem,
            this.systemHotkey2ToolStripMenuItem,
            this.systemHotkey3ToolStripMenuItem});
            this.ctxShortcuts.Name = "ctxShortcuts";
            this.ctxShortcuts.Size = new System.Drawing.Size(198, 92);
            // 
            // systemHotkey1ToolStripMenuItem
            // 
            this.systemHotkey1ToolStripMenuItem.Name = "systemHotkey1ToolStripMenuItem";
            this.systemHotkey1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.systemHotkey1ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.systemHotkey1ToolStripMenuItem.Text = "systemHotkey1";
            this.systemHotkey1ToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // systemHotkey2ToolStripMenuItem
            // 
            this.systemHotkey2ToolStripMenuItem.Name = "systemHotkey2ToolStripMenuItem";
            this.systemHotkey2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.systemHotkey2ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.systemHotkey2ToolStripMenuItem.Text = "systemHotkey2";
            this.systemHotkey2ToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // systemHotkey3ToolStripMenuItem
            // 
            this.systemHotkey3ToolStripMenuItem.Name = "systemHotkey3ToolStripMenuItem";
            this.systemHotkey3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.systemHotkey3ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.systemHotkey3ToolStripMenuItem.Text = "systemHotkey3";
            this.systemHotkey3ToolStripMenuItem.Click += new System.EventHandler(this.systemHotkey3_Pressed);
            // 
            // DepartmentPriceUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 473);
            this.Controls.Add(this.chkZeroWholeSalePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkZeroPrice);
            this.Controls.Add(this.chkAbsoluteFinding);
            this.Controls.Add(this.btnPutPrice);
            this.Controls.Add(this.txtWholeSalePrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.productMasterSearchControl);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepartmentPriceUpdateForm";
            this.Text = "Cập nhật giá hàng hoá";
            this.Load += new System.EventHandler(this.DepartmentPriceUpdateForm_Load);
            this.Controls.SetChildIndex(this.productMasterSearchControl, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.dgvProduct, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.txtPrice, 0);
            this.Controls.SetChildIndex(this.txtWholeSalePrice, 0);
            this.Controls.SetChildIndex(this.btnPutPrice, 0);
            this.Controls.SetChildIndex(this.chkAbsoluteFinding, 0);
            this.Controls.SetChildIndex(this.chkZeroPrice, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.chkZeroWholeSalePrice, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ctxShortcuts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProductMasterSearchControl productMasterSearchControl;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtWholeSalePrice;
        private System.Windows.Forms.Button btnPutPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAbsoluteFinding;
        private System.Windows.Forms.CheckBox chkZeroPrice;
        private System.Windows.Forms.CheckBox chkZeroWholeSalePrice;
        private System.Windows.Forms.ContextMenuStrip ctxShortcuts;
        private System.Windows.Forms.ToolStripMenuItem systemHotkey1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemHotkey2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemHotkey3ToolStripMenuItem;
    }
}