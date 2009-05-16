namespace AppFrameClient.View.Masters
{
    partial class ProductTypeMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductTypeMasterForm));
            System.Windows.Forms.Label tYPE_IDLabel;
            System.Windows.Forms.Label tYPE_NAMELabel;
            System.Windows.Forms.Label cREATE_DATELabel;
            System.Windows.Forms.Label cREATE_IDLabel;
            System.Windows.Forms.Label uPDATE_DATELabel;
            System.Windows.Forms.Label uPDATE_IDLabel;
            System.Windows.Forms.Label eXCLUSIVE_KEYLabel;
            System.Windows.Forms.Label dEL_FLGLabel;
            this.masterDB = new AppFrameClient.MasterDB();
            this.product_typeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_typeTableAdapter = new AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter();
            this.tableAdapterManager = new AppFrameClient.MasterDBTableAdapters.TableAdapterManager();
            this.product_typeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.product_typeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tYPE_IDTextBox = new System.Windows.Forms.TextBox();
            this.tYPE_NAMETextBox = new System.Windows.Forms.TextBox();
            this.cREATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cREATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.uPDATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uPDATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.eXCLUSIVE_KEYTextBox = new System.Windows.Forms.TextBox();
            this.dEL_FLGTextBox = new System.Windows.Forms.TextBox();
            tYPE_IDLabel = new System.Windows.Forms.Label();
            tYPE_NAMELabel = new System.Windows.Forms.Label();
            cREATE_DATELabel = new System.Windows.Forms.Label();
            cREATE_IDLabel = new System.Windows.Forms.Label();
            uPDATE_DATELabel = new System.Windows.Forms.Label();
            uPDATE_IDLabel = new System.Windows.Forms.Label();
            eXCLUSIVE_KEYLabel = new System.Windows.Forms.Label();
            dEL_FLGLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_typeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_typeBindingNavigator)).BeginInit();
            this.product_typeBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // product_typeBindingSource
            // 
            this.product_typeBindingSource.DataMember = "product_type";
            this.product_typeBindingSource.DataSource = this.masterDB;
            // 
            // product_typeTableAdapter
            // 
            this.product_typeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.product_colorTableAdapter = null;
            this.tableAdapterManager.product_sizeTableAdapter = null;
            this.tableAdapterManager.product_typeTableAdapter = this.product_typeTableAdapter;
            this.tableAdapterManager.UpdateOrder = AppFrameClient.MasterDBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // product_typeBindingNavigator
            // 
            this.product_typeBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.product_typeBindingNavigator.BindingSource = this.product_typeBindingSource;
            this.product_typeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.product_typeBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.product_typeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.product_typeBindingNavigatorSaveItem});
            this.product_typeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.product_typeBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.product_typeBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.product_typeBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.product_typeBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.product_typeBindingNavigator.Name = "product_typeBindingNavigator";
            this.product_typeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.product_typeBindingNavigator.Size = new System.Drawing.Size(338, 25);
            this.product_typeBindingNavigator.TabIndex = 0;
            this.product_typeBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 13);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // product_typeBindingNavigatorSaveItem
            // 
            this.product_typeBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.product_typeBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("product_typeBindingNavigatorSaveItem.Image")));
            this.product_typeBindingNavigatorSaveItem.Name = "product_typeBindingNavigatorSaveItem";
            this.product_typeBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.product_typeBindingNavigatorSaveItem.Text = "Save Data";
            this.product_typeBindingNavigatorSaveItem.Click += new System.EventHandler(this.product_typeBindingNavigatorSaveItem_Click);
            // 
            // tYPE_IDLabel
            // 
            tYPE_IDLabel.AutoSize = true;
            tYPE_IDLabel.Location = new System.Drawing.Point(11, 41);
            tYPE_IDLabel.Name = "tYPE_IDLabel";
            tYPE_IDLabel.Size = new System.Drawing.Size(52, 13);
            tYPE_IDLabel.TabIndex = 1;
            tYPE_IDLabel.Text = "TYPE ID:";
            // 
            // tYPE_IDTextBox
            // 
            this.tYPE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_typeBindingSource, "TYPE_ID", true));
            this.tYPE_IDTextBox.Location = new System.Drawing.Point(110, 38);
            this.tYPE_IDTextBox.Name = "tYPE_IDTextBox";
            this.tYPE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.tYPE_IDTextBox.TabIndex = 2;
            // 
            // tYPE_NAMELabel
            // 
            tYPE_NAMELabel.AutoSize = true;
            tYPE_NAMELabel.Location = new System.Drawing.Point(11, 67);
            tYPE_NAMELabel.Name = "tYPE_NAMELabel";
            tYPE_NAMELabel.Size = new System.Drawing.Size(72, 13);
            tYPE_NAMELabel.TabIndex = 3;
            tYPE_NAMELabel.Text = "TYPE NAME:";
            // 
            // tYPE_NAMETextBox
            // 
            this.tYPE_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_typeBindingSource, "TYPE_NAME", true));
            this.tYPE_NAMETextBox.Location = new System.Drawing.Point(110, 64);
            this.tYPE_NAMETextBox.Name = "tYPE_NAMETextBox";
            this.tYPE_NAMETextBox.Size = new System.Drawing.Size(200, 20);
            this.tYPE_NAMETextBox.TabIndex = 4;
            // 
            // cREATE_DATELabel
            // 
            cREATE_DATELabel.AutoSize = true;
            cREATE_DATELabel.Location = new System.Drawing.Point(11, 94);
            cREATE_DATELabel.Name = "cREATE_DATELabel";
            cREATE_DATELabel.Size = new System.Drawing.Size(85, 13);
            cREATE_DATELabel.TabIndex = 5;
            cREATE_DATELabel.Text = "CREATE DATE:";
            // 
            // cREATE_DATEDateTimePicker
            // 
            this.cREATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.product_typeBindingSource, "CREATE_DATE", true));
            this.cREATE_DATEDateTimePicker.Location = new System.Drawing.Point(110, 90);
            this.cREATE_DATEDateTimePicker.Name = "cREATE_DATEDateTimePicker";
            this.cREATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.cREATE_DATEDateTimePicker.TabIndex = 6;
            // 
            // cREATE_IDLabel
            // 
            cREATE_IDLabel.AutoSize = true;
            cREATE_IDLabel.Location = new System.Drawing.Point(11, 119);
            cREATE_IDLabel.Name = "cREATE_IDLabel";
            cREATE_IDLabel.Size = new System.Drawing.Size(67, 13);
            cREATE_IDLabel.TabIndex = 7;
            cREATE_IDLabel.Text = "CREATE ID:";
            // 
            // cREATE_IDTextBox
            // 
            this.cREATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_typeBindingSource, "CREATE_ID", true));
            this.cREATE_IDTextBox.Location = new System.Drawing.Point(110, 116);
            this.cREATE_IDTextBox.Name = "cREATE_IDTextBox";
            this.cREATE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.cREATE_IDTextBox.TabIndex = 8;
            // 
            // uPDATE_DATELabel
            // 
            uPDATE_DATELabel.AutoSize = true;
            uPDATE_DATELabel.Location = new System.Drawing.Point(11, 146);
            uPDATE_DATELabel.Name = "uPDATE_DATELabel";
            uPDATE_DATELabel.Size = new System.Drawing.Size(86, 13);
            uPDATE_DATELabel.TabIndex = 9;
            uPDATE_DATELabel.Text = "UPDATE DATE:";
            // 
            // uPDATE_DATEDateTimePicker
            // 
            this.uPDATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.product_typeBindingSource, "UPDATE_DATE", true));
            this.uPDATE_DATEDateTimePicker.Location = new System.Drawing.Point(110, 142);
            this.uPDATE_DATEDateTimePicker.Name = "uPDATE_DATEDateTimePicker";
            this.uPDATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.uPDATE_DATEDateTimePicker.TabIndex = 10;
            // 
            // uPDATE_IDLabel
            // 
            uPDATE_IDLabel.AutoSize = true;
            uPDATE_IDLabel.Location = new System.Drawing.Point(11, 171);
            uPDATE_IDLabel.Name = "uPDATE_IDLabel";
            uPDATE_IDLabel.Size = new System.Drawing.Size(68, 13);
            uPDATE_IDLabel.TabIndex = 11;
            uPDATE_IDLabel.Text = "UPDATE ID:";
            // 
            // uPDATE_IDTextBox
            // 
            this.uPDATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_typeBindingSource, "UPDATE_ID", true));
            this.uPDATE_IDTextBox.Location = new System.Drawing.Point(110, 168);
            this.uPDATE_IDTextBox.Name = "uPDATE_IDTextBox";
            this.uPDATE_IDTextBox.Size = new System.Drawing.Size(200, 20);
            this.uPDATE_IDTextBox.TabIndex = 12;
            // 
            // eXCLUSIVE_KEYLabel
            // 
            eXCLUSIVE_KEYLabel.AutoSize = true;
            eXCLUSIVE_KEYLabel.Location = new System.Drawing.Point(11, 197);
            eXCLUSIVE_KEYLabel.Name = "eXCLUSIVE_KEYLabel";
            eXCLUSIVE_KEYLabel.Size = new System.Drawing.Size(93, 13);
            eXCLUSIVE_KEYLabel.TabIndex = 13;
            eXCLUSIVE_KEYLabel.Text = "EXCLUSIVE KEY:";
            // 
            // eXCLUSIVE_KEYTextBox
            // 
            this.eXCLUSIVE_KEYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_typeBindingSource, "EXCLUSIVE_KEY", true));
            this.eXCLUSIVE_KEYTextBox.Location = new System.Drawing.Point(110, 194);
            this.eXCLUSIVE_KEYTextBox.Name = "eXCLUSIVE_KEYTextBox";
            this.eXCLUSIVE_KEYTextBox.Size = new System.Drawing.Size(200, 20);
            this.eXCLUSIVE_KEYTextBox.TabIndex = 14;
            // 
            // dEL_FLGLabel
            // 
            dEL_FLGLabel.AutoSize = true;
            dEL_FLGLabel.Location = new System.Drawing.Point(11, 223);
            dEL_FLGLabel.Name = "dEL_FLGLabel";
            dEL_FLGLabel.Size = new System.Drawing.Size(54, 13);
            dEL_FLGLabel.TabIndex = 15;
            dEL_FLGLabel.Text = "DEL FLG:";
            // 
            // dEL_FLGTextBox
            // 
            this.dEL_FLGTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.product_typeBindingSource, "DEL_FLG", true));
            this.dEL_FLGTextBox.Location = new System.Drawing.Point(110, 220);
            this.dEL_FLGTextBox.Name = "dEL_FLGTextBox";
            this.dEL_FLGTextBox.Size = new System.Drawing.Size(200, 20);
            this.dEL_FLGTextBox.TabIndex = 16;
            // 
            // ProductTypeMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 269);
            this.Controls.Add(tYPE_IDLabel);
            this.Controls.Add(this.tYPE_IDTextBox);
            this.Controls.Add(tYPE_NAMELabel);
            this.Controls.Add(this.tYPE_NAMETextBox);
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
            this.Controls.Add(this.product_typeBindingNavigator);
            this.Name = "ProductTypeMasterForm";
            this.Text = "ProductTypeMasterForm";
            this.Load += new System.EventHandler(this.ProductTypeMasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_typeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_typeBindingNavigator)).EndInit();
            this.product_typeBindingNavigator.ResumeLayout(false);
            this.product_typeBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource product_typeBindingSource;
        private AppFrameClient.MasterDBTableAdapters.product_typeTableAdapter product_typeTableAdapter;
        private AppFrameClient.MasterDBTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator product_typeBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton product_typeBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox tYPE_IDTextBox;
        private System.Windows.Forms.TextBox tYPE_NAMETextBox;
        private System.Windows.Forms.DateTimePicker cREATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox cREATE_IDTextBox;
        private System.Windows.Forms.DateTimePicker uPDATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox uPDATE_IDTextBox;
        private System.Windows.Forms.TextBox eXCLUSIVE_KEYTextBox;
        private System.Windows.Forms.TextBox dEL_FLGTextBox;
    }
}