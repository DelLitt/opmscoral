using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class BlockInCostPK
    {
        protected Int64 _blockId;
        protected Int64 _costType;

        public virtual Int64 BlockId
        {
            get
            {
                return _blockId;
            }
            set
            {
                _blockId = value;
            }
        }
        public virtual Int64 CostType
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
