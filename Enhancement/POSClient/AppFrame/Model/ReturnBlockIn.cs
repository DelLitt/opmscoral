using System;
using System.Collections;

namespace AppFrame.Model
{
    #region ReturnBlockIn
    /// <summary>
    /// ReturnBlockIn object for NHibernate mapped table 'return_block_in'.
    /// </summary>
    [Serializable]
    public class ReturnBlockIn : System.IComparable
    {
    	#region Member Variables

        protected Int64 _blockInId; 		
        protected Int64 _blockDetailId; 		
        protected string _description;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;

        #endregion

        #region Constructors

        public ReturnBlockIn () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual ReturnBlockInPK ReturnBlockInPK { get; set; }
        public virtual Int64 BlockInId
        {
            get
            {
                return _blockInId;
            }
            set
            {
                _blockInId = value;
            }
        }
        public virtual Int64 BlockDetailId
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

        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public virtual DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }
        public virtual string CreateId
        {
            get
            {
                return _createId;
            }
            set
            {
                _createId = value;
            }
        }
        public virtual DateTime UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
            }
        }
        public virtual string UpdateId
        {
            get
            {
                return _updateId;
            }
            set
            {
                _updateId = value;
            }
        }
        public virtual Int64 ExclusiveKey
        {
            get
            {
                return _exclusiveKey;
            }
            set
            {
                _exclusiveKey = value;
            }
        }
        public virtual Int64 DelFlg
        {
            get
            {
                return _delFlg;
            }
            set
            {
                _delFlg = value;
            }
        }


        #endregion
        
        #region IComparable Methods
        
        public virtual int CompareTo(object obj)
        {
            return 0;
        }
        
        #endregion
        
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
    #endregion
}