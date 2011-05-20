using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Utility
{
    public sealed class NumberUtility
    {
        public static long ParseLong(object value)
        {
            if (value == null)
            {
                return 0;
            }
            long returnValue = 0;
            Int64.TryParse(value.ToString(), out returnValue);
            return returnValue;
        }

        public static int ParseInt(object value)
        {
            if (value == null)
            {
                return 0;
            }
            int returnValue = 0;
            Int32.TryParse(value.ToString(), out returnValue);
            return returnValue;
        }

        public static bool CheckLong(object value, out long outValue)
        {
            if (value == null || value.ToString().Length <= 0)
            {
                outValue = 0;
                return false;
            }
            return Int64.TryParse(value.ToString(), out outValue);
        }

        public static bool CheckLongNullIsZero(object value, out long outValue)
        {
            if (value == null || value.ToString().Length <= 0)
            {
                outValue = 0;
                return true;
            }
            return Int64.TryParse(value.ToString(), out outValue);
        }
    }

}
