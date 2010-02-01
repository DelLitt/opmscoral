using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using NMG.Core.Domain;
using NMG.Core.Util;

namespace NMG.Core.Generator
{
    public abstract class MappingGenerator : AbstractGenerator
    {
        private readonly ApplicationPreferences applicationPreferences;

        public bool IsAssigned { get; set; }

        protected MappingGenerator(ApplicationPreferences applicationPreferences, ColumnDetails columnDetails)
            : base(applicationPreferences.FolderPath, applicationPreferences.TableName, applicationPreferences.NameSpace, applicationPreferences.AssemblyName, applicationPreferences.Sequence, columnDetails)
        {
            this.applicationPreferences = applicationPreferences;
            IsAssigned = applicationPreferences.PrimaryKeyType == PrimaryKeyType.Assigned;
        }

        protected abstract void AddIdGenerator(XmlDocument xmldoc, XmlElement idElement);
        protected abstract void AddCompositeIdGenerator(XmlDocument xmldoc, XmlElement idElement, List<ColumnDetail> compositeKey, ApplicationPreferences applicationPreferences);

        public override void Generate()
        {
            string realTableName = GlobalCache.Instance.ReplaceShortWords(tableName);
            string fileName = filePath + realTableName.GetFormattedText() + ".hbm.xml";
            using (var stringWriter = new StringWriter())
            {
                var xmldoc = CreateMappingDocument();
                xmldoc.Save(stringWriter);
                string generatedXML = RemoveEmptyNamespaces(stringWriter.ToString());

                using (var writer = new StreamWriter(fileName))
                {
                    writer.Write(generatedXML);
                    writer.Flush();
                }
            }
        }

        private static string RemoveEmptyNamespaces(string mappingContent)
        {
            mappingContent = mappingContent.Replace("utf-16", "utf-8");
            return mappingContent.Replace("xmlns=\"\"", "");
        }

