using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace AppFrame.Utility.Mapper
{
    /// <summary>
    /// Converter convert from a Form to an Object
    /// </summary>
    /// <typeparam name="TDestinationClass">Result object</typeparam>
    /// <typeparam name="TSourceClass">Source form</typeparam>
    public class ModelMapper<TDestinationClass, TSourceClass> : BaseMapper<TDestinationClass,TSourceClass> where TSourceClass : Form, new()
    {
        public ModelMapper()
        {
                        
        }
        /// <summary>
        /// Convert from TextBox,ComboBox to immuntable object such as Int32,In64,Boolean,String
        /// </summary>
        /// <param name="source">Form</param>
        /// <returns>converted object</returns>
        public TDestinationClass Convert(TSourceClass source)
        {
            TDestinationClass destinationClass = (TDestinationClass)Activator.CreateInstance(typeof(TDestinationClass));
            Type sourceType = source.GetType();
            Type destType = destinationClass.GetType();
            PropertyInfo[] destFields = destType.GetProperties();
            
            foreach (Control control in source.Controls)
            {
                PropertyInfo destProp = GetPropertyFromName(control.Name, destFields);
                // if control is textbox
                if ((control.GetType().Name == typeof(TextBox).Name) && destProp != null)
                {
                    Type destPropType = destProp.PropertyType;                    
                    destProp.SetValue(destinationClass,
                        ConvertBaseValue(destPropType, ((TextBox)control).Text), null);
                }

                // if control is textbox
                if ((control.GetType().Name == typeof(ComboBox).Name) && destProp != null)
                {
                    Type destPropType = destProp.PropertyType;
                    destProp.SetValue(destinationClass,
                        ConvertBaseValue(destPropType,((ComboBox)control).SelectedValue.ToString()), null);

                }


            }
            return destinationClass;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destType"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private object ConvertBaseValue(Type destType, string p)
        {
            switch (destType.Name)
            {

                case "Int32":
                    System.Int32 int32Obj = 0;
                    Int32.TryParse(p, out int32Obj);
                    return int32Obj;
                    break;
                case "Int64":
                    System.Int64 int64Obj = 0;
                    Int64.TryParse(p, out int64Obj);
                    return int64Obj;
                    break;
                case "String":
                    return p;
                    break;
                case "Boolean":
                    System.Boolean boolObj = false;
                    Boolean.TryParse(p, out boolObj);
                    return boolObj;
                    break;
                case "DateTime":
                    System.DateTime dateTimeObj;
                    DateTime.TryParseExact(p, "dd-MM-yyyy", null, DateTimeStyles.None, out dateTimeObj);
                    return dateTimeObj;
                    break;
                default:
                    return p;
            }
        }

        private PropertyInfo GetPropertyFromName(string name, PropertyInfo[] fields)
        {
            string[] hungaryPatterns = new string[] {
                "txt","cbo" };
            if (CheckUtility.StringStartWith(name, hungaryPatterns))
            {
                name = name.Substring(3);
            }
            foreach (PropertyInfo propertyInfo in fields)
            {
                if (name.Equals(propertyInfo.Name))
                {
                    return propertyInfo;
                }
            }
            return null;
        }
    }
}