using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.CustomAttributes
{
    public class SingletonAttribute : Attribute
    {
        private Type _type;
        private string _name;
        public SingletonAttribute(Type type)
        {
            _type = type;
        }
        public SingletonAttribute(string name, Type type)
        {
            _name = name;
            _type = type;
        }

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
