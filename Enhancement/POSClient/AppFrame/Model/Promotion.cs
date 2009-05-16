using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Promotion
    /// <summary>
    /// Promotion object for NHibernate mapped table 'promotion'.
    /// </summary>
    [Serializable]
    public class Promotion : System.IComparable
    {
    	#region Member Variables

        protected Int64 _promotionId; 		
        protected string _promotionName;
        protected Int64 _discountPrice;
        protected Int64 _discountPercent;
        protected Int64 _promotionType;
        protected Int64 _giftProductId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // DepartmentPromotion
        protected IList _departmentPromotions = new ArrayList();

        #endregion

        #region Constructors

        public Promotion () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 PromotionId
        {
            get
            {
                return _promotionId;
            }
            set
            {
                _promotionId = value;
            }
        }

        public virtual string PromotionName
        {
            get
            {
                return _promotionName;
            }
            set
            {
                _promotionName = value;
            }
        }
        public virtual Int64 DiscountPrice
        {
            get
            {
                return _discountPrice;
            }
            set
            {
                _discountPrice = value;
            }
        }
        public virtual Int64 DiscountPercent
        {
            get
            {
                return _discountPercent;
            }
            set
            {
                _discountPercent = value;
            }
        }
        public virtual Int64 PromotionType
        {
            get
            {
                return _promotionType;
            }
            set
            {
                _promotionType = value;
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

        
        // DepartmentPromotion
        public virtual IList DepartmentPromotions
        {
            get
            {
                return _departmentPromotions;
            }
            set
            {
                _departmentPromotions = value;
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