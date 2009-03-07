using System;
using System.Collections;
using System.ComponentModel;
using AppFrame.Controls;

namespace AppFrame.Model
{
    #region Stock
    /// <summary>
    /// Stock object for NHibernate mapped table 'stock_defect'.
    /// </summary>
    [Serializable]
    public class DepartmentStockDefect : System.IComparable
    {
        #region Member Variables
        
        protected Int64 _quantity;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Product _product;

        #endregion

        #region Constructors

        public DepartmentStockDefect()
        {
        }

        #endregion

        #region Public Properties
        
        public virtual Int64 Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
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




        public virtual Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }
        public virtual ProductMaster ProductMaster { get; set; }


        
        public virtual DepartmentStockDefectPK DepartmentStockDefectPK { get; set; }
        public virtual long GoodCount { get; set; }

        public virtual int ErrorCount { get; set; }
        public virtual int OldErrorCount { get; set; }
        public virtual int DamageCount { get; set; }
        public virtual int OldDamageCount { get; set; }        
        public virtual int LostCount { get; set; }
        public virtual int OldLostCount { get; set; }
        public virtual int UnconfirmCount { get; set; }
        public virtual int OldUnconfirmCount { get; set; }
        public virtual string Description { get; set; }

        // not mapping field
        public virtual DepartmentStock DepartmentStock { get; set; }
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