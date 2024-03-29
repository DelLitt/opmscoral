using System;
using System.Collections;
using System.Text;

namespace AppFrame.Model
{
    #region StockOut
    /// <summary>
    /// StockOut object for NHibernate mapped table 'stock_out'.
    /// </summary>
    [Serializable]
    public class StockOut : System.IComparable
    {
    	#region Member Variables

        protected Int64 _stockoutId; 		
        protected DateTime _stockOutDate;
        protected long _departmentId;
        protected DateTime _createDate;
        protected string _createId;
        protected DateTime _updateDate;
        protected string _updateId;
        protected Int64 _exclusiveKey;
        protected Int64 _delFlg;
        // StockOutDetail
        protected IList _stockOutDetails = new ArrayList();
        // StockOutCost
        protected IList _stockOutCosts = new ArrayList();
        

        #endregion

        #region Constructors

        public StockOut () 
        {
        }
        
        #endregion

        #region Public Properties

        
        public virtual Int64 StockoutId
        {
            get
            {
                return _stockoutId;
            }
            set
            {
                _stockoutId = value;
            }
        }

        public virtual DateTime StockOutDate
        {
            get
            {
                return _stockOutDate;
            }
            set
            {
                _stockOutDate = value;
            }
        }
        public virtual long DepartmentId
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

        
        // StockOutDetail
        public virtual IList StockOutDetails
        {
            get
            {
                return _stockOutDetails;
            }
            set
            {
                _stockOutDetails = value;
            }
        }
        
        
        // StockOutCost
        public virtual IList StockOutCosts
        {
            get
            {
                return _stockOutCosts;
            }
            set
            {
                _stockOutCosts = value;
            }
        }
        public virtual Int64 StockId 
        {
            get;
            set;
        }
        public virtual StockDefectStatus DefectStatus { get; set; }

        public virtual bool NotUpdateMainStock { get; set; }
        public virtual long ConfirmFlg { get; set; }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Mã xuất kho: ").Append(StockoutId).Append(" ngày: ").Append(StockOutDate.ToString("dd/MM/yyyy hh:mm:ss")).Append("\r\n").Append("Chi tiết:\r\n");
            if (StockOutDetails != null && StockOutDetails.Count > 0)
            {
                foreach (StockOutDetail detail in StockOutDetails)
                {
                    sb.Append("Tên sản phẩm: ").Append(detail.ProductMaster.ProductName).Append(" ")
                        .Append(", mã vạch: ").Append(detail.Product.ProductId).Append(", số lượng:").Append(
                        detail.Quantity).Append("\r\n");
                }
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}