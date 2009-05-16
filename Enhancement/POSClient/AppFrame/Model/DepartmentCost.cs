using System;
using System.Collections;

namespace AppFrame.Model
{
    #region DepartmentCost
    /// <summary>
    /// DepartmentCost object for NHibernate mapped table 'department_cost'.
    /// </summary>
    [Serializable]
    public class DepartmentCost : System.IComparable
    {
    	#region Member Variables

        protected Int64 _departmentId; 		
        protected DateTime _costDate; 		
        protected Int64 _costType;
        protected string _costName;
        protected string _costDescription;
        protected Int64 _cost;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Department _department;

        #endregion

        #region Constructors

        public DepartmentCost () 
        {
        }
        
        #endregion

        #region Public Properties

		public virtual DepartmentCostPK DepartmentCostPK { get; set; }
		
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
        public virtual DateTime CostDate
        {
            get
            {
                return _costDate;
            }
            set
            {
                _costDate = value;
            }
        }

        public virtual Int64 CostType
        {
            get
            {
                return _costType;
            }
            set
            {
                _costType = value;
            }
        }
        public virtual string CostName
        {
            get
            {
                return _costName;
            }
            set
            {
                _costName = value;
            }
        }
        public virtual string CostDescription
        {
            get
            {
                return _costDescription;
            }
            set
            {
                _costDescription = value;
            }
        }
        public virtual Int64 Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
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

        public virtual Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
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