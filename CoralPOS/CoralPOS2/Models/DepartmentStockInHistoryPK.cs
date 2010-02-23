using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class DepartmentStockInHistoryPK {
        
        public virtual long DestDepartmentId {
            get;
            set;
        }
        
        public virtual long SourceDepartmentid {
            get;
            set;
        }
        
        public virtual string StockInId {
            get;
            set;
        }
        
        public virtual long StockOutId {
            get;
            set;
        }
   	 protected bool Equals(DepartmentStockInHistoryPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as DepartmentStockInHistoryPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
