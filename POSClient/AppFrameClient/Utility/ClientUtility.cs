using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AppFrameClient.Common;
using MySql.Data.MySqlClient;

namespace AppFrameClient.Utility
{
    public class ClientUtility
    {
        public static void DumpDatabase()
        {
            string mySQLDumpPath = ClientSetting.MySQLDumpPath+"\\mysqldump.exe";
            string dbBackupPath = ClientSetting.DBBackupPath;
            string backupFileName = string.Format("POSBackup_{0}.sql", DateTime.Now.ToString("yyyyHHmmss"));
            try
            {
                // Need to use "--databases" to force CREATE DATABASE command in script
                // --hex-blob to turn blob fields into hex strings
                string mysqldumpstring = string.Format("--database {0} --result-file={1} --single-transaction --routines --triggers --user={2} --password={3} --add-drop-database=true", 
                                                      "pos", // dbname
                                                      dbBackupPath+"\\"+backupFileName, // backupfile
                                                      "dbadmin",  // username
                                                      "1qw45DCM9rl"); 

                // Create info needed by process
                ProcessStartInfo info = new ProcessStartInfo(mySQLDumpPath);
                info.Arguments = mysqldumpstring;
                info.UseShellExecute = false;
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;

                // Create process
                Process p = new Process();
                p.StartInfo = info;
                // Set up asynchronous read event
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();

                //TODO, check for errors

            }
            finally
            {
                // Flush and close file
            } 
        }
        public static void CleanDatabase()
        {
            MySqlConnection cn = new
                MySqlConnection("Data Source=localhost;Database=pos;User ID=dbadmin;password=1qw45DCM9rl;Port=3306;");
            MySqlCommand cmd = new MySqlCommand("CleanPurchaseOrder", cn);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("dayBefore", 2);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
