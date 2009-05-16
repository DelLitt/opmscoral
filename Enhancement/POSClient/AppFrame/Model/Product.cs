using System;
using System.Collections;
using AppFrame.Common;

namespace AppFrame.Model
{
    #region Product
    /// <summary>
    /// Product object for NHibernate mapped table 'product'.
    /// </summary>
    [Serializable]
    public class Product : System.IComparable
    {
    	#region Member Variables

        protected string _productId; 
		
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected BlockInDetail _blockInDetail;
        protected ProductMaster _productMaster;
        // StockOutDetail
        protected IList _stockOutDetails = new ArrayList();
        // StockInDetail
        protected IList _stockInDetails = new ArrayList();
        // Stock
        protected IList _stocks = new ArrayList();
        // DepartmentStockOutDetail
        protected IList _departmentStockOutDetails = new ArrayList();
        // DepartmentStockInDetail
        protected IList _departmentStockInDetails = new ArrayList();
        // DepartmentPromotion
        protected IList _departmentPromotions = new ArrayList();
        // DepartmentStock
        protected IList _departmentStocks = new ArrayList();
        // PurchaseOrderDetail
        protected IList _purchaseOrderDetails = new ArrayList();
        protected string _productFullName;
        #endregion

        #region Constructors

        public Product () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual string ProductFullName 
        { 
            get
            {
                _productFullName = ProductId.PadRight(36, ' ') + " | " + ProductMaster.ProductName;
                return null;            
            }
            set
            {
                _productFullName = value;     
            }
        }
        public virtual Int64 Price { get; set; }
        public virtual Int64 Quantity { get; set; }

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


        public virtual BlockInDetail BlockInDetail
        {
            get
            {
                return _blockInDetail;
            }
            set
            {
                _blockInDetail = value;
            }
        }
        

        public virtual ProductMaster ProductMaster
        {
            get
            {
                return _productMaster;
            }
            set
            {
                _productMaster = value;
            }
        }
        
        
        // StockOutDetail
        public virtual IList StockOutDetails
        {
            get
            {
                return _stockOutDetails;
            }
            set
            {
                _stockOutDetails = value;
            }
        }
        
        
        // StockInDetail
        public virtual IList StockInDetails
        {
            get
            {
                return _stockInDetails;
            }
            set
            {
                _stockInDetails = value;
            }
        }
        
        
        // Stock
        public virtual IList Stocks
        {
            get
            {
                return _stocks;
            }
            set
            {
                _stocks = value;
            }
        }
        
        
        // DepartmentStockOutDetail
        public virtual IList DepartmentStockOutDetails
        {
            get
            {
                return _departmentStockOutDetails;
            }
            set
            {
                _departmentStockOutDetails = value;
            }
        }
        
        
        // DepartmentStockInDetail
        public virtual IList DepartmentStockInDetails
        {
            get
            {
                return _departmentStockInDetails;
            }
            set
            {
                _departmentStockInDetails = value;
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
        
        
        // DepartmentStock
        public virtual IList DepartmentStocks
        {
            get
            {
                return _departmentStocks;
            }
            set
            {
                _departmentStocks = value;
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