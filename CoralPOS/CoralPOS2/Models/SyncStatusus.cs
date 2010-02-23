using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class SyncStatusus {
        
        public SyncStatusus() {
        }
        
        public virtual System.DateTime LastSyncDate {
            get;
            set;
        }
        
        public virtual string CreateId {
            get;
            set;
        }
   	 protected bool Equals(SyncStatusus entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as SyncStatusus);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
