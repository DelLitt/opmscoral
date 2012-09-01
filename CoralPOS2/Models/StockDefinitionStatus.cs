using System;
using System.Runtime.Serialization;
using AppFrame.Validation;


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class StockDefinitionStatus {
        
        public StockDefinitionStatus() {
        }
        
        [DataMember(Name="1", Order=1)]
        public virtual long DefectStatusId {
            get;
            set;
        }
        
        [DataMember(Name="2", Order=2)]
        public virtual string DefectStatusName {
            get;
            set;
        }
        [DataMember(Name = "3", Order = 3)]
        public virtual string DefectStatusDescription
        {
            get;
            set;
        }
   	 protected bool Equals(StockDefinitionStatus entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as StockDefinitionStatus);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }

    public class DefinitionStatus
    {
        public const long NORMAL_STOCKOUT = 0;
        public const long ERROR = 1;
        public const long DAMAGE = 2;
        public const long LOST = 3;
        public const long TEMP_STOCKOUT = 4;
        public const long TO_PRODUCER = 5;
        public const long TO_MAINSTOCK = 6;
        public const long TO_OTHER_DEPT = 7;
        public const long DESTROY_LOST_AND_DAMAGE = 8;
        public const long PROTOTYPE = 9;
    }
}
