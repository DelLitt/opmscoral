using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class StockDefinitionStatus {
        
        public StockDefinitionStatus() {
        }
        
        public virtual long DefectStatusId {
            get;
            set;
        }
        
        public virtual string DefectStatusName {
            get;
            set;
        }
   	 protected bool Equals(StockDefinitionStatus entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockDefinitionStatus);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
