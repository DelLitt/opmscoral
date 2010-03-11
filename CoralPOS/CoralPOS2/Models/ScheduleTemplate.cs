using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class ScheduleTemplate {
        
        public ScheduleTemplate() {
        }
        
        public virtual ScheduleTemplatePK ScheduleTemplatePK {
            get;
            set;
        }
        
        public virtual System.DateTime CreateDate {
            get;
            set;
        }
        
        public virtual string CreateId {
            get;
            set;
        }
        
        public virtual long DelFlg {
            get;
            set;
        }
        
        public virtual System.DateTime EndDate {
            get;
            set;
        }
        
        public virtual long ExFld1 {
            get;
            set;
        }
        
        public virtual long ExFld2 {
            get;
            set;
        }
        
        public virtual long ExFld3 {
            get;
            set;
        }
        
        public virtual string ExFld4 {
            get;
            set;
        }
        
        public virtual string ExFld5 {
            get;
            set;
        }
        
        public virtual long ExclusiveKey {
            get;
            set;
        }
        
        public virtual long Friday {
            get;
            set;
        }
        
        public virtual long Monday {
            get;
            set;
        }
        
        public virtual long Saturday {
            get;
            set;
        }
        
        public virtual System.DateTime StartDate {
            get;
            set;
        }
        
        public virtual long Sunday {
            get;
            set;
        }
        
        public virtual long Thursday {
            get;
            set;
        }
        
        public virtual long Tuesday {
            get;
            set;
        }
        
        public virtual System.DateTime UpdateDate {
            get;
            set;
        }
        
        public virtual string UpdateId {
            get;
            set;
        }
        
        public virtual long Wednesday {
            get;
            set;
        }
   	 protected bool Equals(ScheduleTemplate entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as ScheduleTemplate);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
