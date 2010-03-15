using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

        public static void AddToList<TClass>(IList destList, Collection<TClass> srcList, string propertyName)
        {
            foreach (TClass compareObj in srcList)
            {
                bool isFound = false;
                PropertyInfo info1 = compareObj.GetType().GetProperty(propertyName, typeof (string));
                string value1 = (string) (info1.GetValue(compareObj, null));
                foreach (var obj in destList)
                {
                    TClass destObj = (TClass) obj;
                    PropertyInfo info2 = destObj.GetType().GetProperty(propertyName, typeof(string));
                    string value2 = (string)(info2.GetValue(destObj, null));
                    if(!string.IsNullOrEmpty(value1) && value1.Equals(value2))
                    {
                        isFound = true;
                        break;
                    }
                }
                if(isFound) continue;
                destList.Add(compareObj);
            }
        }

        public static void AddToList<TClass>(IList destList, IList<TClass> srcList, string propertyName)
        {
            foreach (TClass compareObj in srcList)
            {
                bool isFound = false;
                PropertyInfo info1 = compareObj.GetType().GetProperty(propertyName, typeof(string));
                string value1 = (string)(info1.GetValue(compareObj, null));
                foreach (var obj in destList)
                {
                    TClass destObj = (TClass)obj;
                    PropertyInfo info2 = destObj.GetType().GetProperty(propertyName, typeof(string));
                    string value2 = (string)(info2.GetValue(destObj, null));
                    if (!string.IsNullOrEmpty(value1) && value1.Equals(value2))
                    {
                        isFound = true;
                        break;
                    }
                }
                if (isFound) continue;
                destList.Add(compareObj);
            }
        }

        public static void RemoveFromList<TClass>(IList destList, IList<TClass> srcList, string propertyName)
        {
            foreach (TClass compareObj in srcList)
            {
                bool isFound = false;
                PropertyInfo info1 = compareObj.GetType().GetProperty(propertyName, typeof (string));
                string value1 = (string) (info1.GetValue(compareObj, null));
                foreach (var obj in destList)
                {
                    TClass destObj = (TClass) obj;
                    PropertyInfo info2 = destObj.GetType().GetProperty(propertyName, typeof (string));
                    string value2 = (string) (info2.GetValue(destObj, null));
                    if (!string.IsNullOrEmpty(value1) && value1.Equals(value2))
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound) continue;
                destList.Remove(compareObj);
            }
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
