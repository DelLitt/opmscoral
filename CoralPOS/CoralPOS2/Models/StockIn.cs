using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Caliburn.PresentationFramework.Behaviors;
using Caliburn.PresentationFramework.ViewModels;
using Caliburn.Testability;


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate]
    public class StockIn //:IDataErrorInfo 
    {
        
        public StockIn() {
        }
        
        public virtual long StockInId {
            get;
            set;
        }
        
        public virtual long ConfirmFlg {
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
        
        [Required]
        public virtual string Description {
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
        
        public virtual long StockInCost {
            get;
            set;
        }
        
        public virtual System.DateTime StockInDate {
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

        [Required]
        public virtual IList<StockInDetail> StockInDetails {
            get;
            set;
        }
   	 protected bool Equals(StockIn entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockIn);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}

        /*public virtual string this[string columnName]
        {
            get
            {
                DefaultValidator validator = new DefaultValidator();
                var error = validator.Validate(this, columnName).FirstOrDefault();
                return error!=null?error.Message : string.Empty; 
            }
        }

        public virtual string Error
        {
            get; set;
        }*/
    }
}