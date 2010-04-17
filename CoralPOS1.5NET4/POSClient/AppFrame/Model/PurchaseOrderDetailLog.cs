using System;
using System.Collections;

namespace AppFrame.Model
{
    #region PurchaseOrderDetailLog
    /// <summary>
    /// PurchaseOrderDetailLog object for NHibernate mapped table 'purchase_order_detail_log'.
    /// </summary>
    [Serializable]
    public class PurchaseOrderDetailLog : System.IComparable
    {
    	#region Member Variables

        protected Int64 _purchaseOrderDetailLogId; 		
        protected Int64 _departmentId; 		
        protected Int64 _purchaseOrderDetailId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;

        #endregion

        #region Constructors

        public PurchaseOrderDetailLog () 
        {
        }
        
        #endregion
        public virtual PurchaseOrderDetailLogPK PurchaseOrderDetailLogPK { get; set; }
        #region Public Properties

        public virtual Int64 PurchaseOrderDetailLogId
        {
            get
            {
                return _purchaseOrderDetailLogId;
            }
            set
            {
                _purchaseOrderDetailLogId = value;
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

        public virtual Int64 PurchaseOrderDetailId
        {
            get
            {
                return _purchaseOrderDetailId;
            }
            set
            {
                _purchaseOrderDetailId = value;
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