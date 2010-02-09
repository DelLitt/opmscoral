using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class DaoGenerateArgument  : IGenerateArgument
    {
        public string ClassName { get; set; }
        public string NamespaceName { get; set; }
        public string ModelNamespaceName { get; set; }
        
        public DaoGenerateArgument(string className,string namespaceName,string modelNamespace)
        {
            ClassName = className;
            NamespaceName = namespaceName;
            ModelNamespaceName = modelNamespace;
        }
    }
    
}
