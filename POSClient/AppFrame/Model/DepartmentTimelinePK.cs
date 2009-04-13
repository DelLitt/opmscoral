using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    public class DepartmentTimelinePK
    {
        public virtual long DepartmentId {
            get;
            set;}
        public virtual long Period { get; set; }

        #region Equals and GetHashCode Methods
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
