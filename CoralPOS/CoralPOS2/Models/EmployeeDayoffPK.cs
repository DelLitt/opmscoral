using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class EmployeeDayoffPK {
        
        public virtual System.DateTime DayoffTime {
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
   	 protected bool Equals(EmployeeDayoffPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as EmployeeDayoffPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
