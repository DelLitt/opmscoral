using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class CustomerDetail {
        
        public CustomerDetail() {
        }
        
        public virtual long CustomerId {
            get;
            set;
        }
        
        public virtual string Address {
            get;
            set;
        }
        
        public virtual System.DateTime Birthday {
            get;
            set;
        }
        
        public virtual long BuyCount {
            get;
            set;
        }
        
        public virtual string Cmnd {
            get;
            set;
        }
        
        public virtual long CountryId {
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
        
        public virtual long ExclusiveKey {
            get;
            set;
        }
        
        public virtual long MoneySpent {
            get;
            set;
        }
        
        public virtual string PassportNumber {
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
   	 protected bool Equals(CustomerDetail entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as CustomerDetail);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
