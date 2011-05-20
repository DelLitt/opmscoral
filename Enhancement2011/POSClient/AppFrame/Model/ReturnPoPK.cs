using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class ReturnPoPK
    {
        public virtual string PurchaseOrderId
        {
            get;
            set;
        }
        public virtual Int64 PurchaseOrderDetailId
        {
            get;
            set;
        }
        public virtual Int64 DepartmentId
        {
            get;
            set;
        }
        public virtual DateTime CreateDate
        {
            get; 
            set;
        }

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
