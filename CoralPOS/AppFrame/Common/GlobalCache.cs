using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public sealed class GlobalCache
    {
        // singleton instance
        private static GlobalCache globalCache = null;
        // inner map
        public IDictionary<string, object> globalMap = null;

        /// <summary>
        /// Define constant in global cache.
        /// </summary>
        public const string CURRENT_USER = "CurrentUser";

        
        private GlobalCache()
        {
            globalMap = new Dictionary<string, object>();
        }
        public static GlobalCache Instance
        {
            get
            {
                if (globalCache == null) globalCache = new GlobalCache();
                return globalCache;
            }
        }

        public bool IsSet(string key)
        {
            return globalMap.ContainsKey(key) && globalMap[key] != null;
        }
        public void Put(string key,object variable)
        {
            globalMap.Add(key,variable);
        }
        public IDictionary<string,object> Map
        {
            get
            {
                return globalMap;
            }
        }
    }
}
