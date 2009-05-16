using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class BlockInDetailPK
    {
        protected Int64 _blockId;
        protected string _blockDetailId;

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
        public virtual string BlockDetailId
        {
            get
            {
                return _blockDetailId;
            }
            set
            {
                _blockDetailId = value;
            }
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
