using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using NMG.Core;
using NMG.Core.Domain;
using NMG.Core.Generator;
using NMG.Core.Util;

namespace NHibernateMappingGenerator
{
    public partial class App : Form
    {
        
        private List<ApplicationPreferences> _tablePreferences = new List<ApplicationPreferences>();
        private ApplicationPreferences CurrentTablePreference { get; set;}
        private ApplicationSettings _applicationSettings;
        private string _currentProjectPath;
        private bool _isDirty = false;
        public App()
        {
            InitializeComponent();
            tablesComboBox.SelectedIndexChanged += TablesSelectedIndexChanged;
            serverTypeComboBox.SelectedIndexChanged += ServerTypeSelected;
            dbTableDetailsGridView.DataError += DataError;
            BindData();
            tablesComboBox.Enabled = false;
            sequencesComboBox.Enabled = false;
            Closing += App_Closing;

            #region Unused code
            //ApplicationSettings applicationSettings = null;

            //try 
            //{	        
            //    applicationSettings = ApplicationSettings.Load();
            //    _applicationSettings = applicationSettings;
            //}
            //catch (Exception)
            //{

            //}
            //if (applicationSettings != null)
            //{
            //    connStrTextBox.Text = applicationSettings.ConnectionString;
            //    serverTypeComboBox.SelectedItem = applicationSettings.ServerType;
            //    nameSpaceTextBox.Text = applicationSettings.NameSpace;
            //    assemblyNameTextBox.Text = applicationSettings.AssemblyName;
            //} 
            #endregion

            sameAsDBRadioButton.Checked = true;
            prefixLabel.Visible = prefixTextBox.Visible = false;
            cSharpRadioButton.Checked = true;
            hbmMappingOption.Checked = true;
         
            // add event check dirty state for text box
            AddDirtyHandler(this.Controls);
            this.mainTabControl.Enabled = false;
        }

        private void AddDirtyHandler(Control.ControlCollection collection)
        {
            foreach (Control control in collection)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    TextBox textBox = (TextBox)control;
                    textBox.TextChanged += new EventHandler(DirtyChecking);
                }

