using System;
using System.Collections;

namespace AppFrame.Model
{
    #region PurchaseOrderLog
    /// <summary>
    /// PurchaseOrderLog object for NHibernate mapped table 'purchase_order_log'.
    /// </summary>
    [Serializable]
    public class PurchaseOrderLog : System.IComparable
    {
    	#region Member Variables

        protected Int64 _purchaseOrderLogId; 		
        protected Int64 _departmentId; 		
        protected long _purchaseOrderId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;

        #endregion

        #region Constructors

        public PurchaseOrderLog () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual PurchaseOrderLogPK PurchaseOrderLogPK { get; set; }
        public virtual Int64 PurchaseOrderLogId
        {
            get
            {
                return _purchaseOrderLogId;
            }
            set
            {
                _purchaseOrderLogId = value;
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

        public virtual long PurchaseOrderId
        {
            get
            {
                return _purchaseOrderId;
            }
            set
            {
                _purchaseOrderId = value;
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