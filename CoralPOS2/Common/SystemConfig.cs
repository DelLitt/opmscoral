using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using ServiceStack.Text;

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
                bool loadSuccess = config.Load();
                if (!loadSuccess)
                {
                    config.CreateDefaultValue();
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
        public long SubStockInvoiceStockOut { get; set; }
        public string ConnectionProtocol { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool Load()
        {
            bool returnVal = false;
            Stream stream = null; 
            try
            {
                stream = File.Open(CONFIG_FILE_NAME, FileMode.Open);
                Load(stream);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                returnVal = false;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return returnVal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public bool Load(string path)
        {
            Stream stream = null;
            try
            {
                stream = File.Open(path + @"\" + CONFIG_FILE_NAME, FileMode.Open);
                Load(stream);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }
        private void Load(Stream stream)
        {

            //var reader = new SoapFormatter();
            var reader = new TypeSerializer<SystemConfig>();
            var streamReader = new StreamReader(stream);
            SystemConfig config = reader.DeserializeFromReader(streamReader);
            
            var mapper = EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<SystemConfig, SystemConfig>();
            mapper.Map(config, this); 
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            Stream stream = File.Open(CONFIG_FILE_NAME, FileMode.Create);
            
            var writer = new TypeSerializer<SystemConfig>();
            var streamWriter = new StreamWriter(stream);
            writer.SerializeToWriter(this, streamWriter);            
            streamWriter.Close();
            //var writer = new SoapFormatter();
            //streamWriter.Flush();
            /*stream.Flush();
            stream.Close();*/
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateDefaultValue()
        {
            SetDefaultPath();
            DbToolPath = @"C:\Program Files\MySQL\bin";
            BarcodeType = @"Code39";
            BillPrinter = "Epson 403 TM 4";
            ConnectionProtocol = "Http";
            SubStockInvoiceStockOut = 0;

        }
        public void SetDefaultPath()
        {
            SyncImportPath = @"\POS\CH-KHO";
            SyncExportPath = @"\POS\KHO-CH";
            SyncBackupPath = @"\POS\Backup";
            SyncErrorPath = @"\POS\Error";
            SyncSuccessPath = @"\POS\Success";
        }
    }
}
