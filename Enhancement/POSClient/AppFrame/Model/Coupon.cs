using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Coupon
    /// <summary>
    /// Coupon object for NHibernate mapped table 'coupon'.
    /// </summary>
    [Serializable]
    public class Coupon : System.IComparable
    {
        #region Member Variables

        protected Int64 _couponId;
        protected string _couponName;
        protected Int64 _discountValue;
        protected Int64 _discountPercent;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected CouponType _couponType;
        // PublishedCoupon
        protected IList _publishedCoupons = new ArrayList();

        #endregion

        #region Constructors

        public Coupon()
        {
        }

        #endregion

        #region Public Properties

        public virtual Int64 CouponId
        {
            get
            {
                return _couponId;
            }
            set
            {
                _couponId = value;
            }
        }

        public virtual string CouponName
        {
            get
            {
                return _couponName;
            }
            set
            {
                _couponName = value;
            }
        }
        public virtual Int64 DiscountValue
        {
            get
            {
                return _discountValue;
            }
            set
            {
                _discountValue = value;
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


        public virtual CouponType CouponType
        {
            get
            {
                return _couponType;
            }
            set
            {
                _couponType = value;
            }
        }


        // PublishedCoupon
        public virtual IList PublishedCoupons
        {
            get
            {
                return _publishedCoupons;
            }
            set
            {
                _publishedCoupons = value;
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