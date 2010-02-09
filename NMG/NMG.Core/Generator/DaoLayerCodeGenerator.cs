using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core.Generator
{
    public class DaoLayerCodeGenerator : IGenerator
    {
        public DaoClassPreferences DaoClassPreferences { get; set; }
        public DaoLayerCodeGenerator(DaoClassPreferences daoClassPreferences)
        {
            DaoClassPreferences = daoClassPreferences;
        }
        public void Generate()
        {
            string[] objectFiles = Directory.GetFiles(DaoClassPreferences.DaoObjectLookupPath);
            foreach (string objectFile in objectFiles)
            {
                string objectName = GetObjectName(objectFile);
                if(objectName.EndsWith("PK")) continue;
                DaoGenerateArgument daoGenerateArgument = 
                    new DaoGenerateArgument(objectName,DaoClassPreferences.DaoNamespaceName,DaoClassPreferences.ModelNamespaceName);
                // generate interface code
                string source = HibernateDaoInterfaceTemplate.Transform(daoGenerateArgument);
                WriteToFile(InterfaceName(objectName),source);
                source = HibernateDaoClassTemplate.Transform(daoGenerateArgument);
                WriteToFile(objectName,source);
                
            }
        }

        private string InterfaceName(string name)
        {
            return "I" + name;
        }

        private void WriteToFile(string objectName,string source)
        {
            string fileName = DaoClassPreferences.DaoGeneratePath + @"\" + objectName + @"Dao" + @".cs";
            using(var writer = new StreamWriter(fileName))
            {
                writer.Write(source);
                writer.Flush();
                writer.Close();
            }
        }

        private string GetObjectName(string objectFile)
        {
            string temp = objectFile.Substring(objectFile.LastIndexOf("\\") + 1);
            return temp.Substring(0, temp.IndexOf("."));
        }
    }
}
