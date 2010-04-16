using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.DataLayer;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

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
           if(syncToDept.DepartmentInfo)
           {
               ObjectCriteria<Department> deptCrit = new ObjectCriteria<Department>();
               deptCrit.Add(dpm => dpm.DepartmentId == syncToDept.Department.DepartmentId);
               syncToDept.Department = (Department)DepartmentDao.FindFirst(deptCrit);
           }
           
           if(syncToDept.ProductMasterInfo)
           {
               syncToDept.ProductList = ProductDao.FindAll(new LinqCriteria<Product>());
               syncToDept.PriceList = MainPriceDao.FindAll(new LinqCriteria<MainPrice>());
           }
           else
           {
               if(syncToDept.PriceInfo)
               {
                   syncToDept.PriceList = MainPriceDao.FindAll(new LinqCriteria<MainPrice>());
               }
           }
           LinqCriteria<StockOut>  stockOutCrit = new LinqCriteria<StockOut>();
            stockOutCrit.AddCriteria(so => so.CreateDate > DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0)));
            stockOutCrit.AddCriteria(so => so.Department.DepartmentId == syncToDept.Department.DepartmentId);
            stockOutCrit.AddFetchPath(so => so.StockOutDetails);
            IList<StockOut> stockOuts = StockOutDao.FindAll(stockOutCrit);

            syncToDept.StockOutList = stockOuts;
            return syncToDept;
        }
    }
}
