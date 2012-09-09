using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
    public class AutowiredAttribute : Attribute
    {
        private bool _required;

        public AutowiredAttribute(bool required = false)
        {
            _required = required;
        }

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }
    }
}
