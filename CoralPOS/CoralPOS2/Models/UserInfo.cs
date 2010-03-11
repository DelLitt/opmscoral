using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class UserInfo {
        
        public UserInfo() {
        }
        
        public virtual string Username {
            get;
            set;
        }
        
        public virtual long Deleted {
            get;
            set;
        }
        
        public virtual long DepartmentId {
            get;
            set;
        }
        
        public virtual string EmployeeId {
            get;
            set;
        }
        
        public virtual string Password {
            get;
            set;
        }
        
        public virtual long Suspended {
            get;
            set;
        }
   	 protected bool Equals(UserInfo entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as UserInfo);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
