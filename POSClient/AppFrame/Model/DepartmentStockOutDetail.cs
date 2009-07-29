using System;
using System.Collections;
using System.Runtime.Serialization;

namespace AppFrame.Model
{
    #region DepartmentStockOutDetail
    /// <summary>
    /// DepartmentStockOutDetail object for NHibernate mapped table 'department_stock_out_detail'.
    /// </summary>
    [Serializable]
    [DataContract(Name = "DepartmentStockOutDetail", Namespace = "http://localhost:8001/")]
    public class DepartmentStockOutDetail : System.IComparable
    {
    	#region Member Variables

        protected Int64 _stockOutId; 		
        protected string _productId; 		
        protected Int64 _departmentId; 		
        protected Int64 _quantity;
        protected string _description;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected DepartmentStockOut _departmentStockOut;
        protected Product _product;

        #endregion

        #region Constructors

        public DepartmentStockOutDetail () 
        {
        }
        
        #endregion

        #region Public Properties
        
        [DataMember]
        public virtual DepartmentStockOutDetailPK DepartmentStockOutDetailPK { get; set; }
        //public virtual Int64 StockOutDetailId { get; set; }
		

        [DataMember]
        public virtual Int64 GoodQuantity { get; set; }
        [DataMember]
        public virtual Int64 DamageQuantity { get; set; }
        [DataMember]
        public virtual Int64 ErrorQuantity { get; set; }
        [DataMember]
        public virtual Int64 LostQuantity { get; set; }
        [DataMember]
        public virtual Int64 UnconfirmQuantity { get; set; }
        [DataMember]
        public virtual Int64 StockOutId
        {
            get
            {
                return _stockOutId;
            }
            set
            {
                _stockOutId = value;
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
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
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
        
        public virtual DepartmentStockOut DepartmentStockOut
        {
            get
            {
                return _departmentStockOut;
            }
            set
            {
                _departmentStockOut = value;
            }
        }
        [DataMember]
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
        [DataMember]
        public virtual ProductMaster ProductMaster { get; set; }
        [DataMember]
        public virtual StockDefectStatus DefectStatus { get; set; }
        [DataMember]
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
    }
    #endregion
}