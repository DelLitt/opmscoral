using System;
using System.Collections;

namespace AppFrame.Model
{
    #region StockIn
    /// <summary>
    /// StockIn object for NHibernate mapped table 'stock_in'.
    /// </summary>
    [Serializable]
    public class StockIn : System.IComparable
    {
    	#region Member Variables

        protected DateTime _stockInDate;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // StockInDetail
        protected IList _stockInDetails = new ArrayList();

        #endregion

        #region Constructors

        public StockIn () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual long StockInType { get; set; }
        public virtual string StockInId
        {
            get;
            set;
            
        }

        public virtual string Description
        {
            get;
            set;

        }

        public virtual DateTime StockInDate
        {
            get
            {
                return _stockInDate;
            }
            set
            {
                _stockInDate = value;
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

        
        // StockInDetail
        public virtual IList StockInDetails
        {
            get
            {
                return _stockInDetails;
            }
            set
            {
                _stockInDetails = value;
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