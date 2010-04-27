using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AppFrame.DataLayer.Utils;
using AppFrame.Utils;
using CoralPOS.Models;
using System.Linq;

using POSClient.DataLayer.Implement;
using Spring.Data.Common;
using Spring.Data.Support;

namespace POSClient.BusinessLogic.Implement
{
    public class SyncLogic : ISyncLogic
    {
        public ProductDao ProductDao { get; set; }
        public ProductMasterDao ProductMasterDao { get; set; }
        public StockOutDao StockOutDao { get; set; }
        public DepartmentDao DepartmentDao { get; set; }
        public MainPriceDao MainPriceDao { get; set; }

        public SyncToMainObject SyncToMain(SyncToMainObject syncToMainObject)
        {
            if(syncToMainObject.HasCommonInfo)
            {
                
            }
            return syncToMainObject;
        }

        public SyncResult SyncFromMain(SyncToDepartmentObject syncToDept)
        {
            SyncResult result = new SyncResult();
            #region useless
            /*Department department = syncToDept.Department;
            DepartmentDao.SaveOrUpdate(department);
            if(!ObjectUtility.IsNullOrEmpty(syncToDept.ProductMasterList))
                SyncCommonInformation(syncToDept);
            if(!ObjectUtility.IsNullOrEmpty(syncToDept.StockOutList))
                SyncStockOut(syncToDept);*/

            #endregion

            SyncCommonInformation(syncToDept);
            SyncStockOut(syncToDept);
            return result;
        }

        private string SyncStockOut(SyncToDepartmentObject syncToDept)
        {
            /*var stockOutList = syncToDept.StockOutList;
            var productList = from so in stockOutList
                              from soDetail in so.StockOutDetails
                              select soDetail.Product;

            var colorList = from prd in productList
                            select prd.ProductColor;
            var sizeList = from prd in productList
                            select prd.ProductSize;*/

            PosDatabase database = PosDatabase.Instance;
            
            /*database.UpdateDataTable(syncToDept.ProductColor, "CRL_EX_PRD_COLOR");
            database.UpdateDataTable(syncToDept.ProductSize, "CRL_EX_PRD_COLOR");*/

            return "";
        }

        private string SyncCommonInformation(SyncToDepartmentObject syncToDept)
        {
            #region useless
            /*var productMasterList = syncToDept.ProductMasterList;
            if (ObjectUtility.IsNullOrEmpty(productMasterList)) return "";
            ProductMasterDao.BatchUpdate(productMasterList);

            var priceList = syncToDept.PriceList;
            MainPriceDao.BatchUpdate(priceList);*/

            #endregion

            PosDatabase database = PosDatabase.Instance;

            /*DataTable categoryCurrent = database.ExecuteQueryAll("CRL_CAT");
            categoryCurrent.Merge(database.ConvertDataType(syncToDept.Category, categoryCurrent));
            categoryCurrent.TableName = "CRL_CAT";
            database.UpdateDataTable(categoryCurrent);

            DataTable productTypeCurrent = database.ExecuteQueryAll("CRL_PRD_TYP");
            
            productTypeCurrent.Merge(database.ConvertDataType(syncToDept.ProductType, productTypeCurrent));
            productTypeCurrent.TableName = "CRL_PRD_TYP";
            database.UpdateDataTable(productTypeCurrent);*/
            database.UpdateDataTable(syncToDept.Category, "CRL_CAT");
            database.UpdateDataTable(syncToDept.ProductType, "CRL_PRD_TYP");
            database.UpdateDataTable(syncToDept.ProductMaster,"CRL_PRD_MST");
            database.UpdateDataTable(syncToDept.ProductColor, "CRL_EX_PRD_COLOR");
            database.UpdateDataTable(syncToDept.ProductSize, "CRL_EX_PRD_SIZE");
            database.UpdateDataTable(syncToDept.Product, "CRL_PRD");
            return "";
        }

        public IList<SyncResult> SyncFromMain(string importPath)
        {
            IList<SyncResult> resultList = new List<SyncResult>();
            string[] importFiles = Directory.GetFiles(importPath, "*.ssf");

            foreach (string importFile in importFiles)
            {
                Stream readerStream = File.Open(importFile, FileMode.Open);
                BinaryFormatter reader = new BinaryFormatter();
                SyncToDepartmentObject syncToDept = (SyncToDepartmentObject)reader.Deserialize(readerStream);
                if(syncToDept == null) continue;
                resultList.Add(SyncFromMain(syncToDept));
            }
            return resultList;
            
        }
    }
}
