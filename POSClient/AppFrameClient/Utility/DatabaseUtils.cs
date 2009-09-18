using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Utility;
using AppFrameClient.Common;
using Ionic.Zip;
using Ionic.Zlib;
using MySql.Data.MySqlClient;


namespace AppFrameClient.Utility
{
    public class DatabaseUtils
    {
        private const string ZIP_PASSWORD = "8FcsjTNcxp";
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
                CleanDatabase(SaleStatistic, ImExStatistic);
            }
            catch (System.Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }

        }

        private static void CleanDatabase(bool statistic, bool imExStatistic)
        {
            string db = "pos";
            string user = "dbadmin";
            string pass = "1qw45DCM9rl";

            string deletePODet = "\" delete from purchase_order_detail where create_date < '" +
                                 DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0))).ToString("yyyy-MM-dd") +"'; \"";

            ExecuteMySQLCmdLine(deletePODet,db,user,pass);

            string deletePO = "\" delete from purchase_order where create_date < '" +
                                 DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0))).ToString("yyyy-MM-dd") + "';\""; 
            ExecuteMySQLCmdLine(deletePO,db,user,pass);
        }

        private static void ExecuteMySQLCmdLine(string sqlString,string dbName,string username,string password)
        {
            string mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe";
            try
            {
                // Need to use "--databases" to force CREATE DATABASE command in script
                // --hex-blob to turn blob fields into hex strings
                string mysqldumpstring = string.Format("--database={0} --execute={1} --user={2} --password={3}",
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

        private static void ExecuteMySQLDumpCmdLine(bool isDump,string sqlString)
        {
            string mySQLDumpPath;
            if (isDump)
            {
                mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysqldump.exe";
            }
            else
            {
                mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe"; 
            }
            ProcessStartInfo info = new ProcessStartInfo(mySQLDumpPath);
            Process p = new Process();
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            try
            {
                string mysqldumpstring = sqlString;


                // Create info needed by process
                info.Arguments = mysqldumpstring;

                string[] args = null;
                if(!isDump)
                {
                    args = mysqldumpstring.Split('<');
                    info.Arguments = args[0];
                    info.RedirectStandardInput = true;
                }

                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;
                
                
                //info.CreateNoWindow = true;
                // Create process
                
                p.StartInfo = info;
                // Set up asynchronous read event
                p.Start();
                
                if(!isDump)
                {
                    p.StandardInput.WriteLine("\\."+args[1]);
                    p.StandardInput.WriteLine("exit");
                }

                
                p.WaitForExit();
                //TODO, check for errors

            }
            finally
            {
                // Flush and close file
            }
            if(p.ExitCode != 0)
            {
                MessageBox.Show("Xử lý thông tin chung thất bại.");
            }
            p.ErrorDataReceived -= new DataReceivedEventHandler(p_ErrorDataReceived);
            p.OutputDataReceived -= new DataReceivedEventHandler(p_OutputDataReceived);
        }

        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
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

        public static void LoadMasterData(bool productMasters,bool departments,bool prices)
        {
            IList list = GetPOSSyncDrives();
            if (list == null || list.Count == 0)
            {
                return;
            }
            string dbBackupPath = list[0].ToString() + "POS";
            dbBackupPath = dbBackupPath.Replace('\\', ('/'));
            string backupFileName = "MasterData_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".sql";

            string product_type = "";
            string product_size = "";
            string product_color = "";
            string product_master = "";
            string product = "";

            string department = "";
            string employee = "";
            string employee_info = "";

            string department_price = "";

            if(productMasters)
            {
                product_type = "product_type";
                product_size = "product_size";
                product_color = "product_color";
                product_master = "product_master";
                product = "product"; 
            }

            if(departments)
            {
                department = "department";
                employee = "employee";
                employee_info = "employee_info"; 
            }

            if(prices)
            {
                department_price = "department_price"; 
            }
            string backupFile = dbBackupPath + "/" + backupFileName;
            string mysqldumpstring = string.Format("--database {0} --table {1} {2} {3} {4} {5} {6} {7} {8} {9} --replace --add-drop-table=false --no-create-info --no-create-db --result-file={10} --single-transaction --user={11} --password={12} --skip-add-locks --add-locks=false --quick ",
                                                      "pos", // dbname
                                                      product_type,
                                                      product_size,
                                                      product_color,
                                                      product_master,
                                                      product,
                                                      department,
                                                      employee_info,
                                                      employee,
                                                      department_price,
                                                      backupFile, // backupfile
                                                      "dbadmin",  // username
                                                      "1qw45DCM9rl"); 

           ExecuteMySQLDumpCmdLine(true,mysqldumpstring);
           using (ZipFile masterZipFile = new ZipFile())
           {
               masterZipFile.Password = ZIP_PASSWORD;
               masterZipFile.AddFile(backupFile,"");
               masterZipFile.Save(dbBackupPath + "/" + "MasterData_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
           }
           File.Delete(backupFile);
            
        }

        public static void SyncMasterData(string masterFileName)
        {
            string pathExtract = masterFileName.Substring(0, masterFileName.LastIndexOf("\\"));
            using (ZipFile masterZipFile = ZipFile.Read(masterFileName))
            {
                masterZipFile.Password = ZIP_PASSWORD;
                masterZipFile.ExtractAll(pathExtract,ExtractExistingFileAction.OverwriteSilently);
            }
            string[] files = Directory.GetFiles(pathExtract);
            foreach (string file in files)
            {
                if(!file.EndsWith("sql")) continue;
                string syncString = string.Format(" --database={0} --user={1} --password={2}  < {3} ", "pos", "dbadmin", "1qw45DCM9rl", file);   
                ExecuteMySQLDumpCmdLine(false,syncString);
                File.Delete(file);
            }
            File.Delete(masterFileName);
        }
    }
}
