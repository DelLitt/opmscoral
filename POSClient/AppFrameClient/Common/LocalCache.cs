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
    }
}
