using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    public class RoleEqualityComparer : IEqualityComparer<Role>
    {

        #region IEqualityComparer<Role> Members

        public bool Equals(Role x, Role y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            string xName = x.Name;
            string yName = y.Name;
            return (xName.Equals(yName));
        }

        public int GetHashCode(Role obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
