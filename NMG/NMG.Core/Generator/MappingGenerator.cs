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
        private readonly Dictionary<string, TableReference> _tableReferences;
        public bool IsAssigned { get; set; }

        protected MappingGenerator(ApplicationPreferences applicationPreferences, ColumnDetails columnDetails)
            : base(applicationPreferences.FolderPath, applicationPreferences.TableName, applicationPreferences.NameSpace, applicationPreferences.AssemblyName, applicationPreferences.Sequence, columnDetails)
        {
            this.applicationPreferences = applicationPreferences;
            IsAssigned = applicationPreferences.PrimaryKeyType == PrimaryKeyType.Assigned;
            this._tableReferences = applicationPreferences.TableReferences;
        }

        protected abstract void AddIdGenerator(XmlDocument xmldoc, XmlElement idElement);
        protected abstract void AddCompositeIdGenerator(XmlDocument xmldoc, XmlElement idElement, List<ColumnDetail> compositeKey, ApplicationPreferences applicationPreferences);

        public override void Generate()
        {
            string realTableName = GlobalCache.Instance.ReplaceShortWords(tableName.ToUpper());
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
            string realTableName = GlobalCache.Instance.ReplaceShortWords(tableName.ToUpper());

            var xmldoc = new XmlDocument();
            var xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", string.Empty, string.Empty);
            xmldoc.AppendChild(xmlDeclaration);
            var root = xmldoc.CreateElement("hibernate-mapping", "urn:nhibernate-mapping-2.2");
            root.SetAttribute("assembly", assemblyName);
            root.SetAttribute("namespace", nameSpace);
            xmldoc.AppendChild(root);

            var classElement = xmldoc.CreateElement("class");
            //classElement.SetAttribute("name", nameSpace + "." + realTableName.GetFormattedText() + ", " + assemblyName);
            classElement.SetAttribute("name", realTableName.GetFormattedText());
            classElement.SetAttribute("table", tableName);
            //classElement.SetAttribute("lazy", "true");
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
                                pkName = GlobalCache.Instance.ReplaceShortWords(tableName.ToUpper());
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

            var tableReferences = applicationPreferences.TableReferences;
            if(tableReferences!= null && tableReferences.Count > 0)
            {
                foreach (KeyValuePair<string, TableReference> pair in tableReferences)
                {
                    TableReference reference = pair.Value;
                    switch(reference.ReferenceType)
                    {
                        case ReferenceType.OneToMany:
                            AddOneToManyProperty(xmldoc, classElement, reference);    
                            break;
                        case ReferenceType.ManyToOne:
                            AddManyToOneProperty(xmldoc, classElement, reference);
                            break;
                    }
                }
                
                
            }

            return xmldoc;
        }

        private void AddManyToOneProperty(XmlDocument xmldoc, XmlElement classElement, TableReference reference)
        {
            string refTableName = GlobalCache.Instance.ReplaceShortWords(reference.ReferenceTable.ToUpper());
            refTableName = refTableName.GetFormattedText();
            var xmlNode = xmldoc.CreateElement("many-to-one");
            //xmlNode.SetAttribute("lazy", "true");
            /*xmlNode.SetAttribute("update", "false");
            xmlNode.SetAttribute("insert", "false");*/
            xmlNode.SetAttribute("class", refTableName);
            xmlNode.SetAttribute("name", refTableName);

            foreach (KeyValuePair<ColumnDetail, ColumnDetail> refColumn in reference.TableColumns)
            {
                var xmlColumn = xmldoc.CreateElement("column");
                xmlColumn.SetAttribute("name", refColumn.Key.ColumnName);

                // if foreign column differ with primary key
                if(!refColumn.Key.Equals(refColumn.Value.ColumnName))
                {
                    string primaryColName = refColumn.Value.ColumnName;
                    ApplicationPreferences primaryKeys =
                        GlobalCache.Instance.TablePreferences.
                            Find(pref => pref.TableName.Equals(reference.ReferenceTable));
                    if (primaryKeys == null) throw new Exception("Reference table " + reference.ReferenceTable + "does not exist for " + tableName + " !");
                    var metadataReader = GlobalCache.Instance.MetaDataReader;
                    ColumnDetails primaryDetails = metadataReader.GetTableDetails(primaryKeys.TableName);
                    List<ColumnDetail> priKeys = primaryDetails.FindAll(col => col.IsPrimaryKey);
                    
                    if(priKeys.Find( col =>col.ColumnName.Equals(primaryColName)) != null)
                    {
                        if(priKeys.Count == 1)
                        {
                            string realPriPrefColName = primaryColName.GetFormattedText();
                            //xmlColumn.SetAttribute("property-ref", realPriPrefColName);
                        }
                        else if(priKeys.Count > 1)
                        {
                            string priCompositePK = GlobalCache.Instance.ReplaceShortWords(primaryKeys.TableName.ToUpper());
                            priCompositePK = priCompositePK.GetFormattedText() + "PK";
                            xmlNode.SetAttribute("property-ref", priCompositePK);
                            //xmlColumn.SetAttribute("property-ref", primaryColName.GetFormattedText());
                        }
                    }
                    else
                    {
                        if (primaryDetails.Find(col => col.ColumnName.Equals(primaryColName)) != null)
                        {
                            //xmlColumn.SetAttribute("property-ref", primaryColName.GetFormattedText());
                        }
                    }
                    
                }
                xmlNode.AppendChild(xmlColumn);
            }

            classElement.AppendChild(xmlNode);
        }

        private void AddOneToManyProperty(XmlDocument xmldoc, XmlElement classElement, TableReference reference)
        {
            
                string refTableName = GlobalCache.Instance.ReplaceShortWords(reference.ReferenceTable.ToUpper());
                refTableName = refTableName.GetFormattedText();
                var xmlNode = xmldoc.CreateElement("bag");
                //xmlNode.SetAttribute("lazy", "true");
                xmlNode.SetAttribute("inverse", "true");
                xmlNode.SetAttribute("name", refTableName + "s");

                var xmlKeyNode = xmldoc.CreateElement("key");
                foreach (KeyValuePair<ColumnDetail,ColumnDetail> refColumn in reference.TableColumns)
                {
                    var xmlColumn = xmldoc.CreateElement("column");
                    xmlColumn.SetAttribute("name", refColumn.Key.ColumnName);
                    xmlKeyNode.AppendChild(xmlColumn);
                }
                xmlNode.AppendChild(xmlKeyNode);

                var xmlRefType = xmldoc.CreateElement("one-to-many");
                xmlRefType.SetAttribute("class", refTableName);
                xmlNode.AppendChild(xmlRefType);

                classElement.AppendChild(xmlNode);
            
        }

        private void AddAllProperties(XmlDocument xmldoc, XmlNode classElement)
        {
            foreach (var columnDetail in columnDetails)
            {
                if (columnDetail.IsPrimaryKey) continue;
                if (IsReferenceColumn(columnDetail)) continue;
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

        private bool IsReferenceColumn(ColumnDetail detail)
        {
            if(_tableReferences == null || _tableReferences.Count == 0 )
            {
                return false;
            }
            foreach (KeyValuePair<string, TableReference> pair in _tableReferences)
            {
                TableReference reference = pair.Value;
                foreach (KeyValuePair<ColumnDetail, ColumnDetail> column in reference.TableColumns)
                {
                    if(column.Key.ColumnName.Equals(detail.ColumnName)) 
                        return true;                    
                }
            }
            return false;
        }
    }
}