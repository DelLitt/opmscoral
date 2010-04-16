using System; 
using System.Text; 
using System.Collections.Generic; 
using System.Runtime.Serialization; 
using Caliburn.PresentationFramework.Behaviors; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class UserRole {
        
        public UserRole() {
        }
        
        [DataMember(Name="3", Order=3)]
        public virtual UserRolePK UserRolePK {
            get;
            set;
        }
        
        [DataMember(Name="4", Order=4)]
        public virtual Role Role {
            get;
            set;
        }
        
        [DataMember(Name="5", Order=5)]
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
