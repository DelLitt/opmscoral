using System;
using System.Collections;

namespace AppFrame.Model
{
    #region DepartmentPromotion
    /// <summary>
    /// DepartmentPromotion object for NHibernate mapped table 'department_promotion'.
    /// </summary>
    [Serializable]
    public class DepartmentPromotion : System.IComparable
    {
    	#region Member Variables

        protected Int64 _departmentPromotionId; 		
        protected long _departmentId;
        protected DateTime _startDate;
        protected DateTime _endDate;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Promotion _promotion;
        // PurchaseOrderPromotion
        protected IList _purchaseOrderPromotions = new ArrayList();
        protected Product _product;

        #endregion

        #region Constructors

        public DepartmentPromotion () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 DepartmentPromotionId
        {
            get
            {
                return _departmentPromotionId;
            }
            set
            {
                _departmentPromotionId = value;
            }
        }

        public virtual long DepartmentId
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
        public virtual DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
        public virtual DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
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


        public virtual Promotion Promotion
        {
            get
            {
                return _promotion;
            }
            set
            {
                _promotion = value;
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