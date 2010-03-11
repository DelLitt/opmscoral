using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class ReturnBlockInPK {
        
        public virtual long BlockDetailId {
            get;
            set;
        }
        
        public virtual long BlockInId {
            get;
            set;
        }
   	 protected bool Equals(ReturnBlockInPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as ReturnBlockInPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
