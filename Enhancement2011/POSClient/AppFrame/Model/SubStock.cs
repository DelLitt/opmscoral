using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    public class SubStock
    {
        #region Member Variables

        protected Int64 _stockId; 		
        protected Int64 _quantity;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Product _product;

        #endregion

        #region Constructors

        public SubStock() 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual Int64 GoodQuantity { get; set; }
        public virtual Int64 DamageQuantity { get; set; }
        public virtual Int64 ErrorQuantity { get; set; }
        public virtual Int64 LostQuantity { get; set; }
        public virtual Int64 UnconfirmQuantity { get; set; }

        public virtual Int64 OldGoodQuantity { get; set; }
        public virtual Int64 OldDamageQuantity { get; set; }
        public virtual Int64 OldErrorQuantity { get; set; }
        public virtual Int64 OldLostQuantity { get; set; }
        public virtual Int64 OldUnconfirmQuantity { get; set; }

        public virtual Int64 SubStockId
        {
            get
            {
                return _stockId;
            }
            set
            {
                _stockId = value;
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

        public virtual ProductMaster ProductMaster { get; set; }
    }
}
