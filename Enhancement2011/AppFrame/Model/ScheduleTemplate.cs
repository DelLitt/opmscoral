using System;
using System.Collections;

namespace AppFrame.Model
{
    #region ScheduleTemplate
    /// <summary>
    /// ScheduleTemplate object for NHibernate mapped table 'schedule_template'.
    /// </summary>
    [Serializable]
    public class ScheduleTemplate : System.IComparable
    {
    	#region Member Variables

        protected Int64 _employeeId; 		
        protected Int64 _scheduleId; 		
        protected Int64 _departmentId; 		
        protected Int64 _monday;
        protected Int64 _tuesday;
        protected Int64 _wednesday;
        protected Int64 _thursday;
        protected Int64 _friday;
        protected Int64 _saturday;
        protected Int64 _sunday;
        protected Int64 _delFlg;
        protected DateTime _startDate;
        protected DateTime _endDate;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Department _department;

        #endregion

        #region Constructors

        public ScheduleTemplate () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual ScheduleTemplatePK ScheduleTemplatePK { get; set; }
        public virtual Int64 EmployeeId
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
        public virtual Int64 ScheduleId
        {
            get
            {
                return _scheduleId;
            }
            set
            {
                _scheduleId = value;
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

        public virtual Int64 Monday
        {
            get
            {
                return _monday;
            }
            set
            {
                _monday = value;
            }
        }
        public virtual Int64 Tuesday
        {
            get
            {
                return _tuesday;
            }
            set
            {
                _tuesday = value;
            }
        }
        public virtual Int64 Wednesday
        {
            get
            {
                return _wednesday;
            }
            set
            {
                _wednesday = value;
            }
        }
        public virtual Int64 Thursday
        {
            get
            {
                return _thursday;
            }
            set
            {
                _thursday = value;
            }
        }
        public virtual Int64 Friday
        {
            get
            {
                return _friday;
            }
            set
            {
                _friday = value;
            }
        }
        public virtual Int64 Saturday
        {
            get
            {
                return _saturday;
            }
            set
            {
                _saturday = value;
            }
        }
        public virtual Int64 Sunday
        {
            get
            {
                return _sunday;
            }
            set
            {
                _sunday = value;
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
        public virtual DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
        public virtual DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
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