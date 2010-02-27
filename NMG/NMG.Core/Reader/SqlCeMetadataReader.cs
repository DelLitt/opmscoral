using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using NMG.Core.Domain;

namespace NMG.Core.Reader
{
    public class SqlCeMetadataReader : IMetadataReader
    {
        private string _connectionStr;
        public SqlCeMetadataReader(string connectionStr)
        {
            this._connectionStr = connectionStr;
        }
        public ColumnDetails GetTableDetails(string selectedTableName)
        {
            var columnDetails = new ColumnDetails();
            var conn = new SqlCeConnection(_connectionStr);
            conn.Open();
            using (conn)
            {
                using (var tableDetailsCommand = conn.CreateCommand())
                {
                    tableDetailsCommand.CommandText =
                        "select column_name, data_type, character_maximum_length, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE from information_schema.columns where table_name = '" +
                        selectedTableName + "'";
                    using (var sqlDataReader = tableDetailsCommand.ExecuteReader(CommandBehavior.Default))
                    {
                        if (sqlDataReader != null)
                        {
                            while (sqlDataReader.Read())
                            {
                                var columnName = sqlDataReader.GetString(0);
                                var dataType = sqlDataReader.GetString(1);
                                int dataLength = 0;
                                int dataPrecision = 0;
                                int dataScale = 0;
                                bool isNullable = false;
                                try
                                {
                                    dataLength = sqlDataReader.GetInt32(2);
                                    dataPrecision = sqlDataReader.GetInt32(3);
                                    dataScale = sqlDataReader.GetInt32(4);
                                    isNullable = sqlDataReader.GetBoolean(5);
                                }
                                catch (Exception)
                                {

                                }

                                columnDetails.Add(new ColumnDetail(columnName, dataType, dataLength, dataPrecision,
                                                                   dataScale, isNullable));
                            }
                        }
                    }
                }
                using (var constraintCommand = conn.CreateCommand())
                {
                    constraintCommand.CommandText = "select constraint_name from information_schema.TABLE_CONSTRAINTS where table_name = '" + selectedTableName + "' and constraint_type = 'PRIMARY KEY'";
                    var value = constraintCommand.ExecuteScalar();
                    if (value != null)
                    {
                        var constraintName = (string)value;
                        using (var pkColumnCommand = conn.CreateCommand())
                        {
                            pkColumnCommand.CommandText = "select column_name from information_schema.KEY_COLUMN_USAGE where table_name = '" + selectedTableName + "' and constraint_name = '" + constraintName + "'";
                            var colNames = pkColumnCommand.ExecuteReader();
                            //var colName = pkColumnCommand.ExecuteScalar();
                            while (colNames.Read())
                                {
                                    var pkColumnName = (string) colNames.GetValue(0);
                                    var columnDetail =
                                        columnDetails.Find(detail => detail.ColumnName.Equals(pkColumnName));
                                    columnDetail.IsPrimaryKey = true;
                                }
                            
                        }
                    }
                }
            }
            columnDetails.Sort((x, y) => x.ColumnName.CompareTo(y.ColumnName));
            return columnDetails;

        }

        public List<string> GetTables()
        {
            var tables = new List<string>();
            var conn = new SqlCeConnection(_connectionStr);
            conn.Open();
            using (conn)
            {
                SqlCeCommand tableCommand = conn.CreateCommand();
                tableCommand.CommandText = "SELECT table_name FROM INFORMATION_SCHEMA.TABLES";
                SqlCeDataReader sqlDataReader = tableCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (sqlDataReader != null)
                    while (sqlDataReader.Read())
                    {
                        string tableName = sqlDataReader.GetString(0);
                        tables.Add(tableName);
                    }
            }
            tables.Sort((x, y) => x.CompareTo(y));
            return tables;
        }

        public List<string> GetSequences()
        {
            return new List<string>();
        }
    }
}
