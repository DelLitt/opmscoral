using System;
using System.Collections;

namespace AppFrame.Model
{
    #region DepartmentStockOut
    /// <summary>
    /// DepartmentStockOut object for NHibernate mapped table 'department_stock_out'.
    /// </summary>
    [Serializable]
    public class DepartmentStockOut : System.IComparable
    {
    	#region Member Variables

        protected Int64 _stockOutId; 		
        protected Int64 _departmentId; 		
        protected DateTime _stockOutDate;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // DepartmentStockOutCost
        protected IList _departmentStockOutCosts = new ArrayList();
        // DepartmentStockOutDetail
        protected IList _departmentStockOutDetails = new ArrayList();

        #endregion

        #region Constructors

        public DepartmentStockOut () 
        {
        }
        
        #endregion

        #region Public Properties

		public virtual DepartmentStockOutPK DepartmentStockOutPK { get; set; }
		
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

        public virtual DateTime StockOutDate
        {
            get
            {
                return _stockOutDate;
            }
            set
            {
                _stockOutDate = value;
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

        
        // DepartmentStockOutCost
        public virtual IList DepartmentStockOutCosts
        {
            get
            {
                return _departmentStockOutCosts;
            }
            set
            {
                _departmentStockOutCosts = value;
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
        public virtual StockDefectStatus DefectStatus { get; set; }
        public Int64 ConfirmFlg { get; set; }
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