using System;
using System.Collections;
using System.Windows.Forms;

namespace AppFrame.Model
{
    #region PurchaseOrder
    /// <summary>
    /// PurchaseOrder object for NHibernate mapped table 'purchase_order'.
    /// </summary>
    [Serializable]
    public class PurchaseOrder : System.IComparable
    {
    	#region Member Variables

        protected string _purchaseOrderId; 		
        protected Int64 _departmentId; 		
        protected Int64 _purchasePrice;
        protected Int64 _orderStatus;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Customer _customer;
        // Receipt
        protected IList _receipts = new ArrayList();
        // PurchaseOrderDetail
        protected IList _purchaseOrderDetails = new ArrayList();

        #endregion

        #region Constructors

        public PurchaseOrder () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual PurchaseOrderPK PurchaseOrderPK { get; set; }
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

        public virtual string PurchaseOrderDescription
        {
            get; set;
            /*{
                string description = "";
                foreach (PurchaseOrderDetail purchaseOrderDetail in PurchaseOrderDetails)
                {
                    description+=purchaseOrderDetail.ProductMaster.ProductName + " " + Keys.Enter;                    

                }
                return description;
            }*/

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

        public virtual Int64 PurchasePrice
        {
            get
            {
                return _purchasePrice;
            }
            set
            {
                _purchasePrice = value;
            }
        }
        public virtual Int64 OrderStatus
        {
            get
            {
                return _orderStatus;
            }
            set
            {
                _orderStatus = value;
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


        public virtual Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }
        
        
        // Receipt
        public virtual IList Receipts
        {
            get
            {
                return _receipts;
            }
            set
            {
                _receipts = value;
            }
        }
        
        
        // PurchaseOrderDetail
        public virtual IList PurchaseOrderDetails
        {
            get
            {
                return _purchaseOrderDetails;
            }
            set
            {
                _purchaseOrderDetails = value;
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