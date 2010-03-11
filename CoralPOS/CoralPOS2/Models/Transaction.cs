using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class Transaction {
        
        public Transaction() {
        }
        
        public virtual string TransactionId {
            get;
            set;
        }
        
        public virtual string CashierId {
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
        
        public virtual string RegisterId {
            get;
            set;
        }
        
        public virtual string StoreId {
            get;
            set;
        }
        
        public virtual long TransactionType {
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
   	 protected bool Equals(Transaction entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as Transaction);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
