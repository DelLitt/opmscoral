using System;
using System.Collections;

namespace AppFrame.Model
{
    #region DepartmentStock
    /// <summary>
    /// DepartmentStock object for NHibernate mapped table 'department_stock'.
    /// </summary>
    [Serializable]
    public class DepartmentStockTemp : System.IComparable
    {
    	#region Member Variables

        protected Int64 _departmentId; 		
        protected string _productId; 		
        protected Int64 _quantity;
        protected Int64 _onStorePrice;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Product _product;

        #endregion

        #region Constructors

        public DepartmentStockTemp () 
        {
        }

        
        #endregion

        #region Public Properties

		public virtual DepartmentStockTempPK DepartmentStockTempPK { get; set; }
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
        public virtual string ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
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
        public virtual Int64 OnStorePrice
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
        /*public virtual DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }*/
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
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual long Fixed { get; set; }
        public virtual long TempSave { get; set; }
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