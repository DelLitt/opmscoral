namespace AppFrameClient.View.Inventory
{
    partial class DepartmentStockAdhocCheckingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.bdsStockDefect = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.systemHotkey1 = new AppFrame.Controls.HotKey.SystemHotkey(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.productMasterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lostQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unconfirmQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldGoodQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldDamageQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldErrorQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldLostQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldUnconfirmQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onStorePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusiveKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(615, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 66);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Diễn giải";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(418, 11);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(141, 66);
            this.txtDescription.TabIndex = 24;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(64, 34);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(288, 20);
            this.txtProductName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tồn kho";
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.Location = new System.Drawing.Point(64, 59);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.ReadOnly = true;
            this.txtStockQuantity.Size = new System.Drawing.Size(97, 20);
            this.txtStockQuantity.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "XỬ LÝ SỐ LIỆU KIỂM KÊ HÀNG HÓA TẠI KHO CỬA HÀNG";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(781, 17);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(173, 60);
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "XÁC NHẬN";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStockQuantity);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductType);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 85);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Loại";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(64, 11);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(129, 20);
            this.txtProductType.TabIndex = 0;
            // 
            // bdsStockDefect
            // 
            this.bdsStockDefect.DataSource = typeof(AppFrameClient.ViewModel.DepartmentStockTempViewCollection);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(748, 527);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "Bỏ qua";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(897, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(534, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Lưu kết quả xử lý";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productMasterDataGridViewTextBoxColumn,
            this.ProductMaster,
            this.Column2,
            this.quantityDataGridViewTextBoxColumn,
            this.Column1,
            this.goodQuantityDataGridViewTextBoxColumn,
            this.damageQuantityDataGridViewTextBoxColumn,
            this.errorQuantityDataGridViewTextBoxColumn,
            this.lostQuantityDataGridViewTextBoxColumn,
            this.unconfirmQuantityDataGridViewTextBoxColumn,
            this.oldGoodQuantityDataGridViewTextBoxColumn,
            this.oldDamageQuantityDataGridViewTextBoxColumn,
            this.oldErrorQuantityDataGridViewTextBoxColumn,
            this.oldLostQuantityDataGridViewTextBoxColumn,
            this.oldUnconfirmQuantityDataGridViewTextBoxColumn,
            this.departmentIdDataGridViewTextBoxColumn,
            this.productIdDataGridViewTextBoxColumn,
            this.onStorePriceDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.createIdDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.updateIdDataGridViewTextBoxColumn,
            this.exclusiveKeyDataGridViewTextBoxColumn,
            this.delFlgDataGridViewTextBoxColumn});
            this.dgvStock.DataSource = this.bdsStockDefect;
            this.dgvStock.Location = new System.Drawing.Point(12, 126);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(960, 289);
            this.dgvStock.StandardTab = true;
            this.dgvStock.TabIndex = 24;
            this.dgvStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellDoubleClick);
            this.dgvStock.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellContentDoubleClick);
            this.dgvStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellEndEdit);
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(338, 527);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 23);
            this.button4.TabIndex = 33;
            this.button4.Text = "Tự động xử lý kết quả kiểm kê";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // productMasterDataGridViewTextBoxColumn
            // 
            this.productMasterDataGridViewTextBoxColumn.DataPropertyName = "ProductMaster.ProductName";
            this.productMasterDataGridViewTextBoxColumn.HeaderText = "Tên mặt hàng";
            this.productMasterDataGridViewTextBoxColumn.Name = "productMasterDataGridViewTextBoxColumn";
            this.productMasterDataGridViewTextBoxColumn.Width = 135;
            // 
            // ProductMaster
            // 
            this.ProductMaster.DataPropertyName = "ProductMaster.ProductColor.ColorName";
            this.ProductMaster.HeaderText = "Màu sắc";
            this.ProductMaster.Name = "ProductMaster";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProductMaster.ProductSize.SizeName";
            this.Column2.HeaderText = "Cỡ";
            this.Column2.Name = "Column2";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Tồn";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RealQuantity";
            this.Column1.HeaderText = "Tồn thực";
            this.Column1.Name = "Column1";
            // 
            // goodQuantityDataGridViewTextBoxColumn
            // 
            this.goodQuantityDataGridViewTextBoxColumn.DataPropertyName = "GoodQuantity";
            this.goodQuantityDataGridViewTextBoxColumn.HeaderText = "Tốt";
            this.goodQuantityDataGridViewTextBoxColumn.Name = "goodQuantityDataGridViewTextBoxColumn";
            this.goodQuantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // damageQuantityDataGridViewTextBoxColumn
            // 
            this.damageQuantityDataGridViewTextBoxColumn.DataPropertyName = "DamageQuantity";
            this.damageQuantityDataGridViewTextBoxColumn.HeaderText = "Hư";
            this.damageQuantityDataGridViewTextBoxColumn.Name = "damageQuantityDataGridViewTextBoxColumn";
            this.damageQuantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // errorQuantityDataGridViewTextBoxColumn
            // 
            this.errorQuantityDataGridViewTextBoxColumn.DataPropertyName = "ErrorQuantity";
            this.errorQuantityDataGridViewTextBoxColumn.HeaderText = "Lỗi";
            this.errorQuantityDataGridViewTextBoxColumn.Name = "errorQuantityDataGridViewTextBoxColumn";
            this.errorQuantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // lostQuantityDataGridViewTextBoxColumn
            // 
            this.lostQuantityDataGridViewTextBoxColumn.DataPropertyName = "LostQuantity";
            this.lostQuantityDataGridViewTextBoxColumn.HeaderText = "Mất";
            this.lostQuantityDataGridViewTextBoxColumn.Name = "lostQuantityDataGridViewTextBoxColumn";
            this.lostQuantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // unconfirmQuantityDataGridViewTextBoxColumn
            // 
            this.unconfirmQuantityDataGridViewTextBoxColumn.DataPropertyName = "UnconfirmQuantity";
            this.unconfirmQuantityDataGridViewTextBoxColumn.HeaderText = "KXĐ";
            this.unconfirmQuantityDataGridViewTextBoxColumn.Name = "unconfirmQuantityDataGridViewTextBoxColumn";
            this.unconfirmQuantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // oldGoodQuantityDataGridViewTextBoxColumn
            // 
            this.oldGoodQuantityDataGridViewTextBoxColumn.DataPropertyName = "OldGoodQuantity";
            this.oldGoodQuantityDataGridViewTextBoxColumn.HeaderText = "OldGoodQuantity";
            this.oldGoodQuantityDataGridViewTextBoxColumn.Name = "oldGoodQuantityDataGridViewTextBoxColumn";
            this.oldGoodQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // oldDamageQuantityDataGridViewTextBoxColumn
            // 
            this.oldDamageQuantityDataGridViewTextBoxColumn.DataPropertyName = "OldDamageQuantity";
            this.oldDamageQuantityDataGridViewTextBoxColumn.HeaderText = "OldDamageQuantity";
            this.oldDamageQuantityDataGridViewTextBoxColumn.Name = "oldDamageQuantityDataGridViewTextBoxColumn";
            this.oldDamageQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // oldErrorQuantityDataGridViewTextBoxColumn
            // 
            this.oldErrorQuantityDataGridViewTextBoxColumn.DataPropertyName = "OldErrorQuantity";
            this.oldErrorQuantityDataGridViewTextBoxColumn.HeaderText = "OldErrorQuantity";
            this.oldErrorQuantityDataGridViewTextBoxColumn.Name = "oldErrorQuantityDataGridViewTextBoxColumn";
            this.oldErrorQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // oldLostQuantityDataGridViewTextBoxColumn
            // 
            this.oldLostQuantityDataGridViewTextBoxColumn.DataPropertyName = "OldLostQuantity";
            this.oldLostQuantityDataGridViewTextBoxColumn.HeaderText = "OldLostQuantity";
            this.oldLostQuantityDataGridViewTextBoxColumn.Name = "oldLostQuantityDataGridViewTextBoxColumn";
            this.oldLostQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // oldUnconfirmQuantityDataGridViewTextBoxColumn
            // 
            this.oldUnconfirmQuantityDataGridViewTextBoxColumn.DataPropertyName = "OldUnconfirmQuantity";
            this.oldUnconfirmQuantityDataGridViewTextBoxColumn.HeaderText = "OldUnconfirmQuantity";
            this.oldUnconfirmQuantityDataGridViewTextBoxColumn.Name = "oldUnconfirmQuantityDataGridViewTextBoxColumn";
            this.oldUnconfirmQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // departmentIdDataGridViewTextBoxColumn
            // 
            this.departmentIdDataGridViewTextBoxColumn.DataPropertyName = "DepartmentId";
            this.departmentIdDataGridViewTextBoxColumn.HeaderText = "DepartmentId";
            this.departmentIdDataGridViewTextBoxColumn.Name = "departmentIdDataGridViewTextBoxColumn";
            this.departmentIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // onStorePriceDataGridViewTextBoxColumn
            // 
            this.onStorePriceDataGridViewTextBoxColumn.DataPropertyName = "OnStorePrice";
            this.onStorePriceDataGridViewTextBoxColumn.HeaderText = "OnStorePrice";
            this.onStorePriceDataGridViewTextBoxColumn.Name = "onStorePriceDataGridViewTextBoxColumn";
            this.onStorePriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // createIdDataGridViewTextBoxColumn
            // 
            this.createIdDataGridViewTextBoxColumn.DataPropertyName = "CreateId";
            this.createIdDataGridViewTextBoxColumn.HeaderText = "CreateId";
            this.createIdDataGridViewTextBoxColumn.Name = "createIdDataGridViewTextBoxColumn";
            this.createIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            this.updateDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateIdDataGridViewTextBoxColumn
            // 
            this.updateIdDataGridViewTextBoxColumn.DataPropertyName = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.HeaderText = "UpdateId";
            this.updateIdDataGridViewTextBoxColumn.Name = "updateIdDataGridViewTextBoxColumn";
            this.updateIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // exclusiveKeyDataGridViewTextBoxColumn
            // 
            this.exclusiveKeyDataGridViewTextBoxColumn.DataPropertyName = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.HeaderText = "ExclusiveKey";
            this.exclusiveKeyDataGridViewTextBoxColumn.Name = "exclusiveKeyDataGridViewTextBoxColumn";
            this.exclusiveKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // delFlgDataGridViewTextBoxColumn
            // 
            this.delFlgDataGridViewTextBoxColumn.DataPropertyName = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.HeaderText = "DelFlg";
            this.delFlgDataGridViewTextBoxColumn.Name = "delFlgDataGridViewTextBoxColumn";
            this.delFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // DepartmentStockAdhocCheckingForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvStock);
            this.Name = "DepartmentStockAdhocCheckingForm";
            this.Load += new System.EventHandler(this.DepartmentStockCheckingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStockDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.BindingSource bdsStockDefect;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvStock;
        private AppFrame.Controls.HotKey.SystemHotkey systemHotkey1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn productMasterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn damageQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lostQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unconfirmQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldGoodQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldDamageQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldErrorQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldLostQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldUnconfirmQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onStorePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusiveKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delFlgDataGridViewTextBoxColumn;
    }
}