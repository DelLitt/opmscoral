using AFCSetting = POSServer.Properties.Settings;
namespace POSServer.Common
{
    public class ClientSetting
    {

        public const string ZIP_PASSWORD = "gfd83fds32l1asdtg";


        public static long MaxPOId
        {
            get
            {
                return AFCSetting.Default.MaxPOId;
            }
            set
            {
                AFCSetting.Default.MaxPOId = value;
            }
        }

        public static string SubStockDB
        {
            get
            {
                return AFCSetting.Default.SubStockDB;
            }
            set
            {
                AFCSetting.Default.SubStockDB = value;
            }
        }
        public static string SalePointDB
        {
            get
            {
                return AFCSetting.Default.SalePointDB;
            }
            set
            {
                AFCSetting.Default.SalePointDB = value;
            }
        }
        public static bool NegativeStock
        {
            get
            {
                return AFCSetting.Default.NegativeStock;
            }
            set
            {
                AFCSetting.Default.NegativeStock = value;
            }
        }
        public static string ServiceBinding
        {
            get
            {
                return AFCSetting.Default.ServiceBinding;
            }
            set
            {
                AFCSetting.Default.ServiceBinding = value;
            }
        }


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
        public static string MarketDept
        {
            get
            {
                return AFCSetting.Default.DeptMarket;
            }
            set
            {
                AFCSetting.Default.DeptMarket = value;
            }
        }

        public static bool ConfirmByEmployeeId
        {
            get
            {
                return AFCSetting.Default.ConfirmByEmployeeId;
            }
            set
            {
                AFCSetting.Default.ConfirmByEmployeeId = value;
            }
        }

        public static bool NegativeSelling
        {
            get
            {
                return AFCSetting.Default.NegativeSelling;
            }
            set
            {
                AFCSetting.Default.NegativeSelling = value;
            }
        }

        public static bool NegativeExport
        {
            get
            {
                return AFCSetting.Default.NegativeExport;
            }
            set
            {
                AFCSetting.Default.NegativeExport = value;
            }
        }

        public static bool ExportConfirmation
        {
            get
            {
                return AFCSetting.Default.ExportConfirmation;
            }
            set
            {
                AFCSetting.Default.ExportConfirmation = value;
            }
        }

        public static bool ImportConfirmation
        {
            get
            {
                return AFCSetting.Default.ImportConfirmation;
            }
            set
            {
                AFCSetting.Default.ImportConfirmation = value;
            }
        }

        public static BarcodeLib.TYPE BarcodeType
        {
            get
            {
                return AFCSetting.Default.BarcodeType;
            }
            set
            {
                AFCSetting.Default.BarcodeType = value;
            }
        }

        public static void Reset()
        {
            AFCSetting.Default.Reset();
        }


    }
}
