using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class EmployeeMoney  : System.IComparable
    {
        public virtual EmployeeMoneyPK EmployeeMoneyPK { get; set; }
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
        public virtual DateTime DateLogin
        {
            get;
            set;
        }
        public virtual DateTime DateLogout
        {
            get;
            set;
        }
        public virtual DateTime WorkingDay
        {
            get;
            set;
        }
        public virtual long InMoney
        {
            get;
            set;
        }

        public virtual long OutMoney
        {
            get;
            set;
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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}