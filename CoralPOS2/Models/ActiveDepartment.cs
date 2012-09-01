using System;
using System.Runtime.Serialization;
using AppFrame.Validation;


namespace CoralPOS.Models {
	
	
	[Serializable()]
	[Validate()]
	[DataContract()]
	public class ActiveDepartment {
		
		public ActiveDepartment() {
		}
		
		[DataMember(Name="1", Order=1)]
		public virtual long DepartmentId {
			get;
			set;
		}
		
		[DataMember(Name="2", Order=2)]
		public virtual long Active {
			get;
			set;
		}
		
		[DataMember(Name="3", Order=3)]
		public virtual string DepartmentName {
			get;
			set;
		}
		
		[DataMember(Name="4", Order=4)]
		public virtual Department Department {
			get;
			set;
		}
	 protected bool Equals(ActiveDepartment entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as ActiveDepartment);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
