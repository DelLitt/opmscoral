using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using NMG.Core;
using NMG.Core.Domain;

namespace NHibernateMappingGenerator
{
    [Serializable]
    public class ApplicationSettings
    {
        public string TablePreferencesFile { get; set;}
        public string ConnectionString { get; set; }
        public ServerType ServerType { get; set; }
        public string NameSpace { get; set; }
        public string AssemblyName { get; set; }

        public string ProjectName { get; set; }
        public string ModelPathForDao { get; set; }
        public string DataLayerPath { get; set; }
        public string ModelLookupPath { get; set; }
        public string DataLayerNameSpace { get; set; }
        public string DataLayerAssembly { get; set; }

        public string ModelPathForBusiness { get; set; }
        public string BusinessGeneratePath { get; set; }
        public string BusinessNamespaceName { get; set; }
        public string BusinessAssembly { get; set; }
        public string ModelNamespaceForBusiness { get; set; }
        public string DaoNamespaceForBusiness { get; set; }

        public string ViewLookupDir { get; set; }
        public string ViewModelGeneratePath { get; set; }
        public string ViewModelNamespaceName { get; set; }
        public string ViewModelAssemblyName { get; set; }

        public Language Language { get; set; }
        public bool IsFluent { get; set; }
        public FieldGenerationConvention FieldGenerationConvention { get; set; }
        public FieldNamingConvention FieldNamingConvention {get;set;}

        public ApplicationSettings()
        {
        }

        public ApplicationSettings(string connectionString, ServerType serverType, string nameSpace, string assemblyName)
        {
            ConnectionString = connectionString;
            ServerType = serverType;
            NameSpace = nameSpace;
            AssemblyName = assemblyName;
        }

        public void Save()
        {
            var streamWriter = new StreamWriter(Application.LocalUserAppDataPath + @"\nmg.config", false);
            XmlSerializer xmlSerializer;
            using (streamWriter)
            {
                xmlSerializer = new XmlSerializer(typeof (ApplicationSettings));
                xmlSerializer.Serialize(streamWriter, this);
            }
        }

        public void Save(string path)
        {
            string projectPath = EnsureProjectPath(path);

            var streamWriter = new StreamWriter(projectPath + @"\" + ProjectName + ".nmprj", false);
            XmlSerializer xmlSerializer;
            using (streamWriter)
            {
                xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
                xmlSerializer.Serialize(streamWriter, this);
            }
        }
        public static ApplicationSettings Load()
        {
            ApplicationSettings appSettings = null;
            var xmlSerializer = new XmlSerializer(typeof (ApplicationSettings));
            var fi = new FileInfo(Application.LocalUserAppDataPath + @"\nmg.config");
            if (fi.Exists)
            {
                using (FileStream fileStream = fi.OpenRead())
                {
                    appSettings = (ApplicationSettings) xmlSerializer.Deserialize(fileStream);
                }
            }
            return appSettings;
        }

        public static ApplicationSettings Load(string filePath)
        {
            ApplicationSettings appSettings = null;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
                var fi = new FileInfo(filePath); //#+ @"\nmg.nmprj");
                if (fi.Exists)
                {
                    using (FileStream fileStream = fi.OpenRead())
                    {
                        appSettings = (ApplicationSettings)xmlSerializer.Deserialize(fileStream);
                    }
                }
            }
            catch (Exception)
            {

            }
            return appSettings;
        }

        public void SaveTablePreferencesSetting(string path, List<ApplicationPreferences> preferences)
        {

            string projectPath = EnsureProjectPath(path);

            //var streamWriter = File.Open(Application.LocalUserAppDataPath + @"\tablePrefs.obj", FileMode.Create);
            var streamWriter = File.Open(projectPath +@"\" + TablePreferencesFile, FileMode.Create);
            BinaryFormatter binaryFormatter;
            using (streamWriter)
            {
                binaryFormatter = new BinaryFormatter();
                TablePreferenceSettings tablePreferenceSettings = new TablePreferenceSettings
                {
                    TablePreferences = preferences
                };
                binaryFormatter.Serialize(streamWriter, tablePreferenceSettings);
            }
            
        }

        private string EnsureProjectPath(string path)
        {
            string projectPath = path;
            if (!Directory.Exists(projectPath))
            {
                Directory.CreateDirectory(projectPath);
            }
            if (!string.IsNullOrEmpty(ProjectName))
            {
                projectPath = path + "\\" + ProjectName;
                if (!Directory.Exists(projectPath))
                {
                    Directory.CreateDirectory(projectPath);
                }
            }
            return projectPath;
        }
    }
}