using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AppFrameClient.Common;
using MySql.Data.MySqlClient;

namespace AppFrameClient.Utility
{
    public class DatabaseUtils
    {
        private static string posConnectionString = AppFrameClient.Properties.Settings.Default.posConnectionString;
        public static void BackupDatabase(bool SaleStatistic,bool ImExStatistic)
        {

            string mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe";
            string db = "pos";
            string user = "dbadmin";
            string pass = "1qw45DCM9rl";

            IList list = GetPOSSyncDrives();
            if(list == null || list.Count == 0 )
            {
                return;
            }
            string backupPath = list[0].ToString() + AppFrameClient.Properties.Settings.Default.StatBackupPath;
            backupPath = backupPath.Replace('\\', ('/'));

            string timeTicks = DateTime.Now.ToString("yyyyHHmmss");
            //backup purchase_order
            string sqlSelect = "\" SELECT * INTO OUTFILE '";
            string backupFilename = string.Format("purchase_order_{0}.txt", timeTicks);
            string backupSql = sqlSelect + backupPath + "/" + backupFilename + "' " +
            "FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n'  FROM purchase_order; \"";
            ExecuteMySQLCmdLine(backupSql, db, user, pass);

            //backup purchase_order_detail
            sqlSelect = "\" SELECT * FROM purchase_order_detail INTO OUTFILE '";
            backupFilename = string.Format("purchase_order_detail{0}.txt", timeTicks);
            backupSql = sqlSelect + backupPath + "/" + backupFilename + "' \"";
            ExecuteMySQLCmdLine(backupSql, db, user, pass);

        }

        private static void ExecuteMySQLCmdLine(string sqlString,string dbName,string username,string password)
        {
            string mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe";
            try
            {
                // Need to use "--databases" to force CREATE DATABASE command in script
                // --hex-blob to turn blob fields into hex strings
                string mysqldumpstring = string.Format("--database {0} --execute={1} --user={2} --password={3}",
                                                      dbName, // dbname
                                                      sqlString, // backupfile
                                                      username,  // username
                                                      password);

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

        public static IList GetPOSSyncDrives()
        {
            IList posSyncDrives = new ArrayList();
            IList usbList = ClientUtility.GetUSBDrives();
            foreach (string usbDrive in usbList)
            {
                if (CheckBackupSyncDrive(usbDrive))
                {
                    posSyncDrives.Add(usbDrive);
                }
            }
            return posSyncDrives;
        }

        private static bool CheckBackupSyncDrive(string usbDrive)
        {
            if (!Directory.Exists(usbDrive + AppFrameClient.Properties.Settings.Default.StatBackupPath))
            {
                return false;
            }
            return true;
        }
    }
}
