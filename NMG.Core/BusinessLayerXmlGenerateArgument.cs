using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class BusinessLayerXmlGenerateArgument  : IGenerateArgument
    {
        public string Namespace { get; set; }
        public string DaoNamespace { get; set; }
        public string BusinessAssemblyName { get; set; }
        public ArrayList BusinessNamesList { get; set; }


        public BusinessLayerXmlGenerateArgument(string _namespace, string daoNamespace,string businessAssemblyName, ArrayList daoNamesList)
        {
            Namespace = _namespace;
            DaoNamespace = daoNamespace;
            BusinessAssemblyName = businessAssemblyName;
            BusinessNamesList = daoNamesList;
        }
    }
    
}
