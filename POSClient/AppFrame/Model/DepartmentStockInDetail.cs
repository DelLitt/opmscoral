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
    [DataContract(Name = "DepartmentStockInDetail", Namespace = "http://localhost:8001/")]
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
        public virtual long StockOutQuantity { get; set;}
        public virtual long ReStockQuantity { get; set; }

        #endregion

        #region Constructors

        public DepartmentStockInDetail () 
        {
        }
        
        #endregion

        #region Public Properties
        [DataMember]
		public virtual DepartmentStockInDetailPK DepartmentStockInDetailPK { get; set; }
        [DataMember]
        public virtual long Price { get; set; }
        [DataMember]
        public virtual long OnStorePrice { get; set; }
        [DataMember]
        public virtual long OldQuantity { get; set; }
        [DataMember]
        public virtual long StockQuantity { get; set; }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public virtual ProductMaster ProductMaster { get; set; }
        [DataMember]
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