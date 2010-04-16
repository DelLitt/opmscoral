using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using NMG.Core.Domain;
using NMG.Core.Util;

namespace NMG.Core.Generator
{
    public class CodeGenerator : AbstractGenerator
    {
        private readonly ApplicationPreferences applicationPreferences;
        private readonly Dictionary<string, TableReference> tableReferences;
        private readonly Language language;
        
        public CodeGenerator(ApplicationPreferences applicationPreferences, ColumnDetails columnDetails)
            : base(
                applicationPreferences.FolderPath, applicationPreferences.TableName, applicationPreferences.NameSpace,
                applicationPreferences.AssemblyName, applicationPreferences.Sequence, columnDetails)
        {
            this.applicationPreferences = applicationPreferences;
            language = applicationPreferences.Language;
            this.tableReferences = applicationPreferences.TableReferences;
        }

        public override void Generate()
        {
            CodeCompileUnit pkClass = null;
            tableName = GlobalCache.Instance.ReplaceShortWords(tableName);
            var compileUnit = GetCompileUnit(out pkClass);
            if(pkClass!=null)
            {
                WriteToFile(pkClass, tableName.GetFormattedText() + "PK");
            }
            
            WriteToFile(compileUnit, tableName.GetFormattedText());
        }

        public CodeCompileUnit GetCompileUnit(out CodeCompileUnit pkClass)
        {
            var codeGenerationHelper = new CodeGenerationHelper();
            var compileUnit = codeGenerationHelper.GetCodeCompileUnit(nameSpace, tableName.GetFormattedText());
            CodeCompileUnit pkCompileUnit = null;
            var mapper = new DataTypeMapper();
            var newType = compileUnit.Namespaces[0].Types[0];
            List<ColumnDetail> pkColumns = columnDetails.FindAll(col => col.IsPrimaryKey);
            List<ColumnDetail> normalColumns = columnDetails.FindAll(col => col.IsPrimaryKey == false);

            // data contract count
            int dataContractCount = 1;

            // create pk columns
            if(pkColumns.Count > 0)
            {
                if(pkColumns.Count == 1)
                {
                    var columnDetail = pkColumns[0];
                    string propertyName = columnDetail.ColumnName.GetPreferenceFormattedText(applicationPreferences);
                    Type mapFromDbType = mapper.MapFromDBType(columnDetail.DataType, columnDetail.DataLength, columnDetail.DataPrecision, columnDetail.DataScale);

                    switch (applicationPreferences.FieldGenerationConvention)
                    {
                        case FieldGenerationConvention.Property:
                            newType.Members.Add(codeGenerationHelper.CreateProperty(mapFromDbType, propertyName.MakeFirstCharUpperCase()));
                            newType.Members.Add(codeGenerationHelper.CreateField(mapFromDbType, propertyName.MakeFirstCharLowerCase()));
                            break;
                        case FieldGenerationConvention.AutoProperty:
                            propertyName = columnDetail.ColumnName.GetFormattedText();
                            var codeMemberProperty = codeGenerationHelper.CreateAutoProperty(mapFromDbType, propertyName);
                            newType.Members.Add(codeMemberProperty);
                            break;
                        default:
                            newType.Members.Add(codeGenerationHelper.CreateField(mapFromDbType, propertyName));
                            break;
                    } 
                }
                else // composite key
                {
                    string pkClassName = tableName.GetFormattedText() + "PK";
                    string pkRefProperty = pkClassName;
                    pkCompileUnit = codeGenerationHelper.GetCodeCompileUnit(nameSpace, pkClassName);
                    var newPKType = pkCompileUnit.Namespaces[0].Types[0];

                    // create composite member
                    switch (applicationPreferences.FieldGenerationConvention)
                    {
                        case FieldGenerationConvention.Property:
                            newType.Members.Add(codeGenerationHelper.CreateProperty(pkClassName, pkRefProperty.MakeFirstCharUpperCase()));
                            newType.Members.Add(codeGenerationHelper.CreateField(pkClassName, pkRefProperty.MakeFirstCharLowerCase()));
                            break;
                        case FieldGenerationConvention.AutoProperty:
                            //pkPropertyName = columnDetail.ColumnName.GetFormattedText();
                            var codeMemberProperty = codeGenerationHelper.CreateAutoProperty(pkClassName, pkRefProperty);
                            newType.Members.Add(codeMemberProperty);
                            break;
                        default:
                            newType.Members.Add(codeGenerationHelper.CreateField(pkClassName, pkRefProperty));
                            break;
                    }

                    // create pk columns
                    foreach (var columnDetail in pkColumns)
                    {
                        string pkPropertyName = columnDetail.ColumnName.GetPreferenceFormattedText(applicationPreferences);
                        Type pkMapFromDbType = mapper.MapFromDBType(columnDetail.DataType, columnDetail.DataLength, columnDetail.DataPrecision, columnDetail.DataScale);
                        
                        // get compile unit of compile class
                        switch (applicationPreferences.FieldGenerationConvention)
                        {
                            case FieldGenerationConvention.Property:
                                newPKType.Members.Add(codeGenerationHelper.CreateProperty(pkMapFromDbType, pkPropertyName.MakeFirstCharUpperCase()));
                                newPKType.Members.Add(codeGenerationHelper.CreateField(pkMapFromDbType, pkPropertyName.MakeFirstCharLowerCase()));
                                break;
                            case FieldGenerationConvention.AutoProperty:
                                pkPropertyName = columnDetail.ColumnName.GetFormattedText();
                                var codeMemberProperty = codeGenerationHelper.CreateAutoProperty(pkMapFromDbType, pkPropertyName);
                                newPKType.Members.Add(codeMemberProperty);
                                break;
                            default:
                                newPKType.Members.Add(codeGenerationHelper.CreateField(pkMapFromDbType, pkPropertyName));
                                break;
                        }
                    }

                    newPKType.CustomAttributes.Add(new CodeAttributeDeclaration("Serializable"));
                    newPKType.CustomAttributes.Add(new CodeAttributeDeclaration("Validate"));
                    newPKType.CustomAttributes.Add(new CodeAttributeDeclaration("DataContract"));
                    foreach (var member in newPKType.Members)
                    {
                        if (member is CodeMemberProperty)
                        {
                            CodeMemberProperty property = (CodeMemberProperty)member;
                            CodeAttributeArgument[] arguments =
                                new CodeAttributeArgument[]
                         {
                            new CodeAttributeArgument("Name",new CodePrimitiveExpression(dataContractCount.ToString())),
                            new CodeAttributeArgument("Order",new CodePrimitiveExpression(dataContractCount++))
                         };
                            property.CustomAttributes.Add(new CodeAttributeDeclaration("DataMember", arguments));
                        }
                    }
                }
            }

            // create normal columns
            foreach (var columnDetail in normalColumns)
            {
                string propertyName = columnDetail.ColumnName.GetPreferenceFormattedText(applicationPreferences);
                Type mapFromDbType = mapper.MapFromDBType(columnDetail.DataType, columnDetail.DataLength, columnDetail.DataPrecision, columnDetail.DataScale);
                if(FiendInTableReference(columnDetail)) continue;
                switch (applicationPreferences.FieldGenerationConvention)
                {
                    case FieldGenerationConvention.Property:
                        newType.Members.Add(codeGenerationHelper.CreateProperty(mapFromDbType, propertyName.MakeFirstCharUpperCase()));
                        newType.Members.Add(codeGenerationHelper.CreateField(mapFromDbType, propertyName.MakeFirstCharLowerCase()));
                        break;
                    case FieldGenerationConvention.AutoProperty:
                        propertyName = columnDetail.ColumnName.GetFormattedText();
                        var codeMemberProperty = codeGenerationHelper.CreateAutoProperty(mapFromDbType, propertyName);
                        newType.Members.Add(codeMemberProperty);
                        break;
                    default:
                        newType.Members.Add(codeGenerationHelper.CreateField(mapFromDbType, propertyName));
                        break;
                }
            }

            // create detail member if exist
            if(tableReferences != null && tableReferences.Count > 0)
            {
                foreach (KeyValuePair<string, TableReference> pair in tableReferences)
                {
                    TableReference reference = pair.Value;
                    string refTable = GlobalCache.Instance.ReplaceShortWords(reference.ReferenceTable);
                    switch(reference.ReferenceType)
                    {
                        case ReferenceType.OneToMany:
                            refTable = refTable.GetFormattedText();
                            var detailListMemberProperty = codeGenerationHelper.CreateAutoProperty("IList<" + refTable + ">", refTable + "s");
                            newType.Members.Add(detailListMemberProperty);
                            break;
                        case ReferenceType.ManyToOne:
                            refTable = refTable.GetFormattedText();
                            var masterMemberProperty = codeGenerationHelper.CreateAutoProperty(refTable, refTable);
                            newType.Members.Add(masterMemberProperty);
                            break;
                    }
                }
            }

            var constructor = new CodeConstructor {Attributes = MemberAttributes.Public};
            newType.Members.Add(constructor);
            newType.CustomAttributes.Add(new CodeAttributeDeclaration("Serializable"));
            newType.CustomAttributes.Add(new CodeAttributeDeclaration("Validate"));
            newType.CustomAttributes.Add(new CodeAttributeDeclaration("DataContract"));
            foreach (var member in newType.Members)
            {
                if(member is CodeMemberProperty)
                {
                    CodeMemberProperty property = (CodeMemberProperty) member;
                    CodeAttributeArgument[] arguments = 
                        new CodeAttributeArgument[]
                         {
                            new CodeAttributeArgument("Name",new CodePrimitiveExpression(dataContractCount.ToString())),
                            new CodeAttributeArgument("Order",new CodePrimitiveExpression(dataContractCount++))
                         };
                    property.CustomAttributes.Add(new CodeAttributeDeclaration("DataMember",arguments));
                }
            }
            
            pkClass = pkCompileUnit;
            return compileUnit;
        }

