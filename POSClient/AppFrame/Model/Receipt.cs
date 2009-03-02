using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Receipt
    /// <summary>
    /// Receipt object for NHibernate mapped table 'receipt'.
    /// </summary>
    [Serializable]
    public class Receipt : System.IComparable
    {
    	#region Member Variables

        protected Int64 _receiptId; 		
        protected Int64 _departmentId; 		
        protected string _receiptName;
        protected string _receiptNumber;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected PurchaseOrder _purchaseOrder;

        #endregion

        #region Constructors

        public Receipt () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual ReceiptPK ReceiptPK { get; set; }
        public virtual Int64 ReceiptId
        {
            get
            {
                return _receiptId;
            }
            set
            {
                _receiptId = value;
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

        public virtual string ReceiptName
        {
            get
            {
                return _receiptName;
            }
            set
            {
                _receiptName = value;
            }
        }
        public virtual string ReceiptNumber
        {
            get
            {
                return _receiptNumber;
            }
            set
            {
                _receiptNumber = value;
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


        public virtual PurchaseOrder PurchaseOrder
        {
            get
            {
                return _purchaseOrder;
            }
            set
            {
                _purchaseOrder = value;
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