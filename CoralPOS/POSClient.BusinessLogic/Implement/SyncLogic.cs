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
using CoralPOS.PosClientDbTableAdapters;
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
            PosClientDb clientDb = new PosClientDb();
            
            PosDatabase database = PosDatabase.Instance;
            var deptStkInAdapter = new crl_dept_stk_inTableAdapter();
            deptStkInAdapter.ClearBeforeFill = true;
            deptStkInAdapter.Fill(clientDb.crl_dept_stk_in);
            
            var deptStkInDetAdapter = new crl_dept_stk_in_detTableAdapter();
            deptStkInDetAdapter.Fill(clientDb.crl_dept_stk_in_det);

            var deptStkTableAdapter = new crl_dept_stkTableAdapter();
            deptStkTableAdapter.Fill(clientDb.crl_dept_stk);
            
            string template = DateTime.Now.ToString("yyMMdd");
            var maxId = from dr in clientDb.crl_dept_stk_in
                        where dr.STOCK_IN_ID.Contains(template)
                        orderby dr.STOCK_IN_ID descending
                        select dr.STOCK_IN_ID.FirstOrDefault();
            string maxStockInId = ObjectUtility.IsNullOrEmpty(maxId) ? (Int64.Parse(maxId.ToString()) + 1).ToString() : syncToDept.Department.DepartmentId.ToString() + template + "1";

            Department department = syncToDept.Department;

            PosClientDb.crl_stk_out_detDataTable details = new PosClientDb.crl_stk_out_detDataTable();
            foreach (DataRow dataRow in syncToDept.StockOutDetail.Rows)
            {
                var itemArray = dataRow.ItemArray;
                details.Rows.Add(itemArray);
            }


            foreach (DataRow stockOut in syncToDept.StockOut.Rows)
            {
                string filter = "STOCK_OUT_ID = " + stockOut["STOCK_OUT_ID"].ToString();
                var currents = from dr in clientDb.crl_stk_out
                                     where dr.STOCK_OUT_ID == Int64.Parse(stockOut["STOCK_OUT_ID"].ToString())
                                     select dr;
                
                if(currents.Count()>0) continue;
                // create new department stock in 
                PosClientDb.crl_dept_stk_inRow newRow = clientDb.crl_dept_stk_in.Newcrl_dept_stk_inRow();
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
                clientDb.crl_dept_stk_in.Addcrl_dept_stk_inRow(newRow);
                // create department stock in detail
                var specificDetails = from dt in details
                                      where dt.STOCK_OUT_ID == Int64.Parse(stockOut["STOCK_OUT_ID"].ToString())
                                      select dt;
                foreach (PosClientDb.crl_stk_out_detRow crlStkOutDetRow in specificDetails)
                {
                    // insert stock_in
                    PosClientDb.crl_dept_stk_in_detRow detail = clientDb.crl_dept_stk_in_det.Newcrl_dept_stk_in_detRow();
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
                    clientDb.crl_dept_stk_in_det.Addcrl_dept_stk_in_detRow(detail);

                    // update stock
                    PosClientDb.crl_dept_stkRow stkRow = (from stk in clientDb.crl_dept_stk.AsEnumerable() 
                                 where stk.PRODUCT_ID.Equals(crlStkOutDetRow.PRODUCT_ID)
                                 select stk).FirstOrDefault();
                    if(stkRow!=null) // if found
                    {
                        stkRow.QUANTITY += (int)crlStkOutDetRow.QUANTITY;

                    } // not found
                    else
                    {
                        PosClientDb.crl_dept_stkRow newStkRow = clientDb.crl_dept_stk.Newcrl_dept_stkRow();
                        newStkRow.PRODUCT_ID = crlStkOutDetRow.PRODUCT_ID;
                        newStkRow.PRODUCT_MASTER_ID = crlStkOutDetRow.PRODUCT_MASTER_ID;
                        newStkRow.QUANTITY = (int)crlStkOutDetRow.QUANTITY;
                        newStkRow.GOOD_QUANTITY = (int)crlStkOutDetRow.QUANTITY;
                        newStkRow.DEPARTMENT_ID = newRow.DEPARTMENT_ID;
                        newStkRow.EXCLUSIVE_KEY = newRow.EXCLUSIVE_KEY;
                        newStkRow.CREATE_DATE = newRow.CREATE_DATE;
                        newStkRow.UPDATE_DATE = newRow.UPDATE_DATE;
                        newStkRow.CREATE_ID = newRow.CREATE_ID;
                        newStkRow.UPDATE_ID = newRow.UPDATE_ID;
                        clientDb.crl_dept_stk.Addcrl_dept_stkRow(newStkRow);
                    }
                }
                maxStockInId = (Int64.Parse(maxStockInId) + 1).ToString();
                // update departmentstock in
            }
            
            deptStkInAdapter.Update(clientDb.crl_dept_stk_in);
            deptStkInDetAdapter.Update(clientDb.crl_dept_stk_in_det);
            deptStkTableAdapter.Update(clientDb.crl_dept_stk);
            return "";
        }

        private string SyncCommonInformation(SyncToDepartmentObject syncToDept)
        {
            PosDatabase database = PosDatabase.Instance;
            PosClientDb clientDb = new PosClientDb();
            crl_deptTableAdapter crlDeptTableAdapter = new crl_deptTableAdapter();
            crlDeptTableAdapter.Fill(clientDb.crl_dept);
            // sync department information
            database.ReflectUpdateTable(clientDb.crl_dept, syncToDept.DepartmentList);
            crlDeptTableAdapter.Update(clientDb.crl_dept);
            
            // sync product information
            crl_catTableAdapter catTableAdapter = new crl_catTableAdapter();
            catTableAdapter.Fill(clientDb.crl_cat);
            database.ReflectUpdateTable(clientDb.crl_cat,syncToDept.Category);
            catTableAdapter.Update(clientDb.crl_cat);

            crl_prd_typTableAdapter prdTypTableAdapter = new crl_prd_typTableAdapter();
            database.ReflectUpdateTable(clientDb.crl_prd_typ, syncToDept.ProductType);
            prdTypTableAdapter.Update(clientDb.crl_prd_typ);

            crl_ex_prd_colorTableAdapter crlExPrdColorTableAdapter = new crl_ex_prd_colorTableAdapter();
            database.ReflectUpdateTable(clientDb.crl_ex_prd_color, syncToDept.ProductColor);
            crlExPrdColorTableAdapter.Update(clientDb.crl_ex_prd_color);

            crl_ex_prd_sizeTableAdapter prdSizeTableAdapter = new crl_ex_prd_sizeTableAdapter();
            database.ReflectUpdateTable(clientDb.crl_ex_prd_size, syncToDept.ProductSize);
            prdSizeTableAdapter.Update(clientDb.crl_ex_prd_size);

            crl_prd_mstTableAdapter crlPrdMstTableAdapter = new crl_prd_mstTableAdapter();
            database.ReflectUpdateTable(clientDb.crl_prd_mst, syncToDept.ProductMaster);
            crlPrdMstTableAdapter.Update(clientDb.crl_prd_mst);

            crl_prdTableAdapter crlPrdTableAdapter = new crl_prdTableAdapter();
            database.ReflectUpdateTable(clientDb.crl_prd, syncToDept.Product);
            crlPrdTableAdapter.Update(clientDb.crl_prd);
            
            // sync price information
            crl_mn_priceTableAdapter crlMnPriceTableAdapter = new crl_mn_priceTableAdapter();
            database.ReflectUpdateTable(clientDb.crl_mn_price, syncToDept.Prices);
            crlMnPriceTableAdapter.Update(clientDb.crl_mn_price);

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
