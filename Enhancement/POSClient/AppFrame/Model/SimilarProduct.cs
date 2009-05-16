using System;
using System.Collections;

namespace AppFrame.Model
{
    #region SimilarProduct
    /// <summary>
    /// SimilarProduct object for NHibernate mapped table 'similar_product'.
    /// </summary>
    [Serializable]
    public class SimilarProduct : System.IComparable
    {
    	#region Member Variables

        protected Int64 _baseProductId; 		
        protected Int64 _otherProductId; 		
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;

        #endregion

        #region Constructors

        public SimilarProduct () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 BaseProductId
        {
            get
            {
                return _baseProductId;
            }
            set
            {
                _baseProductId = value;
            }
        }
        public virtual Int64 OtherProductId
        {
            get
            {
                return _otherProductId;
            }
            set
            {
                _otherProductId = value;
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