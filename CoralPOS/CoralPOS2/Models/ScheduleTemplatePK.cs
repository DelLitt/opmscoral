using System; 
using System.Text; 
using System.Collections.Generic; 
using System.Runtime.Serialization; 
using Caliburn.PresentationFramework.Behaviors; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class ScheduleTemplatePK {
        
        [DataMember(Name="1", Order=1)]
        public virtual long DepartmentId {
            get;
            set;
        }
        
        [DataMember(Name="2", Order=2)]
        public virtual string EmployeeId {
            get;
            set;
        }
        
        [DataMember(Name="3", Order=3)]
        public virtual long ScheduleId {
            get;
            set;
        }
   	 protected bool Equals(ScheduleTemplatePK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as ScheduleTemplatePK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
