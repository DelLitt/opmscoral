using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class DataLayerXmlGenerateArgument  : IGenerateArgument
    {
        public string AssemblyName { get; set; }
        public string DaoAssemblyName { get; set; }
        public ArrayList DaoNamesList { get; set; }


        public DataLayerXmlGenerateArgument(string assemblyName, string daoAssemblyName, ArrayList daoNamesList)
        {
            AssemblyName = assemblyName;
            DaoAssemblyName = daoAssemblyName;
            DaoNamesList = daoNamesList;
        }
    }
    
}
