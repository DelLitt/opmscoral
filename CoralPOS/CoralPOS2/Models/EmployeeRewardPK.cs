using System;
using System.Runtime.Serialization;
using AppFrame.Validation;


namespace CoralPOS.Models {
	
	
	[Serializable()]
	[Validate()]
	[DataContract()]
	public class EmployeeRewardPK {
		
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
