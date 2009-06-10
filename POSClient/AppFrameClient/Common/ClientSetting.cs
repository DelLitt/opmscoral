using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AFCSetting = AppFrameClient.Properties.Settings;

namespace AppFrameClient.Common
{
    public class ClientSetting
    {   
        public static bool IsClient()
        {
            return string.IsNullOrEmpty(AFCSetting.Default.IsClient)
                       ? false
                       : AFCSetting.Default.IsClient.Equals("1");           
        }

        public static bool IsServer()
        {
            return string.IsNullOrEmpty(AFCSetting.Default.IsClient)
                       ? false
                       : AFCSetting.Default.IsClient.Equals("0");
        }

        public static bool IsSubStock()
        {
            return string.IsNullOrEmpty(AFCSetting.Default.IsClient)
                       ? false
                       : AFCSetting.Default.IsClient.Equals("2");
        }

        public static void Save()
        {
            AFCSetting.Default.Save();
            AFCSetting.Default.Upgrade();
        }
        public static void Reload()
        {
            AFCSetting.Default.Reload();
        }

        public static string SyncImportPath
        {
            get
            {
                return AFCSetting.Default.SyncImportPath;
            }
            set
            {
                AFCSetting.Default.SyncImportPath = value;
            }
        }
        public static string SyncSuccessPath
        {
            get
            {
                return AFCSetting.Default.SyncSuccessPath;
            }
            set
            {
                AFCSetting.Default.SyncSuccessPath = value;
            }
        }
        public static string SyncErrorPath
        {
            get
            {
                return AFCSetting.Default.SyncErrorPath;
            }
            set
            {
                AFCSetting.Default.SyncErrorPath = value;
            }
        }
        public static string SyncExportPath
        {
            get
            {
                return AFCSetting.Default.SyncExportPath;
            }
            set
            {
                AFCSetting.Default.SyncExportPath = value;
            }
        }
        public static string PrinterName
        {
            get
            {
                return AFCSetting.Default.PrinterName;
            }
            set
            {
                AFCSetting.Default.PrinterName = value;
            }
        }
        public static string MySQLDumpPath
        {
            get
            {
                return AFCSetting.Default.MySQLDump;
            }
            set
            {
                AFCSetting.Default.MySQLDump = value;                
            }
        }
        public static string DBBackupPath
        {
            get
            {
                return AFCSetting.Default.DBBackupPath;
            }
            set
            {
                AFCSetting.Default.DBBackupPath = value;
            }
        }

        public static void Reset()
        {
            AFCSetting.Default.Reset();
        }
    }
}
