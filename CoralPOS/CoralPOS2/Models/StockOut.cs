using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Caliburn.PresentationFramework.Behaviors;


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate]
    public class StockOut {
        
        public StockOut() {
        }
        
        public virtual long StockOutId {
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

        [Required]
        public virtual StockDefinitionStatus DefinitionStatus {
            get;
            set;
        }
        
        public virtual long DelFlg {
            get;
            set;
        }
        [Required]
        public virtual Department Department {
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
        
        public virtual long StockId {
            get;
            set;
        }
        
        public virtual System.DateTime StockOutDate {
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
        public virtual long TotalQuantity { get; set; }
        [Required]
        public virtual IList<StockOutDetail> StockOutDetails {
            get;
            set;
        }
   	 protected bool Equals(StockOut entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockOut);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
