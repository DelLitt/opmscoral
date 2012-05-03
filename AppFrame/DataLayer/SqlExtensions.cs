using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;

namespace AppFrame.DataLayer
{
    public static class SqlExtensions
    {
        public static int Day(this IDbMethods methods, System.DateTime dateTime) { return 0; }
        public static int Day(this IDbMethods methods, System.DateTime? dateTime) { return 0; }
        public static int Month(this IDbMethods methods, System.DateTime dateTime) { return 0; }
        public static int Month(this IDbMethods methods, System.DateTime? dateTime) { return 0; }
        public static int Year(this IDbMethods methods, System.DateTime dateTime) { return 0; }
        public static int Year(this IDbMethods methods, System.DateTime? dateTime) { return 0; }
        public static char Char(this IDbMethods methods, int value) { return char.MinValue; }
        public static char Char(this IDbMethods methods, int? value) { return char.MinValue; }
        public static string Lower(this IDbMethods methods, string value) { return null; }
        public static string Upper(this IDbMethods methods, string value) { return null; }
        public static int Ascii(this IDbMethods methods, string value) { return 0; }
        public static int Ascii(this IDbMethods methods, char value) { return 0; }
        public static int Ascii(this IDbMethods methods, char? value) { return 0; }
        public static int Len(this IDbMethods methods, string value) { return 0; }
    }
}
