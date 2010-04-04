using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Behaviors;
using Caliburn.PresentationFramework.ViewModels;


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate]
    public class StockInDetail :IDataErrorInfo {
        
        public StockInDetail() {
        }
        
        public virtual StockInDetailPK StockInDetailPK {
            get;
            set;
        }
        
        public virtual System.DateTime CreateDate {
            get;
            set;
        }
        
        public virtual string CreateId {
            get;
            set;
        }
        
        public virtual long DelFlg {
            get;
            set;
        }
        
        public virtual long ExFld1 {
            get;
            set;
        }
        
        public virtual long ExFld2 {
            get;
            set;
        }
        
        public virtual long ExFld3 {
            get;
            set;
        }
        
        public virtual string ExFld4 {
            get;
            set;
        }
        
        public virtual string ExFld5 {
            get;
            set;
        }
        
        public virtual long ExclusiveKey {
            get;
            set;
        }

        [Range(1, 99999)]
        public virtual long Price {
            get;
            set;
        }
        
        public virtual ProductMaster ProductMaster {
            get;
            set;
        }
        [Range(1,99999)]    
        public virtual long Quantity {
            get;
            set;
        }
        
        public virtual long SellPrice {
            get;
            set;
        }
        
        public virtual long StockInType {
            get;
            set;
        }
        
        public virtual System.DateTime UpdateDate {
            get;
            set;
        }
        
        public virtual string UpdateId {
            get;
            set;
        }
        
        public virtual StockIn StockIn {
            get;
            set;
        }
        [Required]
        public virtual Product Product {
            get;
            set;
        }
        public virtual MainPrice MainPrice
        {
            get; 
            set;
        }

   	 protected bool Equals(StockInDetail entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockInDetail);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}

        public virtual string this[string columnName]
        {
            get
            {
                DefaultValidator validator = new DefaultValidator();
                var error = validator.Validate(this, columnName).FirstOrDefault();
                return error != null ? error.Message : string.Empty;
            }
        }

        public virtual string Error
        {
            get;set;
        }
    }
}
