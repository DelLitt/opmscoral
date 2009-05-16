using System;
using System.Collections;

namespace AppFrame.Model
{
    #region StockOutCost
    /// <summary>
    /// StockOutCost object for NHibernate mapped table 'stock_out_cost'.
    /// </summary>
    [Serializable]
    public class StockOutCost : System.IComparable
    {
    	#region Member Variables

        protected Int64 _stockOutId; 		
        protected Int64 _costType; 		
        protected Int64 _cost;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected StockOut _stockOut;

        #endregion

        #region Constructors

        public StockOutCost () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual StockOutCostPK StockOutCostPK { get; set; }
        public virtual Int64 StockOutId
        {
            get
            {
                return _stockOutId;
            }
            set
            {
                _stockOutId = value;
            }
        }
        public virtual Int64 CostType
        {
            get
            {
                return _costType;
            }
            set
            {
                _costType = value;
            }
        }

        public virtual Int64 Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
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


        public virtual StockOut StockOut
        {
            get
            {
                return _stockOut;
            }
            set
            {
                _stockOut = value;
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