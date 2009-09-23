using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Utility;
using AppFrameClient.Common;
using log4net;
using MySql.Data.MySqlClient;

namespace AppFrameClient.Utility
{
    public class ClientUtility
    {
        public static void DumpDatabase()
        {
            string mySQLDumpPath = ClientSetting.MySQLDumpPath+"\\mysqldump.exe";
            if(!File.Exists(mySQLDumpPath))
            {
                throw new BusinessException("Tập thực  thi mysqldump không tồn tại trên đường dẫn. Xin xem lại trong cấu hình hệ thống");
            }
            string POSSyncDrive = ClientUtility.GetPOSSyncDrives()[0].ToString();
            string dbBackupPath = POSSyncDrive + ClientSetting.DBBackupPath;
            if(!Directory.Exists(dbBackupPath))
            {
                throw new BusinessException("Đường dẫn backup dữ liệu không tồn tại. Xin xem lại trong cấu hình hệ thống");    
            }
            string backupFileName = string.Format("POSBackup_{0}.sql", DateTime.Now.ToString("yyyyHHmmss"));
            try
            {
                // Need to use "--databases" to force CREATE DATABASE command in script
                // --hex-blob to turn blob fields into hex strings
                string mysqldumpstring = string.Format("--database {0} --result-file={1} --single-transaction --routines --triggers --user={2} --password={3} --add-drop-database=true --quick ", 
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
        public static IList GetUSBDrives()
        {
            IList usbList = new ArrayList();
            foreach (ManagementObject drive in new ManagementObjectSearcher(
                "select * from Win32_DiskDrive where InterfaceType='USB'").Get())
            {
                // associate physical disks with partitions
                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"]
                      + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {   
                    // associate partitions with logical disks (drive letter volumes)
                    foreach (ManagementObject disk in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                          + partition["DeviceID"]
                          + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        usbList.Add(disk["Name"]);
                    }
                }

                // this may display nothing if the physical disk
            }
            return usbList;
        }

        public static IList GetPOSSyncDrives()
        {
            IList posSyncDrives = new ArrayList();
            IList usbList = GetUSBDrives();
            foreach (string usbDrive in usbList)
            {
               if(CheckPOSSyncDrive(usbDrive))
               {
                   posSyncDrives.Add(usbDrive);
               }
            }
            return posSyncDrives;
        }
        public static bool CheckPOSSyncDrive(string usbDrive)
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

        public static void MoveFileToSpecificDir(string path, string fileName)
        {
            try
            {
                string specificDeptPath = null;
                string testName = fileName.Substring(fileName.LastIndexOf("\\")+1,
                                                         fileName.Length - (fileName.LastIndexOf("\\")+1));
                /*if (fileName.IndexOf("SyncUp") > 0)
                {*/
                    long deptId = Int64.Parse(testName.Substring(0, testName.IndexOf("_")));
                    specificDeptPath = path + "\\" + deptId.ToString();
                /*}

                if (fileName.IndexOf("SyncDown") > 0)
                {
                    specificDeptPath = path + "\\" + testName.Substring(0,testName.IndexOf("_SyncDown_"));
                }*/

                if (specificDeptPath == null) throw new Exception();
                if (!Directory.Exists(specificDeptPath))
                {
                    Directory.CreateDirectory(specificDeptPath);
                }
                File.Move(fileName, specificDeptPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\")+1, fileName.Length - (fileName.LastIndexOf("\\")+1)));
            }
            catch (Exception)
            {
                try
                {
                    File.Move(fileName, path + "\\" + fileName.Substring(fileName.LastIndexOf("\\")+1, fileName.Length - (fileName.LastIndexOf("\\")+1)));
                }
                catch (Exception) { }
            }
        }

        public static void Log(ILog logger, string message)
        {
            //MDC.Set("user", ClientInfo.getInstance().LoggedUser.Name);
            log4net.GlobalContext.Properties["user"] = ClientInfo.getInstance().LoggedUser.Name;
            logger.Error(message); //now log error
        }

        public static void Log(ILog logger, string message, string action)
        {
            //MDC.Set("user", ClientInfo.getInstance().LoggedUser.Name);
            log4net.GlobalContext.Properties["user"] = ClientInfo.getInstance().LoggedUser.Name;
            log4net.GlobalContext.Properties["action"] = action;
            logger.Error(message); //now log error
        }

        public static string EnsureSyncPath(string path, Department department)
        {
            string ensurePath = path + "\\" + department.DepartmentId;
            bool result = false;
            
                try
                {
                    if(!Directory.Exists(ensurePath))
                    {
                        Directory.CreateDirectory(ensurePath);
                    }
                    result = true;
                }
                catch (Exception)
                {
                    
                    
                }
            
            if(result)
            {
                return ensurePath;
            }
            else
            {
                return path;
            }
        }

        public enum SyncType { SyncUp, SyncDown }
        public static DateTime GetLastSyncTime(string exportPath,Department department,SyncType syncType)
        {
            DateTime lastSyncTime = DateTime.MinValue;
            string[] syncTimeFiles = Directory.GetFiles(exportPath, "*.synctime");
            string mark = "_Status";
            if(syncType == SyncType.SyncUp)
            {
                mark += "SyncUp";
            }
            if (syncType == SyncType.SyncDown)
            {
                mark += "SyncDown";
            }
            foreach (string file in syncTimeFiles)
            {
                if(file.IndexOf(department.DepartmentId + mark) >=0 )
                {
                    Stream stream = File.OpenRead(file);
                    BinaryFormatter formatter = new BinaryFormatter();
                    lastSyncTime  = (DateTime)formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            return lastSyncTime;
        }

        public static void WriteLastSyncTime(DateTime syncTime,string exportPath,Department department,SyncType syncType)
        {
            DateTime lastSyncTime = DateTime.Now;
            string mark = "_Status";
            if (syncType == SyncType.SyncUp)
            {
                mark += "SyncUp";
            }
            if (syncType == SyncType.SyncDown)
            {
                mark += "SyncDown";
            }
            string lastSyncFile = exportPath + "\\" + department.DepartmentId + mark +".synctime";
            Stream stream = File.Open(lastSyncFile, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, syncTime);
            stream.Close();
        }

        public static void CopyDirectory(string src,string dst)
        {
            String[] Files;

            if(dst[dst.Length-1]!=Path.DirectorySeparatorChar) 
                dst+=Path.DirectorySeparatorChar;
            if(!Directory.Exists(dst)) Directory.CreateDirectory(dst);
            Files=Directory.GetFileSystemEntries(src);
            foreach(string Element in Files)
            {
                // Sub directories

                if(Directory.Exists(Element)) 
                    CopyDirectory(Element,dst+Path.GetFileName(Element));
                // Files in directory

                else 
                    File.Copy(Element,dst+Path.GetFileName(Element),true);
            }
        }
        
        public static void MoveDirectory(string src,string dst,bool deleteEmptyDir)
        {
            String[] Files;

            if(dst[dst.Length-1]!=Path.DirectorySeparatorChar) 
                dst+=Path.DirectorySeparatorChar;
            if(!Directory.Exists(dst)) Directory.CreateDirectory(dst);
            Files=Directory.GetFileSystemEntries(src);
            foreach(string Element in Files)
            {
                if (Directory.Exists(Element)) // Sub directories
                {
                    MoveDirectory(Element, dst + Path.GetFileName(Element),deleteEmptyDir);
                    if(deleteEmptyDir) Directory.Delete(Element);
                }
                else    // Files in directory
                {
                    File.Copy(Element, dst + Path.GetFileName(Element), true);
                    File.Delete(Element);
                }
            }
        }
        
    }
}
