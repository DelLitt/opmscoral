using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMG.Core
{
    public class ViewModelPreferences
    {
        public string ViewObjectLookupPath { get; set; }
        public string ViewModelGeneratePath { get; set; }
        public string ViewModelNamespaceName { get; set; }
        public string ViewModelAssembly { get; set; }

        public ViewModelPreferences(string viewObjectLookup, string viewModelGenPath, string viewModelNamespace, string viewModelAssembly)
        {
            ViewObjectLookupPath = viewObjectLookup;
            ViewModelGeneratePath = viewModelGenPath;
            ViewModelNamespaceName = viewModelNamespace;
            ViewModelAssembly = viewModelAssembly;
        }
    }
}
