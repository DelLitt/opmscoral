using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewAttribute
    {
        private Type ViewScreen { get; set; }
        public ViewAttribute(Type type)
        {
            ViewScreen = type;
        }
    }
}
