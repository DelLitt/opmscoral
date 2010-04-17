using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Utility.Mapper
{
    public abstract class ObjectTransform<TObject,TForm> where TForm :Form , new()
    {
        /// <summary>
        /// Contains mapped control and mapping properties
        /// </summary>
        protected Dictionary<string, string> mapProps = new Dictionary<string, string>();
        
        /// <summary>
        /// Transform object model to a form.
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="sourceObject">Object Model</param>
        public abstract void Transform(ref TForm form, TObject sourceObject);

        /// <summary>
        /// Transoform an model to a form in a basic way
        /// </summary>
        /// <param name="form">destination form</param>
        /// <param name="sourceObject">object model</param>
        public void BaseTransform(ref TForm form, TObject sourceObject)
        {
            const char SEPARATOR = '.';
            IEnumerator enumMap = mapProps.Keys.GetEnumerator();


            while (enumMap.MoveNext())
            {
                // get key under string[] 
                string[] controlInfo = enumMap.Current.ToString().Split(SEPARATOR);
                // get control name
                string controlName = controlInfo[0];
                // get control value
                string controlValue = controlInfo[1];
                // get control needs to set value
                Control control = form.Controls[controlName];

                string key = (string)enumMap.Current;

                SetValue(ref control, controlValue, sourceObject, mapProps[key]);

            }
        }
        
        /// <summary>
        /// Get PropertyInfo from property name in a source object
        /// </summary>
        /// <param name="propertyName">Name of properties</param>
        /// <param name="sourceObject">source object</param>
        /// <returns></returns>
        public PropertyInfo GetProperty(string propertyName, object sourceObject)
        {
            PropertyInfo[] props = sourceObject.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.Equals(propertyName))
                {
                    return prop;
                }
            }
            return null;
        }

        /// <summary>
        /// Set value of a property of an object to a control in a form.
        /// </summary>
        /// <param name="control">Control need to set value</param>
        /// <param name="destProperty">property of Control need to set value</param>
        /// <param name="sourceObject">object model</param>
        /// <param name="sourceProperty">property of model need to get value</param>
        public void SetValue(ref Control control, string destProperty, object sourceObject, string sourceProperty)
        {

            PropertyInfo sourcePropertyInfo = GetProperty(sourceProperty, sourceObject);
            PropertyInfo destPropertyInfo = GetProperty(destProperty, control);
            if (sourceProperty == null || destProperty == null)
            {
                return;
            }

            object settingValue = ConvertBaseValue(destPropertyInfo.PropertyType,
                                               sourcePropertyInfo.GetValue(sourceObject, null), sourcePropertyInfo.PropertyType);

            destPropertyInfo.SetValue(control, settingValue, null);
        }

        /// <summary>
        /// Convert value of a type to value of another Type
        /// </summary>
        /// <param name="destType">Destination Type</param>
        /// <param name="srcValue">value need to convert</param>
        /// <param name="srcType">Type of value need to convert </param>
        /// <returns></returns>
        private object ConvertBaseValue(Type destType, object srcValue, Type srcType)
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
