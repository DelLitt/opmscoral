using System;
using System.Collections;

namespace AppFrame.Model
{
    #region BlockInDetail
    /// <summary>
    /// BlockInDetail object for NHibernate mapped table 'block_in_detail'.
    /// </summary>
    [Serializable]
    public class BlockInDetail : System.IComparable
    {
    	#region Member Variables

        protected Int64 _blockId; 		
        protected Int64 _blockDetailId; 		
        protected string _detailValue;
        protected Int64 _manufactureId;
        protected Int64 _packagerId;
        protected Int64 _countryId;
        protected Int64 _supplierId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected DateTime _importDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        protected BlockIn _blockIn;
        // Product
        protected IList _products = new ArrayList();

        #endregion

        #region Constructors

        public BlockInDetail () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 StockInId { get; set; }

        public virtual BlockInDetailPK BlockInDetailPK { get; set; }

        public virtual Int64 BlockId
        {
            get
            {
                return _blockId;
            }
            set
            {
                _blockId = value;
            }
        }
        public virtual Int64 BlockDetailId
        {
            get
            {
                return _blockDetailId;
            }
            set
            {
                _blockDetailId = value;
            }
        }

        public virtual string DetailValue
        {
            get
            {
                return _detailValue;
            }
            set
            {
                _detailValue = value;
            }
        }
        public virtual Int64 ManufactureId
        {
            get
            {
                return _manufactureId;
            }
            set
            {
                _manufactureId = value;
            }
        }
        public virtual Int64 PackagerId
        {
            get
            {
                return _packagerId;
            }
            set
            {
                _packagerId = value;
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

        public virtual DateTime ImportDate
        {
            get
            {
                return _importDate;
            }
            set
            {
                _importDate = value;
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

        public virtual BlockIn BlockIn
        {
            get
            {
                return _blockIn;
            }
            set
            {
                _blockIn = value;
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