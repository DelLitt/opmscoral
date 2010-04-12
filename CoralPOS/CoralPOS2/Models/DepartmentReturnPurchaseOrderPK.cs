using Caliburn.PresentationFramework.Behaviors; 
using System.Runtime.Serialization; 
using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class DepartmentReturnPurchaseOrderPK {
        
        [DataMember(Name="1", Order=1)]
        public virtual System.DateTime CreateDate {
            get;
            set;
        }
        
        [DataMember(Name="2", Order=2)]
        public virtual long DepartmentId {
            get;
            set;
        }
        
        [DataMember(Name="3", Order=3)]
        public virtual long PurchaseOrderDetailId {
            get;
            set;
        }
        
        [DataMember(Name="4", Order=4)]
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
