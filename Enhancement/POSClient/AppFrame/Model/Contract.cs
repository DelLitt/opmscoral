using System;
using System.Collections;

namespace AppFrame.Model
{
    #region Contract
    /// <summary>
    /// Contract object for NHibernate mapped table 'contract'.
    /// </summary>
    [Serializable]
    public class Contract : System.IComparable
    {
    	#region Member Variables

        protected Int64 _contractId; 		
        protected Int64 _departmentId; 		
        protected string _contractName;
        protected Int64 _contractType;
        protected DateTime _startDate;
        protected DateTime _endDate;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Employee _employee;

        #endregion

        #region Constructors

        public Contract () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual ContractPK ContractPK { get; set; }

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

        public virtual string ContractName
        {
            get
            {
                return _contractName;
            }
            set
            {
                _contractName = value;
            }
        }
        public virtual Int64 ContractType
        {
            get
            {
                return _contractType;
            }
            set
            {
                _contractType = value;
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