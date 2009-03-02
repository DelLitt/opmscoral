using System;
using System.Collections;
using System.ComponentModel;
using AppFrame.Common;
using AppFrame.Controls;

namespace AppFrame.Model
{
    #region ProductMaster
    /// <summary>
    /// ProductMaster object for NHibernate mapped table 'product_master'.
    /// </summary>
    [TypeDescriptionProvider(typeof(ComplexCustomDescriptionProvider<ProductMaster>))]
    [Serializable]
    public class ProductMaster : ClonableObject,System.IComparable
    {
    	#region Member Variables

        protected string _productMasterId; 		
        protected string _productName;
        protected string _description;
        protected Int64 _supplierId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected Packager _packager;
        protected ProductColor _productColor;
        protected Country _country;
        protected Category _category;
        protected Manufacturer _manufacturer;
        protected ProductSize _productSize;
        // Product
        protected IList _products = new ArrayList();
        protected Distributor _distributor;
        protected ProductType _productType;
        protected string _productFullName;

        #endregion

        #region Constructors

        public ProductMaster () 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual string ImagePath { get; set; }
        
        public virtual string ProductFullName
        {
            get
            {
                
                _productFullName =  ProductMasterId.PadRight(36,' ') + " | " + ProductName;
                return _productFullName;
            }
            set
            {
                _productFullName = value;                
            }
            
        }
        public virtual string Barcode { get; set;}
        public virtual string ProductMasterId
        {
            get
            {
                return _productMasterId;
            }
            set
            {
                _productMasterId = value;
            }
        }

        public virtual string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public virtual Int64 SupplierId
        {
            get
            {
                return _supplierId;
            }
            set
            {
                _supplierId = value;
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


        public virtual Packager Packager
        {
            get
            {
                return _packager;
            }
            set
            {
                _packager = value;
            }
        }
        

        public virtual ProductColor ProductColor
        {
            get
            {
                return _productColor;
            }
            set
            {
                _productColor = value;
            }
        }
        

        public virtual Country Country
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
        

        public virtual Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }
        

        public virtual Manufacturer Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                _manufacturer = value;
            }
        }
        

        public virtual ProductSize ProductSize
        {
            get
            {
                return _productSize;
            }
            set
            {
                _productSize = value;
            }
        }
        
        
        // Product
        public virtual IList Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }
        

        public virtual Distributor Distributor
        {
            get
            {
                return _distributor;
            }
            set
            {
                _distributor = value;
            }
        }
        

        public virtual ProductType ProductType
        {
            get
            {
                return _productType;
            }
            set
            {
                _productType = value;
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