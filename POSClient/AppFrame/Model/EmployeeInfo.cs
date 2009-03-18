using System;
using System.Collections;
using System.ComponentModel;
using AppFrame.Controls;

namespace AppFrame.Model
{
    #region EmployeeInfo
    /// <summary>
    /// EmployeeInfo object for NHibernate mapped table 'employee_detail'.
    /// </summary>
    /// 
    [Serializable]
    public class EmployeeInfo : System.IComparable
    {
    	#region Member Variables

        /*protected Int64 _employeeId;
        protected Int64 _departmentId; 		*/
        protected string _address;
        protected DateTime _birthday;
        protected Int64 _country;
        protected Int64 _contractId;
        protected Int64 _salary;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Employee _employee;
        protected DateTime _startDate;
        protected string employeeName;
        #endregion

        #region Constructors

        public EmployeeInfo () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual EmployeePK EmployeePK { get; set; }
       /* public virtual Int64 EmployeeId
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
        public virtual DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }
        public virtual Int64 Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }
        public virtual Int64 ContractId
        {
            get
            {
                return _contractId;
            }
            set
            {
                _contractId = value;
            }
        }
        public virtual Int64 Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
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
        public virtual Department Department { get; set; }
        public virtual string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
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