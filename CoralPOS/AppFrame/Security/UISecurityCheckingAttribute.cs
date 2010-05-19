using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Security
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UISecurityCheckingAttribute : Attribute
    {
        private bool shoudCheck = false;
        public UISecurityCheckingAttribute()
        {
            shoudCheck = true;
        }

        public bool ShouldCheck
        {
            get
            {
                return shoudCheck;
            }
        }
    }
}
