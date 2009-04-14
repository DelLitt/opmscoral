﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class DepartmentManagement : System.IComparable
    {
        public virtual DepartmentManagementPK DepartmentManagementPK { get; set; }
        public virtual long Position { get; set; }
        public virtual DateTime CreateDate
        {
            get;
            set;
        }
        public virtual string CreateId
        {
            get;
            set;
        }
        public virtual DateTime UpdateDate
        {
            get;
            set;
        }
        public virtual string UpdateId
        {
            get;
            set;
        }

        public virtual bool Equals(DepartmentManagement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.DepartmentManagementPK, DepartmentManagementPK);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (DepartmentManagement)) return false;
            return Equals((DepartmentManagement) obj);
        }

        public override int GetHashCode()
        {
            return (DepartmentManagementPK != null ? DepartmentManagementPK.GetHashCode() : 0);
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
    }
}