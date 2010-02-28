using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AttachMenuAttribute : Attribute
    {
        private Type _menuClass;
        public AttachMenuAttribute(Type menuClass)
        {
            _menuClass = menuClass;
        }

        public Type AttachMenu
        {
            get
            {
                return _menuClass;
            }
        }
    }
}
