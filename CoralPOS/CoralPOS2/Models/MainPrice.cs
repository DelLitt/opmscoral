using System; 
using System.Text; 
using System.Collections.Generic; 
using System.Runtime.Serialization;
using AppFrame.WPF.ValidationAttributes;
using Caliburn.PresentationFramework.Behaviors; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class MainPrice {
        
        public MainPrice() {
        }
        
        [DataMember(Name="3", Order=3)]
        public virtual MainPricePK MainPricePK {
            get;
            set;
        }
        
        [DataMember(Name="4", Order=4)]
        public virtual System.DateTime CreateDate {
            get;
            set;
        }
        
        [DataMember(Name="5", Order=5)]
        public virtual string CreateId {
            get;
            set;
        }
        
        [DataMember(Name="6", Order=6)]
        public virtual long DelFlg {
            get;
            set;
        }
        
        [DataMember(Name="7", Order=7)]
        public virtual long ExFld1 {
            get;
            set;
        }
        
        [DataMember(Name="8", Order=8)]
        public virtual long ExFld2 {
            get;
            set;
        }
        
        [DataMember(Name="9", Order=9)]
        public virtual long ExFld3 {
            get;
            set;
        }
        
        [DataMember(Name="10", Order=10)]
        public virtual string ExFld4 {
            get;
            set;
        }
        
        [DataMember(Name="11", Order=11)]
        public virtual string ExFld5 {
            get;
            set;
        }
        
        [DataMember(Name="12", Order=12)]
        public virtual long ExclusiveKey {
            get;
            set;
        }
        
        [DataMember(Name="13", Order=13)]
        [Min(1)]
        public virtual long Price {
            get;
            set;
        }
        
        [DataMember(Name="14", Order=14)]
        public virtual System.DateTime UpdateDate {
            get;
            set;
        }
        
        [DataMember(Name="15", Order=15)]
        public virtual string UpdateId {
            get;
            set;
        }
        
        [DataMember(Name="16", Order=16)]
        [Min(0)]
        public virtual long WholeSalePrice {
            get;
            set;
        }
   	 protected bool Equals(MainPrice entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as MainPrice);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
