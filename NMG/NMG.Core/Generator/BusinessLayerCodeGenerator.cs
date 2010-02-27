using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core.Generator
{
    public class BusinessLayerCodeGenerator : IGenerator
    {
        public BusinessClassPreferences BusinessClassPreferences { get; set; }
        public BusinessLayerCodeGenerator(BusinessClassPreferences businessClassPreferences)
        {
            BusinessClassPreferences = businessClassPreferences;
        }
        public void Generate()
        {
            string[] objectFiles = Directory.GetFiles(BusinessClassPreferences.ModelObjectLookupPath);
            foreach (string objectFile in objectFiles)
            {
                string objectName = GetObjectName(objectFile);
                if(objectName.EndsWith("PK")) continue;
                BusinessGenerateArgument daoGenerateArgument =
                    new BusinessGenerateArgument(objectName, 
                                                 BusinessClassPreferences.BusinessNamespaceName, 
                                                 BusinessClassPreferences.ModelNamespaceName,
                                                 BusinessClassPreferences.DaoNamespaceName);
                // generate interface code
                string source = BusinessLayerInterfaceTemplate.Transform(daoGenerateArgument);
                WriteToFile(InterfaceName(objectName),source);
                source = BusinessLayerClassTemplate.Transform(daoGenerateArgument);
                WriteToFile(objectName,source);
                
            }
        }

        private string InterfaceName(string name)
        {
            return "I" + name;
        }

        private void WriteToFile(string objectName,string source)
        {
            string fileName = BusinessClassPreferences.BusinessGeneratePath + @"\" + objectName + @"Logic" + @".cs";
            using(var writer = new StreamWriter(fileName))
            {
                writer.Write(source);
                writer.Flush();
                writer.Close();
            }
        }

        private string GetObjectName(string objectFile)
        {
            string temp = objectFile.Substring(objectFile.LastIndexOf(@"\") + 1);
            return temp.Substring(0, temp.IndexOf("."));
        }
    }
}
