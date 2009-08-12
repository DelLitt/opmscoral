using System;
using AppFrame.Presenter.GoodsIO;

namespace AppFrameClient.View.GoodsIO
{
    partial class ProductMasterExtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMasterExtraForm));
            this.label8 = new System.Windows.Forms.Label();
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.colorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.typeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDescription1 = new System.Windows.Forms.Label();
            this.manufacturerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbxProductSize = new System.Windows.Forms.ListBox();
            this.lbxProductColor = new System.Windows.Forms.ListBox();
            this.btnCreateDistributor = new System.Windows.Forms.Button();
            this.btnCreatePackager = new System.Windows.Forms.Button();
            this.btnCreateManufacturer = new System.Windows.Forms.Button();
            this.btnCreateCountry = new System.Windows.Forms.Button();
            this.btnCreateSize = new System.Windows.Forms.Button();
            this.btnCreateColor = new System.Windows.Forms.Button();
            this.btnCreateType = new System.Windows.Forms.Button();
            this.cbbDistributor = new System.Windows.Forms.ComboBox();
            this.distributorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cbbPackager = new System.Windows.Forms.ComboBox();
            this.packagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cbbManufacturer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbCountry = new System.Windows.Forms.ComboBox();
            this.cbbProductType = new System.Windows.Forms.ComboBox();
            this.txtProductMasterId = new System.Windows.Forms.TextBox();
            this.lblProductMasterId = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.btnRemoveColor = new System.Windows.Forms.Button();
            this.bdsColors = new System.Windows.Forms.BindingSource(this.components);
            this.bdsSizes = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddSize = new System.Windows.Forms.Button();
            this.btnRemoveSize = new System.Windows.Forms.Button();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtProductName = new AppFrame.Controls.CoralTextBox();
            this.lstProductColors = new Rafael.Windows.Forms.ListBox.CoralListBox();
            this.lstProductSizes = new Rafael.Windows.Forms.ListBox.CoralListBox();
            this.imagePathFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(164, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "THÔNG TIN SẢN PHẨM";
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataSource = typeof(AppFrame.Model.Country);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(520, 521);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(38, 23);
            this.btnSelect.TabIndex = 121;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(135, 521);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(379, 22);
            this.txtImagePath.TabIndex = 102;
            // 
            // colorBindingSource
            // 
            this.colorBindingSource.DataSource = typeof(AppFrame.Model.ProductColor);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 120;
            this.label1.Text = "Hình ảnh";
            // 
            // typeBindingSource
            // 
            this.typeBindingSource.DataSource = typeof(AppFrame.Model.ProductType);
            // 
            // sizeBindingSource
            // 
            this.sizeBindingSource.DataSource = typeof(AppFrame.Model.ProductSize);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(135, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(423, 48);
            this.txtDescription.TabIndex = 94;
            // 
            // txtDescription1
            // 
            this.txtDescription1.AutoSize = true;
            this.txtDescription1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription1.Location = new System.Drawing.Point(24, 88);
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.Size = new System.Drawing.Size(38, 14);
            this.txtDescription1.TabIndex = 119;
            this.txtDescription1.Text = "Mô tả";
            // 
            // manufacturerBindingSource
            // 
            this.manufacturerBindingSource.DataSource = typeof(AppFrame.Model.Manufacturer);
            // 
            // lbxProductSize
            // 
            this.lbxProductSize.DataSource = this.sizeBindingSource;
            this.lbxProductSize.DisplayMember = "SizeName";
            this.lbxProductSize.FormattingEnabled = true;
            this.lbxProductSize.ItemHeight = 14;
            this.lbxProductSize.Location = new System.Drawing.Point(133, 277);
            this.lbxProductSize.Name = "lbxProductSize";
            this.lbxProductSize.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxProductSize.Size = new System.Drawing.Size(185, 88);
            this.lbxProductSize.TabIndex = 97;
            // 
            // lbxProductColor
            // 
            this.lbxProductColor.DataSource = this.colorBindingSource;
            this.lbxProductColor.DisplayMember = "ColorName";
            this.lbxProductColor.FormattingEnabled = true;
            this.lbxProductColor.ItemHeight = 14;
            this.lbxProductColor.Location = new System.Drawing.Point(133, 175);
            this.lbxProductColor.Name = "lbxProductColor";
            this.lbxProductColor.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxProductColor.Size = new System.Drawing.Size(185, 88);
            this.lbxProductColor.TabIndex = 96;
            // 
            // btnCreateDistributor
            // 
            this.btnCreateDistributor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDistributor.Location = new System.Drawing.Point(324, 477);
            this.btnCreateDistributor.Name = "btnCreateDistributor";
            this.btnCreateDistributor.Size = new System.Drawing.Size(40, 25);
            this.btnCreateDistributor.TabIndex = 118;
            this.btnCreateDistributor.Text = "...";
            this.btnCreateDistributor.UseVisualStyleBackColor = true;
            this.btnCreateDistributor.Click += new System.EventHandler(this.btnCreateDistributor_Click);
            // 
            // btnCreatePackager
            // 
            this.btnCreatePackager.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePackager.Location = new System.Drawing.Point(324, 449);
            this.btnCreatePackager.Name = "btnCreatePackager";
            this.btnCreatePackager.Size = new System.Drawing.Size(40, 25);
            this.btnCreatePackager.TabIndex = 117;
            this.btnCreatePackager.Text = "...";
            this.btnCreatePackager.UseVisualStyleBackColor = true;
            this.btnCreatePackager.Click += new System.EventHandler(this.btnCreatePackager_Click);
            // 
            // btnCreateManufacturer
            // 
            this.btnCreateManufacturer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateManufacturer.Location = new System.Drawing.Point(324, 420);
            this.btnCreateManufacturer.Name = "btnCreateManufacturer";
            this.btnCreateManufacturer.Size = new System.Drawing.Size(40, 25);
            this.btnCreateManufacturer.TabIndex = 116;
            this.btnCreateManufacturer.Text = "...";
            this.btnCreateManufacturer.UseVisualStyleBackColor = true;
            this.btnCreateManufacturer.Click += new System.EventHandler(this.btnCreateManufacturer_Click);
            // 
            // btnCreateCountry
            // 
            this.btnCreateCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCountry.Location = new System.Drawing.Point(324, 391);
            this.btnCreateCountry.Name = "btnCreateCountry";
            this.btnCreateCountry.Size = new System.Drawing.Size(40, 25);
            this.btnCreateCountry.TabIndex = 115;
            this.btnCreateCountry.Text = "...";
            this.btnCreateCountry.UseVisualStyleBackColor = true;
            this.btnCreateCountry.Click += new System.EventHandler(this.btnCreateCountry_Click);
            // 
            // btnCreateSize
            // 
            this.btnCreateSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSize.Location = new System.Drawing.Point(327, 340);
            this.btnCreateSize.Name = "btnCreateSize";
            this.btnCreateSize.Size = new System.Drawing.Size(40, 25);
            this.btnCreateSize.TabIndex = 114;
            this.btnCreateSize.Text = "...";
            this.btnCreateSize.UseVisualStyleBackColor = true;
            this.btnCreateSize.Click += new System.EventHandler(this.btnCreateSize_Click);
            // 
            // btnCreateColor
            // 
            this.btnCreateColor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateColor.Location = new System.Drawing.Point(327, 240);
            this.btnCreateColor.Name = "btnCreateColor";
            this.btnCreateColor.Size = new System.Drawing.Size(40, 25);
            this.btnCreateColor.TabIndex = 113;
            this.btnCreateColor.Text = "...";
            this.btnCreateColor.UseVisualStyleBackColor = true;
            this.btnCreateColor.Click += new System.EventHandler(this.btnCreateColor_Click);
            // 
            // btnCreateType
            // 
            this.btnCreateType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateType.Location = new System.Drawing.Point(327, 142);
            this.btnCreateType.Name = "btnCreateType";
            this.btnCreateType.Size = new System.Drawing.Size(40, 25);
            this.btnCreateType.TabIndex = 112;
            this.btnCreateType.Text = "...";
            this.btnCreateType.UseVisualStyleBackColor = true;
            this.btnCreateType.Click += new System.EventHandler(this.btnCreateType_Click);
            // 
            // cbbDistributor
            // 
            this.cbbDistributor.DataSource = this.distributorBindingSource;
            this.cbbDistributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDistributor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDistributor.FormattingEnabled = true;
            this.cbbDistributor.Location = new System.Drawing.Point(135, 479);
            this.cbbDistributor.Name = "cbbDistributor";
            this.cbbDistributor.Size = new System.Drawing.Size(185, 22);
            this.cbbDistributor.TabIndex = 101;
            // 
            // distributorBindingSource
            // 
            this.distributorBindingSource.DataSource = typeof(AppFrame.Model.Distributor);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 482);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 14);
            this.label7.TabIndex = 111;
            this.label7.Text = "Hãng phân phối";
            // 
            // cbbPackager
            // 
            this.cbbPackager.DataSource = this.packagerBindingSource;
            this.cbbPackager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPackager.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPackager.FormattingEnabled = true;
            this.cbbPackager.Location = new System.Drawing.Point(135, 449);
            this.cbbPackager.Name = "cbbPackager";
            this.cbbPackager.Size = new System.Drawing.Size(185, 22);
            this.cbbPackager.TabIndex = 100;
            // 
            // packagerBindingSource
            // 
            this.packagerBindingSource.DataSource = typeof(AppFrame.Model.Packager);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 14);
            this.label6.TabIndex = 110;
            this.label6.Text = "Hãng đóng gói";
            // 
            // cbbManufacturer
            // 
            this.cbbManufacturer.DataSource = this.manufacturerBindingSource;
            this.cbbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbManufacturer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbManufacturer.FormattingEnabled = true;
            this.cbbManufacturer.Location = new System.Drawing.Point(135, 420);
            this.cbbManufacturer.Name = "cbbManufacturer";
            this.cbbManufacturer.Size = new System.Drawing.Size(185, 22);
            this.cbbManufacturer.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 109;
            this.label5.Text = "Hãng sản xuất";
            // 
            // cbbCountry
            // 
            this.cbbCountry.DataSource = this.countryBindingSource;
            this.cbbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCountry.FormattingEnabled = true;
            this.cbbCountry.Location = new System.Drawing.Point(135, 391);
            this.cbbCountry.Name = "cbbCountry";
            this.cbbCountry.Size = new System.Drawing.Size(185, 22);
            this.cbbCountry.TabIndex = 98;
            // 
            // cbbProductType
            // 
            this.cbbProductType.DataSource = this.typeBindingSource;
            this.cbbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProductType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProductType.FormattingEnabled = true;
            this.cbbProductType.Location = new System.Drawing.Point(135, 144);
            this.cbbProductType.Name = "cbbProductType";
            this.cbbProductType.Size = new System.Drawing.Size(183, 22);
            this.cbbProductType.TabIndex = 95;
            this.cbbProductType.SelectedIndexChanged += new System.EventHandler(this.cbbProductType_SelectedIndexChanged);
            // 
            // txtProductMasterId
            // 
            this.txtProductMasterId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductMasterId.Location = new System.Drawing.Point(135, 24);
            this.txtProductMasterId.Name = "txtProductMasterId";
            this.txtProductMasterId.ReadOnly = true;
            this.txtProductMasterId.Size = new System.Drawing.Size(185, 22);
            this.txtProductMasterId.TabIndex = 92;
            // 
            // lblProductMasterId
            // 
            this.lblProductMasterId.AutoSize = true;
            this.lblProductMasterId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductMasterId.Location = new System.Drawing.Point(24, 31);
            this.lblProductMasterId.Name = "lblProductMasterId";
            this.lblProductMasterId.Size = new System.Drawing.Size(78, 14);
            this.lblProductMasterId.TabIndex = 108;
            this.lblProductMasterId.Text = "Mã sản phẩm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(24, 394);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 14);
            this.label15.TabIndex = 107;
            this.label15.Text = "Nước sản xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 106;
            this.label4.Text = "Kích cỡ / Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 105;
            this.label3.Text = "Màu sắc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 104;
            this.label2.Text = "Chủng loại:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 14);
            this.label9.TabIndex = 103;
            this.label9.Text = "Tên mặt hàng";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(373, 144);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(185, 22);
            this.txtProductType.TabIndex = 122;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(327, 176);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(40, 23);
            this.btnAddColor.TabIndex = 123;
            this.btnAddColor.Text = "-->";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // btnRemoveColor
            // 
            this.btnRemoveColor.Location = new System.Drawing.Point(327, 201);
            this.btnRemoveColor.Name = "btnRemoveColor";
            this.btnRemoveColor.Size = new System.Drawing.Size(40, 23);
            this.btnRemoveColor.TabIndex = 124;
            this.btnRemoveColor.Text = "<--";
            this.btnRemoveColor.UseVisualStyleBackColor = true;
            this.btnRemoveColor.Click += new System.EventHandler(this.btnRemoveColor_Click);
            // 
            // bdsColors
            // 
            this.bdsColors.DataSource = typeof(AppFrame.Model.ProductColor);
            // 
            // bdsSizes
            // 
            this.bdsSizes.DataSource = typeof(AppFrame.Model.ProductSize);
            // 
            // btnAddSize
            // 
            this.btnAddSize.Location = new System.Drawing.Point(327, 277);
            this.btnAddSize.Name = "btnAddSize";
            this.btnAddSize.Size = new System.Drawing.Size(40, 23);
            this.btnAddSize.TabIndex = 127;
            this.btnAddSize.Text = "-->";
            this.btnAddSize.UseVisualStyleBackColor = true;
            this.btnAddSize.Click += new System.EventHandler(this.btnAddSize_Click);
            // 
            // btnRemoveSize
            // 
            this.btnRemoveSize.Location = new System.Drawing.Point(327, 306);
            this.btnRemoveSize.Name = "btnRemoveSize";
            this.btnRemoveSize.Size = new System.Drawing.Size(40, 23);
            this.btnRemoveSize.TabIndex = 128;
            this.btnRemoveSize.Text = "<--";
            this.btnRemoveSize.UseVisualStyleBackColor = true;
            this.btnRemoveSize.Click += new System.EventHandler(this.btnRemoveSize_Click);
            // 
            // picProduct
            // 
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(373, 384);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(185, 130);
            this.picProduct.TabIndex = 129;
            this.picProduct.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(230, 579);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 27);
            this.btnSave.TabIndex = 130;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(337, 579);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 27);
            this.btnCancel.TabIndex = 131;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(457, 579);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 27);
            this.btnClose.TabIndex = 132;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.DigitOnly = false;
            this.txtProductName.Format = null;
            this.txtProductName.LetterFormat = AppFrame.Controls.LetterFormat.Upper;
            this.txtProductName.Location = new System.Drawing.Point(135, 53);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(423, 22);
            this.txtProductName.TabIndex = 133;
            // 
            // lstProductColors
            // 
            this.lstProductColors.DataSource = this.bdsColors;
            this.lstProductColors.DisabledRows = ((System.Collections.IList)(resources.GetObject("lstProductColors.DisabledRows")));
            this.lstProductColors.DisplayMember = "ColorName";
            this.lstProductColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstProductColors.FormattingEnabled = true;
            this.lstProductColors.Location = new System.Drawing.Point(373, 176);
            this.lstProductColors.Name = "lstProductColors";
            this.lstProductColors.Size = new System.Drawing.Size(185, 95);
            this.lstProductColors.TabIndex = 134;
            // 
            // lstProductSizes
            // 
            this.lstProductSizes.DataSource = this.bdsSizes;
            this.lstProductSizes.DisabledRows = ((System.Collections.IList)(resources.GetObject("lstProductSizes.DisabledRows")));
            this.lstProductSizes.DisplayMember = "SizeName";
            this.lstProductSizes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstProductSizes.FormattingEnabled = true;
            this.lstProductSizes.Location = new System.Drawing.Point(373, 277);
            this.lstProductSizes.Name = "lstProductSizes";
            this.lstProductSizes.Size = new System.Drawing.Size(185, 95);
            this.lstProductSizes.TabIndex = 135;
            // 
            // imagePathFileDialog
            // 
            this.imagePathFileDialog.DefaultExt = "jpg";
            this.imagePathFileDialog.FileName = "openFileDialog1";
            this.imagePathFileDialog.Filter = "JPG files |*.jpg|All files|*.*";
            this.imagePathFileDialog.RestoreDirectory = true;
            // 
            // ProductMasterExtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 631);
            this.Controls.Add(this.lstProductSizes);
            this.Controls.Add(this.lstProductColors);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.btnRemoveSize);
            this.Controls.Add(this.btnAddSize);
            this.Controls.Add(this.btnRemoveColor);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.txtProductType);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDescription1);
            this.Controls.Add(this.lbxProductSize);
            this.Controls.Add(this.lbxProductColor);
            this.Controls.Add(this.btnCreateDistributor);
            this.Controls.Add(this.btnCreatePackager);
            this.Controls.Add(this.btnCreateManufacturer);
            this.Controls.Add(this.btnCreateCountry);
            this.Controls.Add(this.btnCreateSize);
            this.Controls.Add(this.btnCreateColor);
            this.Controls.Add(this.btnCreateType);
            this.Controls.Add(this.cbbDistributor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbPackager);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbManufacturer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbCountry);
            this.Controls.Add(this.cbbProductType);
            this.Controls.Add(this.txtProductMasterId);
            this.Controls.Add(this.lblProductMasterId);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProductMasterExtraForm";
            this.Text = "Thông tin sản phẩm";
            this.Load += new System.EventHandler(this.ProductMasterExtraForm_Load);
            this.LocationChanged += new System.EventHandler(this.ProductMasterExtraForm_LocationChanged);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.lblProductMasterId, 0);
            this.Controls.SetChildIndex(this.txtProductMasterId, 0);
            this.Controls.SetChildIndex(this.cbbProductType, 0);
            this.Controls.SetChildIndex(this.cbbCountry, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cbbManufacturer, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cbbPackager, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cbbDistributor, 0);
            this.Controls.SetChildIndex(this.btnCreateType, 0);
            this.Controls.SetChildIndex(this.btnCreateColor, 0);
            this.Controls.SetChildIndex(this.btnCreateSize, 0);
            this.Controls.SetChildIndex(this.btnCreateCountry, 0);
            this.Controls.SetChildIndex(this.btnCreateManufacturer, 0);
            this.Controls.SetChildIndex(this.btnCreatePackager, 0);
            this.Controls.SetChildIndex(this.btnCreateDistributor, 0);
            this.Controls.SetChildIndex(this.lbxProductColor, 0);
            this.Controls.SetChildIndex(this.lbxProductSize, 0);
            this.Controls.SetChildIndex(this.txtDescription1, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtImagePath, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.txtProductType, 0);
            this.Controls.SetChildIndex(this.btnAddColor, 0);
            this.Controls.SetChildIndex(this.btnRemoveColor, 0);
            this.Controls.SetChildIndex(this.btnAddSize, 0);
            this.Controls.SetChildIndex(this.btnRemoveSize, 0);
            this.Controls.SetChildIndex(this.picProduct, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.txtProductName, 0);
            this.Controls.SetChildIndex(this.lstProductColors, 0);
            this.Controls.SetChildIndex(this.lstProductSizes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.BindingSource countryBindingSource;
        public System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.TextBox txtImagePath;
        public System.Windows.Forms.BindingSource colorBindingSource;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.BindingSource typeBindingSource;
        public System.Windows.Forms.BindingSource sizeBindingSource;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label txtDescription1;
        public System.Windows.Forms.BindingSource manufacturerBindingSource;
        public System.Windows.Forms.ListBox lbxProductSize;
        public System.Windows.Forms.ListBox lbxProductColor;
        public System.Windows.Forms.Button btnCreateDistributor;
        public System.Windows.Forms.Button btnCreatePackager;
        public System.Windows.Forms.Button btnCreateManufacturer;
        public System.Windows.Forms.Button btnCreateCountry;
        public System.Windows.Forms.Button btnCreateSize;
        public System.Windows.Forms.Button btnCreateColor;
        public System.Windows.Forms.Button btnCreateType;
        public System.Windows.Forms.ComboBox cbbDistributor;
        public System.Windows.Forms.BindingSource distributorBindingSource;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbbPackager;
        public System.Windows.Forms.BindingSource packagerBindingSource;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbbManufacturer;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbbCountry;
        public System.Windows.Forms.ComboBox cbbProductType;
        public System.Windows.Forms.TextBox txtProductMasterId;
        private System.Windows.Forms.Label lblProductMasterId;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Button btnRemoveColor;
        private System.Windows.Forms.Button btnAddSize;
        private System.Windows.Forms.Button btnRemoveSize;
        private System.Windows.Forms.PictureBox picProduct;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bdsColors;
        private System.Windows.Forms.BindingSource bdsSizes;
        private AppFrame.Controls.CoralTextBox txtProductName;
        private Rafael.Windows.Forms.ListBox.CoralListBox lstProductColors;
        private Rafael.Windows.Forms.ListBox.CoralListBox lstProductSizes;
        private System.Windows.Forms.OpenFileDialog imagePathFileDialog;

        public event EventHandler<ProductMasterEventArgs> DeleteProductMasterEvent;
    }
}