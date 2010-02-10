using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class BusinessClassPreferences
    {
        public string ModelObjectLookupPath { get; set; }
        public string BusinessGeneratePath { get; set; }
        public string BusinessNamespaceName { get; set; }
        public string ModelNamespaceName { get; set; }
        public string DaoNamespaceName { get; set; }

        public BusinessClassPreferences(string modelObjectLookup, string businessGenPath, string businessNamespace, string modelNamespace,string daoNamespace)
        {
            ModelObjectLookupPath = modelObjectLookup;
            BusinessGeneratePath = businessGenPath;
            BusinessNamespaceName = businessNamespace;
            ModelNamespaceName = modelNamespace;
            DaoNamespaceName = daoNamespace;
        }
    }
}
