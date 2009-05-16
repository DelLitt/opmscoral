using System;
using System.Collections;
using System.ComponentModel;
using AppFrame.Controls;

namespace AppFrame.Model
{
    #region StockOutDetail
    /// <summary>
    /// StockOutDetail object for NHibernate mapped table 'stock_out_detail'.
    /// </summary>
    [TypeDescriptionProvider(typeof(ComplexCustomDescriptionProvider<StockOutDetail>))]
    [Serializable]
    public class StockOutDetail : System.IComparable
    {
    	#region Member Variables

        protected Int64 _stockOutId; 		
        protected string _productId; 		
        protected Int64 _quantity;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Product _product;
        protected StockOut _stockOut;

        #endregion

        #region Constructors

        public StockOutDetail () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual Int64 StockOutDetailId { get; set; }
        //public virtual StockOutDetailPK StockOutDetailPK { get; set; }
        public virtual string Description { get; set; }
        public virtual Int64 GoodQuantity { get; set; }
        public virtual Int64 DamageQuantity { get; set; }
        public virtual Int64 ErrorQuantity { get; set; }
        public virtual Int64 LostQuantity { get; set; }
        public virtual Int64 UnconfirmQuantity { get; set; }
        public virtual Int64 StockQuantity { get; set; }
        public virtual Int64 Price { get; set; }
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
        public virtual string ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

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
        
        public virtual StockDefectStatus DefectStatus { get; set; }
        

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
        
        public virtual ProductMaster ProductMaster { get; set; }
    }
    #endregion
}