using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class DepartmentTimeline : System.IComparable
    {
        public virtual DepartmentTimelinePK DepartmentTimelinePK { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual DateTime WorkingDay { get; set; }
        public virtual DateTime CreateDate
        {
            get;set;
        }
        public virtual string CreateId
        {
            get;set;
        }
        public virtual DateTime UpdateDate
        {
            get;
            set;
        }
        public virtual string UpdateId
        {
            get;set;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: 
        ///                     Value 
        ///                     Meaning 
        ///                     Less than zero 
        ///                     This instance is less than <paramref name="obj"/>. 
        ///                     Zero 
        ///                     This instance is equal to <paramref name="obj"/>. 
        ///                     Greater than zero 
        ///                     This instance is greater than <paramref name="obj"/>. 
        /// </returns>
        /// <param name="obj">An object to compare with this instance. 
        ///                 </param><exception cref="T:System.ArgumentException"><paramref name="obj"/> is not the same type as this instance. 
        ///                 </exception><filterpriority>2</filterpriority>
        public virtual int CompareTo(object obj)
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (DepartmentTimeline)) return false;
            return Equals((DepartmentTimeline) obj);
        }

        public override int GetHashCode()
        {
            return (DepartmentTimelinePK != null ? DepartmentTimelinePK.GetHashCode() : 0);
        }
    }
}
