using System; 
using System.Text; 
using System.Collections.Generic; 
using System.Runtime.Serialization; 
using Caliburn.PresentationFramework.Behaviors; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class ReturnBlockInPK {
        
        [DataMember(Name="1", Order=1)]
        public virtual long BlockDetailId {
            get;
            set;
        }
        
        [DataMember(Name="2", Order=2)]
        public virtual long BlockInId {
            get;
            set;
        }
   	 protected bool Equals(ReturnBlockInPK entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as ReturnBlockInPK);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
