﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using NMG.Core;
using NMG.Core.Domain;
using NMG.Core.Util;

namespace NHibernateMappingGenerator
{
    public partial class App : Form
    {
        
        private List<ApplicationPreferences> _tablePreferences = new List<ApplicationPreferences>();
        private ApplicationPreferences CurrentTablePreference { get; set;}

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
            ApplicationSettings applicationSettings = null;

            try 
	        {	        
		        applicationSettings = ApplicationSettings.Load();
	        }
	        catch (Exception)
	        {

	        }
            if (applicationSettings != null)
            {
                connStrTextBox.Text = applicationSettings.ConnectionString;
                serverTypeComboBox.SelectedItem = applicationSettings.ServerType;
                nameSpaceTextBox.Text = applicationSettings.NameSpace;
                assemblyNameTextBox.Text = applicationSettings.AssemblyName;
            }
            sameAsDBRadioButton.Checked = true;
            prefixLabel.Visible = prefixTextBox.Visible = false;
            cSharpRadioButton.Checked = true;
            hbmMappingOption.Checked = true;
            
        }

        private void DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            errorLabel.Text = "Error in column " + e.ColumnIndex + ". Detail : " + e.Exception.Message;
        }

        private void App_Closing(object sender, CancelEventArgs e)
        {
            var applicationSettings = new ApplicationSettings(connStrTextBox.Text, (ServerType) serverTypeComboBox.SelectedItem, nameSpaceTextBox.Text,
                                                              assemblyNameTextBox.Text);
            applicationSettings.Save();
            MessageBox.Show("Completed !");
        }

        private void ServerTypeSelected(object sender, EventArgs e)
        {
            bool isOracleSelected = ((ServerType) serverTypeComboBox.SelectedItem == ServerType.Oracle);
            connStrTextBox.Text = isOracleSelected ? StringConstants.ORACLE_CONN_STR_TEMPLATE : StringConstants.SQL_CONN_STR_TEMPLATE;
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
                var applicationPreferences = _tablePreferences[tablesComboBox.SelectedIndex];
                CurrentTablePreference = applicationPreferences;
                
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
            saveFileDialog.ShowDialog();
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
    }
}