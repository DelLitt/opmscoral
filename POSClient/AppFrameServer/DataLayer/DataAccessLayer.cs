//1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890/
//Date          Name        Remarks
//----------------------------------------------------------------------------------------------------/
//06Aug2008     Chenjx      Added GetConnectionString() to use Web Service from the Web.Config.
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Net;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace AppFrameServer.DataLayer
{
    public class DataAccessLayer
    {
        Object DBType;
        DbConnection connDB;
        private DbTransaction transaction;
        private static string connectionStr ="";

        // <summary>
        // Constructor calling for Initialization
        // <para name="DataBaseName">Name of the Connection String in web.config file. Default will be connCommon</para>
        // <para name="DataBaseName">Name of the Connection String in web.config file. Default will be connCommon</para>
        // </summary>
        public DataAccessLayer(string strServer)
        {
            connDB = new MySqlConnection(GetConnectionString(strServer));
            
        }
        /// <summary>
        /// Create ConnectionString using TSPL Web service.-Chenjx
        /// </summary>
        /// <returns></returns>
        private String GetConnectionString(string strServerInput)
        {
            string result;

            if (connectionStr.Length > 0)
                result =  connectionStr;
            else
            {
                /*string strUserID = ConfigurationManager.AppSettings["DBUserID"];
                string strPswd = ConfigurationManager.AppSettings["DBUserPwd"];
                string strDBName = ConfigurationManager.AppSettings["DBName"];
                string strServer = ConfigurationManager.AppSettings["DBServer"];*/
                string strUserID = "dbadmin";
                string strPswd = "1qw45DCM9rl";
                string strDBName = "pos";
                string strServer = strServerInput;
                //Use the Web.Config url to call web service.
                connectionStr = "Server=" + strServer + ";Database=" + strDBName + ";User ID=" + strUserID +";Password=" + strPswd + ";";
                result = connectionStr;
            }
            return result;
        }
        /// <summary> 
        /// Returns FirstRow and First column's value for the query (Just like Execute Scalar Function) 
        /// </summary> 
        public void ExecuteQuery(string SqlString)
        {
            try
            {
                connDB.Open();
                DbCommand cmdDB = connDB.CreateCommand();
                cmdDB.CommandText = SqlString;
                cmdDB.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connDB.Close();
            }
        }

        public void ExecuteUpdate(string SqlString)
        {
            /*try
            {
                connDB.Open();*/
                DbCommand cmdDB = connDB.CreateCommand();
                cmdDB.CommandText = SqlString;
                cmdDB.ExecuteNonQuery();
            /*}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connDB.Close();
            }*/
        }

        public object ExecuteScalar(string SqlString)
        {
                object obj;
                DbCommand cmdDB = connDB.CreateCommand();
                cmdDB.CommandText = SqlString;
                obj = cmdDB.ExecuteScalar();
                return obj;
        }
        /// <summary> 
        /// Returns FirstRow and First column's value for the query (Just like Execute Scalar Function) 
        /// </summary> 
        public object GetSingleValue(string SqlString)
        {
            try
            {
                object obj;
                connDB.Open();
                DbCommand cmdDB = connDB.CreateCommand();
                cmdDB.CommandText = SqlString;
                obj = cmdDB.ExecuteScalar();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connDB.Close();
            }
        }

        public DbTransaction OpenTransaction()
        {
            transaction = connDB.BeginTransaction();
            return transaction;
        }

        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public DbTransaction GetTransaction()
        {
            return transaction;
        }
        public void Open()
        {
            connDB.Open();
        }

        public void Close()
        {
            try
            {
                connDB.Close();
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}