        private bool FiendInTableReference(ColumnDetail detail)
        {
            if(tableReferences == null || tableReferences.Count == 0) return false;
            foreach (KeyValuePair<string, TableReference> pair in tableReferences)
            {
                Dictionary<ColumnDetail,ColumnDetail> columns = pair.Value.TableColumns;
                foreach (KeyValuePair<ColumnDetail, ColumnDetail> dictionary in columns)
                {
                    if(dictionary.Key.ColumnName.Equals(detail.ColumnName)) return true;
                }
            }
            return false;
        }

        private void WriteToFile(CodeCompileUnit compileUnit, string className)
        {
            var provider = GetCodeDomProvider();
            
            string sourceFile = GetCompleteFilePath(provider, className);
            using (provider)
            {
                var streamWriter = new StreamWriter(sourceFile);
                var textWriter = new IndentedTextWriter(streamWriter, "    ");
                using (textWriter)
                {
                    using (streamWriter)
                    {
                        var options = new CodeGeneratorOptions {BlankLinesBetweenMembers = true,VerbatimOrder = false};
                        provider.GenerateCodeFromCompileUnit(compileUnit, textWriter, options);
                        
                    }
                }
            }
            // write extra methods
            WriteExtraMethods(sourceFile,className);
            CleanupGeneratedFile(sourceFile);
        }

