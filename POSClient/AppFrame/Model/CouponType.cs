using System;
using System.Collections;

namespace AppFrame.Model
{
    #region CouponType
    /// <summary>
    /// CouponType object for NHibernate mapped table 'coupon_type'.
    /// </summary>
    [Serializable]
    public class CouponType : System.IComparable
    {
    	#region Member Variables

        protected Int64 _couponTypeId; 		
        protected string _couponTypeName;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // Coupon
        protected IList _coupons = new ArrayList();

        #endregion

        #region Constructors

        public CouponType () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 CouponTypeId
        {
            get
            {
                return _couponTypeId;
            }
            set
            {
                _couponTypeId = value;
            }
        }

        public virtual string CouponTypeName
        {
            get
            {
                return _couponTypeName;
            }
            set
            {
                _couponTypeName = value;
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

        
        // Coupon
        public virtual IList Coupons
        {
            get
            {
                return _coupons;
            }
            set
            {
                _coupons = value;
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