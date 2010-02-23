using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class DepartmentPurchaseOrderPK {
        
        public virtual long DepartmentId {
            get;
            set;
        }
        
        public virtual string PurchaseOrderId {
            get;
            set;
        }
   	 protected bool Equals(DepartmentPurchaseOrderPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as DepartmentPurchaseOrderPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
