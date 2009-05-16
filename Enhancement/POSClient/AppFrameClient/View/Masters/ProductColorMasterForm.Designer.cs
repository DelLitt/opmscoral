namespace AppFrameClient.View.Masters
{
    partial class ProductColorMasterForm
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
            System.Windows.Forms.Label cOLOR_IDLabel;
            System.Windows.Forms.Label cOLOR_NAMELabel;
            System.Windows.Forms.Label cREATE_DATELabel;
            System.Windows.Forms.Label cREATE_IDLabel;
            System.Windows.Forms.Label uPDATE_DATELabel;
            System.Windows.Forms.Label uPDATE_IDLabel;
            System.Windows.Forms.Label eXCLUSIVE_KEYLabel;
            System.Windows.Forms.Label dEL_FLGLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductColorMasterForm));
            this.masterDB = new AppFrameClient.MasterDB();
            this.product_colorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_colorTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_colorTableAdapter();
            this.tableAdapterManager = new AppFrameClient.MasterDBTableAdapters.TableAdapterManager();
            this.product_colorBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.product_colorBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cOLOR_IDTextBox = new System.Windows.Forms.TextBox();
            this.cOLOR_NAMETextBox = new System.Windows.Forms.TextBox();
            this.cREATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cREATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.uPDATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uPDATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.eXCLUSIVE_KEYTextBox = new System.Windows.Forms.TextBox();
            this.dEL_FLGTextBox = new System.Windows.Forms.TextBox();
            cOLOR_IDLabel = new System.Windows.Forms.Label();
            cOLOR_NAMELabel = new System.Windows.Forms.Label();
            cREATE_DATELabel = new System.Windows.Forms.Label();
            cREATE_IDLabel = new System.Windows.Forms.Label();
            uPDATE_DATELabel = new System.Windows.Forms.Label();
            uPDATE_IDLabel = new System.Windows.Forms.Label();
            eXCLUSIVE_KEYLabel = new System.Windows.Forms.Label();
            dEL_FLGLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_colorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_colorBindingNavigator)).BeginInit();
            this.product_colorBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // cOLOR_IDLabel
            // 
            cOLOR_IDLabel.AutoSize = true;
            cOLOR_IDLabel.Location = new System.Drawing.Point(110, 47);
            cOLOR_IDLabel.Name = "cOLOR_IDLabel";
            cOLOR_IDLabel.Size = new System.Drawing.Size(48, 13);
            cOLOR_IDLabel.TabIndex = 1;
            cOLOR_IDLabel.Text = "Mã màu:";
            // 
            // cOLOR_NAMELabel
            // 
            cOLOR_NAMELabel.AutoSize = true;
            cOLOR_NAMELabel.Location = new System.Drawing.Point(110, 73);
            cOLOR_NAMELabel.Name = "cOLOR_NAMELabel";
            cOLOR_NAMELabel.Size = new System.Drawing.Size(52, 13);
            cOLOR_NAMELabel.TabIndex = 3;
            cOLOR_NAMELabel.Text = "Tên màu:";
            // 
            // cREATE_DATELabel
            // 
            cREATE_DATELabel.AutoSize = true;
            cREATE_DATELabel.Location = new System.Drawing.Point(110, 100);
            cREATE_DATELabel.Name = "cREATE_DATELabel";
            cREATE_DATELabel.Size = new System.Drawing.Size(53, 13);
            cREATE_DATELabel.TabIndex = 5;
            cREATE_DATELabel.Text = "Ngày tạo:";
            // 
            // cREATE_IDLabel
            // 
            cREATE_IDLabel.AutoSize = true;
            cREATE_IDLabel.Location = new System.Drawing.Point(110, 125);
            cREATE_IDLabel.Name = "cREATE_IDLabel";
            cREATE_IDLabel.Size = new System.Drawing.Size(56, 13);
            cREATE_IDLabel.TabIndex = 7;
            cREATE_IDLabel.Text = "Người tạo:";
            // 
            // uPDATE_DATELabel
            // 
            uPDATE_DATELabel.AutoSize = true;
            uPDATE_DATELabel.Location = new System.Drawing.Point(110, 152);
            uPDATE_DATELabel.Name = "uPDATE_DATELabel";
            uPDATE_DATELabel.Size = new System.Drawing.Size(55, 13);
            uPDATE_DATELabel.TabIndex = 9;
            uPDATE_DATELabel.Text = "Ngày sửa:";
            // 
            // uPDATE_IDLabel
            // 
            uPDATE_IDLabel.AutoSize = true;
            uPDATE_IDLabel.Location = new System.Drawing.Point(110, 177);
            uPDATE_IDLabel.Name = "uPDATE_IDLabel";
            uPDATE_IDLabel.Size = new System.Drawing.Size(58, 13);
            uPDATE_IDLabel.TabIndex = 11;
            uPDATE_IDLabel.Text = "Người sửa:";
            // 
            // eXCLUSIVE_KEYLabel
            // 
            eXCLUSIVE_KEYLabel.AutoSize = true;
            eXCLUSIVE_KEYLabel.Location = new System.Drawing.Point(110, 203);
            eXCLUSIVE_KEYLabel.Name = "eXCLUSIVE_KEYLabel";
            eXCLUSIVE_KEYLabel.Size = new System.Drawing.Size(93, 13);
            eXCLUSIVE_KEYLabel.TabIndex = 13;
            eXCLUSIVE_KEYLabel.Text = "EXCLUSIVE KEY:";
            eXCLUSIVE_KEYLabel.Visible = false;
            // 
            // dEL_FLGLabel
            // 
            dEL_FLGLabel.AutoSize = true;
            dEL_FLGLabel.Location = new System.Drawing.Point(110, 229);
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
            // product_colorBindingSource
            // 
            this.product_colorBindingSource.DataMember = "product_color";
            this.product_colorBindingSource.DataSource = this.masterDB;
            // 
            // product_colorTableAdapter
            // 
            this.product_colorTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.product_colorTableAdapter = this.product_colorTableAdapter;
            this.tableAdapterManager.product_sizeTableAdapter = null;
            this.tableAdapterManager.product_typeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppFrameClient.MasterDBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // product_colorBindingNavigator
            // 
            this.product_colorBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.product_colorBindingNavigator.BindingSource = this.product_colorBindingSource;
            this.product_colorBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.product_colorBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.product_colorBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.product_colorBindingNavigatorSaveItem});
            this.product_colorBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.product_colorBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.product_colorBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.product_colorBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.product_colorBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.product_colorBindingNavigator.Name = "product_colorBindingNavigator";
            this.product_colorBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.product_colorBindingNavigator.Size = new System.Drawing.Size(449, 25);
            this.product_colorBindingNavigator.TabIndex = 0;
            this.product_colorBindingNavigator.Text = "bindingNavigator1";
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
            // product_colorBindingNavigatorSaveItem
            // 
            this.product_colorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.product_colorBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("product_colorBindingNavigatorSaveItem.Image")));
            this.product_colorBindingNavigatorSaveItem.Name = "product_colorBindingNavigatorSaveItem";
            this.product_colorBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.product_colorBindingNavigatorSaveItem.Text = "Save Data";
            this.product_colorBindingNavigatorSaveItem.Click += new System.EventHandler(this.product_colorBindingNavigatorSaveItem_Click);
            // 
            // cOLOR_IDTextBox
            // 
            this.cOLOR_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_colorBindingSource, "COLOR_ID", true));
            this.cOLOR_IDTextBox.Location = new System.Drawing.Point(209, 44);
            this.cOLOR_IDTextBox.Name = "cOLOR_IDTextBox";
            this.cOLOR_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.cOLOR_IDTextBox.TabIndex = 2;
            // 
            // cOLOR_NAMETextBox
            // 
            this.cOLOR_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_colorBindingSource, "COLOR_NAME", true));
            this.cOLOR_NAMETextBox.Location = new System.Drawing.Point(209, 70);
            this.cOLOR_NAMETextBox.Name = "cOLOR_NAMETextBox";
            this.cOLOR_NAMETextBox.Size = new System.Drawing.Size(200, 20);
            this.cOLOR_NAMETextBox.TabIndex = 4;
            // 
            // cREATE_DATEDateTimePicker
            // 
            this.cREATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.product_colorBindingSource, "CREATE_DATE", true));
            this.cREATE_DATEDateTimePicker.Location = new System.Drawing.Point(209, 96);
            this.cREATE_DATEDateTimePicker.Name = "cREATE_DATEDateTimePicker";
            this.cREATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.cREATE_DATEDateTimePicker.TabIndex = 6;
            // 
            // cREATE_IDTextBox
            // 
            this.cREATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_colorBindingSource, "CREATE_ID", true));
            this.cREATE_IDTextBox.Location = new System.Drawing.Point(209, 122);
            this.cREATE_IDTextBox.Name = "cREATE_IDTextBox";
            this.cREATE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.cREATE_IDTextBox.TabIndex = 8;
            // 
            // uPDATE_DATEDateTimePicker
            // 
            this.uPDATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.product_colorBindingSource, "UPDATE_DATE", true));
            this.uPDATE_DATEDateTimePicker.Location = new System.Drawing.Point(209, 148);
            this.uPDATE_DATEDateTimePicker.Name = "uPDATE_DATEDateTimePicker";
            this.uPDATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.uPDATE_DATEDateTimePicker.TabIndex = 10;
            // 
            // uPDATE_IDTextBox
            // 
            this.uPDATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_colorBindingSource, "UPDATE_ID", true));
            this.uPDATE_IDTextBox.Location = new System.Drawing.Point(209, 174);
            this.uPDATE_IDTextBox.Name = "uPDATE_IDTextBox";
            this.uPDATE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.uPDATE_IDTextBox.TabIndex = 12;
            // 
            // eXCLUSIVE_KEYTextBox
            // 
            this.eXCLUSIVE_KEYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_colorBindingSource, "EXCLUSIVE_KEY", true));
            this.eXCLUSIVE_KEYTextBox.Location = new System.Drawing.Point(209, 200);
            this.eXCLUSIVE_KEYTextBox.Name = "eXCLUSIVE_KEYTextBox";
            this.eXCLUSIVE_KEYTextBox.Size = new System.Drawing.Size(200, 20);
            this.eXCLUSIVE_KEYTextBox.TabIndex = 14;
            this.eXCLUSIVE_KEYTextBox.Visible = false;
            // 
            // dEL_FLGTextBox
            // 
            this.dEL_FLGTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_colorBindingSource, "DEL_FLG", true));
            this.dEL_FLGTextBox.Location = new System.Drawing.Point(209, 226);
            this.dEL_FLGTextBox.Name = "dEL_FLGTextBox";
            this.dEL_FLGTextBox.Size = new System.Drawing.Size(200, 20);
            this.dEL_FLGTextBox.TabIndex = 16;
            this.dEL_FLGTextBox.Visible = false;
            // 
            // ProductColorMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 266);
            this.Controls.Add(cOLOR_IDLabel);
            this.Controls.Add(this.cOLOR_IDTextBox);
            this.Controls.Add(cOLOR_NAMELabel);
            this.Controls.Add(this.cOLOR_NAMETextBox);
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
            this.Controls.Add(this.product_colorBindingNavigator);
            this.Name = "ProductColorMasterForm";
            this.Text = "ProductColorMasterForm";
            this.Load += new System.EventHandler(this.ProductColorMasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_colorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_colorBindingNavigator)).EndInit();
            this.product_colorBindingNavigator.ResumeLayout(false);
            this.product_colorBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource product_colorBindingSource;
        private AppFrameClient.MasterDBTableAdapters.product_colorTableAdapter product_colorTableAdapter;
        private AppFrameClient.MasterDBTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator product_colorBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton product_colorBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox cOLOR_IDTextBox;
        private System.Windows.Forms.TextBox cOLOR_NAMETextBox;
        private System.Windows.Forms.DateTimePicker cREATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox cREATE_IDTextBox;
        private System.Windows.Forms.DateTimePicker uPDATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox uPDATE_IDTextBox;
        private System.Windows.Forms.TextBox eXCLUSIVE_KEYTextBox;
        private System.Windows.Forms.TextBox dEL_FLGTextBox;
    }
}