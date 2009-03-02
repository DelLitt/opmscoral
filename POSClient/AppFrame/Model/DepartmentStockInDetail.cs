using System;
using System.Collections;
using System.Runtime.Serialization;
using AppFrame.Common;

namespace AppFrame.Model
{
    #region DepartmentStockInDetail
    /// <summary>
    /// DepartmentStockInDetail object for NHibernate mapped table 'department_stock_in_detail'.
    /// </summary>
    [Serializable]
    public class DepartmentStockInDetail : ClonableObject, System.IComparable
    {
    	#region Member Variables

        protected Int64 _stockInId; 		
        protected string _productId; 		
        protected Int64 _departmentId; 		
        protected Int64 _quantity;
        protected DateTime _createDate;
        protected string _createId;

        

        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected DepartmentStockIn _departmentStockIn;
        protected Product _product;

        #endregion

        #region Constructors

        public DepartmentStockInDetail () 
        {
        }
        
        #endregion

        #region Public Properties

		public virtual DepartmentStockInDetailPK DepartmentStockInDetailPK { get; set; }
        
        public virtual long Price { get; set; }
        public virtual long OnStorePrice { get; set; }
        public virtual long OldQuantity { get; set; }
        public virtual long StockQuantity { get; set; }
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

        public virtual DepartmentStockIn DepartmentStockIn
        {
            get
            {
                return _departmentStockIn;
            }
            set
            {
                _departmentStockIn = value;
            }
        }
        public virtual Product Product
        {
            get;set;
            /*{
                return _product;
            }
            set
            {
                _product = value;
            }*/
        }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual Int64 Sold { get; set; }
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

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //throw new System.NotImplementedException();
        }

        #endregion
        
        public override object Clone()
        {
            return base.Clone();
        }
    }
    #endregion
}