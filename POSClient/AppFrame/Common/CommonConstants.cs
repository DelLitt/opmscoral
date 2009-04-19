using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    public sealed class CommonConstants
    {
        public static readonly string ERROR_RESOURCES = "errorResources";
        public static readonly string MESSAGE_RESOURCES = "messageResources";

        public static readonly long DEL_FLG_YES = 1;
        public static readonly long DEL_FLG_NO = 0;
        public static readonly int PRODUCT_ID_LENGTH = 12;

        public static readonly string SERVER_SYNC_FORMAT = ".exp";
        public static readonly string CLIENT_SYNC_FORMAT = ".imp";
        public static int MAX_QUERY_RESULT = 50;
        public static string UNDEFINED_BARCODE = "000000000000";
        public static string UNDEFINED_BARCODE_MARK ="000";
        public static int UNDEFINED_BARCODE_MARK_LENGTH = 3;
        public static int EMPLOYEE_BARCODE_LENGTH = 8;
        public static string LAST_SYNCTIME_SERVER_FILE = "_LastSyncTime.exp";
        public static string LAST_SYNCTIME_CLIENT_FILE = "_LastSyncTime.imp";
    }
}
