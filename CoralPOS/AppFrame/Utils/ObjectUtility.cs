using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame.Utils
{
    public class ObjectUtility
    {
        public static T GetObject<T>(string name)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            var obj = ctx.GetObject(name);
            return (T) obj;
        }

        /// <summary>
        /// Check object is null or empty if a list
        /// </summary>
        /// <param name="checkingObj"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(object checkingObj)
        {
            if (checkingObj == null) return true;

            Type type = checkingObj.GetType();
            if(type == typeof(string))
            {
                return string.IsNullOrEmpty((string)checkingObj);
            }

            if(type.IsArray)
            {
                return ((object[]) checkingObj).Count() == 0;
            }
            if(type.IsSubclassOf(typeof(ICollection)))
            {
                return ((ICollection) checkingObj).Count == 0;
            }
            return false;
        }
    }
}
