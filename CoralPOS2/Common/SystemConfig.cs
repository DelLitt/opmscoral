using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CoralPOS.Common
{
    [Serializable]
    public class SystemConfig
    {
        public const string CONFIG_FILE_NAME = "posconfig.cfg";
        private static SystemConfig config;
        private SystemConfig()
        {
        }
        public static SystemConfig Instance
        {
            get
            {
                if(config == null)
                {
                    config = new SystemConfig();
                }
                return config;
            }
        }
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
        public bool Load()
        {
            try
            {
                Stream stream = File.Open(CONFIG_FILE_NAME, FileMode.Open);
                Load(stream);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public bool Load(string path)
        {
            try
            {
                Stream stream = File.Open(path + @"\" + CONFIG_FILE_NAME, FileMode.Open);
                Load(stream);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void Load(Stream stream)
        {
            BinaryFormatter writer = new BinaryFormatter();
            SystemConfig config = (SystemConfig)writer.Deserialize(stream);
            stream.Flush();
            stream.Close();
            var mapper = EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<SystemConfig, SystemConfig>();
            mapper.Map(config, this); 
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            Stream stream = File.Open(CONFIG_FILE_NAME, FileMode.Create);
            BinaryFormatter writer = new BinaryFormatter();
            writer.Serialize(stream, this);
            stream.Flush();
            stream.Close();
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
