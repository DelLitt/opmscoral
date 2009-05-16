using System;
using System.Collections;

namespace AppFrame.Model
{
    #region DepartmentReturnDetail
    /// <summary>
    /// DepartmentReturnDetail object for NHibernate mapped table 'department_return_detail'.
    /// </summary>
    [Serializable]
    public class DepartmentReturnDetail : System.IComparable
    {
    	#region Member Variables

        protected Int64 _departmentReturnId; 		
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
        protected DepartmentReturn _departmentReturn;

        #endregion

        #region Constructors

        public DepartmentReturnDetail () 
        {
        }
        
        #endregion

        #region Public Properties

		public virtual DepartmentReturnDetailPK DepartmentReturnDetailPK { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
		
        public virtual Int64 DepartmentReturnId
        {
            get
            {
                return _departmentReturnId;
            }
            set
            {
                _departmentReturnId = value;
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

        public virtual DepartmentReturn DepartmentReturn
        {
            get
            {
                return _departmentReturn;
            }
            set
            {
                _departmentReturn = value;
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