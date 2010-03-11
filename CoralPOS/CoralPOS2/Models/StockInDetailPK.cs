using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class StockInDetailPK {
        
        public virtual string ProductId {
            get;
            set;
        }
        
        public virtual string StockInId {
            get;
            set;
        }
   	 protected bool Equals(StockInDetailPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockInDetailPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
