using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class DepartmentPurchaseOrderDetailLogPK {
        
        public virtual long DepartmentId {
            get;
            set;
        }
        
        public virtual long PurchaseOrderDetailLogId {
            get;
            set;
        }
   	 protected bool Equals(DepartmentPurchaseOrderDetailLogPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as DepartmentPurchaseOrderDetailLogPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
