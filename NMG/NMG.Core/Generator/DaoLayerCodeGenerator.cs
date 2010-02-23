using System;
using System.Collections;
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
            ArrayList daoNameList = new ArrayList();
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
                daoNameList.Add(DaoClassPreferences.DaoNamespaceName + "." + objectName);
            }
            DataLayerXmlGenerateArgument argument = new DataLayerXmlGenerateArgument(DaoClassPreferences.ModelNamespaceName,DaoClassPreferences.DaoNamespaceName,daoNameList);
            string dataXmlsource = DataLayerXmlTemplate.Transform(argument);
            string fileName = DaoClassPreferences.DaoGeneratePath + @"\DataLayer" + @".xml";
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(dataXmlsource);
                writer.Flush();
                writer.Close();
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
