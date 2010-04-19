using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppFrame.DataLayer;
using AppFrame.Utils;
using CoralPOS.Models;
using NHibernate;
using NHibernate.Linq;
using POSServer.DataLayer.Implement;
using ProtoBuf;

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
            return (IList<SyncResult>)StockOutDao.Execute(delegate(ISession session)
                                    {
                                        
                                        if (syncToDept.DepartmentInfo)
                                        {
                                            ObjectCriteria<Department> deptCrit = new ObjectCriteria<Department>();
                                            deptCrit.Add(dpm => dpm.DepartmentId == syncToDept.Department.DepartmentId);
                                            syncToDept.Department = (Department)DepartmentDao.FindFirst(deptCrit);
                                        }

                                        if (syncToDept.ProductMasterInfo)
                                        {
                                            IQuery query = session.CreateQuery("from Product fetch all properties");
                                            syncToDept.ProductList = query.List<Product>();

                                            IQuery priceQuery = session.CreateQuery("from MainPrice fetch all properties");
                                            syncToDept.PriceList = priceQuery.List<MainPrice>();
                                        }
                                        else
                                        {
                                            if (syncToDept.PriceInfo)
                                            {
                                                IQuery priceQuery = session.CreateQuery("from MainPrice fetch all properties");
                                                syncToDept.PriceList = priceQuery.List<MainPrice>();
                                            }
                                        }
                                        var stockOutQuery = session.CreateQuery("from StockOut fetch all properties");
                                        syncToDept.StockOutList = stockOutQuery.List<StockOut>();
                                        
                                        SyncToDepartmentObject first = new SyncToDepartmentObject();
                                        first.Department = syncToDept.Department;
                                        first.ProductList = syncToDept.ProductList;
                                        first.PriceList = syncToDept.PriceList;
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
                                        Serializer.Serialize(stream, first);
                                        stream.Flush();
                                        stream.Close();

                                        // write each stock out to a sync file for avoiding duplicate update
                                        if (!ObjectUtility.IsNullOrEmpty(syncToDept.StockOutList))
                                        {
                                            foreach (StockOut stockOut in syncToDept.StockOutList)
                                            {
                                                countSyncFile += 1;
                                                SyncToDepartmentObject soSync = new SyncToDepartmentObject();
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
                                                Serializer.Serialize(soStream, soSync);
                                                soStream.Flush();
                                                soStream.Close();
                                            }
                                        }
                                        return resultList;
                                    }
                                    );
            
        }

        private SyncToDepartmentObject GetSyncData(SyncToDepartmentObject syncToDept)
        {
            if (syncToDept.DepartmentInfo)
            {
                ObjectCriteria<Department> deptCrit = new ObjectCriteria<Department>();
                deptCrit.Add(dpm => dpm.DepartmentId == syncToDept.Department.DepartmentId);
                syncToDept.Department = (Department)DepartmentDao.FindFirst(deptCrit);
            }

            if (syncToDept.ProductMasterInfo)
            {

                ProductDao.Execute(delegate(ISession session)
                {
                    string hql = "from Product fetch all properties";
                    IQuery query = session.CreateQuery(hql);
                    syncToDept.ProductList = query.List<Product>();
                    return null;
                })
                ;
                syncToDept.ProductList = ProductDao.FindAll(new LinqCriteria<Product>());
                foreach (Product product in syncToDept.ProductList)
                {
                    ProductDao.Fetch(product);
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
            syncToDept.StockOutList = stockOuts;
            return syncToDept; 
        }
    }
}
