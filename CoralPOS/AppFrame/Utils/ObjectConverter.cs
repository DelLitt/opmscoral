
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
        public static List<T> ConvertGenericList<T>(IList list)
        {
            List<T> retList = new List<T>();
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
        public static List<T> ConvertGenericList<T>(BindingList<T> list)
        {
            List<T> retList = new List<T>();
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

        public static IList ConvertToNonGenericList<T>(BindingList<T> list)
        {
            IList retList = new ArrayList();
            foreach (T t in list)
            {
                retList.Add(t);
            }
            return retList;
        }
        public static IList ConvertToNonGenericList<T>(IList<T> list)
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
            DataTable dt = CreateDataTable(properties);
            if (list.Count > 0)
            {
                foreach (T t in list)
                {
                    FillData(properties, dt, t);
                }
                    
            }
            return dt;                 
        }
        public static DataTable ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            return dt;
        }

        private static DataTable CreateDataTable(PropertyInfo[] properties)
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
        public static DataTable ConvertTo<T>(IList<T> list)
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
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
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
        public static IList<T> ConvertTo<T>(DataTable table)
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

            return ConvertTo<T>(rows);
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




        /*protected IList GetListFromTable(DataTable Table, ICopy DummyObj, IList ObjList)
     {
         foreach (DataRow dr in Table.Rows) {
             ObjList.Add(DummyObj.NewCopy(dr.ItemArray));
         }
         return ObjList;
     }
    
     public interface ICopy
     {
         ICopy NewCopy(object[] @params);
     }
     public class Form1
     {
         List<elephant> ElephantList = new List<elephant>();
         Collection GiraffeCollection = new Collection();
         private class elephant : ICopy
         {
             private int _legs;
             private bool _trunk;
             public int Legs {
                 get { return _legs; }
                 set { _legs = value; }
             }
             public bool Trunk {
                 get { return _trunk; }
                 set { _trunk = false; }
             }
             public elephant()
             {
             }
             public elephant(int legs, bool trunk)
             {
                 _legs = legs;
                 _trunk = trunk;
             }
             public ICopy NewCopy(object[] @params)
             {
                 return new elephant(@params(0), @params(1));
             }
         }
         private class giraffe : ICopy
         {
             private int _legs;
             private string _neck;
             private bool _tail;
             public int Legs {
                 get { return _legs; }
                 set { _legs = value; }
             }
             public string Neck {
                 get { return _neck; }
                 set { _neck = false; }
             }
             public bool Tail {
                 get { return _tail; }
                 set { _tail = value; }
             }
             public giraffe()
             {
             }
             public giraffe(int legs, string neck, bool tail)
             {
                 _legs = legs;
                 _neck = neck;
                 _tail = tail;
             }
             public ICopy NewCopy(object[] @params)
             {
                 return new giraffe(@params(0), @params(1), @params(2));
             }
         }
         private DataTable ElephantTable = new DataTable();
         private DataTable GiraffeTable = new DataTable();
         private void makeElephantTable()
         {
             DataColumn dc0 = new DataColumn("Legs", typeof(int));
             ElephantTable.Columns.Add(dc0);
             DataColumn dc1 = new DataColumn("Trunk", typeof(bool));
             ElephantTable.Columns.Add(dc1);
             for (int i = 0; i <= 5; i++) {
                 ElephantTable.Rows.Add(i, i % 2 == 0);
             }
             ElephantTable.AcceptChanges();
         }
         private void makeGiraffeTable()
         {
             DataColumn dc0 = new DataColumn("Legs", typeof(int));
             GiraffeTable.Columns.Add(dc0);
             DataColumn dc1 = new DataColumn("Neck", typeof(string));
             GiraffeTable.Columns.Add(dc1);
             DataColumn dc2 = new DataColumn("Tail", typeof(bool));
             GiraffeTable.Columns.Add(dc2);
             for (int i = 0; i <= 5; i++) {
                 GiraffeTable.Rows.Add(i, "Long", i % 2 == 0);
             }
             GiraffeTable.AcceptChanges();
         }
         protected IList GetListFromTable(DataTable Table, ICopy DummyObj, IList ObjList)
         {
             foreach (DataRow dr in Table.Rows) {
                 ObjList.Add(DummyObj.NewCopy(dr.ItemArray));
             }
             return ObjList;
         }
         private void // ERROR: Handles clauses are not supported in C# Button1_Click(object sender, System.EventArgs e)
         {
             makeElephantTable();
             ElephantList = GetListFromTable(ElephantTable, new elephant(), ElephantList);
             foreach (elephant item in ElephantList) {
                 Debug.WriteLine(item.Legs.ToString + "|" + item.Trunk.ToString);
             }
             makeGiraffeTable();
             GiraffeCollection = GetListFromTable(GiraffeTable, new giraffe(), GiraffeCollection);
             foreach (giraffe item in GiraffeCollection) {
                 Debug.WriteLine(item.Legs.ToString + "|" + item.Neck.ToString + "|" + item.Tail.ToString);
             }
         }
     }*/



    }
}