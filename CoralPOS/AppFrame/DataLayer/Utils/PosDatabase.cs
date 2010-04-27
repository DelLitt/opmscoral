using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Spring.Data;
using Spring.Data.Common;
using Spring.Data;
using Spring.Data.Core;
using Spring.Data.Objects;
using Spring.Data.Support;

namespace AppFrame.DataLayer.Utils
{
    public class PosDatabase : AdoDaoSupport
    {
        public PosDatabase(AdoTemplate adoTemplate)
        {
            AdoTemplate = adoTemplate;
        }

        public DataTable ExecuteQuery(string query)
        {
            return AdoTemplate.DataTableCreate(CommandType.Text, query);
        }

        public DataTable ExecuteQuery(string query, IDbParameters parameters)
        {
            return AdoTemplate.DataTableCreateWithParams(CommandType.Text, query, parameters);
        }


        public DataTable ExecuteQueryAll(string tableName)
        {
            string query = "SELECT * FROM " + tableName;
            return AdoTemplate.DataTableCreate(CommandType.Text, query);
        }

        public DataTable ExecuteQueryAll(string tableName, IDbParameters parameters,string paramMark)
        {
            string query = "SELECT * FROM " + tableName;
            if(parameters.Count > 0)
            {
                query += " WHERE ";
            }
            int countParams = 0;
            foreach (IDataParameter dbParameter in parameters.DataParameterCollection)
            {
                countParams++;
                if (countParams > 1) query += " AND ";
                query +=" " +dbParameter.ParameterName + "=" + paramMark + dbParameter.ParameterName;
                
            }
            return AdoTemplate.DataTableCreateWithParams(CommandType.Text, query, parameters);
        }


        public void UpdateDataTable(DataTable source,DataTable changes)
        {
            IDbParametersBuilder builder = new DbParametersBuilder(DbProvider);
            source.Merge(changes);
            AdoTemplate.DataTableUpdateWithCommandBuilder(source, CommandType.Text, "SELECT * FROM " + source.TableName,
                                                          builder.GetParameters(), source.TableName);
            
        }

        public void UpdateDataTable(DataTable dataTable)
        {
            IDbParametersBuilder builder = new DbParametersBuilder(DbProvider);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine(dataRow.ItemArray.ToString());
                Console.WriteLine(dataRow.RowState.ToString());
            }
            AdoTemplate.DataTableUpdateWithCommandBuilder(dataTable, CommandType.Text, "SELECT * FROM " + dataTable.TableName,
                                                          builder.GetParameters(), dataTable.TableName);

            
            
        }
        public static PosDatabase Instance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PosDatabase>();
            }
        }

        public void SaveToDatabase(DataTable dataTable)
        {
            
        }
        public DataTable ConvertDataType(DataTable source, DataTable dest)
        {
            DataTable clone = dest.Clone();
            foreach (DataRow dataRow in source.Rows)
            {
                var itemArray = dataRow.ItemArray;
                clone.Rows.Add(itemArray);
            }
            return clone;
        }

        public void UpdateDataTable(DataTable dataTable, string tableName)
        {
            DataTable current = ExecuteQueryAll(tableName);
            current.TableName = tableName;
            current.Merge(ConvertDataType(dataTable, current));
            DataTable update = current.GetChanges();
            update.TableName = tableName;

            UpdateDataTable(update);
        }

        public void FastUpdateDataTable(DataTable dataTable,string tableName)
        {
            DataTable current = ExecuteQueryTableDirect(tableName);
            current.TableName = tableName;
            ReflectUpdateTable(current, dataTable);

            
        }

        private DataTable ExecuteQueryTableDirect(string tableName)
        {
            return AdoTemplate.DataTableCreate(CommandType.TableDirect, tableName);
        }

        private void ReflectUpdateTable(DataTable current, DataTable dataTable)
        {
            DataColumnCollection columns = current.Columns;
            DataColumn[] priKeys = current.PrimaryKey;
            
            var duplicateRow =     from crow in current.AsEnumerable()
                                   from row in dataTable.AsEnumerable()
                                   where CompareRow(crow,row,priKeys) == true
                                   select crow;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var result = from dupRow in duplicateRow
                             where CompareRow(dupRow, dataRow, priKeys) == true
                             select dupRow;

                if(result.Count()>0)
                {
                    DataRow currRow = result.FirstOrDefault();
                    AssignValue(currRow,dataRow,columns);
                }
                else
                {
                    DataRow newRow = current.NewRow();
                    AssignValue(newRow, dataRow, columns);
                    current.Rows.Add(newRow);
                }
            }

            IDbParametersBuilder builder = new DbParametersBuilder(DbProvider);
            AdoTemplate.DataTableUpdateWithCommandBuilder(current, CommandType.Text, "SELECT * FROM " + current.TableName,
                                                          builder.GetParameters(), current.TableName);
        }

        private void AssignValue(DataRow newRow, DataRow dataRow, DataColumnCollection columns)
        {
            foreach (DataColumn dataColumn in columns)
            {
                var val = dataRow[dataColumn.ColumnName];
                
                if (val == null)
                    newRow[dataColumn.ColumnName] = dataColumn.DefaultValue;
                else
                    newRow[dataColumn.ColumnName] = ConvertValue(val,dataColumn.DataType);
            }
        }

        private object ConvertValue(object val, Type dataType)
        {
            DateTime dt=new DateTime(1976,1,1);
            if(val is DateTime)
            {
                val=DateTime.Parse(val.ToString());
                if (dt.CompareTo(DateTime.Parse(val.ToString())) > 0)
                    val = dt;
            }
            return val;
        }

        private bool ExistRow(DataRow dataRow, IEnumerable<DataRow> duplicateRow, DataColumn[] priKeys)
        {
            var result = from dupRow in duplicateRow
                         where CompareRow(dupRow, dataRow, priKeys) == true 
                         select dupRow;
            return result.Count() > 0;             
        }

        private bool CompareRow(DataRow crow, DataRow row, DataColumn[] priKeys)
        {
            foreach (DataColumn dataColumn in priKeys)
            {
                if(!crow[dataColumn.ColumnName].ToString().Equals(row[dataColumn.ColumnName].ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
