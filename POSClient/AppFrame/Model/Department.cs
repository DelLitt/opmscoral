using System;
using System.Collections;
using System.Runtime.Serialization;

namespace AppFrame.Model
{
    #region Department
    /// <summary>
    /// Department object for NHibernate mapped table 'department'.
    /// </summary>
    [Serializable]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Department", Namespace = "http://localhost:8001/")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOut))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOutPK))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOutCost[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOutCost))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOutCostPK))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOutDetail[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentStockOutDetail))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Product))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BlockInDetail))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BlockInDetailPK))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BlockIn))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ProductMaster))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Packager))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ProductColor))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Country))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Category))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Manufacturer))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ProductSize))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Distributor))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ProductType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(StockDefectStatus))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentPrice))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DepartmentPricePK))]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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