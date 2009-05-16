using System;
using System.Collections;

namespace AppFrame.Model
{
    #region EmployeeDayoff
    /// <summary>
    /// EmployeeDayoff object for NHibernate mapped table 'employee_dayoff'.
    /// </summary>
    [Serializable]
    public class EmployeeDayoff : System.IComparable
    {
    	#region Member Variables

        protected string _employeeId; 		
        protected DateTime _dayoffTime; 		
        protected Int64 _departmentId; 		
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Employee _employee;

        #endregion

        #region Constructors

        public EmployeeDayoff () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual EmployeeDayoffPK EmployeeDayoffPK { get; set; }
        public virtual string EmployeeId
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
        public virtual DateTime DayoffTime
        {
            get
            {
                return _dayoffTime;
            }
            set
            {
                _dayoffTime = value;
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

        public virtual Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
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