using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AttachMenuAndMainScreenAttribute : Attribute
    {
        private Type _menuClass;
        private Type _mainScreen;
        public AttachMenuAndMainScreenAttribute(Type menuClass,Type mainScreen)
        {
            _menuClass = menuClass;
            _mainScreen = mainScreen;
        }

        public AttachMenuAndMainScreenAttribute(Type menuClass)
        {
            _menuClass = menuClass;
            _mainScreen = null;
        }

        public Type AttachMenu
        {
            get
            {
                return _menuClass;
            }
        }
        public Type MainScreen
        {
            get
            {
                return _mainScreen;
            }
        }
    }
}
