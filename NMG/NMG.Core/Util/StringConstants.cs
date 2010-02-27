using System;

namespace NMG.Core.Util
{
    public class StringConstants
    {
        public static string ORACLE_CONN_STR_TEMPLATE = "Data Source=XE;User Id=Sample; Password=password;";
        public static string SQL_CONN_STR_TEMPLATE = "Data Source=localhost;Initial Catalog=Sample;Integrated Security=SSPI;";

        public static string SQLCE_CONN_STR_TEMPLATE = @"Data Source=C:\Data\pos2.sdf;Password=admin;";
        
    }
}