using System;
using System.Collections;

namespace AppFrame.Model
{
    #region PurchaseOrderDetail
    /// <summary>
    /// PurchaseOrderDetail object for NHibernate mapped table 'purchase_order_detail'.
    /// </summary>
    [Serializable]
    public class PurchaseOrderDetail : System.IComparable
    {
    	#region Member Variables

        protected string _purchaseOrderId; 		
        protected Int64 _purchaseOrderDetailId;
        protected Int64 _departmentId;
        protected Product _product;
        protected Int64 _quantity;
        protected Int64 _onStorePrice;
        protected Int64 _purchaseStatus;
        protected Int64 _purchaseType;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected PurchaseOrder _purchaseOrder;
        // PurchaseOrderPromotion
        protected IList _purchaseOrderPromotions = new ArrayList();
        protected Tax _tax;
        

        #endregion

        #region Constructors

        public PurchaseOrderDetail () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual PurchaseOrderDetailPK PurchaseOrderDetailPK { get; set; }
        
        public virtual string PurchaseOrderId
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

        public virtual Int64 Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public virtual Int64 Price
        {
            get
            {
                return _onStorePrice;
            }
            set
            {
                _onStorePrice = value;
            }
        }
        public virtual Int64 PurchaseStatus
        {
            get
            {
                return _purchaseStatus;
            }
            set
            {
                _purchaseStatus = value;
            }
        }
        public virtual Int64 PurchaseType
        {
            get
            {
                return _purchaseType;
            }
            set
            {
                _purchaseType = value;
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
        
        // PurchaseOrderPromotion
        public virtual IList PurchaseOrderPromotions
        {
            get
            {
                return _purchaseOrderPromotions;
            }
            set
            {
                _purchaseOrderPromotions = value;
            }
        }
        

        public virtual Tax Tax
        {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
            }
        }
        

        public virtual Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual string Note { get; set; }
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