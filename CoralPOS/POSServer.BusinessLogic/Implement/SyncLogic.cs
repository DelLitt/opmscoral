using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AppFrame.DataLayer.Utils;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;
using Spring.Data.Common;

namespace POSServer.BusinessLogic.Implement
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

        public SyncToDepartmentObject SyncToDepartment(SyncToDepartmentObject syncToDept)
        {
            syncToDept = GetSyncData(syncToDept);
            return syncToDept;
        }

        public IList<SyncResult> SyncToDepartment(string exportPath, SyncToDepartmentObject syncToDept)
        {
            IList<SyncResult> resultList = new List<SyncResult>();
            Department department = syncToDept.Department;
            syncToDept = GetSyncData(syncToDept);

            #region useless
            /*SyncToDepartmentObject first = new SyncToDepartmentObject();
                                        first.Department = syncToDept.Department;
                                        first.ProductMasterList = syncToDept.ProductMasterList;
                                        first.PriceList = syncToDept.PriceList;
                                        first.StockOutList = new List<StockOut>();*/

            #endregion
            int countSyncFile = 1;
            string fileName = exportPath + "\\" + department.DepartmentId
                                          + "_" + countSyncFile.ToString()
                                          + "_SyncDown_"
                                          + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                                          + ".ssf";
            SyncResult result = new SyncResult();
            result.FileName = fileName;
            result.Status = "Thành công";
            resultList.Add(result);
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter writer = new BinaryFormatter();
            writer.Serialize(stream, syncToDept);
            /*NxBinaryWriter nxWriter = new NxBinaryWriter(stream);
            nxWriter.WriteObject(first);*/
            stream.Flush();
            stream.Close();

            #region useless
            // write each stock out to a sync file for avoiding duplicate update
            /*if (!ObjectUtility.IsNullOrEmpty(syncToDept.StockOutList))
            {
                foreach (StockOut stockOut in syncToDept.StockOutList)
                {
                    //StockOut _initedstockOut = LazyInitializer.InitializeEntity(stockOut, 0, DaoConstants.MODEL_NAMESPACE, session)
                    countSyncFile += 1;
                    SyncToDepartmentObject soSync = new SyncToDepartmentObject();
                    first.ProductMasterList = new List<ProductMaster>();
                    first.PriceList = new List<MainPrice>();
                    soSync.Department = syncToDept.Department;
                    soSync.StockOutList = new List<StockOut>();
                    soSync.StockOutList.Add(stockOut);

                    string soFileName = exportPath + "\\" + department.DepartmentId
                                  + "_" + countSyncFile.ToString()
                                  + "_SyncDown_"
                                  + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                                  + ".ssf";
                    SyncResult soResult = new SyncResult();
                    soResult.FileName = soFileName;
                    soResult.Status = "Thành công";
                    resultList.Add(soResult);
                    Stream soStream = File.Open(soFileName, FileMode.Create);
                    BinaryFormatter soWriter = new BinaryFormatter();
                    soWriter.Serialize(soStream, soSync);
                    /*NxBinaryWriter nxSoWriter = new NxBinaryWriter(soStream);
                    nxSoWriter.WriteObject(soSync);♥1♥
                    //Serializer.Serialize(soStream, soSync);
                    soStream.Flush();
                    soStream.Close();
                }
            }*/

            #endregion
            return resultList;
            /*}
            );*/

        }

        public SyncResult SyncToDepartment(string exportPath)
        {
            return null;
        }

        private SyncToDepartmentObject GetSyncData(SyncToDepartmentObject syncToDept)
        {
            PosDatabase database = PosDatabase.Instance;
            if (syncToDept.DepartmentInfo)
            {
                IDbParametersBuilder builder = new DbParametersBuilder(database.DbProvider);
                //builder.Create().Name("update_date").Type(DbType.DateTime).Value(syncToDept.LastSyncTime);
                syncToDept.DepartmentList = database.ExecuteQueryAll("CRL_DEPT");
            }

            if (syncToDept.ProductMasterInfo)
            {

                syncToDept.ProductMaster = database.ExecuteQueryAll("CRL_PRD_MST");
                syncToDept.ProductType = database.ExecuteQueryAll("CRL_PRD_TYP");
                syncToDept.Category = database.ExecuteQueryAll("CRL_CAT");
                syncToDept.ProductColor = database.ExecuteQueryAll("CRL_EX_PRD_COLOR");
                syncToDept.ProductSize = database.ExecuteQueryAll("CRL_EX_PRD_SIZE");
                syncToDept.Product = database.ExecuteQueryAll("CRL_PRD");

                syncToDept.Prices = database.ExecuteQueryAll("CRL_MN_PRICE");
            }
            else
            {
                if (syncToDept.PriceInfo)
                {
                    syncToDept.Prices = database.ExecuteQueryAll("CRL_MN_PRICE");
                }
            }

            syncToDept.StockOut = database.ExecuteQueryAll("CRL_STK_OUT");
            syncToDept.StockOutDetail = database.ExecuteQueryAll("CRL_STK_OUT_DET");
            #region Useless
            /*if (syncToDept.DepartmentInfo)
            {
                ObjectCriteria<Department> deptCrit = new ObjectCriteria<Department>();
                deptCrit.Add(dpm => dpm.DepartmentId == syncToDept.Department.DepartmentId);
                syncToDept.Department = (Department)DepartmentDao.FindFirst(deptCrit);
            }

            if (syncToDept.ProductMasterInfo)
            {

                ProductDao.Execute(delegate(ISession session)
                {
                    string hql = "from ProductMaster fetch all properties";
                    IQuery query = session.CreateQuery(hql);
                    syncToDept.ProductMasterList = query.List<ProductMaster>();
                    return null;
                })
                ;
                syncToDept.ProductMasterList = ProductMasterDao.FindAll(new LinqCriteria<ProductMaster>());
                foreach (ProductMaster product in syncToDept.ProductMasterList)
                {
                    ProductMasterDao.Fetch(product);
                }
                syncToDept.PriceList = MainPriceDao.FindAll(new LinqCriteria<MainPrice>());
                foreach (MainPrice mainPrice in syncToDept.PriceList)
                {
                    MainPriceDao.Fetch(mainPrice);
                }
            }
            else
            {
                if (syncToDept.PriceInfo)
                {
                    syncToDept.PriceList = MainPriceDao.FindAll(new LinqCriteria<MainPrice>());
                }
            }
            LinqCriteria<StockOut> stockOutCrit = new LinqCriteria<StockOut>();
            stockOutCrit.AddCriteria(so => so.CreateDate > DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0)));
            stockOutCrit.AddCriteria(so => so.Department.DepartmentId == syncToDept.Department.DepartmentId);
            stockOutCrit.AddFetchPath(so => so.StockOutDetails);
            IList<StockOut> stockOuts = StockOutDao.FindAll(stockOutCrit);
            foreach (StockOut stockOut in stockOuts)
            {
                StockOutDao.Fetch(stockOut);
            }
            syncToDept.StockOutList = stockOuts; */
            #endregion
            
            return syncToDept; 
        }
    }


}
