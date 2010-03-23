using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Spring.Context;
using System.Linq;
using System.Linq.Expressions;
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
        /// Add with distinc values
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="destList"></param>
        /// <param name="srcList"></param>
        /// <param name="propertyName"></param>
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

        /// <summary>
        /// Add with distinc values
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="destList"></param>
        /// <param name="srcList"></param>
        /// <param name="func"></param>
        public static void AddToList<TClass>(IList destList, Collection<TClass> srcList, Expression<Func<TClass,string>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            string propName = memberExpression.Member.Name;
            AddToList(destList,srcList,propName);
        }

        /// <summary>
        /// Add with distinc values
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="destList"></param>
        /// <param name="srcList"></param>
        /// <param name="propertyName"></param>
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

        /// <summary>
        /// Remove with distinc values
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="destList"></param>
        /// <param name="srcList"></param>
        /// <param name="propertyName"></param>
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



        public static void RemoveFromList<TClass>(IList srcList, TClass element, string propertyName)
        {
            PropertyInfo info1 = element.GetType().GetProperty(propertyName, typeof(string));
            string value1 = (string)(info1.GetValue(element, null));
            object foundElement = null;
            foreach (TClass compareObj in srcList)
            {
                    PropertyInfo info2 = compareObj.GetType().GetProperty(propertyName, typeof(string));
                    string value2 = (string)(info2.GetValue(compareObj, null));
                    if (!string.IsNullOrEmpty(value1) && value1.Equals(value2))
                    {
                        foundElement = compareObj;
                        break;
                    }
             }
             if (foundElement==null) return;
             srcList.Remove(foundElement);
        }

        public static void AddToList<T>(IList list, IList srcList, Expression<Func<T, string>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            string propName = memberExpression.Member.Name;
            AddToList<T>(list, srcList, propName);
        }

        public static void AddToList<TClass>(IList destList, IList srcList, string propertyName)
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
    }
}
