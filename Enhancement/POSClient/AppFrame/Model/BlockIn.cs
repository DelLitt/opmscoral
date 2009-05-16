using System;
using System.Collections;

namespace AppFrame.Model
{
    #region BlockIn
    /// <summary>
    /// BlockIn object for NHibernate mapped table 'block_in'.
    /// </summary>
    /// 
    [Serializable]
    public class BlockIn : System.IComparable
    {
    	#region Member Variables

        protected Int64 _blockId; 		
        protected string _blockName;
        protected DateTime _importDate;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // BlockInDetail
        protected IList _blockInDetails = new ArrayList();
        // BlockInCost
        protected IList _blockInCosts = new ArrayList();

        #endregion

        #region Constructors

        public BlockIn () 
        {
        }
        
        #endregion

        #region Public Properties

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

        public virtual string BlockName
        {
            get
            {
                return _blockName;
            }
            set
            {
                _blockName = value;
            }
        }
        public virtual DateTime ImportDate
        {
            get
            {
                return _importDate;
            }
            set
            {
                _importDate = value;
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

        
        // BlockInDetail
        public virtual IList BlockInDetails
        {
            get
            {
                return _blockInDetails;
            }
            set
            {
                _blockInDetails = value;
            }
        }
        
        
        // BlockInCost
        public virtual IList BlockInCosts
        {
            get
            {
                return _blockInCosts;
            }
            set
            {
                _blockInCosts = value;
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