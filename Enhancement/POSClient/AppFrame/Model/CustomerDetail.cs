using System;
using System.Collections;

namespace AppFrame.Model
{
    #region CustomerDetail
    /// <summary>
    /// CustomerDetail object for NHibernate mapped table 'customer_detail'.
    /// </summary>
    [Serializable]
    public class CustomerDetail : System.IComparable
    {
    	#region Member Variables

        protected Int64 _customerId; 		
        protected string _address;
        protected Int64 _countryId;
        protected DateTime _birthday;
        protected string _passportNumber;
        protected string _cmnd;
        protected Int64 _moneySpent;
        protected Int64 _buyCount;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Customer _customer;

        #endregion

        #region Constructors

        public CustomerDetail () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
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
        public virtual Int64 CountryId
        {
            get
            {
                return _countryId;
            }
            set
            {
                _countryId = value;
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
        public virtual string PassportNumber
        {
            get
            {
                return _passportNumber;
            }
            set
            {
                _passportNumber = value;
            }
        }
        public virtual string Cmnd
        {
            get
            {
                return _cmnd;
            }
            set
            {
                _cmnd = value;
            }
        }
        public virtual Int64 MoneySpent
        {
            get
            {
                return _moneySpent;
            }
            set
            {
                _moneySpent = value;
            }
        }
        public virtual Int64 BuyCount
        {
            get
            {
                return _buyCount;
            }
            set
            {
                _buyCount = value;
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


        public virtual Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
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