using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class PurchaseOrdersLog {
        
        public PurchaseOrdersLog() {
        }
        
        public virtual long Id {
            get;
            set;
        }
        
        public virtual System.DateTime Date {
            get;
            set;
        }
        
        public virtual string Exception {
            get;
            set;
        }
        
        public virtual string Level {
            get;
            set;
        }
        
        public virtual string Logger {
            get;
            set;
        }
        
        public virtual string Message {
            get;
            set;
        }
        
        public virtual string PosAction {
            get;
            set;
        }
        
        public virtual string PosUser {
            get;
            set;
        }
        
        public virtual string Thread {
            get;
            set;
        }
   	 protected bool Equals(PurchaseOrdersLog entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as PurchaseOrdersLog);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
