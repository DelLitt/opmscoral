namespace AppFrameClient.View.Masters
{
    partial class ProductSizeMasterForm
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
            System.Windows.Forms.Label sIZE_IDLabel;
            System.Windows.Forms.Label sIZE_NAMELabel;
            System.Windows.Forms.Label cREATE_DATELabel;
            System.Windows.Forms.Label cREATE_IDLabel;
            System.Windows.Forms.Label uPDATE_DATELabel;
            System.Windows.Forms.Label uPDATE_IDLabel;
            System.Windows.Forms.Label eXCLUSIVE_KEYLabel;
            System.Windows.Forms.Label dEL_FLGLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSizeMasterForm));
            this.masterDB = new AppFrameClient.MasterDB();
            this.product_sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_sizeTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_sizeTableAdapter();
            this.tableAdapterManager = new AppFrameClient.MasterDBTableAdapters.TableAdapterManager();
            this.product_sizeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.product_sizeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.sIZE_IDTextBox = new System.Windows.Forms.TextBox();
            this.sIZE_NAMETextBox = new System.Windows.Forms.TextBox();
            this.cREATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cREATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.uPDATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uPDATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.eXCLUSIVE_KEYTextBox = new System.Windows.Forms.TextBox();
            this.dEL_FLGTextBox = new System.Windows.Forms.TextBox();
            sIZE_IDLabel = new System.Windows.Forms.Label();
            sIZE_NAMELabel = new System.Windows.Forms.Label();
            cREATE_DATELabel = new System.Windows.Forms.Label();
            cREATE_IDLabel = new System.Windows.Forms.Label();
            uPDATE_DATELabel = new System.Windows.Forms.Label();
            uPDATE_IDLabel = new System.Windows.Forms.Label();
            eXCLUSIVE_KEYLabel = new System.Windows.Forms.Label();
            dEL_FLGLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_sizeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_sizeBindingNavigator)).BeginInit();
            this.product_sizeBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // sIZE_IDLabel
            // 
            sIZE_IDLabel.AutoSize = true;
            sIZE_IDLabel.Location = new System.Drawing.Point(14, 40);
            sIZE_IDLabel.Name = "sIZE_IDLabel";
            sIZE_IDLabel.Size = new System.Drawing.Size(65, 13);
            sIZE_IDLabel.TabIndex = 1;
            sIZE_IDLabel.Text = "Mã kích cỡ:";
            // 
            // sIZE_NAMELabel
            // 
            sIZE_NAMELabel.AutoSize = true;
            sIZE_NAMELabel.Location = new System.Drawing.Point(14, 66);
            sIZE_NAMELabel.Name = "sIZE_NAMELabel";
            sIZE_NAMELabel.Size = new System.Drawing.Size(69, 13);
            sIZE_NAMELabel.TabIndex = 3;
            sIZE_NAMELabel.Text = "Tên kích cỡ:";
            // 
            // cREATE_DATELabel
            // 
            cREATE_DATELabel.AutoSize = true;
            cREATE_DATELabel.Location = new System.Drawing.Point(14, 93);
            cREATE_DATELabel.Name = "cREATE_DATELabel";
            cREATE_DATELabel.Size = new System.Drawing.Size(53, 13);
            cREATE_DATELabel.TabIndex = 5;
            cREATE_DATELabel.Text = "Ngày tạo:";
            // 
            // cREATE_IDLabel
            // 
            cREATE_IDLabel.AutoSize = true;
            cREATE_IDLabel.Location = new System.Drawing.Point(14, 118);
            cREATE_IDLabel.Name = "cREATE_IDLabel";
            cREATE_IDLabel.Size = new System.Drawing.Size(56, 13);
            cREATE_IDLabel.TabIndex = 7;
            cREATE_IDLabel.Text = "Người tạo:";
            // 
            // uPDATE_DATELabel
            // 
            uPDATE_DATELabel.AutoSize = true;
            uPDATE_DATELabel.Location = new System.Drawing.Point(14, 145);
            uPDATE_DATELabel.Name = "uPDATE_DATELabel";
            uPDATE_DATELabel.Size = new System.Drawing.Size(80, 13);
            uPDATE_DATELabel.TabIndex = 9;
            uPDATE_DATELabel.Text = "Ngày cập nhật:";
            // 
            // uPDATE_IDLabel
            // 
            uPDATE_IDLabel.AutoSize = true;
            uPDATE_IDLabel.Location = new System.Drawing.Point(14, 170);
            uPDATE_IDLabel.Name = "uPDATE_IDLabel";
            uPDATE_IDLabel.Size = new System.Drawing.Size(83, 13);
            uPDATE_IDLabel.TabIndex = 11;
            uPDATE_IDLabel.Text = "Người cập nhật:";
            // 
            // eXCLUSIVE_KEYLabel
            // 
            eXCLUSIVE_KEYLabel.AutoSize = true;
            eXCLUSIVE_KEYLabel.Location = new System.Drawing.Point(14, 196);
            eXCLUSIVE_KEYLabel.Name = "eXCLUSIVE_KEYLabel";
            eXCLUSIVE_KEYLabel.Size = new System.Drawing.Size(93, 13);
            eXCLUSIVE_KEYLabel.TabIndex = 13;
            eXCLUSIVE_KEYLabel.Text = "EXCLUSIVE KEY:";
            eXCLUSIVE_KEYLabel.Visible = false;
            // 
            // dEL_FLGLabel
            // 
            dEL_FLGLabel.AutoSize = true;
            dEL_FLGLabel.Location = new System.Drawing.Point(14, 222);
            dEL_FLGLabel.Name = "dEL_FLGLabel";
            dEL_FLGLabel.Size = new System.Drawing.Size(54, 13);
            dEL_FLGLabel.TabIndex = 15;
            dEL_FLGLabel.Text = "DEL FLG:";
            dEL_FLGLabel.Visible = false;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // product_sizeBindingSource
            // 
            this.product_sizeBindingSource.DataMember = "product_size";
            this.product_sizeBindingSource.DataSource = this.masterDB;
            // 
            // product_sizeTableAdapter
            // 
            this.product_sizeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.product_colorTableAdapter = null;
            this.tableAdapterManager.product_sizeTableAdapter = this.product_sizeTableAdapter;
            this.tableAdapterManager.product_typeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppFrameClient.MasterDBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // product_sizeBindingNavigator
            // 
            this.product_sizeBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.product_sizeBindingNavigator.BindingSource = this.product_sizeBindingSource;
            this.product_sizeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.product_sizeBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.product_sizeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.product_sizeBindingNavigatorSaveItem});
            this.product_sizeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.product_sizeBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.product_sizeBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.product_sizeBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.product_sizeBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.product_sizeBindingNavigator.Name = "product_sizeBindingNavigator";
            this.product_sizeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.product_sizeBindingNavigator.Size = new System.Drawing.Size(329, 25);
            this.product_sizeBindingNavigator.TabIndex = 0;
            this.product_sizeBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // product_sizeBindingNavigatorSaveItem
            // 
            this.product_sizeBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.product_sizeBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("product_sizeBindingNavigatorSaveItem.Image")));
            this.product_sizeBindingNavigatorSaveItem.Name = "product_sizeBindingNavigatorSaveItem";
            this.product_sizeBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.product_sizeBindingNavigatorSaveItem.Text = "Save Data";
            this.product_sizeBindingNavigatorSaveItem.Click += new System.EventHandler(this.product_sizeBindingNavigatorSaveItem_Click_1);
            // 
            // sIZE_IDTextBox
            // 
            this.sIZE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_sizeBindingSource, "SIZE_ID", true));
            this.sIZE_IDTextBox.Location = new System.Drawing.Point(113, 37);
            this.sIZE_IDTextBox.Name = "sIZE_IDTextBox";
            this.sIZE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.sIZE_IDTextBox.TabIndex = 2;
            // 
            // sIZE_NAMETextBox
            // 
            this.sIZE_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_sizeBindingSource, "SIZE_NAME", true));
            this.sIZE_NAMETextBox.Location = new System.Drawing.Point(113, 63);
            this.sIZE_NAMETextBox.Name = "sIZE_NAMETextBox";
            this.sIZE_NAMETextBox.Size = new System.Drawing.Size(200, 20);
            this.sIZE_NAMETextBox.TabIndex = 4;
            // 
            // cREATE_DATEDateTimePicker
            // 
            this.cREATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.product_sizeBindingSource, "CREATE_DATE", true));
            this.cREATE_DATEDateTimePicker.Location = new System.Drawing.Point(113, 89);
            this.cREATE_DATEDateTimePicker.Name = "cREATE_DATEDateTimePicker";
            this.cREATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.cREATE_DATEDateTimePicker.TabIndex = 6;
            // 
            // cREATE_IDTextBox
            // 
            this.cREATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_sizeBindingSource, "CREATE_ID", true));
            this.cREATE_IDTextBox.Location = new System.Drawing.Point(113, 115);
            this.cREATE_IDTextBox.Name = "cREATE_IDTextBox";
            this.cREATE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.cREATE_IDTextBox.TabIndex = 8;
            // 
            // uPDATE_DATEDateTimePicker
            // 
            this.uPDATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.product_sizeBindingSource, "UPDATE_DATE", true));
            this.uPDATE_DATEDateTimePicker.Location = new System.Drawing.Point(113, 141);
            this.uPDATE_DATEDateTimePicker.Name = "uPDATE_DATEDateTimePicker";
            this.uPDATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.uPDATE_DATEDateTimePicker.TabIndex = 10;
            // 
            // uPDATE_IDTextBox
            // 
            this.uPDATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_sizeBindingSource, "UPDATE_ID", true));
            this.uPDATE_IDTextBox.Location = new System.Drawing.Point(113, 167);
            this.uPDATE_IDTextBox.Name = "uPDATE_IDTextBox";
            this.uPDATE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.uPDATE_IDTextBox.TabIndex = 12;
            // 
            // eXCLUSIVE_KEYTextBox
            // 
            this.eXCLUSIVE_KEYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_sizeBindingSource, "EXCLUSIVE_KEY", true));
            this.eXCLUSIVE_KEYTextBox.Location = new System.Drawing.Point(113, 193);
            this.eXCLUSIVE_KEYTextBox.Name = "eXCLUSIVE_KEYTextBox";
            this.eXCLUSIVE_KEYTextBox.Size = new System.Drawing.Size(200, 20);
            this.eXCLUSIVE_KEYTextBox.TabIndex = 14;
            this.eXCLUSIVE_KEYTextBox.Visible = false;
            // 
            // dEL_FLGTextBox
            // 
            this.dEL_FLGTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_sizeBindingSource, "DEL_FLG", true));
            this.dEL_FLGTextBox.Location = new System.Drawing.Point(113, 219);
            this.dEL_FLGTextBox.Name = "dEL_FLGTextBox";
            this.dEL_FLGTextBox.Size = new System.Drawing.Size(200, 20);
            this.dEL_FLGTextBox.TabIndex = 16;
            this.dEL_FLGTextBox.Visible = false;
            // 
            // ProductSizeMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 255);
            this.Controls.Add(sIZE_IDLabel);
            this.Controls.Add(this.sIZE_IDTextBox);
            this.Controls.Add(sIZE_NAMELabel);
            this.Controls.Add(this.sIZE_NAMETextBox);
            this.Controls.Add(cREATE_DATELabel);
            this.Controls.Add(this.cREATE_DATEDateTimePicker);
            this.Controls.Add(cREATE_IDLabel);
            this.Controls.Add(this.cREATE_IDTextBox);
            this.Controls.Add(uPDATE_DATELabel);
            this.Controls.Add(this.uPDATE_DATEDateTimePicker);
            this.Controls.Add(uPDATE_IDLabel);
            this.Controls.Add(this.uPDATE_IDTextBox);
            this.Controls.Add(eXCLUSIVE_KEYLabel);
            this.Controls.Add(this.eXCLUSIVE_KEYTextBox);
            this.Controls.Add(dEL_FLGLabel);
            this.Controls.Add(this.dEL_FLGTextBox);
            this.Controls.Add(this.product_sizeBindingNavigator);
            this.Name = "ProductSizeMasterForm";
            this.Text = "ProductSizeMasterForm";
            this.Load += new System.EventHandler(this.ProductSizeMasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_sizeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_sizeBindingNavigator)).EndInit();
            this.product_sizeBindingNavigator.ResumeLayout(false);
            this.product_sizeBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource product_sizeBindingSource;
        private AppFrameClient.MasterDBTableAdapters.product_sizeTableAdapter product_sizeTableAdapter;
        private AppFrameClient.MasterDBTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator product_sizeBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton product_sizeBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox sIZE_IDTextBox;
        private System.Windows.Forms.TextBox sIZE_NAMETextBox;
        private System.Windows.Forms.DateTimePicker cREATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox cREATE_IDTextBox;
        private System.Windows.Forms.DateTimePicker uPDATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox uPDATE_IDTextBox;
        private System.Windows.Forms.TextBox eXCLUSIVE_KEYTextBox;
        private System.Windows.Forms.TextBox dEL_FLGTextBox;

    }
}