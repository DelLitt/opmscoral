using System;
using System.Collections;

namespace AppFrame.Model
{
    #region ProductColor
    /// <summary>
    /// ProductColor object for NHibernate mapped table 'product_color'.
    /// </summary>
    [Serializable]
    public class ProductColor : System.IComparable
    {
    	#region Member Variables

        protected Int64 _colorId; 		
        protected string _colorName;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // ProductMaster
        protected IList _productMasters = new ArrayList();

        #endregion

        #region Constructors

        public ProductColor () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 ColorId
        {
            get
            {
                return _colorId;
            }
            set
            {
                _colorId = value;
            }
        }

        public virtual string ColorName
        {
            get
            {
                return _colorName;
            }
            set
            {
                _colorName = value;
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

        
        // ProductMaster
        /*public virtual IList ProductMasters
        {
            get
            {
                return _productMasters;
            }
            set
            {
                _productMasters = value;
            }
        }*/
        

        #endregion
        
        #region IComparable Methods
        
        public virtual int CompareTo(object obj)
        {

            ProductColor color = (ProductColor) this;
            ProductColor compareColor = (ProductColor) obj;
            if (color.ColorId > compareColor.ColorId)
                return 1;
            if (color.ColorId < compareColor.ColorId)
                return -1;
            
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
            ProductColor color = (ProductColor)this;
            ProductColor compareColor = (ProductColor)obj;
            return color.ColorId == compareColor.ColorId;
            
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