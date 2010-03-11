using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class UserRole {
        
        public UserRole() {
        }
        
        public virtual UserRolePK UserRolePK {
            get;
            set;
        }
        
        public virtual Role Role {
            get;
            set;
        }
        
        public virtual UserInfo UserInfo {
            get;
            set;
        }
   	 protected bool Equals(UserRole entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as UserRole);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
