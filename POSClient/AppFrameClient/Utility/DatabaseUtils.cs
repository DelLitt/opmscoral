using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AppFrameClient.Common;
using Ionic.Zip;
using Ionic.Zlib;
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

            string timeTicks = DateTime.Now.ToString("yyyyMMddHHmmss");
            //backup purchase_order
            string sqlSelect = "\" SELECT * INTO OUTFILE '";
            string backupFilename1 = string.Format("purchase_order_{0}.txt", timeTicks);
            string backupSql = sqlSelect + backupPath + "/" + backupFilename1 + "' " +
            " FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n'  FROM purchase_order; \"";
            ExecuteMySQLCmdLine(backupSql, db, user, pass);

            //backup purchase_order_detail
            sqlSelect = "\" SELECT *  INTO OUTFILE '";
            string backupFilename2 = string.Format("purchase_order_detail{0}.txt", timeTicks);
            backupSql = sqlSelect + backupPath + "/" + backupFilename2 + "'  " +
            " FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n'  FROM purchase_order_detail; \"";
            ExecuteMySQLCmdLine(backupSql, db, user, pass);
            
            try
            {
                backupFilename1 = backupPath + "/" + backupFilename1;
                backupFilename2 = backupPath + "/" + backupFilename2;
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = "admin123";
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    // add this map file into the "images" directory in the zip archive
                    zip.AddFile(backupFilename1,"");
                    // add the report into a different directory in the archive
                    zip.AddFile(backupFilename2,"");
                    
                    string zipFileName = string.Format("purchase_order_{0}.zip", timeTicks);
                    zip.Save(backupPath + "/" + zipFileName);
                }
                File.Delete(backupFilename1);
                File.Delete(backupFilename2);
            }
            catch (System.Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }

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
