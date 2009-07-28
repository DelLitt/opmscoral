using System;
using System.Collections;

namespace AppFrame.Model
{
    #region StockInDetail
    /// <summary>
    /// StockInDetail object for NHibernate mapped table 'stock_in_detail'.
    /// </summary>
    [Serializable]
    public class StockInDetail : System.IComparable
    {
    	#region Member Variables

        public enum StockInStatus
        {
            IMPORTED = 1, COMPLETELY_STOCKED, PARTIAL_STOCK, RETURNED_FROM_DEPT
        } ;

        protected Int64 _stockInId; 		
        protected string _productId; 		
        protected Int64 _quantity;
        protected Int64 _price;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected StockIn _stockIn;
        protected Product _product;

        #endregion

        #region Constructors

        public StockInDetail () 
        {
        }
        
        #endregion

        #region Public Properties
        
        public virtual StockInDetailPK StockInDetailPK { get; set; }
        public virtual Int64 SellPrice { get; set; }
        public virtual Int64 StockInType { get ; set ;}
        public virtual Int64 OldQuantity { get; set; }
        public virtual Int64 StockOutQuantity { get; set; }
        public virtual Int64 ReStockQuantity { get; set; }
        public virtual Int64 WholeSalePrice { get; set; }
        public virtual Int64 StockInId
        {
            get
            {
                return _stockInId;
            }
            set
            {
                _stockInId = value;
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

        public virtual StockIn StockIn
        {
            get
            {
                return _stockIn;
            }
            set
            {
                _stockIn = value;
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
        public virtual DepartmentPrice DepartmentPrice { get; set; }
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
    #endregion
}