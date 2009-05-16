using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Department
    /// <summary>
    /// Department object for NHibernate mapped table 'department'.
    /// </summary>
    [Serializable]
    public class Department : System.IComparable
    {
        #region Member Variables

        protected Int64 _departmentId;
        protected string _departmentName;
        protected string _address;
        protected Int64 _managerId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // DepartmentCost
        protected IList _departmentCosts = new ArrayList();
        // Employee
        protected IList _employees = new ArrayList();
        // ScheduleTemplate
        protected IList _scheduleTemplates = new ArrayList();
        protected DateTime _startDate;
        private int active;

        #endregion

        #region Constructors

        public Department()
        {
        }

        #endregion

        #region Public Properties
        public virtual string NameAddress
        {
            get
            {
                return _departmentName + " - " + _address;
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

        public virtual string DepartmentName
        {
            get
            {
                return _departmentName;
            }
            set
            {
                _departmentName = value;
            }
        }
        public virtual string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public virtual Int64 ManagerId
        {
            get
            {
                return _managerId;
            }
            set
            {
                _managerId = value;
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


        // DepartmentCost
        public virtual IList DepartmentCosts
        {
            get
            {
                return _departmentCosts;
            }
            set
            {
                _departmentCosts = value;
            }
        }


        // Employee
        public virtual IList Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
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
        // ScheduleTemplate
        public virtual IList ScheduleTemplates
        {
            get
            {
                return _scheduleTemplates;
            }
            set
            {
                _scheduleTemplates = value;
            }
        }

        public virtual int Active
        {
            get { return active; }
            set { active = value; }
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