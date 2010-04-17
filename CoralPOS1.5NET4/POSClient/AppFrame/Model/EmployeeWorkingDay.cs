using System;
using System.Collections;

namespace AppFrame.Model
{
    #region EmployeeWorkingDay
    /// <summary>
    /// EmployeeWorkingDay object for NHibernate mapped table 'employee_working_days'.
    /// </summary>
    [Serializable]
    public class EmployeeWorkingDay : System.IComparable
    {
    	#region Member Variables

        protected string _employeeId; 		
        protected DateTime _workingDay; 		
        protected Int64 _period; 		
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

        public EmployeeWorkingDay () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual EmployeeWorkingDayPK EmployeeWorkingDayPK { get; set; }
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
        public virtual DateTime WorkingDay
        {
            get
            {
                return _workingDay;
            }
            set
            {
                _workingDay = value;
            }
        }
        public virtual Int64 Period
        {
            get
            {
                return _period;
            }
            set
            {
                _period = value;
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

        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual Department Department { get; set; }

        public virtual string DisplayStartTime 
        { 
            get
            {
                if(StartTime.CompareTo(DateTime.MinValue)== 0)
                {
                    return "";
                }
                else
                {
                    return StartTime.ToString("HH:mm:ss");
                }
            }
        }
        public virtual string DisplayEndTime
        {
            get
            {
                if (EndTime.CompareTo(DateTime.MinValue) == 0)
                {
                    return "";
                }
                else
                {
                    return EndTime.ToString("HH:mm:ss");
                }
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