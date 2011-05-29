namespace AppFrameClient.View.Masters
{
    partial class CategoryForm
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
            System.Windows.Forms.Label cATEGORY_IDLabel;
            System.Windows.Forms.Label pARENT_CATEGORY_IDLabel;
            System.Windows.Forms.Label cATEGORY_NAMELabel;
            System.Windows.Forms.Label cREATE_DATELabel;
            System.Windows.Forms.Label cREATE_IDLabel;
            System.Windows.Forms.Label uPDATE_DATELabel;
            System.Windows.Forms.Label uPDATE_IDLabel;
            System.Windows.Forms.Label eXCLUSIVE_KEYLabel;
            System.Windows.Forms.Label dEL_FLGLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.masterDB = new AppFrameClient.MasterDB();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new AppFrameClient.MasterDBTableAdapters.categoryTableAdapter();
            this.tableAdapterManager = new AppFrameClient.MasterDBTableAdapters.TableAdapterManager();
            this.categoryBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.categoryBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cATEGORY_IDTextBox = new System.Windows.Forms.TextBox();
            this.pARENT_CATEGORY_IDTextBox = new System.Windows.Forms.TextBox();
            this.cATEGORY_NAMETextBox = new System.Windows.Forms.TextBox();
            this.cREATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cREATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.uPDATE_DATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uPDATE_IDTextBox = new System.Windows.Forms.TextBox();
            this.eXCLUSIVE_KEYTextBox = new System.Windows.Forms.TextBox();
            this.dEL_FLGTextBox = new System.Windows.Forms.TextBox();
            cATEGORY_IDLabel = new System.Windows.Forms.Label();
            pARENT_CATEGORY_IDLabel = new System.Windows.Forms.Label();
            cATEGORY_NAMELabel = new System.Windows.Forms.Label();
            cREATE_DATELabel = new System.Windows.Forms.Label();
            cREATE_IDLabel = new System.Windows.Forms.Label();
            uPDATE_DATELabel = new System.Windows.Forms.Label();
            uPDATE_IDLabel = new System.Windows.Forms.Label();
            eXCLUSIVE_KEYLabel = new System.Windows.Forms.Label();
            dEL_FLGLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingNavigator)).BeginInit();
            this.categoryBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // cATEGORY_IDLabel
            // 
            cATEGORY_IDLabel.AutoSize = true;
            cATEGORY_IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cATEGORY_IDLabel.Location = new System.Drawing.Point(40, 61);
            cATEGORY_IDLabel.Name = "cATEGORY_IDLabel";
            cATEGORY_IDLabel.Size = new System.Drawing.Size(88, 16);
            cATEGORY_IDLabel.TabIndex = 1;
            cATEGORY_IDLabel.Text = "Mã phân loại:";
            // 
            // pARENT_CATEGORY_IDLabel
            // 
            pARENT_CATEGORY_IDLabel.AutoSize = true;
            pARENT_CATEGORY_IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pARENT_CATEGORY_IDLabel.Location = new System.Drawing.Point(40, 87);
            pARENT_CATEGORY_IDLabel.Name = "pARENT_CATEGORY_IDLabel";
            pARENT_CATEGORY_IDLabel.Size = new System.Drawing.Size(92, 16);
            pARENT_CATEGORY_IDLabel.TabIndex = 3;
            pARENT_CATEGORY_IDLabel.Text = "Phân loại cha:";
            // 
            // cATEGORY_NAMELabel
            // 
            cATEGORY_NAMELabel.AutoSize = true;
            cATEGORY_NAMELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cATEGORY_NAMELabel.Location = new System.Drawing.Point(40, 113);
            cATEGORY_NAMELabel.Name = "cATEGORY_NAMELabel";
            cATEGORY_NAMELabel.Size = new System.Drawing.Size(93, 16);
            cATEGORY_NAMELabel.TabIndex = 5;
            cATEGORY_NAMELabel.Text = "Tên phân loại:";
            // 
            // cREATE_DATELabel
            // 
            cREATE_DATELabel.AutoSize = true;
            cREATE_DATELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cREATE_DATELabel.Location = new System.Drawing.Point(40, 140);
            cREATE_DATELabel.Name = "cREATE_DATELabel";
            cREATE_DATELabel.Size = new System.Drawing.Size(66, 16);
            cREATE_DATELabel.TabIndex = 7;
            cREATE_DATELabel.Text = "Ngày tạo:";
            // 
            // cREATE_IDLabel
            // 
            cREATE_IDLabel.AutoSize = true;
            cREATE_IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cREATE_IDLabel.Location = new System.Drawing.Point(40, 165);
            cREATE_IDLabel.Name = "cREATE_IDLabel";
            cREATE_IDLabel.Size = new System.Drawing.Size(69, 16);
            cREATE_IDLabel.TabIndex = 9;
            cREATE_IDLabel.Text = "Người tạo:";
            // 
            // uPDATE_DATELabel
            // 
            uPDATE_DATELabel.AutoSize = true;
            uPDATE_DATELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            uPDATE_DATELabel.Location = new System.Drawing.Point(40, 192);
            uPDATE_DATELabel.Name = "uPDATE_DATELabel";
            uPDATE_DATELabel.Size = new System.Drawing.Size(98, 16);
            uPDATE_DATELabel.TabIndex = 11;
            uPDATE_DATELabel.Text = "Ngày cập nhật:";
            // 
            // uPDATE_IDLabel
            // 
            uPDATE_IDLabel.AutoSize = true;
            uPDATE_IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            uPDATE_IDLabel.Location = new System.Drawing.Point(40, 217);
            uPDATE_IDLabel.Name = "uPDATE_IDLabel";
            uPDATE_IDLabel.Size = new System.Drawing.Size(101, 16);
            uPDATE_IDLabel.TabIndex = 13;
            uPDATE_IDLabel.Text = "Người cập nhật:";
            // 
            // eXCLUSIVE_KEYLabel
            // 
            eXCLUSIVE_KEYLabel.AutoSize = true;
            eXCLUSIVE_KEYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            eXCLUSIVE_KEYLabel.Location = new System.Drawing.Point(40, 243);
            eXCLUSIVE_KEYLabel.Name = "eXCLUSIVE_KEYLabel";
            eXCLUSIVE_KEYLabel.Size = new System.Drawing.Size(113, 16);
            eXCLUSIVE_KEYLabel.TabIndex = 15;
            eXCLUSIVE_KEYLabel.Text = "EXCLUSIVE KEY:";
            // 
            // dEL_FLGLabel
            // 
            dEL_FLGLabel.AutoSize = true;
            dEL_FLGLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dEL_FLGLabel.Location = new System.Drawing.Point(40, 269);
            dEL_FLGLabel.Name = "dEL_FLGLabel";
            dEL_FLGLabel.Size = new System.Drawing.Size(65, 16);
            dEL_FLGLabel.TabIndex = 17;
            dEL_FLGLabel.Text = "DEL FLG:";
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "category";
            this.categoryBindingSource.DataSource = this.masterDB;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.categoryTableAdapter = this.categoryTableAdapter;
            this.tableAdapterManager.confirm_stock_inTableAdapter = null;
            this.tableAdapterManager.product_colorTableAdapter = null;
            this.tableAdapterManager.product_master_idsTableAdapter = null;
            this.tableAdapterManager.product_masterTableAdapter = null;
            this.tableAdapterManager.product_sizeTableAdapter = null;
            this.tableAdapterManager.product_typeTableAdapter = null;
            this.tableAdapterManager.productTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppFrameClient.MasterDBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // categoryBindingNavigator
            // 
            this.categoryBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.categoryBindingNavigator.BindingSource = this.categoryBindingSource;
            this.categoryBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.categoryBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.categoryBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.categoryBindingNavigatorSaveItem});
            this.categoryBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.categoryBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.categoryBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.categoryBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.categoryBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.categoryBindingNavigator.Name = "categoryBindingNavigator";
            this.categoryBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.categoryBindingNavigator.Size = new System.Drawing.Size(450, 25);
            this.categoryBindingNavigator.TabIndex = 0;
            this.categoryBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(41, 22);
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
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
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
            // categoryBindingNavigatorSaveItem
            // 
            this.categoryBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.categoryBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("categoryBindingNavigatorSaveItem.Image")));
            this.categoryBindingNavigatorSaveItem.Name = "categoryBindingNavigatorSaveItem";
            this.categoryBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.categoryBindingNavigatorSaveItem.Text = "Save Data";
            this.categoryBindingNavigatorSaveItem.Click += new System.EventHandler(this.categoryBindingNavigatorSaveItem_Click);
            // 
            // cATEGORY_IDTextBox
            // 
            this.cATEGORY_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "CATEGORY_ID", true));
            this.cATEGORY_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cATEGORY_IDTextBox.Location = new System.Drawing.Point(186, 58);
            this.cATEGORY_IDTextBox.Name = "cATEGORY_IDTextBox";
            this.cATEGORY_IDTextBox.ReadOnly = true;
            this.cATEGORY_IDTextBox.Size = new System.Drawing.Size(200, 22);
            this.cATEGORY_IDTextBox.TabIndex = 2;
            // 
            // pARENT_CATEGORY_IDTextBox
            // 
            this.pARENT_CATEGORY_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "PARENT_CATEGORY_ID", true));
            this.pARENT_CATEGORY_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pARENT_CATEGORY_IDTextBox.Location = new System.Drawing.Point(186, 84);
            this.pARENT_CATEGORY_IDTextBox.Name = "pARENT_CATEGORY_IDTextBox";
            this.pARENT_CATEGORY_IDTextBox.ReadOnly = true;
            this.pARENT_CATEGORY_IDTextBox.Size = new System.Drawing.Size(200, 22);
            this.pARENT_CATEGORY_IDTextBox.TabIndex = 4;
            // 
            // cATEGORY_NAMETextBox
            // 
            this.cATEGORY_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "CATEGORY_NAME", true));
            this.cATEGORY_NAMETextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cATEGORY_NAMETextBox.Location = new System.Drawing.Point(186, 110);
            this.cATEGORY_NAMETextBox.Name = "cATEGORY_NAMETextBox";
            this.cATEGORY_NAMETextBox.Size = new System.Drawing.Size(200, 22);
            this.cATEGORY_NAMETextBox.TabIndex = 6;
            // 
            // cREATE_DATEDateTimePicker
            // 
            this.cREATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.categoryBindingSource, "CREATE_DATE", true));
            this.cREATE_DATEDateTimePicker.Enabled = false;
            this.cREATE_DATEDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cREATE_DATEDateTimePicker.Location = new System.Drawing.Point(186, 136);
            this.cREATE_DATEDateTimePicker.Name = "cREATE_DATEDateTimePicker";
            this.cREATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.cREATE_DATEDateTimePicker.TabIndex = 8;
            // 
            // cREATE_IDTextBox
            // 
            this.cREATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "CREATE_ID", true));
            this.cREATE_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cREATE_IDTextBox.Location = new System.Drawing.Point(186, 162);
            this.cREATE_IDTextBox.Name = "cREATE_IDTextBox";
            this.cREATE_IDTextBox.ReadOnly = true;
            this.cREATE_IDTextBox.Size = new System.Drawing.Size(200, 22);
            this.cREATE_IDTextBox.TabIndex = 10;
            // 
            // uPDATE_DATEDateTimePicker
            // 
            this.uPDATE_DATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.categoryBindingSource, "UPDATE_DATE", true));
            this.uPDATE_DATEDateTimePicker.Enabled = false;
            this.uPDATE_DATEDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPDATE_DATEDateTimePicker.Location = new System.Drawing.Point(186, 188);
            this.uPDATE_DATEDateTimePicker.Name = "uPDATE_DATEDateTimePicker";
            this.uPDATE_DATEDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.uPDATE_DATEDateTimePicker.TabIndex = 12;
            // 
            // uPDATE_IDTextBox
            // 
            this.uPDATE_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "UPDATE_ID", true));
            this.uPDATE_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uPDATE_IDTextBox.Location = new System.Drawing.Point(186, 214);
            this.uPDATE_IDTextBox.Name = "uPDATE_IDTextBox";
            this.uPDATE_IDTextBox.ReadOnly = true;
            this.uPDATE_IDTextBox.Size = new System.Drawing.Size(200, 22);
            this.uPDATE_IDTextBox.TabIndex = 14;
            // 
            // eXCLUSIVE_KEYTextBox
            // 
            this.eXCLUSIVE_KEYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "EXCLUSIVE_KEY", true));
            this.eXCLUSIVE_KEYTextBox.Enabled = false;
            this.eXCLUSIVE_KEYTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eXCLUSIVE_KEYTextBox.Location = new System.Drawing.Point(186, 240);
            this.eXCLUSIVE_KEYTextBox.Name = "eXCLUSIVE_KEYTextBox";
            this.eXCLUSIVE_KEYTextBox.ReadOnly = true;
            this.eXCLUSIVE_KEYTextBox.Size = new System.Drawing.Size(200, 22);
            this.eXCLUSIVE_KEYTextBox.TabIndex = 16;
            // 
            // dEL_FLGTextBox
            // 
            this.dEL_FLGTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "DEL_FLG", true));
            this.dEL_FLGTextBox.Enabled = false;
            this.dEL_FLGTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dEL_FLGTextBox.Location = new System.Drawing.Point(186, 266);
            this.dEL_FLGTextBox.Name = "dEL_FLGTextBox";
            this.dEL_FLGTextBox.ReadOnly = true;
            this.dEL_FLGTextBox.Size = new System.Drawing.Size(200, 22);
            this.dEL_FLGTextBox.TabIndex = 18;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 344);
            this.Controls.Add(cATEGORY_IDLabel);
            this.Controls.Add(this.cATEGORY_IDTextBox);
            this.Controls.Add(pARENT_CATEGORY_IDLabel);
            this.Controls.Add(this.pARENT_CATEGORY_IDTextBox);
            this.Controls.Add(cATEGORY_NAMELabel);
            this.Controls.Add(this.cATEGORY_NAMETextBox);
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
            this.Controls.Add(this.categoryBindingNavigator);
            this.Name = "CategoryForm";
            this.Text = "Phân loại chủng loại hàng";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingNavigator)).EndInit();
            this.categoryBindingNavigator.ResumeLayout(false);
            this.categoryBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private AppFrameClient.MasterDBTableAdapters.categoryTableAdapter categoryTableAdapter;
        private AppFrameClient.MasterDBTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator categoryBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton categoryBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox cATEGORY_IDTextBox;
        private System.Windows.Forms.TextBox pARENT_CATEGORY_IDTextBox;
        private System.Windows.Forms.TextBox cATEGORY_NAMETextBox;
        private System.Windows.Forms.DateTimePicker cREATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox cREATE_IDTextBox;
        private System.Windows.Forms.DateTimePicker uPDATE_DATEDateTimePicker;
        private System.Windows.Forms.TextBox uPDATE_IDTextBox;
        private System.Windows.Forms.TextBox eXCLUSIVE_KEYTextBox;
        private System.Windows.Forms.TextBox dEL_FLGTextBox;
    }
}