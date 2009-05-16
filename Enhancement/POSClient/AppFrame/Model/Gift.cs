using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Gift
    /// <summary>
    /// Gift object for NHibernate mapped table 'gift'.
    /// </summary>
    [Serializable]
    public class Gift : System.IComparable
    {
        #region Member Variables

        protected Int64 _giftId;
        protected Int64 _departmentId;
        protected string _giftName;
        protected Int64 _quantity;
        protected Int64 _supplierId;
        protected Int64 _price;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // PurchaseOrderPromotion
        protected IList _purchaseOrderPromotions = new ArrayList();

        #endregion

        #region Constructors

        public Gift()
        {
        }

        #endregion

        #region Public Properties
        public virtual GiftPK GiftPK { get; set; }
        public virtual Int64 GiftId
        {
            get
            {
                return _giftId;
            }
            set
            {
                _giftId = value;
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

        public virtual string GiftName
        {
            get
            {
                return _giftName;
            }
            set
            {
                _giftName = value;
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
        public virtual Int64 SupplierId
        {
            get
            {
                return _supplierId;
            }
            set
            {
                _supplierId = value;
            }
        }
        public virtual Int64 Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
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