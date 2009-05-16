using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Customer
    /// <summary>
    /// Customer object for NHibernate mapped table 'customer'.
    /// </summary>
    [Serializable]
    public class Customer : System.IComparable
    {
    	#region Member Variables

        protected Int64 _customerId; 		
        protected string _customerName;
        protected Int64 _moneySpent;
        protected Int64 _buyCount;
        protected DateTime _nearestCome1;
        protected DateTime _nearestCome2;
        protected DateTime _nearestCome3;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected CustomerDetail _customerDetail;
        // PurchaseOrder
        protected IList _purchaseOrders = new ArrayList();

        #endregion

        #region Constructors

        public Customer () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
            }
        }

        public virtual string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
            }
        }
        public virtual Int64 MoneySpent
        {
            get
            {
                return _moneySpent;
            }
            set
            {
                _moneySpent = value;
            }
        }
        public virtual Int64 BuyCount
        {
            get
            {
                return _buyCount;
            }
            set
            {
                _buyCount = value;
            }
        }
        public virtual DateTime NearestCome1
        {
            get
            {
                return _nearestCome1;
            }
            set
            {
                _nearestCome1 = value;
            }
        }
        public virtual DateTime NearestCome2
        {
            get
            {
                return _nearestCome2;
            }
            set
            {
                _nearestCome2 = value;
            }
        }
        public virtual DateTime NearestCome3
        {
            get
            {
                return _nearestCome3;
            }
            set
            {
                _nearestCome3 = value;
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


        public virtual CustomerDetail CustomerDetail
        {
            get
            {
                return _customerDetail;
            }
            set
            {
                _customerDetail = value;
            }
        }
        
        
        // PurchaseOrder
        public virtual IList PurchaseOrders
        {
            get
            {
                return _purchaseOrders;
            }
            set
            {
                _purchaseOrders = value;
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