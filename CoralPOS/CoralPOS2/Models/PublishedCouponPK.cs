using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class PublishedCouponPK {
        
        public virtual long CouponId {
            get;
            set;
        }
        
        public virtual long DepartmentId {
            get;
            set;
        }
        
        public virtual long PublishedCouponId {
            get;
            set;
        }
   	 protected bool Equals(PublishedCouponPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as PublishedCouponPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
