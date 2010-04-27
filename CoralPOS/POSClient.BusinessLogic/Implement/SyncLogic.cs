using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AppFrame.DataLayer.Utils;
using AppFrame.Utils;
using CoralPOS;
using CoralPOS.Models;
using System.Linq;
using System.Linq.Expressions;
using POSClient.DataLayer.Implement;
using CoralPOS.pos2DataSetTableAdapters;
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
        public DepartmentStockInDao DepartmentStockInDao { get; set; }
        public DepartmentStockInDetailDao DepartmentStockInDetailDao { get; set; }
        public DepartmentStockDao DepartmentStockDao { get; set; }

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
            pos2DataSet dataSet = new pos2DataSet();
            
            PosDatabase database = PosDatabase.Instance;
            var deptStkInAdapter = new crl_dept_stk_inTableAdapter();
            deptStkInAdapter.ClearBeforeFill = true;
            deptStkInAdapter.Fill(dataSet.crl_dept_stk_in);
            
            var deptStkInDetAdapter = new crl_dept_stk_in_detTableAdapter();
            deptStkInDetAdapter.Fill(dataSet.crl_dept_stk_in_det);
            
            string template = DateTime.Now.ToString("yyMMdd");
            var maxId = from dr in dataSet.crl_dept_stk_in
                        where dr.STOCK_IN_ID.Contains(template)
                        orderby dr.STOCK_IN_ID descending
                        select dr.STOCK_IN_ID.FirstOrDefault();
            string maxStockInId = ObjectUtility.IsNullOrEmpty(maxId) ? (Int64.Parse(maxId.ToString()) + 1).ToString() : syncToDept.Department.DepartmentId.ToString() + template + "1";

            Department department = syncToDept.Department;
            /*dataSet.crl_dept.Addcrl_deptRow(department.DepartmentId, department.DepartmentName, department.Address,
                                            department.Active, department.CreateDate, department.CreateId,
                                            department.UpdateDate, department.UpdateId, department.ExclusiveKey,
                                            department.DelFlg, department.ExFld1, department.ExFld2, department.ExFld3,
                                            department.ExFld4, department.ExFld5,department.StartDate);
            pos2DataSet.crl_deptRow deptRow = dataSet.crl_dept.FindByDEPARTMENT_ID(department.DepartmentId);*/

            
            pos2DataSet.crl_stk_out_detDataTable details = new pos2DataSet.crl_stk_out_detDataTable();
            foreach (DataRow dataRow in syncToDept.StockOutDetail.Rows)
            {
                var itemArray = dataRow.ItemArray;
                details.Rows.Add(itemArray);
            }


            foreach (DataRow stockOut in syncToDept.StockOut.Rows)
            {
                string filter = "STOCK_OUT_ID = " + stockOut["STOCK_OUT_ID"].ToString();
                var currents = from dr in dataSet.crl_stk_out
                                     where dr.STOCK_OUT_ID == Int64.Parse(stockOut["STOCK_OUT_ID"].ToString())
                                     select dr;
                
                if(currents.Count()>0) continue;
                // create new department stock in 
                pos2DataSet.crl_dept_stk_inRow newRow = dataSet.crl_dept_stk_in.Newcrl_dept_stk_inRow();
                newRow.STOCK_IN_ID = maxStockInId;
                newRow.STOCK_IN_TYPE = 0;
                newRow.SRC_DEPARTMENT_ID = Int64.Parse(stockOut["DEPARTMENT_ID"].ToString());
                newRow.TOTAL_QUANTITY = Int64.Parse(stockOut["TOTAL_QUANTITY"].ToString());
                newRow.DEPARTMENT_ID = department.DepartmentId;
                newRow.STOCK_IN_DATE = DateTime.Now;
                newRow.CREATE_DATE = DateTime.Now;
                newRow.UPDATE_DATE = DateTime.Now;
                newRow.CREATE_ID = "admin";
                newRow.UPDATE_ID = "admin";
                newRow.DESCRIPTION = stockOut["DESCRIPTION"].ToString();
                newRow.EXCLUSIVE_KEY = 1;
                dataSet.crl_dept_stk_in.Addcrl_dept_stk_inRow(newRow);
                // create department stock in detail
                var specificDetails = from dt in details
                                      where dt.STOCK_OUT_ID == Int64.Parse(stockOut["STOCK_OUT_ID"].ToString())
                                      select dt;
                foreach (pos2DataSet.crl_stk_out_detRow crlStkOutDetRow in specificDetails)
                {
                    pos2DataSet.crl_dept_stk_in_detRow detail = dataSet.crl_dept_stk_in_det.Newcrl_dept_stk_in_detRow();
                    detail.STOCK_IN_ID = maxStockInId;
                    detail.DEPARTMENT_ID = newRow.DEPARTMENT_ID;
                    detail.EXCLUSIVE_KEY = newRow.EXCLUSIVE_KEY;
                    detail.CREATE_DATE = newRow.CREATE_DATE;
                    detail.UPDATE_DATE = newRow.UPDATE_DATE;
                    detail.CREATE_ID = newRow.CREATE_ID;
                    detail.UPDATE_ID = newRow.UPDATE_ID;
                    detail.PRODUCT_ID = crlStkOutDetRow.PRODUCT_ID;
                    detail.PRODUCT_MASTER_ID = crlStkOutDetRow.PRODUCT_MASTER_ID;
                    detail.QUANTITY = crlStkOutDetRow.QUANTITY;

                    dataSet.crl_dept_stk_in_det.Addcrl_dept_stk_in_detRow(detail);
                }
                maxStockInId = (Int64.Parse(maxStockInId) + 1).ToString();
                // update departmentstock in
            }
            
            deptStkInAdapter.Update(dataSet.crl_dept_stk_in);
            deptStkInDetAdapter.Update(dataSet.crl_dept_stk_in_det);
            
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
            database.FastUpdateDataTable(syncToDept.DepartmentList,"CRL_DEPT");
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
