using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class DepartmentReturnPurchaseOrderPK {
        
        public virtual System.DateTime CreateDate {
            get;
            set;
        }
        
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
   	 protected bool Equals(DepartmentReturnPurchaseOrderPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as DepartmentReturnPurchaseOrderPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
