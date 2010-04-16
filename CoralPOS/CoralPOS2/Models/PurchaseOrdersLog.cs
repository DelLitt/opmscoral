using System; 
using System.Text; 
using System.Collections.Generic; 
using System.Runtime.Serialization; 
using Caliburn.PresentationFramework.Behaviors; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class PurchaseOrdersLog {
        
        public PurchaseOrdersLog() {
        }
        
        [DataMember(Name="1", Order=1)]
        public virtual long Id {
            get;
            set;
        }
        
        [DataMember(Name="2", Order=2)]
        public virtual System.DateTime Date {
            get;
            set;
        }
        
        [DataMember(Name="3", Order=3)]
        public virtual string Exception {
            get;
            set;
        }
        
        [DataMember(Name="4", Order=4)]
        public virtual string Level {
            get;
            set;
        }
        
        [DataMember(Name="5", Order=5)]
        public virtual string Logger {
            get;
            set;
        }
        
        [DataMember(Name="6", Order=6)]
        public virtual string Message {
            get;
            set;
        }
        
        [DataMember(Name="7", Order=7)]
        public virtual string PosAction {
            get;
            set;
        }
        
        [DataMember(Name="8", Order=8)]
        public virtual string PosUser {
            get;
            set;
        }
        
        [DataMember(Name="9", Order=9)]
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
