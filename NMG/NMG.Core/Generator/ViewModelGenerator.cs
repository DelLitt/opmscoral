using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            XDocument xDocument = XDocument.Load(fileName);
            var methodNames = from c in xDocument.Descendants("Button")
                              select (string)c.Attribute("Name");

            var fieldNames = from c in xDocument.Descendants("TextBox")
                             select (string)c.Attribute("Name");
            var listNames = from c in xDocument.Descendants("ComboBox")
                            select (string)c.Attribute("Name");
            var detailList = from c in xDocument.Descendants("DataGrid")
                             select (string)c.Attribute("Name");
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
