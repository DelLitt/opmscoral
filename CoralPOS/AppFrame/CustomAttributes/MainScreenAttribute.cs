using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MainScreenAttribute : Attribute
    {
        private Type _clazz;
        public MainScreenAttribute(Type _clazz)
        {
            
        }

        public Type MainScreen
        {
            get
            {
                return _clazz;
            }
        }
    }
}
