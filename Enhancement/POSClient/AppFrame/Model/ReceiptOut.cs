using System;
using System.Collections;

namespace AppFrame.Model
{
    #region ReceiptOut
    /// <summary>
    /// ReceiptOut object for NHibernate mapped table 'receipt_out'.
    /// </summary>
    [Serializable]
    public class ReceiptOut : System.IComparable
    {
    	#region Member Variables

        protected Int64 _receiptOutId; 		
        protected Int64 _departmentId; 		
        protected Int64 _receiptOutName;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // ReceiptOutCost
        protected IList _receiptOutCosts = new ArrayList();

        #endregion

        #region Constructors

        public ReceiptOut () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual ReceiptOutPK ReceiptOutPK { get; set; }
        public virtual Int64 ReceiptOutId
        {
            get
            {
                return _receiptOutId;
            }
            set
            {
                _receiptOutId = value;
            }
        }
        public virtual Int64 DepartmentId
        {
            get
            {
                return _departmentId;
            }
            set
            {
                _departmentId = value;
            }
        }

        public virtual Int64 ReceiptOutName
        {
            get
            {
                return _receiptOutName;
            }
            set
            {
                _receiptOutName = value;
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

        
        // ReceiptOutCost
        public virtual IList ReceiptOutCosts
        {
            get
            {
                return _receiptOutCosts;
            }
            set
            {
                _receiptOutCosts = value;
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