        private static void WriteExtraMethods(string sourceFile,string className)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
            string baseDir = System.IO.Path.GetDirectoryName(a.Location);
            string extraMethodPath = baseDir + "\\" + "ExtraMethodsTemplate.txt";
            string extraContent;
            string sourceContent;
            using(var reader = new StreamReader(extraMethodPath))
            {
                extraContent = reader.ReadToEnd();
            }
            extraContent = extraContent.Replace("ClassNameTemplate", className);
            
            using (var reader = new StreamReader(sourceFile))
            {
                sourceContent = reader.ReadToEnd();
            }

            // find the position of end class ( not end namespace )
            int insertPos = sourceContent.LastIndexOf("}")-1;
            string tempContent = sourceContent.Substring(0, insertPos - 1);
            insertPos = tempContent.LastIndexOf("}") - 1;

            sourceContent = sourceContent.Insert(insertPos, extraContent + "\r\n");
            using (var writer = new StreamWriter(sourceFile))
            {
                writer.Write(sourceContent);
            }

        }

        private static void CleanupGeneratedFile(string sourceFile)
        {
            string entireContent;
            using (var reader = new StreamReader(sourceFile))
            {
                entireContent = reader.ReadToEnd();
            }
            entireContent = RemoveComments(entireContent);
            entireContent = AddStandardHeader(entireContent);
            entireContent = FixAutoProperties(entireContent);
            
            using (var writer = new StreamWriter(sourceFile))
            {
                writer.Write(entireContent);
            }
        }

        // Hack : Auto property generator is not there in CodeDom.
        private static string FixAutoProperties(string entireContent)
        {
            entireContent = entireContent.Replace(@"get {
            }", "get;");
            entireContent = entireContent.Replace(@"set {
            }", "set;");
            return entireContent;
        }

        private static string AddStandardHeader(string entireContent)
        {
            entireContent = "using Caliburn.PresentationFramework.Behaviors; \n" + entireContent;
            entireContent = "using System.Runtime.Serialization; \n" + entireContent;
            entireContent = "using System.Collections.Generic; \n" + entireContent;
            entireContent = "using System.Text; \n" + entireContent;
            entireContent = "using System; \n" + entireContent;
            return entireContent;
        }

        private static string RemoveComments(string entireContent)
        {
            int end = entireContent.LastIndexOf("----------");
            entireContent = entireContent.Remove(0, end + 10);
            return entireContent;
        }

        private string GetCompleteFilePath(CodeDomProvider provider, string className)
        {
            var fileName = filePath + className;
            return provider.FileExtension[0] == '.'
                       ? fileName + provider.FileExtension
                       : fileName + "." + provider.FileExtension;
        }

        private CodeDomProvider GetCodeDomProvider()
        {
            return language == Language.CSharp ? (CodeDomProvider) new CSharpCodeProvider() : new VBCodeProvider();
        }
    }
}