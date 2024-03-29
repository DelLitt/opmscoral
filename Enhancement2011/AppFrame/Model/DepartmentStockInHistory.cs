using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace AppFrame.Model
{
    #region DepartmentStockIn
    /// <summary>
    /// DepartmentStockIn object for NHibernate mapped table 'department_stock_in'.
    /// </summary>
    [Serializable]
    public class DepartmentStockInHistory : System.IComparable//, ISerializable
    {
    	#region Member Variables
        
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        
        #endregion

        #region Constructors

        public DepartmentStockInHistory () 
        {
        }
        
        #endregion

        #region Public Properties
        [DataMember]
		public virtual DepartmentStockInHistoryPK DepartmentStockInHistoryPK { get; set; }

        public virtual string Description { get; set; }
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