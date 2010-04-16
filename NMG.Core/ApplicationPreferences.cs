using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using NMG.Core.Domain;

namespace NMG.Core
{
    [Serializable]
    public class ApplicationPreferences
    {
        public string FolderPath { get; set; }
        public string TableName { get; set; }
        public string NameSpace { get; set; }
        public string AssemblyName { get; set; }
        public string Sequence { get; set; }
        public bool IsFluent { get; set; }
        public string Prefix { get; set; }
        public PrimaryKeyType PrimaryKeyType { get; set; }
        
        [XmlArray]
        public ArrayList DetailTable { get; set; }
        public string MasterTable { get; set; }
        
        public Dictionary<string, TableReference> TableReferences { get; set; }
        
        public Language Language { get; set; }
        public ServerType ServerType { get; set; }
        public FieldNamingConvention FieldNamingConvention { get; set; }
        public FieldGenerationConvention FieldGenerationConvention { get; set; }

        public ApplicationPreferences()
        {
            FieldNamingConvention = FieldNamingConvention.SameAsDatabase;
            FieldGenerationConvention = FieldGenerationConvention.Field;
            Prefix = string.Empty;
        }

        
    }
    public enum PrimaryKeyType
    {
        Sequence,
        Assigned,
        Autonumber
    }
}