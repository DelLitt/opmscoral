using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class EmployeeRewardPK {
        
        public virtual long DepartmentId {
            get;
            set;
        }
        
        public virtual string EmployeeId {
            get;
            set;
        }
        
        public virtual System.DateTime RewardDate {
            get;
            set;
        }
   	 protected bool Equals(EmployeeRewardPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as EmployeeRewardPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
