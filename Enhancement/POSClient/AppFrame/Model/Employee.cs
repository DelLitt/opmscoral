using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Employee
    /// <summary>
    /// Employee object for NHibernate mapped table 'employee'.
    /// </summary>
    [Serializable]
    public class Employee : System.IComparable
    {
    	#region Member Variables

        /*protected Int64 _employeeId; 		
        protected Int64 _departmentId; 		*/
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Department _department;
        // EmployeeWorkingDay
        protected IList _employeeWorkingDays = new ArrayList();
        // EmployeeReward
        protected IList _employeeRewards = new ArrayList();
        // Contract
        protected IList _contracts = new ArrayList();
        protected EmployeeInfo _employeeInfo;
        // EmployeeDayoff
        protected IList _employeeDayoffs = new ArrayList();

        #endregion

        #region Constructors

        public Employee () 
        {
        }
        
        #endregion

        #region Public Properties
		public virtual EmployeePK EmployeePK { get; set; }
        /*public virtual Int64 EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
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
        }*/
        
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
        
        // EmployeeWorkingDay
        public virtual IList EmployeeWorkingDays
        {
            get
            {
                return _employeeWorkingDays;
            }
            set
            {
                _employeeWorkingDays = value;
            }
        }
        
        
        // EmployeeReward
        public virtual IList EmployeeRewards
        {
            get
            {
                return _employeeRewards;
            }
            set
            {
                _employeeRewards = value;
            }
        }
        
        
        // Contract
        public virtual IList Contracts
        {
            get
            {
                return _contracts;
            }
            set
            {
                _contracts = value;
            }
        }
        

        public virtual EmployeeInfo EmployeeInfo
        {
            get
            {
                return _employeeInfo;
            }
            set
            {
                _employeeInfo = value;
            }
        }
        
        
        // EmployeeDayoff
        public virtual IList EmployeeDayoffs
        {
            get
            {
                return _employeeDayoffs;
            }
            set
            {
                _employeeDayoffs = value;
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