        public XmlDocument CreateMappingDocument()
        {
            string realTableName = GlobalCache.Instance.ReplaceShortWords(tableName);

            var xmldoc = new XmlDocument();
            var xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", string.Empty, string.Empty);
            xmldoc.AppendChild(xmlDeclaration);
            var root = xmldoc.CreateElement("hibernate-mapping", "urn:nhibernate-mapping-2.2");
            root.SetAttribute("assembly", assemblyName);
            xmldoc.AppendChild(root);

            var classElement = xmldoc.CreateElement("class");
            classElement.SetAttribute("name", nameSpace + "." + realTableName.GetFormattedText() + ", " + assemblyName);
            classElement.SetAttribute("table", tableName);
            classElement.SetAttribute("lazy", "true");
            root.AppendChild(classElement);
            
                var primaryKeyColumns = columnDetails.FindAll(detail => detail.IsPrimaryKey);
                if (primaryKeyColumns.Count > 0)
                {
                    if (primaryKeyColumns.Count == 1)
                    {
                        var primaryKeyColumn = primaryKeyColumns[0];
                        var idElement = xmldoc.CreateElement("id");
                        string propertyName =
                            primaryKeyColumn.ColumnName.GetPreferenceFormattedText(applicationPreferences);
                        if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.Property)
                        {
                            idElement.SetAttribute("name", propertyName.MakeFirstCharLowerCase());
                        }
                        else 
                        {
                            if(applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.AutoProperty)
                            {
                                propertyName = primaryKeyColumn.ColumnName.GetFormattedText();
                            }
                            idElement.SetAttribute("name", propertyName);
                        }
                        
                        var mapper = new DataTypeMapper();
                        Type mapFromDbType = mapper.MapFromDBType(primaryKeyColumn.DataType, primaryKeyColumn.DataLength,
                                                                  primaryKeyColumn.DataPrecision,
                                                                  primaryKeyColumn.DataScale);
                        idElement.SetAttribute("type", mapFromDbType.Name);
                        idElement.SetAttribute("column", primaryKeyColumn.ColumnName);
                        if (applicationPreferences.FieldGenerationConvention != FieldGenerationConvention.AutoProperty)
                        {
                            idElement.SetAttribute("access", "field");
                        }
                        classElement.AppendChild(idElement);

                        AddIdGenerator(xmldoc, idElement);
                    }
                    else // composite key
                    {
                        var primaryKeyColumn = primaryKeyColumns[0];
                        var idElement = xmldoc.CreateElement("composite-id");
                        string pkName = tableName.GetPreferenceFormattedText(applicationPreferences) + "PK";
                        if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.Property)
                        {
                            idElement.SetAttribute("name", pkName.MakeFirstCharLowerCase());
                            idElement.SetAttribute("class", realTableName.GetFormattedText() + "PK");
                        }
                        else
                        {
                            if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.AutoProperty)
                            {
                                pkName = GlobalCache.Instance.ReplaceShortWords(tableName);
                                pkName = pkName.GetFormattedText() + "PK";
                            }

                            idElement.SetAttribute("name", pkName);
                            idElement.SetAttribute("class", pkName);
                        }
                        classElement.AppendChild(idElement);
                        AddCompositeIdGenerator(xmldoc, idElement, primaryKeyColumns, applicationPreferences);
                    }
                }
            

            AddAllProperties(xmldoc, classElement);

            ArrayList detailTableList = applicationPreferences.DetailTable;
            if(detailTableList!= null && detailTableList.Count > 0)
            {
                AddDetailProperties(xmldoc, classElement, primaryKeyColumns, applicationPreferences);    
            }
            if (!string.IsNullOrEmpty(applicationPreferences.MasterTable))
            {
                AddMasterProperty(xmldoc, classElement, primaryKeyColumns, applicationPreferences);
            }

            return xmldoc;
        }

        private void AddMasterProperty(XmlDocument xmldoc, XmlElement classElement, List<ColumnDetail> primaryKeyColumns, ApplicationPreferences preferences)
        {
            List<ColumnDetail> masterPrimaryKeys = new List<ColumnDetail>();
            var globalPreferences = GlobalCache.Instance.TablePreferences;
            foreach (ApplicationPreferences preference in globalPreferences)
            {
                if(preference.TableName.Equals(preferences.MasterTable))
                {
                    List<ColumnDetail> tableColumns =
                        GlobalCache.Instance.MetaDataReader.GetTableDetails(preference.TableName);
                    masterPrimaryKeys = tableColumns.FindAll(column => column.IsPrimaryKey);
                    break;
                }
            }
            if(masterPrimaryKeys.Count == 0) return;

            string masterTableName = GlobalCache.Instance.ReplaceShortWords(preferences.MasterTable);
                masterTableName = masterTableName.GetFormattedText();
            var xmlNode = xmldoc.CreateElement("many-to-one");
            xmlNode.SetAttribute("lazy", "true");
            xmlNode.SetAttribute("update", "false");
            xmlNode.SetAttribute("insert", "false");
            xmlNode.SetAttribute("class", masterTableName);

            foreach (ColumnDetail columnDetail in masterPrimaryKeys)
            {
                var xmlColumn = xmldoc.CreateElement("column");
                xmlColumn.SetAttribute("name", columnDetail.ColumnName);
                xmlNode.AppendChild(xmlColumn);
            }

            classElement.AppendChild(xmlNode);
        }

        private void AddDetailProperties(XmlDocument xmldoc, XmlElement classElement, List<ColumnDetail> primaryKeyColumns, ApplicationPreferences preferences)
        {
            if (columnDetails.Count == 0) return;
            foreach (string detailTable in preferences.DetailTable)
            {
                string detailTableName = GlobalCache.Instance.ReplaceShortWords(detailTable);
                detailTableName = detailTableName.GetFormattedText();
                var xmlNode = xmldoc.CreateElement("bag");
                xmlNode.SetAttribute("lazy", "true");
                xmlNode.SetAttribute("inverse", "true");
                xmlNode.SetAttribute("name", detailTableName + "s");

                var xmlKeyNode = xmldoc.CreateElement("key");
                foreach (ColumnDetail columnDetail in primaryKeyColumns)
                {
                    var xmlColumn = xmldoc.CreateElement("column");
                    xmlColumn.SetAttribute("name", columnDetail.ColumnName);
                    xmlKeyNode.AppendChild(xmlColumn);
                }
                xmlNode.AppendChild(xmlKeyNode);

                var xmlRefType = xmldoc.CreateElement("one-to-many");
                xmlRefType.SetAttribute("class", detailTableName);
                xmlNode.AppendChild(xmlRefType);

                classElement.AppendChild(xmlNode);
            }
        }

        private void AddAllProperties(XmlDocument xmldoc, XmlNode classElement)
        {
            foreach (var columnDetail in columnDetails)
            {
                if (columnDetail.IsPrimaryKey)
                    continue;
                var xmlNode = xmldoc.CreateElement("property");
                string propertyName = columnDetail.ColumnName.GetPreferenceFormattedText(applicationPreferences);
                if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.Property)
                {
                    xmlNode.SetAttribute("name", propertyName.MakeFirstCharLowerCase());    
                }else
                {
                    if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.AutoProperty)
                    {
                        propertyName = columnDetail.ColumnName.GetFormattedText();
                    }
                    xmlNode.SetAttribute("name", propertyName);
                }
                
                xmlNode.SetAttribute("column", columnDetail.ColumnName);
                if (applicationPreferences.FieldGenerationConvention != FieldGenerationConvention.AutoProperty)
                {
                    xmlNode.SetAttribute("access", "field");
                }
                classElement.AppendChild(xmlNode);
            }
        }
    }
}