using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Linq;

namespace NMG.Core.Generator
{
    public class ViewModelGenerator : IGenerator
    {

        public ViewModelPreferences ViewModelPreferences { get; set; }
         public ViewModelGenerator(ViewModelPreferences businessClassPreferences)
        {
            ViewModelPreferences = businessClassPreferences;
        }

        public void Generate()
        {
            IList<string> viewsList = GetViewList(ViewModelPreferences.ViewObjectLookupPath);

            foreach (string fileName in viewsList)
            {
                GenerateFile(fileName);
                
            }
        }

        private void GenerateFile(string fileName)
        {
            string className = fileName.Substring(fileName.LastIndexOf(@"\")+1);
            string viewPath = fileName.Substring(0, fileName.LastIndexOf(@"\"));
            if(className.EndsWith(".xaml"))
            {
                className = className.Substring(0, className.IndexOf(".xaml"));
                if(className.EndsWith("View"))
                {
                    className = className.Replace("View", "ViewModel");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            
            XDocument xDocument = XDocument.Load(fileName);
            /*foreach (XElement element in xDocument.Descendants())
            {
                Console.WriteLine(element.Name.LocalName);
            }*/

            var methodNames = from button in xDocument.Descendants()
                              where button.Name.LocalName.Equals("Button")
                              select (string)button.Attribute("Name").Value;

            var fieldNames = from textBox in xDocument.Descendants()
                             where textBox.Name.LocalName.Equals("TextBox")
                             select (string)textBox.Attribute("Name").Value;
            var listNames = from comboBox in xDocument.Descendants()
                            where comboBox.Name.LocalName.Equals("ComboBox")
                            select (string)comboBox.Attribute("Name").Value;
            var detailList = from dataGrid in xDocument.Descendants()
                             where dataGrid.Name.LocalName.Equals("DataGrid")
                             select (string)dataGrid.Attribute("Name").Value;

            string interfaceName = "I" + className;
            string namespaceName = viewPath.Substring(viewPath.IndexOf(ViewModelPreferences.ViewModelAssembly));
            namespaceName = namespaceName.Replace(@"\", ".");
            namespaceName = namespaceName.Replace(@"View", "ViewModel");
            ViewModelGenerateArgument argument = new ViewModelGenerateArgument
                                                     (
                                                         className,
                                                         namespaceName,
                                                         ConvertToArrayList(fieldNames),
                                                         ConvertToArrayList(methodNames),null,null
                                                     );
            string source = ViewModelInterfaceTemplate.Transform(argument);
            string saveViewModelPath = ViewModelPreferences.ViewModelGeneratePath + @"\" + namespaceName.Replace(".", @"\");
            WriteToFile(interfaceName, source, saveViewModelPath);

            ViewModelGenerateArgument classArgument = new ViewModelGenerateArgument
                                                     (
                                                         className,
                                                         namespaceName,
                                                         ConvertToArrayList(fieldNames),
                                                         ConvertToArrayList(methodNames), 
                                                         ConvertToArrayList(detailList),
                                                         ConvertToArrayList(listNames)
                                                     );
            source = ViewModelClassTemplate.Transform(classArgument);
            WriteToFile(className,source,saveViewModelPath);

        }

        private ArrayList ConvertToArrayList(IEnumerable<string> enumerable)
        {
            IEnumerator enumerator = enumerable.GetEnumerator();
            ArrayList list = new ArrayList();
            while(enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }
            return list;
        }

        private void WriteToFile(string objectName, string source,string viewPath)
        {
            EnsurePathExist(viewPath);
            string fileName = viewPath + @"\" + objectName + @".cs";
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(source);
                writer.Flush();
                writer.Close();
            }
        }

        private void EnsurePathExist(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private IList<string> GetViewList(string path)
        {
            IList<string> list = new List<string>();

            string[] xamlFiles = Directory.GetFiles(path, "*.xaml", SearchOption.AllDirectories);
            foreach (var xamlFile in xamlFiles)
            {
                list.Add(xamlFile);
            }
            return list;
        }
    }
}
