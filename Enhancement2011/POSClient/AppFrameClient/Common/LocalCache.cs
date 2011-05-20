using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrameClient.Common
{
    public class LocalCache
    {
        private static LocalCache localCache = null;
        public const string HID_KEYBOARD_DEVICE = "HID Keyboard";
        public const int USER_BARCODE_LENGTH = 8;
        public const string ADHOC_USERNAME = "pos";
        private LocalCache()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static LocalCache Instance()
        {
            if (localCache == null)
            {
                localCache = new LocalCache();
            }
            return localCache;
        }
        public BaseUser PreviousUser
        {
            get; set;
        }
        public BaseUser CurrentUser
        { 
            get; set;
        }

        public bool InputFromBarcodeReader
        {
            get; set;
        }
    }
}
