using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class BusinessGenerateArgument  : IGenerateArgument
    {
        public string ClassName { get; set; }
        public string NamespaceName { get; set; }
        public string ModelNamespaceName { get; set; }
        public string DaoNamespaceName { get; set; }

        public BusinessGenerateArgument(string className, string namespaceName, string modelNamespace,string daoNamespace)
        {
            ClassName = className;
            NamespaceName = namespaceName;
            ModelNamespaceName = modelNamespace;
            DaoNamespaceName = daoNamespace;
        }
    }
    
}
