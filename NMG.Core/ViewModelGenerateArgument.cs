using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class ViewModelGenerateArgument  : IGenerateArgument
    {
        public string ClassName { get; set; }
        public string NamespaceName { get; set; }
        public ArrayList FieldNames { get; set; }
        public ArrayList MethodNames { get; set; }
        public ArrayList DetailList { get; set; }
        public ArrayList ListName { get; set; }

        public ViewModelGenerateArgument(string className, string namespaceName, ArrayList fieldNames, ArrayList methodNames,ArrayList detailList,ArrayList listNames)
        {
            ClassName = className;
            NamespaceName = namespaceName;
            FieldNames = fieldNames;
            MethodNames = methodNames;
            DetailList = detailList;
            ListName = listNames;
        }
    }
    
}
