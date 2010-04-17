using System;
using System.Collections;

namespace AppFrame.Model
{
    #region DepartmentReturn
    /// <summary>
    /// DepartmentReturn object for NHibernate mapped table 'department_return'.
    /// </summary>
    [Serializable]
    public class DepartmentReturn : System.IComparable
    {
    	#region Member Variables

        protected Int64 _departmentReturnId; 		
        protected string _productId;
        protected Int64 _departmentId;
        protected Int64 _returnStatus;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // DepartmentReturnDetail
        protected IList _departmentReturnDetails = new ArrayList();
        // DepartmentReturnCost
        protected IList _departmentReturnCosts = new ArrayList();

        #endregion

        #region Constructors

        public DepartmentReturn () 
        {
        }
        
        #endregion

        #region Public Properties

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
        public virtual Int64 ReturnStatus
        {
            get
            {
                return _returnStatus;
            }
            set
            {
                _returnStatus = value;
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

        
        // DepartmentReturnDetail
        public virtual IList DepartmentReturnDetails
        {
            get
            {
                return _departmentReturnDetails;
            }
            set
            {
                _departmentReturnDetails = value;
            }
        }
        
        
        // DepartmentReturnCost
        public virtual IList DepartmentReturnCosts
        {
            get
            {
                return _departmentReturnCosts;
            }
            set
            {
                _departmentReturnCosts = value;
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