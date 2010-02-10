using System.Drawing;
using System.Windows.Forms;

namespace NHibernateMappingGenerator
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.connStrTextBox = new System.Windows.Forms.TextBox();
            this.dbConnStrLabel = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.tablesComboBox = new System.Windows.Forms.ComboBox();
            this.sequencesComboBox = new System.Windows.Forms.ComboBox();
            this.dbTableDetailsGridView = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSharpType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errorLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameSpaceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.assemblyNameTextBox = new System.Windows.Forms.TextBox();
            this.serverTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.generateAllBtn = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.basicSettingsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.genMappingCheck = new System.Windows.Forms.CheckBox();
            this.genClassCheck = new System.Windows.Forms.CheckBox();
            this.clearCheck = new System.Windows.Forms.CheckBox();
            this.editButton = new System.Windows.Forms.Button();
            this.tableReferenceGroup = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.refColumnGrid = new System.Windows.Forms.DataGridView();
            this.refColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refTableColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.refColumnDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.refName = new System.Windows.Forms.TextBox();
            this.refTypeCombo = new System.Windows.Forms.ComboBox();
            this.detailTableCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableRefList = new System.Windows.Forms.ListBox();
            this.removeReferenceButton = new System.Windows.Forms.Button();
            this.detailTablesList = new System.Windows.Forms.ListBox();
            this.addReferenceButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.loadSettingButton = new System.Windows.Forms.Button();
            this.saveSettingButton = new System.Windows.Forms.Button();
            this.assignedRadio = new System.Windows.Forms.RadioButton();
            this.sequenceRadio = new System.Windows.Forms.RadioButton();
            this.businessLayerTabPage = new System.Windows.Forms.TabPage();
            this.errorCodeGen = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDaoLookup = new System.Windows.Forms.TextBox();
            this.btnDaoDirSelect = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDaoLayerDir = new System.Windows.Forms.TextBox();
            this.btnGenDao = new System.Windows.Forms.Button();
            this.btnDaoLayerSelect = new System.Windows.Forms.Button();
            this.txtDaoAssembly = new System.Windows.Forms.TextBox();
            this.txtDaoNamespace = new System.Windows.Forms.TextBox();
            this.advanceSettingsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.autoPropertyRadioBtn = new System.Windows.Forms.RadioButton();
            this.propertyRadioBtn = new System.Windows.Forms.RadioButton();
            this.fieldRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fluentMappingOption = new System.Windows.Forms.RadioButton();
            this.hbmMappingOption = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vbRadioButton = new System.Windows.Forms.RadioButton();
            this.cSharpRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.prefixRadioButton = new System.Windows.Forms.RadioButton();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.camelCasedRadioButton = new System.Windows.Forms.RadioButton();
            this.sameAsDBRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbTableDetailsGridView)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.basicSettingsTabPage.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableReferenceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refColumnGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refColumnDetailBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.businessLayerTabPage.SuspendLayout();
            this.advanceSettingsTabPage.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connStrTextBox
            // 
            this.connStrTextBox.Location = new System.Drawing.Point(142, 21);
            this.connStrTextBox.Name = "connStrTextBox";
            this.connStrTextBox.Size = new System.Drawing.Size(490, 20);
            this.connStrTextBox.TabIndex = 0;
            this.connStrTextBox.Text = "Data Source=XE; user ID=Sample; Password=password;";
            // 
            // dbConnStrLabel
            // 
            this.dbConnStrLabel.AutoSize = true;
            this.dbConnStrLabel.Location = new System.Drawing.Point(8, 25);
            this.dbConnStrLabel.Name = "dbConnStrLabel";
            this.dbConnStrLabel.Size = new System.Drawing.Size(124, 15);
            this.dbConnStrLabel.TabIndex = 1;
            this.dbConnStrLabel.Text = "DB Connection String";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(901, 19);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(140, 23);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "&Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtnClicked);
            // 
            // tablesComboBox
            // 
            this.tablesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tablesComboBox.FormattingEnabled = true;
            this.tablesComboBox.Location = new System.Drawing.Point(11, 72);
            this.tablesComboBox.Name = "tablesComboBox";
            this.tablesComboBox.Size = new System.Drawing.Size(496, 21);
            this.tablesComboBox.TabIndex = 3;
            this.tablesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesComboBox_SelectedIndexChanged);
            // 
            // sequencesComboBox
            // 
            this.sequencesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sequencesComboBox.FormattingEnabled = true;
            this.sequencesComboBox.Location = new System.Drawing.Point(513, 72);
            this.sequencesComboBox.Name = "sequencesComboBox";
            this.sequencesComboBox.Size = new System.Drawing.Size(370, 21);
            this.sequencesComboBox.TabIndex = 4;
            this.sequencesComboBox.SelectedIndexChanged += new System.EventHandler(this.sequencesComboBox_SelectedIndexChanged);
            // 
            // dbTableDetailsGridView
            // 
            this.dbTableDetailsGridView.AllowUserToAddRows = false;
            this.dbTableDetailsGridView.AllowUserToDeleteRows = false;
            this.dbTableDetailsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbTableDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbTableDetailsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnDataType,
            this.cSharpType,
            this.isPrimaryKey});
            this.dbTableDetailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbTableDetailsGridView.Location = new System.Drawing.Point(3, 16);
            this.dbTableDetailsGridView.Name = "dbTableDetailsGridView";
            this.dbTableDetailsGridView.RowHeadersVisible = false;
            this.dbTableDetailsGridView.Size = new System.Drawing.Size(1038, 298);
            this.dbTableDetailsGridView.TabIndex = 5;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Column Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnDataType
            // 
            this.columnDataType.HeaderText = "Data Type";
            this.columnDataType.Name = "columnDataType";
            this.columnDataType.ReadOnly = true;
            // 
            // cSharpType
            // 
            this.cSharpType.HeaderText = "C# Type";
            this.cSharpType.Name = "cSharpType";
            this.cSharpType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSharpType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isPrimaryKey
            // 
            this.isPrimaryKey.HeaderText = "Primary Key";
            this.isPrimaryKey.Name = "isPrimaryKey";
            this.isPrimaryKey.ReadOnly = true;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.errorLabel.ForeColor = System.Drawing.Color.Crimson;
            this.errorLabel.Location = new System.Drawing.Point(13, 178);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 20);
            this.errorLabel.TabIndex = 6;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(14, 30);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(431, 20);
            this.folderTextBox.TabIndex = 7;
            this.folderTextBox.Text = "D:\\Temp\\";
            this.folderTextBox.TextChanged += new System.EventHandler(this.folderTextBox_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(14, 105);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(106, 23);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateClicked);
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Location = new System.Drawing.Point(451, 30);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(54, 23);
            this.folderSelectButton.TabIndex = 9;
            this.folderSelectButton.Text = "&Select";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select the folder in which the mapping and domain files would be generated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "NameSpace :";
            // 
            // nameSpaceTextBox
            // 
            this.nameSpaceTextBox.Location = new System.Drawing.Point(105, 53);
            this.nameSpaceTextBox.Name = "nameSpaceTextBox";
            this.nameSpaceTextBox.Size = new System.Drawing.Size(340, 20);
            this.nameSpaceTextBox.TabIndex = 12;
            this.nameSpaceTextBox.Text = "Sample.CustomerService.Domain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "AssemblyName :";
            // 
            // assemblyNameTextBox
            // 
            this.assemblyNameTextBox.Location = new System.Drawing.Point(105, 79);
            this.assemblyNameTextBox.Name = "assemblyNameTextBox";
            this.assemblyNameTextBox.Size = new System.Drawing.Size(340, 20);
            this.assemblyNameTextBox.TabIndex = 14;
            this.assemblyNameTextBox.Text = "Sample.CustomerService.Domain";
            // 
            // serverTypeComboBox
            // 
            this.serverTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverTypeComboBox.FormattingEnabled = true;
            this.serverTypeComboBox.Location = new System.Drawing.Point(639, 21);
            this.serverTypeComboBox.Name = "serverTypeComboBox";
            this.serverTypeComboBox.Size = new System.Drawing.Size(244, 21);
            this.serverTypeComboBox.TabIndex = 15;
            this.serverTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.serverTypeComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Select a table";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select the sequence for the selected table";
            // 
            // generateAllBtn
            // 
            this.generateAllBtn.Location = new System.Drawing.Point(339, 105);
            this.generateAllBtn.Name = "generateAllBtn";
            this.generateAllBtn.Size = new System.Drawing.Size(106, 23);
            this.generateAllBtn.TabIndex = 18;
            this.generateAllBtn.Text = "Generate &All";
            this.generateAllBtn.UseVisualStyleBackColor = true;
            this.generateAllBtn.Click += new System.EventHandler(this.GenerateAllClicked);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.basicSettingsTabPage);
            this.mainTabControl.Controls.Add(this.businessLayerTabPage);
            this.mainTabControl.Controls.Add(this.advanceSettingsTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1058, 657);
            this.mainTabControl.TabIndex = 19;
            // 
            // basicSettingsTabPage
            // 
            this.basicSettingsTabPage.Controls.Add(this.groupBox6);
            this.basicSettingsTabPage.Controls.Add(this.groupBox5);
            this.basicSettingsTabPage.Controls.Add(this.groupBox4);
            this.basicSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.basicSettingsTabPage.Name = "basicSettingsTabPage";
            this.basicSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.basicSettingsTabPage.Size = new System.Drawing.Size(1050, 631);
            this.basicSettingsTabPage.TabIndex = 1;
            this.basicSettingsTabPage.Text = "Model Mapping";
            this.basicSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dbTableDetailsGridView);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 106);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1044, 317);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.genMappingCheck);
            this.groupBox5.Controls.Add(this.genClassCheck);
            this.groupBox5.Controls.Add(this.clearCheck);
            this.groupBox5.Controls.Add(this.editButton);
            this.groupBox5.Controls.Add(this.tableReferenceGroup);
            this.groupBox5.Controls.Add(this.tableRefList);
            this.groupBox5.Controls.Add(this.removeReferenceButton);
            this.groupBox5.Controls.Add(this.detailTablesList);
            this.groupBox5.Controls.Add(this.addReferenceButton);
            this.groupBox5.Controls.Add(this.folderTextBox);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.generateAllBtn);
            this.groupBox5.Controls.Add(this.folderSelectButton);
            this.groupBox5.Controls.Add(this.assemblyNameTextBox);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.generateButton);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.nameSpaceTextBox);
            this.groupBox5.Controls.Add(this.errorLabel);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 423);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1044, 205);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            // 
            // genMappingCheck
            // 
            this.genMappingCheck.AutoSize = true;
            this.genMappingCheck.Checked = true;
            this.genMappingCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genMappingCheck.Location = new System.Drawing.Point(165, 157);
            this.genMappingCheck.Name = "genMappingCheck";
            this.genMappingCheck.Size = new System.Drawing.Size(129, 19);
            this.genMappingCheck.TabIndex = 36;
            this.genMappingCheck.Text = "Generate Mapping";
            this.genMappingCheck.UseVisualStyleBackColor = true;
            // 
            // genClassCheck
            // 
            this.genClassCheck.AutoSize = true;
            this.genClassCheck.Checked = true;
            this.genClassCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genClassCheck.Location = new System.Drawing.Point(165, 134);
            this.genClassCheck.Name = "genClassCheck";
            this.genClassCheck.Size = new System.Drawing.Size(110, 19);
            this.genClassCheck.TabIndex = 35;
            this.genClassCheck.Text = "Generate Class";
            this.genClassCheck.UseVisualStyleBackColor = true;
            // 
            // clearCheck
            // 
            this.clearCheck.AutoSize = true;
            this.clearCheck.Checked = true;
            this.clearCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearCheck.Location = new System.Drawing.Point(165, 109);
            this.clearCheck.Name = "clearCheck";
            this.clearCheck.Size = new System.Drawing.Size(148, 19);
            this.clearCheck.TabIndex = 34;
            this.clearCheck.Text = "Clear Before Generate";
            this.clearCheck.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(622, 142);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 33;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // tableReferenceGroup
            // 
            this.tableReferenceGroup.Controls.Add(this.lblDesc);
            this.tableReferenceGroup.Controls.Add(this.refColumnGrid);
            this.tableReferenceGroup.Controls.Add(this.label7);
            this.tableReferenceGroup.Controls.Add(this.refName);
            this.tableReferenceGroup.Controls.Add(this.refTypeCombo);
            this.tableReferenceGroup.Controls.Add(this.detailTableCombo);
            this.tableReferenceGroup.Controls.Add(this.label6);
            this.tableReferenceGroup.Enabled = false;
            this.tableReferenceGroup.Location = new System.Drawing.Point(703, 13);
            this.tableReferenceGroup.Name = "tableReferenceGroup";
            this.tableReferenceGroup.Size = new System.Drawing.Size(335, 189);
            this.tableReferenceGroup.TabIndex = 32;
            this.tableReferenceGroup.TabStop = false;
            this.tableReferenceGroup.Text = "Reference Settings";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(16, 69);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(35, 15);
            this.lblDesc.TabIndex = 30;
            this.lblDesc.Text = "Desc";
            // 
            // refColumnGrid
            // 
            this.refColumnGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.refColumnGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.refColumn,
            this.refTableColumn});
            this.refColumnGrid.Location = new System.Drawing.Point(54, 69);
            this.refColumnGrid.Name = "refColumnGrid";
            this.refColumnGrid.RowHeadersVisible = false;
            this.refColumnGrid.Size = new System.Drawing.Size(275, 116);
            this.refColumnGrid.TabIndex = 31;
            this.refColumnGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.refColumnGrid_CellEndEdit);
            // 
            // refColumn
            // 
            this.refColumn.DataSource = this.columnDetailBindingSource;
            this.refColumn.DisplayMember = "ColumnName";
            this.refColumn.HeaderText = "Column";
            this.refColumn.Name = "refColumn";
            this.refColumn.Width = 135;
            // 
            // columnDetailBindingSource
            // 
            this.columnDetailBindingSource.DataSource = typeof(NMG.Core.Domain.ColumnDetail);
            // 
            // refTableColumn
            // 
            this.refTableColumn.DataSource = this.refColumnDetailBindingSource;
            this.refTableColumn.DisplayMember = "ColumnName";
            this.refTableColumn.HeaderText = "Reference Column";
            this.refTableColumn.Name = "refTableColumn";
            this.refTableColumn.Width = 137;
            // 
            // refColumnDetailBindingSource
            // 
            this.refColumnDetailBindingSource.DataSource = typeof(NMG.Core.Domain.ColumnDetail);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Name";
            // 
            // refName
            // 
            this.refName.Location = new System.Drawing.Point(54, 14);
            this.refName.Name = "refName";
            this.refName.Size = new System.Drawing.Size(132, 20);
            this.refName.TabIndex = 26;
            // 
            // refTypeCombo
            // 
            this.refTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.refTypeCombo.FormattingEnabled = true;
            this.refTypeCombo.Location = new System.Drawing.Point(192, 13);
            this.refTypeCombo.Name = "refTypeCombo";
            this.refTypeCombo.Size = new System.Drawing.Size(137, 21);
            this.refTypeCombo.TabIndex = 28;
            // 
            // detailTableCombo
            // 
            this.detailTableCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.detailTableCombo.FormattingEnabled = true;
            this.detailTableCombo.Location = new System.Drawing.Point(54, 42);
            this.detailTableCombo.Name = "detailTableCombo";
            this.detailTableCombo.Size = new System.Drawing.Size(275, 21);
            this.detailTableCombo.TabIndex = 19;
            this.detailTableCombo.SelectedIndexChanged += new System.EventHandler(this.detailTableCombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Ref.Table";
            // 
            // tableRefList
            // 
            this.tableRefList.FormattingEnabled = true;
            this.tableRefList.Location = new System.Drawing.Point(538, 27);
            this.tableRefList.Name = "tableRefList";
            this.tableRefList.Size = new System.Drawing.Size(159, 108);
            this.tableRefList.TabIndex = 25;
            this.tableRefList.SelectedIndexChanged += new System.EventHandler(this.tableRefList_SelectedIndexChanged);
            // 
            // removeReferenceButton
            // 
            this.removeReferenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeReferenceButton.Location = new System.Drawing.Point(569, 141);
            this.removeReferenceButton.Name = "removeReferenceButton";
            this.removeReferenceButton.Size = new System.Drawing.Size(27, 23);
            this.removeReferenceButton.TabIndex = 23;
            this.removeReferenceButton.Text = "-";
            this.removeReferenceButton.UseVisualStyleBackColor = true;
            this.removeReferenceButton.Click += new System.EventHandler(this.removeDetailTable_Click);
            // 
            // detailTablesList
            // 
            this.detailTablesList.FormattingEnabled = true;
            this.detailTablesList.Location = new System.Drawing.Point(516, 181);
            this.detailTablesList.Name = "detailTablesList";
            this.detailTablesList.Size = new System.Drawing.Size(13, 17);
            this.detailTablesList.TabIndex = 22;
            this.detailTablesList.Visible = false;
            // 
            // addReferenceButton
            // 
            this.addReferenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addReferenceButton.Location = new System.Drawing.Point(538, 141);
            this.addReferenceButton.Name = "addReferenceButton";
            this.addReferenceButton.Size = new System.Drawing.Size(25, 23);
            this.addReferenceButton.TabIndex = 21;
            this.addReferenceButton.Text = "+";
            this.addReferenceButton.UseVisualStyleBackColor = true;
            this.addReferenceButton.Click += new System.EventHandler(this.addDetailTable_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.loadSettingButton);
            this.groupBox4.Controls.Add(this.saveSettingButton);
            this.groupBox4.Controls.Add(this.assignedRadio);
            this.groupBox4.Controls.Add(this.sequenceRadio);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dbConnStrLabel);
            this.groupBox4.Controls.Add(this.sequencesComboBox);
            this.groupBox4.Controls.Add(this.serverTypeComboBox);
            this.groupBox4.Controls.Add(this.connStrTextBox);
            this.groupBox4.Controls.Add(this.tablesComboBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.connectBtn);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1044, 103);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // loadSettingButton
            // 
            this.loadSettingButton.Location = new System.Drawing.Point(898, 79);
            this.loadSettingButton.Name = "loadSettingButton";
            this.loadSettingButton.Size = new System.Drawing.Size(140, 23);
            this.loadSettingButton.TabIndex = 21;
            this.loadSettingButton.Text = "Load Setting";
            this.loadSettingButton.UseVisualStyleBackColor = true;
            this.loadSettingButton.Click += new System.EventHandler(this.loadSettingButton_Click);
            // 
            // saveSettingButton
            // 
            this.saveSettingButton.Location = new System.Drawing.Point(898, 53);
            this.saveSettingButton.Name = "saveSettingButton";
            this.saveSettingButton.Size = new System.Drawing.Size(140, 23);
            this.saveSettingButton.TabIndex = 20;
            this.saveSettingButton.Text = "Save Setting";
            this.saveSettingButton.UseVisualStyleBackColor = true;
            this.saveSettingButton.Click += new System.EventHandler(this.saveSettingButton_Click);
            // 
            // assignedRadio
            // 
            this.assignedRadio.AutoSize = true;
            this.assignedRadio.Location = new System.Drawing.Point(806, 51);
            this.assignedRadio.Name = "assignedRadio";
            this.assignedRadio.Size = new System.Drawing.Size(75, 19);
            this.assignedRadio.TabIndex = 19;
            this.assignedRadio.TabStop = true;
            this.assignedRadio.Text = "Assigned";
            this.assignedRadio.UseVisualStyleBackColor = true;
            // 
            // sequenceRadio
            // 
            this.sequenceRadio.AutoSize = true;
            this.sequenceRadio.Location = new System.Drawing.Point(726, 51);
            this.sequenceRadio.Name = "sequenceRadio";
            this.sequenceRadio.Size = new System.Drawing.Size(81, 19);
            this.sequenceRadio.TabIndex = 18;
            this.sequenceRadio.TabStop = true;
            this.sequenceRadio.Text = "Sequence";
            this.sequenceRadio.UseVisualStyleBackColor = true;
            // 
            // businessLayerTabPage
            // 
            this.businessLayerTabPage.Controls.Add(this.errorCodeGen);
            this.businessLayerTabPage.Controls.Add(this.label11);
            this.businessLayerTabPage.Controls.Add(this.txtDaoLookup);
            this.businessLayerTabPage.Controls.Add(this.btnDaoDirSelect);
            this.businessLayerTabPage.Controls.Add(this.label10);
            this.businessLayerTabPage.Controls.Add(this.label9);
            this.businessLayerTabPage.Controls.Add(this.label8);
            this.businessLayerTabPage.Controls.Add(this.txtDaoLayerDir);
            this.businessLayerTabPage.Controls.Add(this.btnGenDao);
            this.businessLayerTabPage.Controls.Add(this.btnDaoLayerSelect);
            this.businessLayerTabPage.Controls.Add(this.txtDaoAssembly);
            this.businessLayerTabPage.Controls.Add(this.txtDaoNamespace);
            this.businessLayerTabPage.Location = new System.Drawing.Point(4, 22);
            this.businessLayerTabPage.Name = "businessLayerTabPage";
            this.businessLayerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.businessLayerTabPage.Size = new System.Drawing.Size(1050, 631);
            this.businessLayerTabPage.TabIndex = 3;
            this.businessLayerTabPage.Text = "Business Layer";
            this.businessLayerTabPage.UseVisualStyleBackColor = true;
            this.businessLayerTabPage.Click += new System.EventHandler(this.DaoLayerGen_Click);
            // 
            // errorCodeGen
            // 
            this.errorCodeGen.AutoSize = true;
            this.errorCodeGen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorCodeGen.ForeColor = System.Drawing.Color.OrangeRed;
            this.errorCodeGen.Location = new System.Drawing.Point(11, 620);
            this.errorCodeGen.Name = "errorCodeGen";
            this.errorCodeGen.Size = new System.Drawing.Size(121, 25);
            this.errorCodeGen.TabIndex = 31;
            this.errorCodeGen.Text = "Waiting ...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "Path for Dao Object Lookup";
            // 
            // txtDaoLookup
            // 
            this.txtDaoLookup.Location = new System.Drawing.Point(6, 159);
            this.txtDaoLookup.Name = "txtDaoLookup";
            this.txtDaoLookup.Size = new System.Drawing.Size(431, 20);
            this.txtDaoLookup.TabIndex = 28;
            this.txtDaoLookup.Text = "D:\\Temp\\";
            // 
            // btnDaoDirSelect
            // 
            this.btnDaoDirSelect.Location = new System.Drawing.Point(443, 157);
            this.btnDaoDirSelect.Name = "btnDaoDirSelect";
            this.btnDaoDirSelect.Size = new System.Drawing.Size(54, 23);
            this.btnDaoDirSelect.TabIndex = 29;
            this.btnDaoDirSelect.Text = "&Select";
            this.btnDaoDirSelect.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Assembly";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 26;
            this.label9.Text = "Namespace";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Path for Dao Generate";
            // 
            // txtDaoLayerDir
            // 
            this.txtDaoLayerDir.Location = new System.Drawing.Point(6, 199);
            this.txtDaoLayerDir.Name = "txtDaoLayerDir";
            this.txtDaoLayerDir.Size = new System.Drawing.Size(431, 20);
            this.txtDaoLayerDir.TabIndex = 19;
            this.txtDaoLayerDir.Text = "D:\\Temp\\";
            // 
            // btnGenDao
            // 
            this.btnGenDao.Location = new System.Drawing.Point(331, 274);
            this.btnGenDao.Name = "btnGenDao";
            this.btnGenDao.Size = new System.Drawing.Size(106, 23);
            this.btnGenDao.TabIndex = 24;
            this.btnGenDao.Text = "Generate Dao Layer";
            this.btnGenDao.UseVisualStyleBackColor = true;
            this.btnGenDao.Click += new System.EventHandler(this.btnGenDao_Click);
            // 
            // btnDaoLayerSelect
            // 
            this.btnDaoLayerSelect.Location = new System.Drawing.Point(443, 199);
            this.btnDaoLayerSelect.Name = "btnDaoLayerSelect";
            this.btnDaoLayerSelect.Size = new System.Drawing.Size(54, 23);
            this.btnDaoLayerSelect.TabIndex = 21;
            this.btnDaoLayerSelect.Text = "&Select";
            this.btnDaoLayerSelect.UseVisualStyleBackColor = true;
            // 
            // txtDaoAssembly
            // 
            this.txtDaoAssembly.Location = new System.Drawing.Point(97, 248);
            this.txtDaoAssembly.Name = "txtDaoAssembly";
            this.txtDaoAssembly.Size = new System.Drawing.Size(340, 20);
            this.txtDaoAssembly.TabIndex = 23;
            this.txtDaoAssembly.Text = "Sample.CustomerService.Domain";
            // 
            // txtDaoNamespace
            // 
            this.txtDaoNamespace.Location = new System.Drawing.Point(97, 222);
            this.txtDaoNamespace.Name = "txtDaoNamespace";
            this.txtDaoNamespace.Size = new System.Drawing.Size(340, 20);
            this.txtDaoNamespace.TabIndex = 22;
            this.txtDaoNamespace.Text = "Sample.CustomerService.Domain";
            // 
            // advanceSettingsTabPage
            // 
            this.advanceSettingsTabPage.Controls.Add(this.groupBox7);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox3);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox2);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox1);
            this.advanceSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.advanceSettingsTabPage.Name = "advanceSettingsTabPage";
            this.advanceSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.advanceSettingsTabPage.Size = new System.Drawing.Size(1050, 631);
            this.advanceSettingsTabPage.TabIndex = 2;
            this.advanceSettingsTabPage.Text = "Preferences";
            this.advanceSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.autoPropertyRadioBtn);
            this.groupBox7.Controls.Add(this.propertyRadioBtn);
            this.groupBox7.Controls.Add(this.fieldRadioBtn);
            this.groupBox7.Location = new System.Drawing.Point(6, 152);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 140);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Field Or Property";
            // 
            // autoPropertyRadioBtn
            // 
            this.autoPropertyRadioBtn.AutoSize = true;
            this.autoPropertyRadioBtn.Checked = true;
            this.autoPropertyRadioBtn.Location = new System.Drawing.Point(6, 65);
            this.autoPropertyRadioBtn.Name = "autoPropertyRadioBtn";
            this.autoPropertyRadioBtn.Size = new System.Drawing.Size(97, 19);
            this.autoPropertyRadioBtn.TabIndex = 6;
            this.autoPropertyRadioBtn.TabStop = true;
            this.autoPropertyRadioBtn.Text = "Auto Property";
            this.autoPropertyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // propertyRadioBtn
            // 
            this.propertyRadioBtn.AutoSize = true;
            this.propertyRadioBtn.Location = new System.Drawing.Point(6, 42);
            this.propertyRadioBtn.Name = "propertyRadioBtn";
            this.propertyRadioBtn.Size = new System.Drawing.Size(70, 19);
            this.propertyRadioBtn.TabIndex = 5;
            this.propertyRadioBtn.Text = "Property";
            this.propertyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fieldRadioBtn
            // 
            this.fieldRadioBtn.AutoSize = true;
            this.fieldRadioBtn.Location = new System.Drawing.Point(6, 19);
            this.fieldRadioBtn.Name = "fieldRadioBtn";
            this.fieldRadioBtn.Size = new System.Drawing.Size(52, 19);
            this.fieldRadioBtn.TabIndex = 4;
            this.fieldRadioBtn.Text = "Field";
            this.fieldRadioBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fluentMappingOption);
            this.groupBox3.Controls.Add(this.hbmMappingOption);
            this.groupBox3.Location = new System.Drawing.Point(439, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 140);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mapping Style";
            // 
            // fluentMappingOption
            // 
            this.fluentMappingOption.AutoSize = true;
            this.fluentMappingOption.Enabled = false;
            this.fluentMappingOption.Location = new System.Drawing.Point(6, 42);
            this.fluentMappingOption.Name = "fluentMappingOption";
            this.fluentMappingOption.Size = new System.Drawing.Size(111, 19);
            this.fluentMappingOption.TabIndex = 5;
            this.fluentMappingOption.Text = "Fluent Mapping";
            this.fluentMappingOption.UseVisualStyleBackColor = true;
            // 
            // hbmMappingOption
            // 
            this.hbmMappingOption.AutoSize = true;
            this.hbmMappingOption.Checked = true;
            this.hbmMappingOption.Location = new System.Drawing.Point(6, 19);
            this.hbmMappingOption.Name = "hbmMappingOption";
            this.hbmMappingOption.Size = new System.Drawing.Size(95, 19);
            this.hbmMappingOption.TabIndex = 4;
            this.hbmMappingOption.TabStop = true;
            this.hbmMappingOption.Text = ".hbm.xml file";
            this.hbmMappingOption.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vbRadioButton);
            this.groupBox2.Controls.Add(this.cSharpRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(223, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language";
            // 
            // vbRadioButton
            // 
            this.vbRadioButton.AutoSize = true;
            this.vbRadioButton.Location = new System.Drawing.Point(6, 42);
            this.vbRadioButton.Name = "vbRadioButton";
            this.vbRadioButton.Size = new System.Drawing.Size(40, 19);
            this.vbRadioButton.TabIndex = 5;
            this.vbRadioButton.Text = "VB";
            this.vbRadioButton.UseVisualStyleBackColor = true;
            // 
            // cSharpRadioButton
            // 
            this.cSharpRadioButton.AutoSize = true;
            this.cSharpRadioButton.Checked = true;
            this.cSharpRadioButton.Location = new System.Drawing.Point(6, 19);
            this.cSharpRadioButton.Name = "cSharpRadioButton";
            this.cSharpRadioButton.Size = new System.Drawing.Size(40, 19);
            this.cSharpRadioButton.TabIndex = 4;
            this.cSharpRadioButton.TabStop = true;
            this.cSharpRadioButton.Text = "C#";
            this.cSharpRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prefixTextBox);
            this.groupBox1.Controls.Add(this.prefixRadioButton);
            this.groupBox1.Controls.Add(this.prefixLabel);
            this.groupBox1.Controls.Add(this.camelCasedRadioButton);
            this.groupBox1.Controls.Add(this.sameAsDBRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generated Property Name";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(47, 93);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(105, 20);
            this.prefixTextBox.TabIndex = 3;
            this.prefixTextBox.Text = "m_";
            // 
            // prefixRadioButton
            // 
            this.prefixRadioButton.AutoSize = true;
            this.prefixRadioButton.Location = new System.Drawing.Point(6, 65);
            this.prefixRadioButton.Name = "prefixRadioButton";
            this.prefixRadioButton.Size = new System.Drawing.Size(70, 19);
            this.prefixRadioButton.TabIndex = 2;
            this.prefixRadioButton.Text = "Prefixed";
            this.prefixRadioButton.UseVisualStyleBackColor = true;
            this.prefixRadioButton.CheckedChanged += new System.EventHandler(this.prefixCheckChanged);
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Location = new System.Drawing.Point(6, 96);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(47, 15);
            this.prefixLabel.TabIndex = 2;
            this.prefixLabel.Text = "Prefix : ";
            // 
            // camelCasedRadioButton
            // 
            this.camelCasedRadioButton.AutoSize = true;
            this.camelCasedRadioButton.Checked = true;
            this.camelCasedRadioButton.Location = new System.Drawing.Point(6, 42);
            this.camelCasedRadioButton.Name = "camelCasedRadioButton";
            this.camelCasedRadioButton.Size = new System.Drawing.Size(94, 19);
            this.camelCasedRadioButton.TabIndex = 1;
            this.camelCasedRadioButton.TabStop = true;
            this.camelCasedRadioButton.Text = "Camelcased";
            this.camelCasedRadioButton.UseVisualStyleBackColor = true;
            // 
            // sameAsDBRadioButton
            // 
            this.sameAsDBRadioButton.AutoSize = true;
            this.sameAsDBRadioButton.Location = new System.Drawing.Point(6, 19);
            this.sameAsDBRadioButton.Name = "sameAsDBRadioButton";
            this.sameAsDBRadioButton.Size = new System.Drawing.Size(207, 19);
            this.sameAsDBRadioButton.TabIndex = 0;
            this.sameAsDBRadioButton.Text = "Same as database column name";
            this.sameAsDBRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Fluent Mapping";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = ".hbm.xml file";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 42);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(98, 17);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Fluent Mapping";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = ".hbm.xml file";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1058, 27);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectMenu,
            this.loadProjectMenu,
            this.saveProjectMenu,
            this.saveProjectAsMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(41, 23);
            this.fileMenu.Text = "File";
            // 
            // newProjectMenu
            // 
            this.newProjectMenu.Name = "newProjectMenu";
            this.newProjectMenu.Size = new System.Drawing.Size(184, 24);
            this.newProjectMenu.Text = "New Project";
            // 
            // loadProjectMenu
            // 
            this.loadProjectMenu.Name = "loadProjectMenu";
            this.loadProjectMenu.Size = new System.Drawing.Size(184, 24);
            this.loadProjectMenu.Text = "Load Project";
            this.loadProjectMenu.Click += new System.EventHandler(this.loadProjectMenu_Click);
            // 
            // saveProjectMenu
            // 
            this.saveProjectMenu.Name = "saveProjectMenu";
            this.saveProjectMenu.Size = new System.Drawing.Size(184, 24);
            this.saveProjectMenu.Text = "Save Project";
            // 
            // saveProjectAsMenu
            // 
            this.saveProjectAsMenu.Name = "saveProjectAsMenu";
            this.saveProjectAsMenu.Size = new System.Drawing.Size(184, 24);
            this.saveProjectAsMenu.Text = "Save Project As ...";
            this.saveProjectAsMenu.Click += new System.EventHandler(this.saveProjectAsMenu_Click);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(356, 1);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(297, 20);
            this.projectNameTextBox.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(268, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Project Name";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 684);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "App";
            this.Text = "NHibernate Mapping Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dbTableDetailsGridView)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.basicSettingsTabPage.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableReferenceGroup.ResumeLayout(false);
            this.tableReferenceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refColumnGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refColumnDetailBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.businessLayerTabPage.ResumeLayout(false);
            this.businessLayerTabPage.PerformLayout();
            this.advanceSettingsTabPage.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox connStrTextBox;
        private System.Windows.Forms.Label dbConnStrLabel;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ComboBox tablesComboBox;
        private System.Windows.Forms.ComboBox sequencesComboBox;
        private System.Windows.Forms.DataGridView dbTableDetailsGridView;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameSpaceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox assemblyNameTextBox;
        private System.Windows.Forms.ComboBox serverTypeComboBox;
        private Label label4;
        private Label label5;
        private Button generateAllBtn;
        private DataGridViewTextBoxColumn columnName;
        private DataGridViewTextBoxColumn columnDataType;
        private DataGridViewComboBoxColumn cSharpType;
        private DataGridViewCheckBoxColumn isPrimaryKey;
        private TabControl mainTabControl;
        private TabPage basicSettingsTabPage;
        private TabPage advanceSettingsTabPage;
        private GroupBox groupBox1;
        private RadioButton sameAsDBRadioButton;
        private RadioButton prefixRadioButton;
        private RadioButton camelCasedRadioButton;
        private TextBox prefixTextBox;
        private Label prefixLabel;
        private GroupBox groupBox2;
        private RadioButton vbRadioButton;
        private RadioButton cSharpRadioButton;
        private GroupBox groupBox3;
        private RadioButton fluentMappingOption;
        private RadioButton hbmMappingOption;
        private GroupBox groupBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private GroupBox groupBox7;
        private RadioButton propertyRadioBtn;
        private RadioButton fieldRadioBtn;
        private RadioButton autoPropertyRadioBtn;
        private RadioButton assignedRadio;
        private RadioButton sequenceRadio;
        private ComboBox detailTableCombo;
        private Label label6;
        private Button removeReferenceButton;
        private ListBox detailTablesList;
        private Button addReferenceButton;
        private Button loadSettingButton;
        private Button saveSettingButton;
        private ListBox tableRefList;
        private ComboBox refTypeCombo;
        private Label label7;
        private TextBox refName;
        private Label lblDesc;
        private DataGridView refColumnGrid;
        private DataGridViewComboBoxColumn refColumn;
        private BindingSource columnDetailBindingSource;
        private DataGridViewComboBoxColumn refTableColumn;
        private BindingSource refColumnDetailBindingSource;
        private GroupBox tableReferenceGroup;
        private Button editButton;
        private CheckBox clearCheck;
        private CheckBox genMappingCheck;
        private CheckBox genClassCheck;
        private TabPage businessLayerTabPage;
        private Label label11;
        private TextBox txtDaoLookup;
        private Button btnDaoDirSelect;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtDaoLayerDir;
        private Button btnGenDao;
        private Button btnDaoLayerSelect;
        private TextBox txtDaoAssembly;
        private TextBox txtDaoNamespace;
        private Label errorCodeGen;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newProjectMenu;
        private ToolStripMenuItem loadProjectMenu;
        private ToolStripMenuItem saveProjectMenu;
        private ToolStripMenuItem saveProjectAsMenu;
        private TextBox projectNameTextBox;
        private Label label12;
    }
}

