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

            current.Merge(ConvertDataType(dataTable, current));
            current.TableName = tableName;
            UpdateDataTable(current);
        }
    }
}
