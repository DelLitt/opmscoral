using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class DaoClassPreferences
    {
        public string DaoObjectLookupPath { get; set; }
        public string DaoGeneratePath { get; set; }
        public string DaoNamespaceName { get; set; }
        public string ModelNamespaceName { get; set; }
        public DaoClassPreferences(string daoObjectLookup,string daoGenPath,string daoNamespace,string modelNamespace)
        {
            DaoObjectLookupPath = daoObjectLookup;
            DaoGeneratePath = daoGenPath;
            DaoNamespaceName = daoNamespace;
            ModelNamespaceName = modelNamespace;
        }
    }
}
