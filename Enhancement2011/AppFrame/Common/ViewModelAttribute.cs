using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class ViewModelAttribute
    {
        public Type AttachViewModel { get; set; }
        public ViewModelAttribute(Type type)
        {
            AttachViewModel = type;
        }
    }
}
