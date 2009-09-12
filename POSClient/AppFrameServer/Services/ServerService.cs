using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrameServer.DataLayer;
using AppFrameServer.Utility;
using AppFrameServer.View.Mapper;

namespace AppFrameServer.Services
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServerService : IServerService
    {
        public static readonly int SUBTODEPT = 1;
        public static readonly int DEPTTOSUB = 2;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static List<IDepartmentStockOutCallback> _callbackList = new List<IDepartmentStockOutCallback>();
        private static List<IDepartmentStockOutCallback> _callbackSubStockList = new List<IDepartmentStockOutCallback>();

        public void JoinDistributingGroup(Department department)
        {
            ServerUtility.Log(logger, department.DepartmentId + " joining the distributing group.");
            // Subscribe the guest to the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();
            if (department.DepartmentId > 9999)
            {
                if (!_callbackSubStockList.Contains(guest))
                {

                    _callbackSubStockList.Add(guest);
                    guest.NotifyConnected();
                    ServerUtility.Log(logger, department.DepartmentId + " joined the substock group.");
                }
            }
            else
            {
                if (!_callbackList.Contains(guest))
                {
                    _callbackList.Add(guest);
                    ServerUtility.Log(logger, department.DepartmentId + " joined the normal group.");
                    guest.NotifyConnected();
                }    
            }
             
        }


        public void RequestDepartmentStockOut(long departmentId)
        {
            ServerUtility.Log(logger, departmentId + " yeu cau thong tin xuat hang.");
            // request stock-out from sub stocks
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyRequestDepartmentStockOut(departmentId);
                     }
                     catch (Exception)
                     {

                     }
                 }); 
        }

        public void RequestRawDepartmentStockOut(long departmentId)
        {
            
        }

        public void RequestRawDepartmentStockIn(long departmentId)
        {
            
        }

        public void RequestDepartmentStockIn(long departmentId)
        {
            ServerUtility.Log(logger, departmentId + " yeu cau thong tin xuat hang.");
            if (departmentId > 9999)
            {
                // request stock-out from departments
                _callbackList.ForEach(
                    delegate(IDepartmentStockOutCallback callback)
                        {
                            try
                            {
                                callback.NotifyRequestDepartmentStockIn(departmentId);
                            }
                            catch (Exception)
                            {

                            }
                        });
            }
            else
            {
                // request stock-out from departments
                _callbackSubStockList.ForEach(
                    delegate(IDepartmentStockOutCallback callback)
                    {
                        try
                        {
                            callback.NotifyRequestDepartmentStockIn(departmentId);
                        }
                        catch (Exception)
                        {

                        }
                    });                
            }
        }

        public DepartmentStockIn MakeAllShoesDepartmentStockInBack(long salePointId,long subStockId)
        {
            return null; 
        }

        /// <summary>
        /// Inform message back to caller
        /// </summary>
        /// <param name="destDeptId"></param>
        /// <param name="channel">1 : Dept Stock Out , 2 : Dept Stock In</param>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        public void InformMessage(long destDeptId,int channel, bool isError, string message)
        {
            _callbackSubStockList.ForEach(
                  delegate(IDepartmentStockOutCallback callback)
                  {
                      try
                      {
                          callback.NotifyInformMessage(destDeptId,channel,isError,message);
                      }
                      catch (Exception)
                      {

                      }
                  }); 
        }

        public void InformDepartmentStockOutSuccess(long sourceDeptId, long destDeptId, long deptStockId)
        {
            ServerUtility.Log(logger, sourceDeptId + " xuat thanh cong xuong " + destDeptId);
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         ServerUtility.Log(logger, sourceDeptId + " dang cap nhat " + deptStockId);
                         callback.NotifyStockOutSuccess(sourceDeptId, destDeptId, deptStockId);
                     }
                     catch (Exception)
                     {

                     }
                 });
        }

        public void InformDepartmentStockOutFail(long sourceDeptId, long destDeptId, long deptStockId)
        {
            ServerUtility.Log(logger, sourceDeptId + " inform stock out success to " + destDeptId);
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyStockOutFail(sourceDeptId, destDeptId, deptStockId);
                     }
                     catch (Exception)
                     {

                     }
                 });
        }

        public void InformDepartmentStockInSuccess(Department department, DepartmentStockIn stockIn,long stockOutId)
        {
            ServerUtility.Log(logger, department.DepartmentId + " inform stock in back success. ");
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyStockInSuccess(department,stockIn,stockOutId);
                     }
                     catch (Exception)
                     {

                     }
                 });
        }

        public void InformMultiDepartmentStockInSuccess(Department department, DepartmentStockIn[] stockInList, long stockOutId)
        {
            ServerUtility.Log(logger, department.DepartmentId + " inform stock in back success. ");
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyMultiStockInSuccess(department, stockInList, stockOutId);
                     }
                     catch (Exception)
                     {

                     }
                 });
        }

        public void InformDepartmentStockInFail(Department department, DepartmentStockIn stockIn, long stockOutId)
        {
            ServerUtility.Log(logger, department.DepartmentId + " inform stock in back success. ");
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyStockInFail(department, stockIn, stockOutId);
                     }
                     catch (Exception)
                     {

                     }
                 });
        }

        public void UpdateStockInBackFlag(Department department, DepartmentStockIn stockIn,long stockOutId)
        {
            ServerUtility.Log(logger, " Cap nhat co xuat hang o " + department.DepartmentId);
            _callbackList.ForEach(
                delegate(IDepartmentStockOutCallback callback)
                {
                    try
                    {
                        // update stock out flag in department
                        callback.NotifyUpdateStockOutFlag(department, stockIn,stockOutId);
                    }
                    catch (Exception)
                    {

                    }
                });
        }

        public void MakeDepartmentStockOut(Department department, DepartmentStockOut stockOut, DepartmentPrice price)
        {
            ServerUtility.Log(logger, " Xuat hang di " + department.DepartmentId );
            _callbackList.ForEach(
                delegate(IDepartmentStockOutCallback callback)
                    {
                        try
                        {
                            // dispatch stock-out to department
                            callback.NotifyNewDepartmentStockOut(department, stockOut, price);
                        }
                        catch (Exception)
                        {   
                            
                        }
                    });
            
        }
        
        public void MakeRawDepartmentStockOut(Department department, DepartmentStockOut stockOut, DepartmentPrice price)
        {

            DataAccessLayer dalSubStock = new DataAccessLayer(Properties.Settings.Default.SubStockDB);
            DataAccessLayer dalSalePoint = new DataAccessLayer(Properties.Settings.Default.SalePointDB);
            
            //DataAccessLayer dalSalePoint = new DataAccessLayer("achay");

            /*try
            {*/

            try
            {
                
                DepartmentStockIn stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
                // get max stock in id
                string deptStr = "";
                string extraZero = "";
                string startNum = "";

                if(department.DepartmentId > 999)
                {
                    deptStr = department.DepartmentId.ToString();
                    extraZero = "000";
                    startNum = "001";
                }
                else
                {
                    deptStr = string.Format("{0:000}", department.DepartmentId);
                    extraZero = "00000";
                    startNum = "00001";
                }
                
                string dateStr = DateTime.Now.ToString("yyMMdd");
                var selectMaxIdSQL = " select max(stock_in_id) from department_stock_in where stock_in_id > '" + dateStr + deptStr + extraZero + "'";
                
                ServerUtility.Log(logger, selectMaxIdSQL);
                //var maxId = dalSalePoint.GetSingleValue(selectMaxIdSQL);
                var maxId = dalSalePoint.GetSingleValue(selectMaxIdSQL);
                string stockInId = "";
                if(maxId == null || maxId.ToString() == string.Empty)
                {
                    stockInId = dateStr + deptStr + startNum; 
                }
                else
                {
                    stockInId = string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));                    
                }
                 


                // search in department_stock_in_history
                string selectHistory = " select stock_in_id from department_stock_in_history "
                                       + " where SOURCE_DEPARTMENT_ID = " + stockOut.DepartmentStockOutPK.DepartmentId
                                       + " and stock_out_id = " + stockOut.DepartmentStockOutPK.StockOutId;
                ServerUtility.Log(logger, selectHistory);
                var existStockInId = dalSalePoint.GetSingleValue(selectHistory);
                if (existStockInId == null || existStockInId.ToString() == string.Empty)
                {
                    string insertHistory = " insert into department_stock_in_history(stock_out_id,source_department_id,stock_in_id,dest_department_id,description,create_id,create_date,update_id,update_date ) values( "
                                           + stockOut.DepartmentStockOutPK.StockOutId + ","
                                           + stockOut.DepartmentStockOutPK.DepartmentId + ",'"
                                           + stockInId + "',"
                                           + stockIn.DepartmentStockInPK.DepartmentId + ",'"
                                           + " Xuat hang xuong cua hang " + "',"
                                           + "'admin'" + ","
                                           + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',"
                                           + "'admin'" + ","
                                           + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                    ServerUtility.Log(logger, insertHistory);
                    dalSalePoint.ExecuteQuery(insertHistory);
                }
                else
                {
                    InformMessage(stockOut.DepartmentStockOutPK.StockOutId,SUBTODEPT, true,
                    stockOut.DepartmentStockOutPK.StockOutId + " đã đến " + stockOut.OtherDepartmentId + " trước đó. Không thể truyền lại !");
                    return;
                }

                DoStockIn(dalSalePoint, department, stockIn, true);
                InformMessage(stockOut.DepartmentStockOutPK.StockOutId,SUBTODEPT, false,
                    stockOut.DepartmentStockOutPK.DepartmentId +  " đã truyền "+ stockOut.DepartmentStockOutPK.StockOutId +" xuống " + stockOut.OtherDepartmentId + " thành công !");
            }
            catch (Exception exception)
            {
                ServerUtility.Log(logger,exception.Message);
                ServerUtility.Log(logger, exception.StackTrace);
                InformMessage(stockOut.DepartmentStockOutPK.StockOutId,SUBTODEPT, true,
                    stockOut.DepartmentStockOutPK.DepartmentId + " đã truyền " + stockOut.DepartmentStockOutPK.StockOutId + " xuống " + stockOut.OtherDepartmentId + " thất bại !");
            }
            
        }

        

        public void MakeMultiDepartmentStockOut(Department department, DepartmentStockOut[] stockOutList, DepartmentPrice price)
        {
            ServerUtility.Log(logger, " Xuat hang di " + department.DepartmentId);
            _callbackList.ForEach(
                delegate(IDepartmentStockOutCallback callback)
                {
                    try
                    {
                        // dispatch stock-out to department
                        callback.NotifyNewMultiDepartmentStockOut(department, stockOutList, price);
                    }
                    catch (Exception)
                    {

                    }
                });
        }

        public void MakeDepartmentStockIn(Department department, DepartmentStockIn stockOut)
        {
            ServerUtility.Log(logger, " Stock-in dispatching from " + department.DepartmentId);
            _callbackList.ForEach(
               delegate(IDepartmentStockOutCallback callback)
               {
                   try
                   {
                       callback.NotifyNewDepartmentStockIn(department, stockOut);
                   }
                   catch (Exception)
                   {

                   }
               });
        }

        public void MakeRawDepartmentStockIn(Department department, DepartmentStockIn stockIn)
        {
            DataAccessLayer dalSubStock = new DataAccessLayer(Properties.Settings.Default.SubStockDB);
            DataAccessLayer dalSalePoint = new DataAccessLayer(Properties.Settings.Default.SalePointDB);

            try
            {
                DepartmentStockOut stockOut = new FastDepartmentStockOutMapper().Convert(stockIn);
                stockOut.DepartmentStockOutPK = new DepartmentStockOutPK();
                // cheat for stock in back to substock
                stockOut.DepartmentStockOutPK.DepartmentId = stockIn.DepartmentStockInPK.DepartmentId;
                Department subStockDept = new Department
                {
                    DepartmentId = stockIn.DepartmentStockInPK.DepartmentId
                };

                DoStockOut(dalSalePoint, department, stockOut, false);
                DoStockIn(dalSubStock, subStockDept, stockIn, false);
                
                InformMessage(subStockDept.DepartmentId, DEPTTOSUB, false, 
                    subStockDept.DepartmentId + " lấy hàng từ " + 
                    department.DepartmentId + " thành công !");
            }
            catch (Exception exception)
            {
                ServerUtility.Log(logger,exception.Message);
                ServerUtility.Log(logger,exception.StackTrace);
                InformMessage(stockIn.DepartmentStockInPK.DepartmentId,DEPTTOSUB,true,exception.Message);
            }
        }

        public void ExitDistributingGroup(Department department)
        {
            ServerUtility.Log(logger, department.DepartmentId + " quitting distributing group. ");
            // Unsubscribe the guest from the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();

            if (_callbackList.Contains(guest))
            {
                ServerUtility.Log(logger, department.DepartmentId + " quit normal group. ");
                _callbackList.Remove(guest);
            }
            if (_callbackSubStockList.Contains(guest))
            {
                ServerUtility.Log(logger, department.DepartmentId + " quit substock group. ");
                _callbackSubStockList.Remove(guest);
            }
        }

        private bool DoStockIn(DataAccessLayer dal, Department department, DepartmentStockIn stockIn, bool NeedUpdateMasterData)
        {
            string deptStr = "";
            string extraZero = "";
            string startNum = "";
            if (department.DepartmentId > 999)
            {
                deptStr = department.DepartmentId.ToString();
                extraZero = "000";
                startNum = "001";
            }
            else
            {
                deptStr = string.Format("{0:000}", department.DepartmentId);
                extraZero = "00000";
                startNum = "00001";
            }
            
            string dateStr = DateTime.Now.ToString("yyMMdd");
            var selectMaxIdSQL = " select max(stock_in_id) from department_stock_in where stock_in_id > '" + dateStr + deptStr + extraZero + "'";
            
            ServerUtility.Log(logger, selectMaxIdSQL);
            var maxId = dal.GetSingleValue(selectMaxIdSQL);
            string stockInId = "";
            if(maxId == null || maxId.ToString() == string.Empty)
            {
                stockInId = dateStr + deptStr + startNum; 
            }
            else
            {
                stockInId = string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));
            }
            
            string insertStockIn = " insert into department_stock_in(department_id,stock_in_id,stock_in_date,create_date,create_id,update_date,update_id,del_flg,exclusive_key) " +
                                   " values(" +
                                   department.DepartmentId + "," +
                                   "'" + stockInId + "'," +
                                   "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                   "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                   "'admin'," +
                                   "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                   "'admin'," +
                                   "0," +
                                   "1)";
            // insert department-stock-in
            ServerUtility.Log(logger, insertStockIn);
            dal.ExecuteQuery(insertStockIn);
            // insert department-stock-in-details
            foreach (DepartmentStockInDetail inDetail in stockIn.DepartmentStockInDetails)
            {
                if(NeedUpdateMasterData)
                {
                    ProcessStockInDetail(inDetail, dal);    
                }

                // insert department-stock-in-detail
                string insertStockInDetail =
                    "insert into department_stock_in_detail(department_id,stock_in_id,product_id,product_master_id,quantity, price, del_flg,create_id,create_date,update_id,update_date) " +
                    " values(" +
                    department.DepartmentId + ",'" +
                    stockInId + "','" +
                    inDetail.Product.ProductId + "','" +
                    inDetail.Product.ProductMaster.ProductMasterId + "'," +
                    inDetail.Quantity + "," +
                    inDetail.Price + "," +
                    "0," +
                    "'admin'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                    "'admin'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                ServerUtility.Log(logger, insertStockInDetail);
                dal.ExecuteQuery(insertStockInDetail);
                // insert department-stock
                //string insertStock = "insert into stock(stock_id,product_id,product_master_id,quantity,create_date,good_quantity,create_id,del_flg) values(18854,'001419317H01','0000000014193',1,'2009-07-27 00:00:00',1,'admin',0)";
                // stock
                string reqDeptStock = "Select product_id from department_stock where product_id ='" +
                                      inDetail.Product.ProductId + "'";
                ServerUtility.Log(logger, reqDeptStock);
                var id = dal.GetSingleValue(reqDeptStock);
                if (id == null || id.ToString() == string.Empty)
                {
                    string insertStock = "insert into department_stock(department_id, product_id, product_master_id, quantity, good_quantity, create_id,create_date,update_id,update_date) values ("
                                         + department.DepartmentId + ", '"
                                         + inDetail.Product.ProductId + "', '"
                                         + inDetail.Product.ProductMaster.ProductMasterId + "', "
                                         + inDetail.Quantity + ", "
                                         + inDetail.Quantity + ", "
                                         + "'admin'," + "'"
                                         + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',"
                                         + "'admin'," + "'"
                                         + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    ServerUtility.Log(logger, insertStock);
                    dal.ExecuteQuery(insertStock);
                }
                else
                {
                    string updateStock = " update department_stock "
                                         + " set quantity = quantity + " + inDetail.Quantity + " , "
                                         + " good_quantity = good_quantity + " + inDetail.Quantity + " "
                                         + " where product_id = '" + inDetail.Product.ProductId + "' "
                                         + " and department_id = " + department.DepartmentId;
                    ServerUtility.Log(logger, updateStock);
                    dal.ExecuteQuery(updateStock);
                }

            }
            return true;
        }
        private bool DoStockOut(DataAccessLayer dal, Department department,DepartmentStockOut stockOut,bool negativeStock)
        {

            // check stock before insert
            foreach (DepartmentStockOutDetail outDetail in stockOut.DepartmentStockOutDetails)
            {
                // stock
                var id = dal.GetSingleValue("Select product_id from department_stock where product_id ='" + outDetail.Product.ProductId+"'");
                if (id == null || id.ToString() == string.Empty)
                {
                    // ERROR
                    throw new BusinessException("Khong co ma hang " + outDetail.Product.ProductId + "trong kho cua hang !");
                }
                else
                {
                    if (!negativeStock)
                    {
                        var varQty =
                            dal.GetSingleValue("Select good_quantity from department_stock where product_id ='" +
                                               outDetail.Product.ProductId + "'");
                        long goodQty = 0;
                        Int64.TryParse(varQty.ToString(), out goodQty);
                        long remainGoodQty = goodQty - outDetail.Quantity;
                        if (remainGoodQty < 0)
                        {
                            throw new BusinessException(outDetail.Product.ProductId +
                                                        " không còn đủ số lượng trong kho.");
                        }
                    }
                }

            }
            // get max stock in id

            var selectMaxIdSQL = " select max(stock_out_id) from department_stock_out";
            var maxId = dal.GetSingleValue(selectMaxIdSQL);
            var stockOutId = (maxId == null || maxId.ToString() == string.Empty ) ? 1 : Int64.Parse(maxId.ToString()) + 1;

            var selectMaxDetIdSQL = " select max(stock_out_detail_id) from department_stock_out_detail";
            var maxDetId = dal.GetSingleValue(selectMaxDetIdSQL);
            var stockOutDetId = (maxDetId == null || maxDetId.ToString() == string.Empty) ? 1 : Int64.Parse(maxDetId.ToString()) + 1;

            string insertStockOut = " insert into department_stock_out(department_id," +
                                   "stock_out_id," +
                                   "stock_out_date," +
                                   "description," +
                                   "defect_status_id," +
                                   "confirm_flg," +
                                   "other_department_id," +
                                   "create_date," +
                                   "create_id," +
                                   "update_date," +
                                   "update_id," +
                                   "del_flg," +
                                   "exclusive_key) " +
                                   " values(" + // values
                                   department.DepartmentId + "," +
                                   "'" + stockOutId + "'," +
                                   "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                   "' Xuat hang ve kho phu ' " + "," +
                                   7 + "," +
                                   0 + "," +
                                   stockOut.DepartmentStockOutPK.DepartmentId + "," +
                                   "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                   "'admin'," +
                                   "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                   "'admin'," +
                                   "0," +
                                   "1)";
            // insert department-stock-in
            ServerUtility.Log(logger,insertStockOut);
            dal.ExecuteQuery(insertStockOut);
            // insert department-stock-in-details
            foreach (DepartmentStockOutDetail outDetail in stockOut.DepartmentStockOutDetails)
            {
                //ProcessStockInDetail(inDetail, dalSalePoint);

                // insert department-stock-in-detail
                string insertStockOutDetail =
                    "insert into department_stock_out_detail(stock_out_detail_id," +
                    "department_id," +
                    "stock_out_id," +
                    "product_id," +
                    "product_master_id," +
                    "quantity," +
                    " good_quantity," +
                    " del_flg," +
                    "create_id," +
                    "create_date," +
                    "update_id," +
                    "update_date) " +
                    " values(" + // values
                    stockOutDetId + "," +
                    department.DepartmentId + "," +
                    stockOutId + ",'" +
                    outDetail.Product.ProductId + "','" +
                    outDetail.Product.ProductMaster.ProductMasterId + "'," +
                    outDetail.Quantity + "," +
                    outDetail.Quantity + "," +
                    "0," +
                    "'admin'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                    "'admin'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                ServerUtility.Log(logger,insertStockOutDetail);
                dal.ExecuteQuery(insertStockOutDetail);
                stockOutDetId += 1;
                // insert department-stock
                //string insertStock = "insert into stock(stock_id,product_id,product_master_id,quantity,create_date,good_quantity,create_id,del_flg) values(18854,'001419317H01','0000000014193',1,'2009-07-27 00:00:00',1,'admin',0)";
                // stock
                dal.ExecuteQuery(" update department_stock "
                              + " set quantity = quantity - " + outDetail.Quantity + " , "
                              + " good_quantity = good_quantity - " + outDetail.Quantity + " "
                              + " where product_id = '" + outDetail.Product.ProductId + "' "
                              + " and department_id = " + department.DepartmentId);

            }

            return true;
        }

        private void ProcessStockInDetail(DepartmentStockInDetail detail, DataAccessLayer dal)
        {

            // insert type name
            string typeName = detail.Product.ProductMaster.ProductType.TypeName;
            object id = dal.GetSingleValue("Select type_id from product_type where type_name = '" + typeName + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                id = dal.GetSingleValue("Select max(type_id) from product_type ");
                if (id == null || id.ToString() == string.Empty)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(id.ToString()) + 1;
                }
                dal.ExecuteQuery("insert into product_type(type_id, type_name) values (" + id.ToString() + ", N'" + typeName.Replace("'", "''") + "')");
            }

            // insert color name
            string colorName = detail.Product.ProductMaster.ProductColor.ColorName;
            id = dal.GetSingleValue("Select color_id from product_color where color_name = '" + colorName.Replace("'", "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {

                id = dal.GetSingleValue("Select max(color_id) from product_color ");
                if (id == null || id.ToString() == string.Empty)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(id.ToString()) + 1;
                }
                dal.ExecuteQuery("insert into product_color(Color_id, Color_name) values (" + id.ToString() + ", N'" + colorName.Replace("'", "''") + "')");
            }

            // insert size name
            string sizeName = detail.Product.ProductMaster.ProductSize.SizeName;
            id = dal.GetSingleValue("Select size_id from product_size where size_name = '" + sizeName.Replace("'", "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                id = dal.GetSingleValue("Select max(size_id) from product_size ");
                if (id == null || id.ToString() == string.Empty)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(id.ToString()) + 1;
                }
                dal.ExecuteQuery("insert into product_size(size_id, size_name) values (" + id.ToString() + ", N'" + sizeName.Replace("'", "''") + "')");

            }


            // insert product master
            string productMasterId = detail.Product.ProductMaster.ProductMasterId;
            id = dal.GetSingleValue("Select product_master_id from product_master where product_master_id = '" + productMasterId + "'");

            if (id == null || id.ToString() == string.Empty)
            {
                id = dal.GetSingleValue("Select max(product_master_id) from product_master ");
                if (id == null || id.ToString() == string.Empty)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(id.ToString()) + 1;
                }
                dal.ExecuteQuery("insert into product_master(product_master_id, product_name, size_id, color_id, type_id, create_date,description) values ('"
                    + productMasterId
                    + "', '" + detail.Product.ProductMaster.ProductName.Replace("'", "''")
                    + "', " + detail.Product.ProductMaster.ProductSize.SizeId + ", "
                    + detail.Product.ProductMaster.ProductColor.ColorId + ", "
                    + detail.Product.ProductMaster.ProductType.TypeId + ", '"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                    + detail.Product.ProductMaster.Description + "')");

            }


            // product
            string productId = detail.Product.ProductId;
            id = dal.GetSingleValue("Select product_id from product where product_id = '" + productId + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                dal.ExecuteQuery("insert into product(product_id, product_master_id, quantity, price, create_date) values ('"
                + productId
                + "', '" + productMasterId
                + "', " + detail.Quantity + ", " + detail.Price + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            }


            // dept-price
            id = dal.GetSingleValue("Select product_master_id from department_price where product_master_id = '" + productMasterId + "'");
            // chi cap nhat gia le, khong cap nhat gia ban si
            if (id == null || id.ToString() == string.Empty)
            {

                dal.ExecuteQuery("insert into department_price(department_id, product_master_id, price,  whole_sale_price) values ("
                    + "0, '" + productMasterId + "', " + detail.Price + ", " + 0 + ")");
            }
            else
            {
                dal.ExecuteQuery("update department_price set price = " + detail.Price
                    + " where  product_master_id = '" + productMasterId + "'");
            }

        }
    }
}
