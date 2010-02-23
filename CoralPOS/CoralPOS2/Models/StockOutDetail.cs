using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class StockOutDetail {
        
        public StockOutDetail() {
        }
        
        public virtual long StockOutDetailId {
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
        
        public virtual long DamageQuantity {
            get;
            set;
        }
        
        public virtual long DefectStatusId {
            get;
            set;
        }
        
        public virtual long DelFlg {
            get;
            set;
        }
        
        public virtual string Description {
            get;
            set;
        }
        
        public virtual long ErrorQuantity {
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
        
        public virtual long GoodQuantity {
            get;
            set;
        }
        
        public virtual long LostQuantity {
            get;
            set;
        }
        
        public virtual string ProductId {
            get;
            set;
        }
        
        public virtual string ProductMasterId {
            get;
            set;
        }
        
        public virtual long Quantity {
            get;
            set;
        }
        
        public virtual long StockOutId {
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
        
        public virtual StockOut StockOut {
            get;
            set;
        }
        
        public virtual Product Product {
            get;
            set;
        }
   	 protected bool Equals(StockOutDetail entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockOutDetail);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
