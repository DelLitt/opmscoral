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
    }
}
