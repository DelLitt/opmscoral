using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppFrame.Utility.Mapper
{
    public abstract class BaseTransform<TDestination,TSource>
    {

        /// <summary>
        /// Contains mapped control and mapping properties
        /// </summary>
        private Dictionary<string, string> mapProps = new Dictionary<string, string>();

        /// <summary>
        /// Contains mapped control and mapping properties
        /// </summary>
        public Dictionary<string, string> MapProperties
        {
            get { return mapProps; }
            set { mapProps = value; }
        }

        /// <summary>
        /// Transform object to another object.
        /// </summary>
        /// <param name="tDestination">destination</param>
        /// <param name="sourceObject">source</param>
        public abstract void Transform(ref TDestination tDestination, TSource sourceObject);

        
        public PropertyInfo GetProperty(object source,string property)
        {
            PropertyInfo[] props = source.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.Equals(property))
                {
                    return prop;
                }
            }
            return null;
        }
        

        /// <summary>
        /// Set value of a property of an object to another object.
        /// </summary>
        /// <param name="destination">destination</param>
        /// <param name="destProperty">destination property</param>
        /// <param name="source">source</param>
        /// <param name="sourceProperty">source property</param>
        public void SetValue( object destination, string destProperty, object source, string sourceProperty)
        {

            PropertyInfo sourcePropertyInfo = GetProperty(source,sourceProperty );
            PropertyInfo destPropertyInfo = GetProperty(destination,destProperty);
            if (sourceProperty == null || destProperty == null)
            {
                return;
            }

            object settingValue = ConvertBaseValue(destPropertyInfo.PropertyType,
                                                   sourcePropertyInfo.PropertyType,
                                                   sourcePropertyInfo.GetValue(source, null));

            destPropertyInfo.SetValue(destination, settingValue, null);
        }

        /// <summary>
        /// Convert value of a type to value of another Type
        /// </summary>
        /// <param name="destType">Destination Type</param>
        /// <param name="srcValue">value need to convert</param>
        /// <param name="srcType">Type of value need to convert </param>
        /// <returns></returns>
        public object ConvertBaseValue(Type destType, Type srcType, object srcValue)
        {

            switch (srcType.Name)
            {

                case "Int32":
                    return ((Int32)srcValue).ToString();
                    break;
                case "Int64":
                    return ((Int64)srcValue).ToString();
                    break;
                case "String":
                    return srcValue;
                    break;
                case "Boolean":
                    return srcValue;
                    break;
                case "DateTime":

                    return ((DateTime)srcValue).ToShortDateString();
                    break;
                default:
                    return srcValue;
            }
        }
    }
}
