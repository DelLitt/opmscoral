using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        public const string ZIP_PASSWORD = "8FcsjTNcxp";
        private static readonly string _posConnectionString = AppFrameClient.Properties.Settings.Default.posConnectionString;
        
        public static readonly string[] TABLE_NAMES = new string[]
                                                    {
                                                        "purchase_order_detail",
                                                        "purchase_order",
                                                        "department_stock_out_detail",
                                                        "department_stock_out",
                                                        "department_stock_in_detail",
                                                        "department_stock_in",
                                                        "stock_out_detail",
                                                        "stock_out",
                                                        "stock_in_detail",
                                                        "stock_in",
                                                        "return_po"
                                                    };
        /// <summary>
        /// Backup database to CRL directories
        /// </summary>
        /// <param name="SaleStatistic"></param>
        /// <param name="ImExStatistic"></param>
        public static void BackupCRLDatabase(bool SaleStatistic,bool ImExStatistic)
        {
            string mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe";
            string db = "pos";
            string user = "dbadmin";
            string pass = "1qw45DCM9rl";

            string crlBackupDrive = GetCLRSyncDriveString();
            if (string.IsNullOrEmpty(crlBackupDrive)) return;
            string backupPath = crlBackupDrive + AppFrameClient.Properties.Settings.Default.StatBackupPath;
            backupPath = backupPath.Replace('\\', ('/'));
            
            List<string> tablesList = new List<string>();
            try
            {
                /* BACKUP TABLES */

                if(SaleStatistic)
                {
                    tablesList.Add("purchase_order_detail");
                    tablesList.Add("purchase_order");
                    tablesList.Add("return_po");
                }
                if(ImExStatistic)
                {
                    tablesList.Add("department_stock_out_detail");
                    tablesList.Add("department_stock_out");

                    tablesList.Add("department_stock_in_detail");
                    tablesList.Add("department_stock_in");
                    
                    tablesList.Add("stock_out_detail");
                    tablesList.Add("stock_out");
                    
                    tablesList.Add("stock_in_detail");
                    tablesList.Add("stock_in");
                }
                List<string> savedFiles = new List<string>();
                BackupTable(backupPath,db,user,pass,tablesList.ToArray(),out savedFiles);
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = "admin123";
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    foreach (string fileName in savedFiles)
                    {
                        // add this map file into the "images" directory in the zip archive
                        zip.AddFile(fileName, "");
                    }
                    
                    string zipFileName = string.Format("clr_backup_{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    zip.Save(backupPath + "/" + zipFileName);
                }
                foreach (string file in savedFiles)
                {
                    File.Delete(file);
                }
                CleanDatabase(SaleStatistic, ImExStatistic);
            }
            catch (System.Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }
        }

        /// <summary>
        /// Restore CRL database
        /// </summary>
        public static void RestoreCRLDatabase()
        {
            string mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe";
            string db = "pos";
            string user = "dbadmin";
            string pass = "1qw45DCM9rl";

            string crlBackupDrive = GetCLRSyncDriveString();
            if (string.IsNullOrEmpty(crlBackupDrive)) return;
            string backupPath = crlBackupDrive + AppFrameClient.Properties.Settings.Default.StatBackupPath;
            backupPath = backupPath.Replace('\\', ('/'));

            foreach (string file in Directory.GetFiles(backupPath))
            {
                if (!file.EndsWith("zip")) continue;
                using(ZipFile zip = new ZipFile(file))
                {
                    zip.Password = "admin123";
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    zip.ExtractAll(backupPath,ExtractExistingFileAction.OverwriteSilently);
                    string[] sqlFiles = Directory.GetFiles(backupPath, "*.txt");
                    RestoreTable(backupPath, db, user, pass, sqlFiles);
                }
            }
        }

        private static void RestoreTable(string path, string db, string user, string pass, string[] sqlFiles)
        {
            foreach (string sqlFile in sqlFiles)
            {
                string file = sqlFile.Replace("\\", "/");
                string tableName = GetTableNameFromFileName(file);
                if(string.IsNullOrEmpty(tableName)) continue;
                //backup purchase_order
                string sqlLoad = "\" LOAD DATA LOCAL INFILE '" + file + "' ";
                //string backupFileName = string.Format(backupPath + "/" + table + "_{0}.txt", timeTicks);
                string restoreSql = sqlLoad + " IGNORE INTO TABLE " + tableName + " " +
                                   " FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n' ; \"";
                ExecuteMySqlCmdLine(restoreSql, db, user, pass);
                //savedFiles.Add(backupFileName);
            }
            foreach (string sqlFile in sqlFiles)
            {
                File.Delete(sqlFile);
            }
        }

        private static string GetTableNameFromFileName(string sqlFile)
        {
            foreach (string tableName in TABLE_NAMES)
            {
                if (sqlFile.IndexOf(tableName) > 0)
                {
                    // check the next is number
                    string test = sqlFile.Substring(sqlFile.LastIndexOf("/")+tableName.Length + 2);
                    test = test.Substring(0, test.LastIndexOf("."));
                    long correctFile = 0;
                    ClientUtility.TryActionHelper(delegate() { correctFile = Int64.Parse(test); }, 1);
                    if(correctFile > 0) return tableName;
                }
            }
            return null;
        }


        /// <summary>
        /// Backup database to CLR directory
        /// </summary>
        /// <param name="SaleStatistic"></param>
        /// <param name="ImExStatistic"></param>
        [Obsolete]
        public static void BackupDatabase(bool SaleStatistic, bool ImExStatistic)
        {

            string mySQLDumpPath = ClientSetting.MySQLDumpPath + "\\mysql.exe";
            string db = "pos";
            string user = "dbadmin";
            string pass = "1qw45DCM9rl";

            string crlBackupDrive = GetCLRSyncDriveString();
            if (string.IsNullOrEmpty(crlBackupDrive)) return;
            string backupPath = crlBackupDrive + AppFrameClient.Properties.Settings.Default.StatBackupPath;
            backupPath = backupPath.Replace('\\', ('/'));
            try {
                /* BACKUP PURCHASE ORDER AND PURCHASE ORDER DETAIL */
                    string timeTicks = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //backup purchase_order
                    string sqlSelect = "\" SELECT * INTO OUTFILE '";
                    string backupFilename1 = string.Format("purchase_order_{0}.txt", timeTicks);
                    string backupSql = sqlSelect + backupPath + "/" + backupFilename1 + "' " +
                                       " FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n'  FROM purchase_order; \"";
                    ExecuteMySqlCmdLine(backupSql, db, user, pass);

                    //backup purchase_order_detail
                    sqlSelect = "\" SELECT *  INTO OUTFILE '";
                    string backupFilename2 = string.Format("purchase_order_detail{0}.txt", timeTicks);
                    backupSql = sqlSelect + backupPath + "/" + backupFilename2 + "'  " +
                                " FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n'  FROM purchase_order_detail; \"";
                    ExecuteMySqlCmdLine(backupSql, db, user, pass);


                    backupFilename1 = backupPath + "/" + backupFilename1;
                    backupFilename2 = backupPath + "/" + backupFilename2;
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.Password = "admin123";
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        // add this map file into the "images" directory in the zip archive
                        zip.AddFile(backupFilename1, "");
                        // add the report into a different directory in the archive
                        zip.AddFile(backupFilename2, "");

                        string zipFileName = string.Format("purchase_order_{0}.zip", timeTicks);
                        zip.Save(backupPath + "/" + zipFileName);
                    }
                    File.Delete(backupFilename1);
                    File.Delete(backupFilename2);
                
                CleanDatabase(true, false);
            }
            catch (System.Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }

        }
        /// <summary>
        /// Backup CRL tables
        /// </summary>
        /// <param name="backupPath"></param>
        /// <param name="db"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="tables"></param>
        private static void BackupTable(string backupPath,string db,string user,string pass, string[] tables,out List<string> savedFiles)
        {
            savedFiles = new List<string>();
            string timeTicks = DateTime.Now.ToString("yyyyMMddHHmmss");
            foreach (string table in tables)
            {
                //backup purchase_order
                string sqlSelect = "\" SELECT * INTO OUTFILE '";
                string backupFileName = string.Format(backupPath + "/" + table + "_{0}.txt", timeTicks);
                string backupSql = sqlSelect + backupFileName + "' " +
                                   " FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\\\"' LINES TERMINATED BY '\n'  FROM "+table +" ; \"";
                ExecuteMySqlCmdLine(backupSql, db, user, pass);
                savedFiles.Add(backupFileName);
            }       
        }

        private static IList GetCLRPOSSyncDrives()
        {
            IList posSyncDrives = new ArrayList();
            IList usbList = ClientUtility.GetUSBDrives();
            foreach (string usbDrive in usbList)
            {
                if (CheckCLRBackupSyncDrive(usbDrive))
                {
                    posSyncDrives.Add(usbDrive);
                }
            }
            return posSyncDrives;
        }

        public static string GetCLRSyncDriveString()
        {
            IList list = GetCLRPOSSyncDrives();
            if (list == null || list.Count == 0)
            {
                return null;
            }
            return list[0] as string;
        }

        private static bool CheckCLRBackupSyncDrive(string usbDrive)
        {
            if (!Directory.Exists(usbDrive + AppFrameClient.Properties.Settings.Default.StatBackupPath))
            {
                return false;
            }
            return true;
        }

        private static void CleanDatabase(bool saleStatistic, bool imExStatistic)
        {
            string db = "pos";
            string user = "dbadmin";
            string pass = "1qw45DCM9rl";
            if (saleStatistic)
            {
                string deleteDetail = "\" delete from purchase_order_detail where create_date < '" +
                                     DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                         "yyyy-MM-dd") + "'; \"";

                ExecuteMySqlCmdLine(deleteDetail, db, user, pass);

                string deleteHeader = "\" delete from purchase_order where create_date < '" +
                                  DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                      "yyyy-MM-dd") + "';\"";
                ExecuteMySqlCmdLine(deleteHeader, db, user, pass);

                string deleteString = "\" delete from return_po where create_date < '" +
                                  DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                      "yyyy-MM-dd") + "';\"";
                ExecuteMySqlCmdLine(deleteString, db, user, pass);

            }

            if(imExStatistic)
            {
                // department_stock_out
                string deleteDetail = "\" delete from department_stock_out_detail where stock_out_id in ( select stock_out_id from department_stock_out where create_date < '" +
                                     DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                         "yyyy-MM-dd") + "'); \"";
                ExecuteMySqlCmdLine(deleteDetail, db, user, pass);

                string deleteHeader = "\" delete from department_stock_out where create_date < '" +
                                  DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                      "yyyy-MM-dd") + "';\"";
                ExecuteMySqlCmdLine(deleteHeader, db, user, pass);
                
                // department_stock_in
                deleteDetail = "\" delete from department_stock_in_detail where create_date < '" +
                                     DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                         "yyyy-MM-dd") + "'; \"";
                ExecuteMySqlCmdLine(deleteDetail, db, user, pass);

                deleteHeader = "\" delete from department_stock_in where create_date < '" +
                                  DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                      "yyyy-MM-dd") + "';\"";
                ExecuteMySqlCmdLine(deleteHeader, db, user, pass);
                
                // stock_out
                deleteDetail = "\" delete from stock_out_detail where create_date < '" +
                                     DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                         "yyyy-MM-dd") + "'; \"";
                ExecuteMySqlCmdLine(deleteDetail, db, user, pass);

                deleteHeader = "\" delete from stock_out where create_date < '" +
                                  DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                      "yyyy-MM-dd") + "';\"";
                ExecuteMySqlCmdLine(deleteHeader, db, user, pass);

                // stock_in
                deleteDetail = "\" delete from stock_in_detail where create_date < '" +
                                     DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                         "yyyy-MM-dd") + "'; \"";
                ExecuteMySqlCmdLine(deleteDetail, db, user, pass);

                deleteHeader = "\" delete from stock_in where create_date < '" +
                                  DateUtility.DateOnly(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).ToString(
                                      "yyyy-MM-dd") + "';\"";
                ExecuteMySqlCmdLine(deleteHeader, db, user, pass);
            }
        }

        private static void ExecuteMySqlCmdLine(string sqlString, string dbName, string username, string password)
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
                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;

                // Create process
                Process p = new Process();
                p.StartInfo = info;
                p.OutputDataReceived +=new DataReceivedEventHandler((sender, e) => POutputDataReceived(sender, e));
                p.ErrorDataReceived +=new DataReceivedEventHandler((sender, e) => PErrorDataReceived(sender, e));
                // Set up asynchronous read event
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
                p.OutputDataReceived -= new DataReceivedEventHandler((sender, e) => POutputDataReceived(sender, e));
                p.ErrorDataReceived -= new DataReceivedEventHandler((sender, e) => PErrorDataReceived(sender, e));
                //TODO, check for errors

            }
            finally
            {
                // Flush and close file
                
            }
        }

        private static void ExecuteMySqlDumpCmdLine(bool isDump, string sqlString)
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
            p.ErrorDataReceived += new DataReceivedEventHandler(PErrorDataReceived);
            p.OutputDataReceived += new DataReceivedEventHandler(POutputDataReceived);
            try
            {
                string mysqldumpstring = sqlString;


                // Create info needed by process
                info.Arguments = mysqldumpstring;

                string[] args = null;
                /*if (!isDump)
                {
                    args = mysqldumpstring.Split('<');
                    info.Arguments = args[0];
                    info.RedirectStandardInput = true;
                }*/

                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;


                //info.CreateNoWindow = true;
                // Create process

                p.StartInfo = info;
                // Set up asynchronous read event
                p.Start();

                /*if (!isDump)
                {
                    p.StandardInput.WriteLine("source \"" + args[1]+"\"");
                    p.StandardInput.WriteLine("exit");
                }*/


                p.WaitForExit();
                //TODO, check for errors

            }
            finally
            {
                // Flush and close file
            }
            if (p.ExitCode != 0)
            {
                MessageBox.Show("Xử lý thông tin chung thất bại.");
            }
            p.ErrorDataReceived -= new DataReceivedEventHandler(PErrorDataReceived);
            p.OutputDataReceived -= new DataReceivedEventHandler(POutputDataReceived);
        }

        static void POutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        static void PErrorDataReceived(object sender, DataReceivedEventArgs e)
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
            if (!Directory.Exists(usbDrive + ClientSetting.SyncSuccessPath))
            {
                return false;
            }
            if (!Directory.Exists(usbDrive + ClientSetting.SyncImportPath))
            {
                return false;
            }
            if (!Directory.Exists(usbDrive + ClientSetting.SyncExportPath))
            {
                return false;
            }
            if (!Directory.Exists(usbDrive + ClientSetting.SyncErrorPath))
            {
                return false;
            }
            return true;
        }

        public static void LoadMasterData(bool productMasters, bool departments, bool prices)
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
            string role = "";
            string userinfo = "";
            string userrole = "";

            string department_price = "";

            if (productMasters)
            {
                product_type = "product_type";
                product_size = "product_size";
                product_color = "product_color";
                product_master = "product_master";
                product = "product";
            }

            if (departments)
            {
                department = "department";
                employee = "employee";
                employee_info = "employee_info";
                userinfo = "userinfo";
                role = "role";
                userrole = "userrole";
            }

            if (prices)
            {
                department_price = "department_price";
            }
            string backupFile = dbBackupPath + "/" + backupFileName;
            string mysqldumpstring = string.Format("--database {0} --table {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} --replace --add-drop-table=false --no-create-info --no-create-db --result-file={13} --single-transaction --user={14} --password={15} --skip-add-locks --add-locks=false --quick ",
                                                      "pos", // dbname
                                                      product_type,
                                                      product_size,
                                                      product_color,
                                                      product_master,
                                                      product,
                                                      department,
                                                      employee_info,
                                                      employee,
                                                      role,
                                                      userinfo,
                                                      userrole,
                                                      department_price,
                                                      backupFile, // backupfile
                                                      "dbadmin",  // username
                                                      "1qw45DCM9rl");

            ExecuteMySqlDumpCmdLine(true, mysqldumpstring);
            using (ZipFile masterZipFile = new ZipFile())
            {
                masterZipFile.Password = ZIP_PASSWORD;
                masterZipFile.AddFile(backupFile, "");
                masterZipFile.Save(dbBackupPath + "/" + "MasterData_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            }
            File.Delete(backupFile);

        }

        public static void SyncMasterData(string masterFileName)
        {
            DbConnection conn;
            DbCommand command;
            string strUserID = "dbadmin";
            string strPswd = "1qw45DCM9rl";
            string strDBName = "pos";
            string strServer = "localhost";
            //Use the Web.Config url to call web service.
            string connectionStr = "Server=" + strServer + ";Database=" + strDBName + ";User ID=" + strUserID + ";Password=" + strPswd + ";";
            object activeDepartmentId = null;
            conn = new MySqlConnection(connectionStr);

            try
            {
                conn.Open();
                command = conn.CreateCommand();
                command.CommandText = " SELECT department_id FROM department WHERE active = 1";
                activeDepartmentId = command.ExecuteScalar();
            }
            catch (Exception)
            {


            }
            finally
            {
                conn.Close();
            }

            // get active department

            string pathExtract = masterFileName.Substring(0, masterFileName.LastIndexOf("\\"));
            using (ZipFile masterZipFile = ZipFile.Read(masterFileName))
            {
                masterZipFile.Password = ZIP_PASSWORD;
                masterZipFile.ExtractAll(pathExtract, ExtractExistingFileAction.OverwriteSilently);
            }
            string[] files = Directory.GetFiles(pathExtract);
            foreach (string file in files)
            {
                if (!file.EndsWith("sql")) continue;
                string syncString = string.Format(" --database={0} --user={1} --password={2}  -e \"source {3} \"", "pos", "dbadmin", "1qw45DCM9rl", file);
                ExecuteMySqlDumpCmdLine(false, syncString);
                File.Delete(file);
            }
            File.Delete(masterFileName);

            // clean database
            string delProduct =
                "\" DELETE from product WHERE product_id NOT IN (SELECT product_id FROM department_stock); \"";
            string delProductMaster = "\" DELETE from product_master WHERE product_master_id NOT IN (SELECT product_master_id FROM product); \"";
            string delDepartmentPrice = "\" DELETE from department_price WHERE product_master_id NOT IN (SELECT product_master_id FROM product_master); \"";

            ExecuteMySqlCmdLine(delProduct, "pos", "dbadmin", "1qw45DCM9rl");
            ExecuteMySqlCmdLine(delProductMaster, "pos", "dbadmin", "1qw45DCM9rl");
            ExecuteMySqlCmdLine(delDepartmentPrice, "pos", "dbadmin", "1qw45DCM9rl");

            // update active department
            if (activeDepartmentId == null || activeDepartmentId.ToString() == string.Empty)
            {

            }
            else
            {
                try
                {
                    conn.Open();
                    command = conn.CreateCommand();
                    command.CommandText = " UPDATE department SET active = 1 WHERE department_id = " + activeDepartmentId.ToString();
                    command.ExecuteNonQuery();
                    //activeDepartmentId = command.ExecuteNonQuery();
                }
                catch (Exception)
                {


                }
                finally
                {
                    conn.Close();
                }
            }

        }

        public static void ClearCLRDatabase(bool SaleStatistic, bool ImExStatistic)
        {
            CleanDatabase(SaleStatistic, ImExStatistic);  
        }
    }
}
