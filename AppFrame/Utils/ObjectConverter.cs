
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;

using NHibernate.Type;

namespace AppFrame.Utils
{
    public sealed class ObjectConverter
    {

        /*public static TDestinationClass Convert<TDestinationClass, TSourceClass>(TSourceClass source)
        {
            MapperRepository repository = MapperRepository.Instance();
            BaseMapper<TDestinationClass, TSourceClass> mapper = repository.Get(source.GetType().FullName) as BaseMapper<TDestinationClass, TSourceClass>;
            return mapper.Convert(source);
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="destType"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static object ConvertBaseValue(Type destType, string p)
        {
            switch (destType.Name)
            {

                case "Int32":
                    if (p.Length == 0)
                        return 0;
                    System.Int32 int32Obj = 0;
                    Int32.TryParse(p, out int32Obj);
                    return int32Obj;
                    break;
                case "Int64":
                    if (p.Length == 0)
                        return 0;
                    System.Int64 int64Obj = 0;
                    Int64.TryParse(p, out int64Obj);
                    return int64Obj;
                    break;
                case "String":
                    return p;
                    break;
                case "Boolean":
                    if (p.Length == 0)
                        return false;
                    System.Boolean boolObj = false;
                    Boolean.TryParse(p, out boolObj);
                    return boolObj;
                    break;
                case "DateTime":
                    if (p.Length == 0)
                        return DateTime.Now;
                    System.DateTime dateTimeObj;
                    DateTime.TryParseExact(p, "dd-MM-yyyy", null, DateTimeStyles.None, out dateTimeObj);
                    return dateTimeObj;
                    break;
                default:
                    return p;
            }


        }

        public static T Convert<T>(string source)
        {
            Type destType = typeof(T);
            switch (destType.Name)
            {

                case "Int32":
                    if (String.IsNullOrEmpty(source))
                        return (T)System.Convert.ChangeType(0, destType);

                    System.Int32 int32Obj = 0;
                    Int32.TryParse(source, out int32Obj);
                    return (T)System.Convert.ChangeType(int32Obj, destType);
                    break;
                case "Int64":
                    if (String.IsNullOrEmpty(source))
                        return (T)System.Convert.ChangeType(0, destType);

                    System.Int64 int64Obj = 0;
                    Int64.TryParse(source, out int64Obj);
                    return (T)System.Convert.ChangeType(int64Obj, destType);
                    break;

                case "Boolean":
                    if (String.IsNullOrEmpty(source))
                        return (T)System.Convert.ChangeType(0, destType);
                    System.Boolean boolObj = false;
                    Boolean.TryParse(source, out boolObj);
                    return (T)System.Convert.ChangeType(boolObj, destType);
                    break;
                case "DateTime":
                    if (String.IsNullOrEmpty(source))
                    {
                        return (T)System.Convert.ChangeType(DateTime.Now, destType);
                    }
                    System.DateTime dateTimeObj;
                    DateTime.TryParseExact(source, "dd-MM-yyyy", null, DateTimeStyles.None, out dateTimeObj);
                    return (T)System.Convert.ChangeType(dateTimeObj, destType);
                    break;

                case "String":
                default:
                    return (T)System.Convert.ChangeType(source, destType);
            }
        }

        public static T Parse<T>(string sourceValue) where T : IConvertible
        {
            return (T)System.Convert.ChangeType(sourceValue, typeof(T));
        }

        public static T Parse<T>(string sourceValue, IFormatProvider provider) where T : IConvertible
        {
            return (T)System.Convert.ChangeType(sourceValue, typeof(T), provider);
        }


        ////Usage
        //DateTime datetime = GenericConverter.Parse<DateTime>("12.10.2007");


        //IFormatProvider providerEN = new System.Globalization.CultureInfo("en-US", true);
        //IFormatProvider providerTR = new System.Globalization.CultureInfo("tr-TR", true);

        //DateTime x = GenericConverter.Parse<DateTime>("12.10.2007", providerTR); // ddMMyyyy
        //DateTime y = GenericConverter.Parse<DateTime>("12.10.2007", providerEN); // MMddyyyy

        //int iValue = GenericConverter.Parse<int>("12");

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(IList list)
        {
            IList<T> retList = new List<T>();
            if (list == null)
            {
                return retList;
            }

            foreach (T t in list)
            {
                retList.Add(t);
            }
            return retList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(BindingList<T> list)
        {
            IList<T> retList = new List<T>();
            if (list == null)
            {
                return retList;
            }

            foreach (T t in list)
            {
                retList.Add(t);
            }
            return retList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inType"></param>
        /// <returns></returns>
        public static IType ConvertToNHibernateType(Type inType)
        {
            switch (inType.Name)
            {

                case "Int32":
                    return NHibernate.NHibernateUtil.Int32;
                    break;
                case "Int64":
                    return NHibernate.NHibernateUtil.Int64;
                    break;
                case "String":
                    return NHibernate.NHibernateUtil.String;
                    break;
                case "Boolean":
                    return NHibernate.NHibernateUtil.Boolean;
                    break;
                case "DateTime":
                    return NHibernate.NHibernateUtil.DateTime;
                    break;
                default:
                    return null;
            }


        }

        public static IList ConvertFrom<T>(BindingList<T> list)
        {
            IList retList = new ArrayList();
            foreach (T t in list)
            {
                retList.Add(t);
            }
            return retList;
        }
        public static IList ConvertFrom<T>(IList<T> list)
        {
            IList retList = new ArrayList();
            foreach (T t in list)
            {
                retList.Add(t);
            }
            return retList;
        }


        /*public static DataTable ConvertToDataTable(DataGridView dataGridView)
        {
            DataGridViewColumnCollection properties= dataGridView.Columns;
            DataTable table = CreateDataTable(properties);
            DataGridViewRowCollection rows = dataGridView.Rows;
            foreach (DataGridViewRow row in rows)
            {
                FillData(row,table);
            }
            return table;
        }

        private static DataTable CreateDataTable(DataGridViewColumnCollection properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (DataGridViewColumn column in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = column.HeaderText;
                dc.DataType = typeof(string);
                dt.Columns.Add(dc);    
            } 
            return dt;
        }

        private static void FillData(DataGridViewRow row, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            
            foreach (DataGridViewCell cell in  row.Cells)
            {
                string value = "";
                if(cell.Value!=null)
                {
                    value = cell.Value.ToString(); 
                }
                dr[cell.OwningColumn.HeaderText] = value;
            }
            dt.Rows.Add(dr);
        }*/

        #region Converting ObjectArray to Datatable
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            PropertyInfo[] properties = list.GetType().GetGenericArguments()[0].GetProperties();
            DataTable dt = ToDataTable(properties);
            if (list.Count > 0)
            {
                foreach (T t in list)
                {
                    FillData(properties, dt, t);
                }
                    
            }
            return dt;                 
        }
        public static DataTable ToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = ToDataTable(properties);
            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            return dt;
        }

        private static DataTable ToDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }
            return dt;
        }
        
        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IList<T> ToList<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ToList<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ToList<T>(rows);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

    }
}