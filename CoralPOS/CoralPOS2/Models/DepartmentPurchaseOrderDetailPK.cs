using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class DepartmentPurchaseOrderDetailPK {
        
        public virtual long DepartmentId {
            get;
            set;
        }
        
        public virtual long PurchaseOrderDetailId {
            get;
            set;
        }
        
        public virtual string PurchaseOrderId {
            get;
            set;
        }
   	 protected bool Equals(DepartmentPurchaseOrderDetailPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as DepartmentPurchaseOrderDetailPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}