                if (control.GetType().Equals(typeof(RadioButton)))
                {
                    RadioButton radioButton = (RadioButton)control;
                    radioButton.CheckedChanged += new EventHandler(DirtyChecking);
                }
                if(control.Controls.Count > 0)
                {
                    AddDirtyHandler(control.Controls);
                }
            }
        }

        private void DirtyChecking(object sender, EventArgs e)
        {
            _isDirty = true;
            UpdateFormTextStatus();
        }

        private void UpdateFormTextStatus()
        {
            if(_isDirty)
            {
                if(!this.Text.EndsWith("*")) this.Text += "*";
            }
            else
            {
                this.Text = this.Text.Replace("*", "");
            }
        }

        private void DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            errorLabel.Text = "Error in column " + e.ColumnIndex + ". Detail : " + e.Exception.Message;
        }

        private void App_Closing(object sender, CancelEventArgs e)
        {
            #region Unused code
            /*var applicationSettings = new ApplicationSettings(connStrTextBox.Text, (ServerType) serverTypeComboBox.SelectedItem, nameSpaceTextBox.Text,
                                                              assemblyNameTextBox.Text);
            applicationSettings.Save();
            MessageBox.Show("Completed !");*/

            #endregion
        }

        private void ServerTypeSelected(object sender, EventArgs e)
        {
            ServerType serverType = (ServerType) serverTypeComboBox.SelectedItem;
            switch(serverType)
            {
                case ServerType.Oracle:
                    connStrTextBox.Text = StringConstants.ORACLE_CONN_STR_TEMPLATE;
                    break;
                case ServerType.SqlServer:
                    connStrTextBox.Text = StringConstants.SQL_CONN_STR_TEMPLATE;
                    break;
                case ServerType.SqlCe:
                    connStrTextBox.Text = StringConstants.SQLCE_CONN_STR_TEMPLATE;
                    break;
                default:
                    connStrTextBox.Text = StringConstants.ORACLE_CONN_STR_TEMPLATE;
                    break;
            }    
            
            /*bool isOracleSelected = ((ServerType) serverTypeComboBox.SelectedItem == ServerType.Oracle);
            connStrTextBox.Text = isOracleSelected ? StringConstants.ORACLE_CONN_STR_TEMPLATE : StringConstants.SQL_CONN_STR_TEMPLATE;*/

        }

        private void BindData()
        {
            serverTypeComboBox.DataSource = Enum.GetValues(typeof (ServerType));
            serverTypeComboBox.SelectedIndex = 0;

            columnName.DataPropertyName = "ColumnName";
            isPrimaryKey.DataPropertyName = "IsPrimaryKey";
            columnDataType.DataPropertyName = "DataType";
            cSharpType.DataPropertyName = "MappedType";
            cSharpType.DataSource = new DotNetTypes();
            refTypeCombo.DataSource = Enum.GetValues(typeof (ReferenceType));
        }

        private void TablesSelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                PopulateTableDetails();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PopulateTableDetails()
        {
            errorLabel.Text = string.Empty;
            var selectedTableName = (string) tablesComboBox.SelectedItem;
            try
            {
                var metadataReader = MetadataFactory.GetReader((ServerType)serverTypeComboBox.SelectedItem, connStrTextBox.Text);
                dbTableDetailsGridView.DataSource = metadataReader.GetTableDetails(selectedTableName);
                columnDetailBindingSource.DataSource = metadataReader.GetTableDetails(selectedTableName);
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

        private void connectBtnClicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                tablesComboBox.Items.Clear();
                sequencesComboBox.Items.Clear();
                PopulateTablesAndSequences();
                CreateApplicationSetttingForTables();
                int selectedIndex = tablesComboBox.SelectedIndex;
                if (selectedIndex < 0) selectedIndex = 0;
                var applicationPreferences = _tablePreferences[selectedIndex];
                CurrentTablePreference = applicationPreferences;

                // load relationships
                if (!string.IsNullOrEmpty(_currentProjectPath))
                {
                    string dirPath = _currentProjectPath;
                    if (!string.IsNullOrEmpty(_applicationSettings.TablePreferencesFile))
                    {
                        var xmlSerializer = new BinaryFormatter();

                        if (!dirPath.EndsWith(@"\")) dirPath = dirPath + @"\";
                        if (File.Exists(dirPath + _applicationSettings.TablePreferencesFile))
                        {
                            var fi = File.Open(dirPath + _applicationSettings.TablePreferencesFile, FileMode.Open);
                            if (fi.CanRead)
                            {
                                using (fi)
                                {
                                    TablePreferenceSettings settings =
                                        (TablePreferenceSettings) xmlSerializer.Deserialize(fi);
                                    if (settings != null) _tablePreferences = settings.TablePreferences;
                                }
                            }
                        }

                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CreateApplicationSetttingForTables()
        {
            var serverType = (ServerType)serverTypeComboBox.SelectedItem;
            bool hasTables = tablesComboBox.Items.Count > 0;
            if(hasTables)
            {
                _tablePreferences.Clear();
                foreach (var item in tablesComboBox.Items)
                {
                    string tableName = item.ToString();
                    var metadataReader = MetadataFactory.GetReader(serverType, connStrTextBox.Text);
                    var applicationPreferences = GetApplicationPreferences(tableName);
                    _tablePreferences.Add(applicationPreferences);
                }
            }
        }

        private void PopulateTablesAndSequences()
        {
            errorLabel.Text = string.Empty;
            var metadataReader = MetadataFactory.GetReader((ServerType)serverTypeComboBox.SelectedItem, connStrTextBox.Text);
            try
            {
                tablesComboBox.Items.AddRange(metadataReader.GetTables().ToArray());
                bool hasTables = tablesComboBox.Items.Count > 0;
                tablesComboBox.Enabled = hasTables;
                if (hasTables)
                {
                    tablesComboBox.SelectedIndex = 0;
                }

                sequencesComboBox.Items.AddRange(metadataReader.GetSequences().ToArray());
                bool hasSequences = sequencesComboBox.Items.Count > 0;
                sequencesComboBox.Enabled = hasSequences;
                if (hasSequences)
                {
                    sequencesComboBox.SelectedIndex = 0;
                }
                detailTableCombo.Items.Clear();
                detailTableCombo.Items.Add(" -- DON'T USE DETAIL TABLE --");
                detailTableCombo.Items.AddRange(metadataReader.GetTables().ToArray());
                detailTableCombo.SelectedIndex = 0;
                assignedRadio.Checked = true;


            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            folderTextBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void GenerateClicked(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            object selectedItem = tablesComboBox.SelectedItem;
            if (selectedItem == null || dbTableDetailsGridView.DataSource == null)
            {
                errorLabel.Text = "Please select a table above to generate the mapping files.";
                return;
            }
            try
            {
                errorLabel.Text = "Generating " + selectedItem + " mapping file ...";
                string tableName = selectedItem.ToString();
                var columnDetails = (ColumnDetails) dbTableDetailsGridView.DataSource;
                Generate(tableName, columnDetails);
                errorLabel.Text = "Generated all files successfully.";
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

        private void GenerateAllClicked(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            if (tablesComboBox.Items == null || tablesComboBox.Items.Count == 0)
            {
                errorLabel.Text = "Please connect to a database to populate the tables first.";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if(clearCheck.Checked)
                    {
                        ClearOutputDirectory();
                        errorLabel.Text = " Delete all file completed ...";
                    }
                    errorLabel.Text = " Generating ...";

                    var serverType = (ServerType) serverTypeComboBox.SelectedItem;

                    //foreach (object item in tablesComboBox.Items)
                    var metadataReader = MetadataFactory.GetReader(serverType, connStrTextBox.Text);
                    GlobalCache.Instance.MetaDataReader = metadataReader;
                    GlobalCache.Instance.TablePreferences = _tablePreferences;
                    foreach (ApplicationPreferences item in _tablePreferences)
                    {
                        item.FolderPath = folderTextBox.Text;
                        item.AssemblyName = assemblyNameTextBox.Text;
                        item.NameSpace = nameSpaceTextBox.Text;
                        /*string tableName = item.ToString();
                        
                        var columnDetails = metadataReader.GetTableDetails(tableName);
                        Generate(tableName, columnDetails);*/
                        var columnDetails = metadataReader.GetTableDetails(item.TableName);
                        var applicationController = new ApplicationController(item, columnDetails);
                        applicationController.Generate(genMappingCheck.Checked,genClassCheck.Checked);
                    }
                    errorLabel.Text = "Generated all files successfully.";
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

        private void ClearOutputDirectory()
        {
            string[] files = Directory.GetFiles(folderTextBox.Text.Trim());
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private void Generate(string tableName, ColumnDetails columnDetails)
        {
            var applicationPreferences = GetApplicationPreferences(tableName);
            var applicationController = new ApplicationController(applicationPreferences, columnDetails);
            applicationController.Generate();
        }

        private Language LanguageSelected
        {
            get { return vbRadioButton.Checked ? Language.VB : Language.CSharp; }
        }

        public bool IsFluent
        {
            get { return fluentMappingOption.Checked ? true : false; }
        }

        private void prefixCheckChanged(object sender, EventArgs e)
        {
            prefixLabel.Visible = prefixTextBox.Visible = prefixRadioButton.Checked;
        }

        private ApplicationPreferences GetApplicationPreferences(string tableName)
        {
            var sequence = string.Empty;
            if (sequencesComboBox.SelectedItem != null)
            {
                sequence = sequencesComboBox.SelectedItem.ToString();
            }

            var applicationPreferences = new ApplicationPreferences
                                             {
                                                 ServerType = (ServerType)serverTypeComboBox.SelectedItem,
                                                 FolderPath = folderTextBox.Text,
                                                 TableName = tableName,
                                                 NameSpace = nameSpaceTextBox.Text,
                                                 AssemblyName = assemblyNameTextBox.Text,
                                                 Sequence = sequence,
                                                 Language = LanguageSelected,
                                                 FieldNamingConvention = GetFieldNamingConvention(),
                                                 FieldGenerationConvention = GetFieldGenerationConvention(),
                                                 Prefix = prefixTextBox.Text
                                             };

            if(sequenceRadio.Checked)
            {
                applicationPreferences.PrimaryKeyType = PrimaryKeyType.Sequence;
            }
            else 
            {
                applicationPreferences.PrimaryKeyType = PrimaryKeyType.Assigned;
            }

            

            return applicationPreferences;
        }

        private FieldGenerationConvention GetFieldGenerationConvention()
        {
            var convention = FieldGenerationConvention.Field;
            if (autoPropertyRadioBtn.Checked)
                convention = FieldGenerationConvention.AutoProperty;
            if (propertyRadioBtn.Checked)
                convention = FieldGenerationConvention.Property;
            return convention;
        }

        private FieldNamingConvention GetFieldNamingConvention()
        {
            var convention = FieldNamingConvention.SameAsDatabase;
            if (prefixRadioButton.Checked)
                convention = FieldNamingConvention.Prefixed;
            if (camelCasedRadioButton.Checked)
                convention = FieldNamingConvention.CamelCase;
            return convention;
        }

        private void addDetailTable_Click(object sender, EventArgs e)
        {
            if (tablesComboBox.SelectedIndex < 0) return;

            if (_tablePreferences.Count <= 0) return;
            var applicationPreferences = _tablePreferences[tablesComboBox.SelectedIndex];
            if(applicationPreferences.TableReferences == null)
            {
                applicationPreferences.TableReferences = new Dictionary<string, TableReference>();
            }
            TableReference reference = new TableReference
                                           {
                                               Name = "REF" + new Random(DateTime.Now.Millisecond).Next().ToString(),
                                               ReferenceType = (ReferenceType)refTypeCombo.SelectedItem,
                                               TableColumns = new Dictionary<ColumnDetail, ColumnDetail>()
                                           };
            applicationPreferences.TableReferences.Add(reference.Name,reference);
            tableRefList.Items.Add(reference.Name);
        }

        private void removeDetailTable_Click(object sender, EventArgs e)
        {
            var selectedItem = (string) tableRefList.SelectedItem;
            if(string.IsNullOrEmpty(selectedItem)) return;

            CurrentTablePreference.TableReferences.Remove(selectedItem);
            PopularTableReferencesList();
        }

        private void serverTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sequencesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateApplicationPreferences();
        }

        private void UpdateApplicationPreferences()
        {
            if(tablesComboBox.SelectedIndex < 0) return;
            
            if(_tablePreferences.Count <= 0) return;
            var applicationPreferences = _tablePreferences[tablesComboBox.SelectedIndex];
            
            if (sequenceRadio.Checked)
            {
                applicationPreferences.PrimaryKeyType = PrimaryKeyType.Sequence;
            }
            else
            {
                applicationPreferences.PrimaryKeyType = PrimaryKeyType.Assigned;
            }
        }

        private ApplicationPreferences GetPreference(IList<ApplicationPreferences> tablePrefs, string detailTable)
        {
            foreach (ApplicationPreferences pref in tablePrefs)
            {
                if(pref.TableName.Equals(detailTable))
                {
                    return pref;
                }
            }
            return null;
        }

        private void saveSettingButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult result = saveFileDialog.ShowDialog();
            if(result == DialogResult.Cancel) return;
            //var streamWriter = File.Open(Application.LocalUserAppDataPath + @"\tablePrefs.obj", FileMode.Create);
            var streamWriter = File.Open(saveFileDialog.FileName, FileMode.Create);
            BinaryFormatter xmlSerializer;
            using (streamWriter)
            {
                xmlSerializer = new BinaryFormatter();
                TablePreferenceSettings tablePreferenceSettings  = new TablePreferenceSettings
                                                                       {
                                                                           TablePreferences = _tablePreferences
                                                                       };
                xmlSerializer.Serialize(streamWriter, tablePreferenceSettings);
            }
            MessageBox.Show("OK!");
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tablesComboBox.SelectedIndex < 0) return;

            if (_tablePreferences.Count <= 0) return;
            var applicationPreferences = _tablePreferences[tablesComboBox.SelectedIndex];
            CurrentTablePreference = applicationPreferences;
            if (sequenceRadio.Checked)
            {
                applicationPreferences.PrimaryKeyType = PrimaryKeyType.Sequence;
            }
            else
            {
                applicationPreferences.PrimaryKeyType = PrimaryKeyType.Assigned;
            }
            
            var serverType = (ServerType)serverTypeComboBox.SelectedItem;
            var metadataReader = MetadataFactory.GetReader(serverType, connStrTextBox.Text);
                    //var columnDetails = metadataReader.GetTableDetails(tableName);
            columnDetailBindingSource.DataSource = metadataReader.GetTableDetails(applicationPreferences.TableName); 
            
            tableRefList.Items.Clear();
            ClearTableReferenceGroup();
            var tableRefs = CurrentTablePreference.TableReferences;
            if(tableRefs !=null && tableRefs.Count > 0)
            {
                foreach (KeyValuePair<string, TableReference> tableReference in tableRefs)
                {
                    tableRefList.Items.Add(tableReference.Key);
                }
            }
        }

        private void ClearTableReferenceGroup()
        {
            refName.Text = "";
            refTypeCombo.SelectedIndex = 0;
            detailTableCombo.SelectedIndex = 0;
            refColumnGrid.Rows.Clear();
        }

        private void loadSettingButton_Click(object sender, EventArgs e)
        {
            var xmlSerializer = new BinaryFormatter();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            //var fi = File.Open(Application.LocalUserAppDataPath + @"\tablePrefs.obj",FileMode.Open);
            var fi = File.Open(fileDialog.FileName, FileMode.Open);
            if (fi.CanRead)
            {
                using (fi)
                {
                    TablePreferenceSettings settings = (TablePreferenceSettings)xmlSerializer.Deserialize(fi);
                    if(settings!= null) _tablePreferences = settings.TablePreferences;
                }
            }
            MessageBox.Show("OK!");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void detailTableCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(detailTableCombo.SelectedIndex == 0) return;
            var serverType = (ServerType)serverTypeComboBox.SelectedItem;
            var metadataReader = MetadataFactory.GetReader(serverType, connStrTextBox.Text);
            var detailTableName = (string)detailTableCombo.SelectedItem;
            refColumnDetailBindingSource.DataSource = metadataReader.GetTableDetails(detailTableName); 
        }

        private void tableRefList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableReferences = CurrentTablePreference.TableReferences;
            if(tableReferences == null) return;
            var selectedItem = (string)tableRefList.SelectedItem;
            if(selectedItem == null) return;
            var tableReference = tableReferences[selectedItem];
            if(tableReference == null) return;

            refName.Text = tableReference.Name;
            refTypeCombo.SelectedItem = tableReference.ReferenceType;
            detailTableCombo.SelectedItem = tableReference.ReferenceTable;
            refColumnGrid.Rows.Clear();
            if(tableReference.TableColumns.Count == 0 ) return;
            foreach (KeyValuePair<ColumnDetail, ColumnDetail> columns in tableReference.TableColumns)
            {
                refColumnGrid.Rows.Add(columns.Key.ColumnName, columns.Value.ColumnName);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var tableReferences = CurrentTablePreference.TableReferences;
            if (tableReferences == null) return;
            var selectedItem = (string)tableRefList.SelectedItem;
            if(selectedItem == null) return;
            var tableReference = tableReferences[selectedItem];
            if (tableReference == null) return;

            bool editState = tableReferenceGroup.Enabled;
            tableReferenceGroup.Enabled = !editState;
            if (tableReferenceGroup.Enabled)
            {
                editButton.Text = "Stop";
                addReferenceButton.Enabled = editState;
                removeReferenceButton.Enabled = editState;
            }
            else
            {
                //set state control
                editButton.Text = "Edit";
                addReferenceButton.Enabled = editState;
                removeReferenceButton.Enabled = editState;

                // update reference
                
                tableReference.ReferenceTable = (string) detailTableCombo.SelectedItem;
                refName.Text = tableReference.ReferenceTable;
                tableReference.Name = refName.Text;
                tableReference.ReferenceType = (ReferenceType)refTypeCombo.SelectedItem;
                
                AddColumnDetail(tableReference, refColumnGrid);
                if(!tableReferences.ContainsKey(tableReference.Name))
                {
                    tableReferences.Add(tableReference.Name, tableReference);
                    tableReferences.Remove(selectedItem);
                }
                else
                {
                    tableReferences[tableReference.Name] = tableReference; 
                }
                
                PopularTableReferencesList();
                if (tableReference.ReferenceType == ReferenceType.OneToMany)
                {
                    // update to other table if reference is one to many
                    ApplicationPreferences otherPref = GetPreference(_tablePreferences, tableReference.ReferenceTable);
                    var otherTableRefs = otherPref.TableReferences;
                    if (otherTableRefs != null && otherTableRefs.Count > 0)
                    {
                        foreach (KeyValuePair<string, TableReference> pair in otherTableRefs)
                        {
                            TableReference reference = pair.Value;
                            if (reference.ReferenceTable.Equals(CurrentTablePreference.TableName)
                                && reference.ReferenceType == ReferenceType.ManyToOne
                                )
                            {
                                return;
                            }
                        }
                    }
                    if (otherTableRefs == null)
                        otherTableRefs = new Dictionary<string, TableReference>();
                    otherPref.TableReferences = otherTableRefs;
                    TableReference inverseRef = new TableReference
                                                    {
                                                        Name = CurrentTablePreference.TableName,
                                                        ReferenceTable = CurrentTablePreference.TableName,
                                                        ReferenceType = ReferenceType.ManyToOne,
                                                        TableColumns = new Dictionary<ColumnDetail, ColumnDetail>()
                                                    };
                    AddColumnDetail(inverseRef, refColumnGrid);
                    otherTableRefs.Add(inverseRef.Name, inverseRef);
                }
            }
        }

        private void PopularTableReferencesList()
        {
            tableRefList.Items.Clear();
            var tableRefs = CurrentTablePreference.TableReferences;
            if (tableRefs != null && tableRefs.Count > 0)
            {
                foreach (KeyValuePair<string, TableReference> tableReference in tableRefs)
                {
                    tableRefList.Items.Add(tableReference.Key);
                }
            }
        }

        private void AddColumnDetail(TableReference tableReference, DataGridView refColumnGrid1)
        {
            tableReference.TableColumns.Clear();
            foreach (DataGridViewRow row in refColumnGrid1.Rows)
            {
                var colName1 = row.Cells[0].Value;
                var colName2 = row.Cells[1].Value;
                if (colName1 == null || colName2 == null) continue;
                ColumnDetail _column = GetColumn(columnDetailBindingSource, colName1.ToString());
                ColumnDetail _refColumn = GetColumn(refColumnDetailBindingSource, colName2.ToString());

                if (_column == null || _refColumn == null) continue;

                tableReference.TableColumns.Add(_column, _refColumn);
            }
        }

        private ColumnDetail GetColumn(BindingSource source, string colName)
        {
            ColumnDetail result = null;
            IEnumerator enumerator = source.GetEnumerator();
            while(enumerator.MoveNext())
            {
                ColumnDetail detail = (ColumnDetail)enumerator.Current;
                if (detail.ColumnName.Equals(colName))
                {
                    result = detail;
                    break;
                }
            }
            return result;
        }

        private void refColumnGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var currentCell = refColumnGrid.CurrentCell;
            if(currentCell == null) return;
            string value = (string)currentCell.Value;
            if (string.IsNullOrEmpty(value)) return;
            ColumnDetail columnDetail =  GetColumn(refColumnDetailBindingSource, value);
            if(columnDetail!=null)
                refColumnGrid.Rows[currentCell.RowIndex].Cells[1].Value = columnDetail.ColumnName;
        }

        private void DaoLayerGen_Click(object sender, EventArgs e)
        {

        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            txtDaoLookup.Text = folderTextBox.Text;
        }

        private void btnGenDao_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            if (string.IsNullOrEmpty(txtDaoLayerDir.Text) )
            {
                errorCodeGen.Text = "Please select a directory for DAO GEN";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                    if (chkDeleteDataLayerDir.Checked)
                    {
                        ClearOutputDirectory(txtDaoLayerDir.Text.Trim());
                        errorCodeGen.Text = " Delete all file completed ...";
                    }
                    errorCodeGen.Text = " Generating ...";

                    DaoClassPreferences daoClassPreferences = new DaoClassPreferences(txtDaoLookup.Text,txtDaoLayerDir.Text,txtDaoNamespace.Text,nameSpaceTextBox.Text,txtDaoAssembly.Text,assemblyNameTextBox.Text);
                    DaoLayerCodeGenerator daoLayerCodeGenerator = new DaoLayerCodeGenerator(daoClassPreferences);
                    daoLayerCodeGenerator.Generate();
                    errorCodeGen.Text = "Generated all files successfully.";
                
                
            }
            catch (Exception ex)
            {
                errorCodeGen.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ClearOutputDirectory(string p)
        {
            if (!Directory.Exists(p)) return;
            Directory.Delete(p,true);
            Directory.CreateDirectory(p);
            /*string[] files = Directory.GetFiles(p.Trim());
            foreach (string file in files)
            {
                File.Delete(file);
            }*/ 
            
        }

        private void saveProjectAsMenu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveProjectDialog = new FolderBrowserDialog();
            saveProjectDialog.ShowDialog();

            SaveCurrentProject(saveProjectDialog.SelectedPath);
            _isDirty = false;
            UpdateFormTextStatus();
            this.mainTabControl.Enabled = true;
        }

        private void SaveCurrentProject(string path)
        {
            if(string.IsNullOrEmpty(path)) return;
            if (_applicationSettings == null)
            {
                MessageBox.Show("Please create new project !");
                return;
            }

            if (string.IsNullOrEmpty(projectNameTextBox.Text))
            {
                MessageBox.Show("Please input project name !");
                return;
            }

            LoadViewToApplicationSettings();
            _applicationSettings.Save(path);

            if (_tablePreferences != null && _tablePreferences.Count > 0)
            {
                _applicationSettings.SaveTablePreferencesSetting(path, _tablePreferences);
            }
            MessageBox.Show("Save project completed !");
        }

        private void LoadViewToApplicationSettings()
        {
            _applicationSettings.ServerType = (ServerType) serverTypeComboBox.SelectedItem;
            _applicationSettings.ConnectionString = connStrTextBox.Text;
            _applicationSettings.ModelPathForDao = folderTextBox.Text.Trim();
            _applicationSettings.NameSpace = nameSpaceTextBox.Text.Trim();
            _applicationSettings.AssemblyName = assemblyNameTextBox.Text.Trim();
            _applicationSettings.FieldGenerationConvention = GetFieldGenerationConvention();
            _applicationSettings.FieldNamingConvention = GetFieldNamingConvention();
            _applicationSettings.Language = cSharpRadioButton.Checked ? Language.CSharp : Language.VB;
            _applicationSettings.IsFluent = IsFluent;
            _applicationSettings.ModelLookupPath = txtDaoLookup.Text.Trim();
            
            _applicationSettings.DataLayerPath = txtDaoLayerDir.Text.Trim();
            _applicationSettings.DataLayerAssembly = txtDaoAssembly.Text.Trim();
            _applicationSettings.DataLayerNameSpace = txtDaoNamespace.Text.Trim();
            _applicationSettings.ProjectName = projectNameTextBox.Text.Trim();
            
            _applicationSettings.TablePreferencesFile = _applicationSettings.ProjectName + ".nmprefobj";

            _applicationSettings.ModelPathForBusiness = txtBusinessLookup.Text.Trim();
            _applicationSettings.BusinessGeneratePath = txtBusinessLayerDir.Text.Trim();
            _applicationSettings.BusinessNamespaceName = txtBusinessNamespace.Text.Trim();
            _applicationSettings.BusinessAssembly = txtBusinessAssembly.Text.Trim();
            _applicationSettings.DaoNamespaceForBusiness = txtDaoNamespaceUsing.Text.Trim();

            _applicationSettings.ViewLookupDir = txtViewLookup.Text.Trim();
            _applicationSettings.ViewModelGeneratePath = txtViewModelDir.Text.Trim();
            _applicationSettings.ViewModelNamespaceName = txtViewModelNamespace.Text.Trim();
            _applicationSettings.ViewModelAssemblyName = txtViewModelAssembly.Text.Trim();
        }

        private void loadProjectMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveProjectDialog = new OpenFileDialog();
            saveProjectDialog.ShowDialog();

            string projectFile = saveProjectDialog.FileName;
            _applicationSettings = ApplicationSettings.Load(projectFile);
            
            if(_applicationSettings == null)
            {
                MessageBox.Show("Cannot open project !");
                return;
            }
            

            LoadApplicationSettings();
            _currentProjectPath = GetSafeProjectPath(saveProjectDialog.FileName);

            // just opened project so it's not dirty
            _isDirty = false;
            UpdateFormTextStatus();
            this.mainTabControl.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">fileName include path</param>
        /// <returns></returns>
        private string GetSafeProjectPath(string fileName)
        {
            return fileName.Substring(0, fileName.LastIndexOf(@"\"));
        }

        private void LoadApplicationSettings()
        {
            if (_applicationSettings != null)
            {
                serverTypeComboBox.SelectedItem = _applicationSettings.ServerType;
                connStrTextBox.Text = _applicationSettings.ConnectionString;
                nameSpaceTextBox.Text = _applicationSettings.NameSpace;
                assemblyNameTextBox.Text = _applicationSettings.AssemblyName;

                folderTextBox.Text = _applicationSettings.ModelPathForDao;
                nameSpaceTextBox.Text = _applicationSettings.NameSpace;
                assemblyNameTextBox.Text = _applicationSettings.AssemblyName;
                _applicationSettings.FieldGenerationConvention = GetFieldGenerationConvention();
                _applicationSettings.FieldNamingConvention = GetFieldNamingConvention();
                _applicationSettings.Language = cSharpRadioButton.Checked ? Language.CSharp : Language.VB;
                if (_applicationSettings.IsFluent)
                    fluentMappingOption.Checked = true;
                else
                {
                    hbmMappingOption.Checked = true;
                }

                txtDaoLookup.Text = _applicationSettings.ModelLookupPath;
                txtDaoLayerDir.Text =  _applicationSettings.DataLayerPath;
                txtDaoAssembly.Text = _applicationSettings.DataLayerAssembly;
                txtDaoNamespace.Text = _applicationSettings.DataLayerNameSpace;
                projectNameTextBox.Text = _applicationSettings.ProjectName;

                txtBusinessLookup.Text = _applicationSettings.ModelPathForBusiness;
                txtBusinessLayerDir.Text = _applicationSettings.BusinessGeneratePath;
                txtBusinessNamespace.Text = _applicationSettings.BusinessNamespaceName;
                txtBusinessAssembly.Text =_applicationSettings.BusinessAssembly;
                txtDaoNamespaceUsing.Text = _applicationSettings.DaoNamespaceForBusiness;

                txtViewLookup.Text = _applicationSettings.ViewLookupDir;
                txtViewModelDir.Text = _applicationSettings.ViewModelGeneratePath;
                txtViewModelNamespace.Text = _applicationSettings.ViewModelNamespaceName;
                txtViewModelAssembly.Text = _applicationSettings.ViewModelAssemblyName;
                this.Text = projectNameTextBox.Text;
            }
        }

        private void saveProjectMenu_Click(object sender, EventArgs e)
        {
            if(_applicationSettings == null)
            {
                MessageBox.Show("Nothing to save. Please create a project !");
                return;
            }
            if(string.IsNullOrEmpty(_currentProjectPath))
            {
                saveProjectAsMenu_Click(sender,e);
                
            }
            else
            {
                string realPath = _currentProjectPath.Substring(0,
                                                            _currentProjectPath.IndexOf(_applicationSettings.ProjectName));
                SaveCurrentProject(realPath);    
            }
            _isDirty = false;
            UpdateFormTextStatus();
            this.mainTabControl.Enabled = true;
        }

        private void newProjectMenu_Click(object sender, EventArgs e)
        {
            
            var applicationSettings = new ApplicationSettings(connStrTextBox.Text, (ServerType)serverTypeComboBox.SelectedItem, nameSpaceTextBox.Text,
                                                              assemblyNameTextBox.Text);
            _applicationSettings = applicationSettings;
            projectNameTextBox.Text = " New NMG Project";
            _applicationSettings.ProjectName = projectNameTextBox.Text;
            _isDirty = true;
            this.mainTabControl.Enabled = true;
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            saveProjectMenu_Click(sender,e);
            this.mainTabControl.Enabled = false;
        }

        private void btnDaoDirSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtDaoLookup.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnDaoLayerSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtDaoLayerDir.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnBusinessDirSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtBusinessLookup.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnBusinessLayerSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtBusinessLayerDir.Text = folderBrowserDialog.SelectedPath;
        }

        private void txtDaoNamespace_TextChanged(object sender, EventArgs e)
        {
            txtDaoNamespaceUsing.Text = txtDaoNamespace.Text;
        }

        private void btnGenBusiness_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            if (string.IsNullOrEmpty(txtBusinessLayerDir.Text))
            {
                errorCodeGen.Text = "Please select a directory for BUSINESS GEN";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (chkDeleteBusinessLayerDir.Checked)
                {
                    ClearOutputDirectory(txtBusinessLayerDir.Text.Trim());
                    errorCodeGen.Text = " Delete all file completed ...";
                }
                errorCodeGen.Text = " Generating ...";

                BusinessClassPreferences businessClassPreferences = new BusinessClassPreferences(txtBusinessLookup.Text, txtBusinessLayerDir.Text, txtBusinessNamespace.Text, nameSpaceTextBox.Text,txtDaoNamespaceUsing.Text,txtBusinessAssembly.Text);
                BusinessLayerCodeGenerator businessLayerCodeGenerator = new BusinessLayerCodeGenerator(businessClassPreferences);
                businessLayerCodeGenerator.Generate();
                errorCodeGen.Text = "Generated all files successfully.";


            }
            catch (Exception ex)
            {
                errorCodeGen.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtViewLookup.Text = folderBrowserDialog.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txtViewModelDir.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnGenViewModel_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            if (string.IsNullOrEmpty(txtBusinessLayerDir.Text))
            {
                errorCodeGen.Text = "Please select a directory for VIEWMODEL GEN";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (chkDeleteViewModelDir.Checked)
                {
                    ClearOutputDirectory(txtViewModelDir.Text.Trim());
                    errorCodeGen.Text = " Delete all file completed ...";
                }
                errorCodeGen.Text = " Generating ...";

                ViewModelPreferences viewModelPreferences = new ViewModelPreferences(txtViewLookup.Text, txtViewModelDir.Text, txtViewModelNamespace.Text, txtViewModelAssembly.Text);

                ViewModelGenerator viewModelGenerator = new ViewModelGenerator(viewModelPreferences);
                viewModelGenerator.Generate();
                errorCodeGen.Text = "Generated all files successfully.";


            }
            catch (Exception ex)
            {
                errorCodeGen.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}