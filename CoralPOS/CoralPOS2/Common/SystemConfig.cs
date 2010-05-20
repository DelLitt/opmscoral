using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoralPOS.Common
{
    public class SystemConfig
    {
        public const string CONFIG_FILE_NAME = "posconfig.cfg";
        public string SyncImportPath
        {
            get;
            set;
        }

        public string SyncExportPath
        {
            get;
            set;
        }

        public string SyncErrorPath
        {
            get;
            set;
        }

        public string SyncSuccessPath
        {
            get;
            set;
        }

        public string SyncBackupPath
        {
            get;
            set;
        }

        public string DbToolPath
        {
            get;
            set;
        }

        public bool NegativeSelling { get; set; }
        public bool NegativeStockOut { get; set; }
        public bool StockInConfirm { get; set; }
        public bool StockOutConfirm { get; set; }
        public bool PurchaseOrderConfirm { get; set; }
        public bool SubStockEmployeeChecking { get; set; }

        public string BarcodeType { get; set; }
        public string BillPrinter { get; set; }
        public IList SubStockInvoiceStockOut { get; set; }
        public string ConnectionProtocol { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateDefaultValue()
        {
            SyncImportPath = @"\POS\CH-KHO";
            SyncExportPath = @"\POS\KHO-CH";
            SyncBackupPath = @"\POS\Backup";
            SyncErrorPath = @"\POS\Error";
            SyncSuccessPath = @"\POS\Success";
            DbToolPath = @"C:\Program Files\Oracle\bin";
            BarcodeType = @"Code39";
            BillPrinter = "Epson 403 TM 4";
            ConnectionProtocol = "Http";
            SubStockInvoiceStockOut = new ArrayList();

        }
    }
}
