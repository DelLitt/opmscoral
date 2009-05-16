using System;
using System.Collections;

namespace AppFrame.Model
{
    #region PurchaseOrderPromotion
    /// <summary>
    /// PurchaseOrderPromotion object for NHibernate mapped table 'purchase_order_promotion'.
    /// </summary>
    [Serializable]
    public class PurchaseOrderPromotion : System.IComparable
    {
    	#region Member Variables

        protected Int64 _purchaseOrderId; 		
        protected Int64 _purchaseOrderDetailId; 		
        protected Int64 _id; 		
        protected Int64 _departmentId; 		
        protected Int64 _giftProductId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected PurchaseOrderDetail _purchaseOrderDetail;
        protected Gift _gift;
        protected DepartmentPromotion _departmentPromotion;

        #endregion

        #region Constructors

        public PurchaseOrderPromotion () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual PurchaseOrderPromotionPK PurchaseOrderPromotionPK { get; set; }
        public virtual Int64 PurchaseOrderId
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
        public virtual Int64 Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
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

        public virtual Int64 GiftProductId
        {
            get
            {
                return _giftProductId;
            }
            set
            {
                _giftProductId = value;
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

        public virtual PurchaseOrderDetail PurchaseOrderDetail
        {
            get
            {
                return _purchaseOrderDetail;
            }
            set
            {
                _purchaseOrderDetail = value;
            }
        }

        public virtual Gift Gift
        {
            get
            {
                return _gift;
            }
            set
            {
                _gift = value;
            }
        }
        

        public virtual DepartmentPromotion DepartmentPromotion
        {
            get
            {
                return _departmentPromotion;
            }
            set
            {
                _departmentPromotion = value;
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