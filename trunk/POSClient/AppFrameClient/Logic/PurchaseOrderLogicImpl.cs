using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Exceptions;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PurchaseOrderLogicImpl : IPurchaseOrderLogic
    {
        private static readonly string FIND_STOCK_SQL = "SELECT s, price FROM DepartmentStock s, Product p, ProductMaster pm, DepartmentPrice price  WHERE s.DepartmentStockPK.ProductId = p.ProductId  AND p.ProductMaster.ProductMasterId = pm.ProductMasterId  AND pm.ProductMasterId = price.DepartmentPricePK.ProductMasterId ";
        public IPurchaseOrderDAO PurchaseOrderDAO { get; set; }
        public IDepartmentStockDAO DepartmentStockDAO { get; set; }
        public IPurchaseOrderDetailDAO PurchaseOrderDetailDAO { get; set; }
        public IDepartmentStockInDetailDAO DepartmentStockInDetailDao { get;set; }
        public IReturnPoDAO ReturnPoDAO {get;set;}

        public ICustomersDAO CustomerDAO { get; set; }

        /// <summary>
        /// Find PurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrder</param>
        /// <returns></returns>
        public PurchaseOrder FindById(object id)
        {
            return PurchaseOrderDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PurchaseOrder Add(PurchaseOrder data)
        {
            /*var maxId = PurchaseOrderDAO.SelectSpecificType(null, Projections.Max("PurchaseOrderPK.PurchaseOrderId"));
            var purchaseOrderId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);*/
            string deptId = string.Format("{0:000}", CurrentDepartment.Get().DepartmentId);
            object maxId = PurchaseOrderDAO.SelectSpecificType(null, Projections.Max("PurchaseOrderPK.PurchaseOrderId"));
            string purchaseOrderId = "000000000001";
            if (maxId != null)
            {
                purchaseOrderId = string.Format("{0:000000000000000}", Int64.Parse(maxId.ToString()) + 1);
            }
            else
            {
                purchaseOrderId = deptId + "000000000001";
            }

            object maxReceptId = ReceiptDAO.SelectSpecificType(null, Projections.Max("ReceiptPK.ReceiptId"));
            string receiptId = "000000000001";
            if (maxReceptId != null)
            {
                receiptId = string.Format("{0:000000000000000}", Int64.Parse(maxReceptId.ToString()) + 1);
            }
            else
            {
                receiptId = deptId + "000000000001";
            }
            /*if(data.Receipts!= null && data.Receipts.Count > 0)
            {
                foreach (Receipt receipt in data.Receipts)
                {
                    receipt.ReceiptPK.ReceiptId = receiptId;
                    ReceiptDAO.Add(receipt);

                    // increase receiptId
                    receiptId = string.Format("{0:000000000000000}", Int64.Parse(receiptId.ToString()) + 1);
                }
            }*/
            /*var purchaseOrderId =
            if(purchaseOrderId==null)
            {
                string shortDateTime = DateTime.Now.ToString("yyMMdd");
                long departmentId = CurrentDepartment.Get().DepartmentId;
                purchaseOrderId = departmentId.ToString().PadLeft(3,'0') + shortDateTime + "0001";
            }
            else
            {
                // add max 
                string purchaseCount = purchaseOrderId.Substring(purchaseOrderId.Length - 4);
                int nextPurchaseOrderIdNumber = int.Parse(purchaseCount) + 1;
                string nextPurchaseOrderId = nextPurchaseOrderIdNumber.ToString().PadLeft(4, '0');
                purchaseOrderId = purchaseOrderId.Substring(0, purchaseOrderId.Length - 4) + nextPurchaseOrderId;
            }*/
            var purchaseOrderPk = new PurchaseOrderPK { DepartmentId = CurrentDepartment.Get().DepartmentId, PurchaseOrderId = purchaseOrderId};
            data.PurchaseOrderPK = purchaseOrderPk;
            data.UpdateDate = DateTime.Now;
            data.CreateDate = DateTime.Now;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            // add description
            string description = "";
            foreach (PurchaseOrderDetail detail in data.PurchaseOrderDetails)
            {
                description += detail.ProductMaster.ProductName+ " "+ System.Environment.NewLine;                                
            }
            data.PurchaseOrderDescription = description;

            // save customer
            Customer customer = data.Customer;

            bool isReturnOrder = IsReturnOrder(data.PurchaseOrderDetails);
            if(!isReturnOrder)
            {
                PurchaseOrderDAO.Add(data);    
            }
            
            
            long id = 1;
            // create PurchaseOrderId for Undefined Purchase Order 
            string undefinedPOId = null;
            long undefinedPODetailId = 1;
            foreach (PurchaseOrderDetail detail in data.PurchaseOrderDetails)
            {
                if (detail.PurchaseOrder != null
                   && detail.PurchaseOrder.PurchaseOrderPK!=null
                   && !string.IsNullOrEmpty(detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId)
                   && detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId.Equals("000"))
                {
                    undefinedPOId = deptId + "NA" + DateTime.Now.ToString("yyMMddHHmmss");
                    break;
                }
            }            

            foreach (PurchaseOrderDetail detail in data.PurchaseOrderDetails)
            {
                // nếu là hàng trả đổi
                if(     detail.PurchaseOrder!= null
                    && detail.PurchaseOrderDetailPK!= null   
                    && !string.IsNullOrEmpty(detail.PurchaseOrderDetailPK.PurchaseOrderId))
                {
                    // Hàng trả đổi
                    ReturnPo po = new ReturnPo();
                    po.CreateDate = DateTime.Now;
                    po.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    po.UpdateDate = DateTime.Now;
                    po.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    ReturnPoPK poPK = new ReturnPoPK
                    {
                        DepartmentId = detail.PurchaseOrderDetailPK.DepartmentId,
                        PurchaseOrderId =
                            detail.PurchaseOrderDetailPK.PurchaseOrderId,
                        PurchaseOrderDetailId =
                            detail.PurchaseOrderDetailPK.PurchaseOrderDetailId,
                        CreateDate = DateTime.Now

                    };
                    po.ReturnPoPK = poPK;
                    po.Quantity = detail.Quantity;
                    po.ReturnDate = DateTime.Now;
                    po.Product = detail.Product;
                    if (detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId.Equals("000"))
                    {
                        po.ReturnPoPK.PurchaseOrderId = undefinedPOId;
                        po.ReturnPoPK.PurchaseOrderDetailId = undefinedPODetailId++;
                    }
                    else
                    {


                        long originAmount = FindOriginAmount(detail);
                        if (originAmount == 0)
                        {
                            throw new BusinessException("Có lỗi ở hoá đơn gốc, đề nghị kiểm tra");
                        }
                        long returnedQuantity = (long) ReturnPoDAO.FindQuantityById(poPK);
                        long currentReturnQuantity = returnedQuantity + +po.Quantity;
                        if (originAmount < currentReturnQuantity)
                        {
                            throw new BusinessException(
                                "Lỗi :" + detail.Product.ProductMaster.ProductName +
                                " .Tổng cộng :" + originAmount +
                                " .Đã trả : " + returnedQuantity +
                                " .Số lượng muốn trả: " + po.Quantity + " !");
                        }
                    }

                    ObjectCriteria stockCrit = new ObjectCriteria();
                    stockCrit.AddEqCriteria("DepartmentStockPK.ProductId", detail.Product.ProductId);
                    IList deptStockList = DepartmentStockDAO.FindAll(stockCrit);
                    if (deptStockList != null && deptStockList.Count > 0)
                    {

                        DepartmentStock deptStock = (DepartmentStock)deptStockList[0];
                        deptStock.GoodQuantity += po.Quantity;
                        deptStock.Quantity += po.Quantity;
                        DepartmentStockDAO.Update(deptStock);
                    }
                    else
                    {
                        throw new BusinessException("Không có mặt hàng này trong kho. Xin vui lòng kiểm tra dữ liệu");
                    }
                    if(!isReturnOrder)
                    {
                        po.NextPurchaseOrderId = purchaseOrderId;
                    }
                    ReturnPoDAO.Add(po);
                    // go to next detail
                    continue;
                }

                var sql = new StringBuilder(FIND_STOCK_SQL);
                // load the stock
                var criteria = new ObjectCriteria(true);
                criteria.AddEqCriteria("s.DelFlg", CommonConstants.DEL_FLG_NO)
                        .AddEqCriteria("s.DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId)
                        .AddEqCriteria("pm.ProductMasterId", detail.ProductMaster.ProductMasterId)
                        .AddEqCriteria("s.Product.ProductId",detail.Product.ProductId);
                foreach (SQLQueryCriteria crit in criteria.GetQueryCriteria())
                {
                    sql.Append(" AND ")
                       .Append(crit.PropertyName)
                       .Append(" ")
                       .Append(crit.SQLString)
                       .Append(" :")
                       .Append(crit.PropertyName)
                       .Append(" ");
                }
                sql.Append(" ORDER BY s.CreateDate ASC");
                IList departmentStock = DepartmentStockDAO.FindStockQuantityForPurchaseOrder(sql.ToString(), criteria);
                long soldQuantity = detail.Quantity;
                if(departmentStock == null)
                {
                    throw new BusinessException("Không có sản phẩm: " + detail.ProductMaster.ProductMasterId + " với mã vạch :" + detail.Product.ProductId);                                            
                }
                DepartmentStockSearchResult result = (DepartmentStockSearchResult)departmentStock[0];
                DepartmentStock stock = (DepartmentStock)result.DepartmentStock;
                /*foreach (DepartmentStock stock in departmentStock)
                {*/
                    // so du con lai
                    
                    // Neu hang trong kho it hon so luong ban
                    if (detail.Quantity > stock.GoodQuantity )
                    {
                        // strange 
                        throw new BusinessException("Số lượng trong kho không đáp ứng đủ số lượng bán cho sản phẩm: " + detail.ProductMaster.ProductMasterId);                        
                    }
                    // Neu xuat du hang
                    stock.GoodQuantity -= detail.Quantity;
                    stock.Quantity -= detail.Quantity;
                    DepartmentStockDAO.Update(stock);
                /*}*/
                

                /*ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("DelFlg", (long)0);
                objectCriteria.AddEqCriteria("DepartmentStockInDetailPK.ProductId", detail.Product.ProductId);
                objectCriteria.AddEqCriteria("DepartmentStockInDetailPK.DepartmentId",
                                             CurrentDepartment.Get().DepartmentId);
                objectCriteria.AddOrder("CreateDate", true);

                IList departmentStockInDetail = DepartmentStockInDetailDao.FindAll(objectCriteria);
                long soldQuantity = detail.Quantity;
                var updateStockList = new List<DepartmentStockInDetail>();
                foreach (DepartmentStockInDetail stock in departmentStockInDetail)
                {
                    // so du con lai
                    long available = stock.Quantity - stock.Sold;
                    
                    // Neu hang trong kho it hon so luong ban
                    if (soldQuantity > stock.Quantity - stock.Sold)
                    {
                        // Ban het ma vach hang da nhap
                        soldQuantity -= available;
                        // tang so ban bang so hang da ban het
                        stock.Sold = stock.Sold + available;
                        stock.UpdateDate = DateTime.Now;
                        updateStockList.Add(stock);
                    }
                    else  // hang con du trong kho
                    {
                        //available -= soldQuantity;
                        // tang so ban nhu binh thuong
                        stock.Sold = stock.Sold + soldQuantity;
                        soldQuantity = 0;
                        stock.UpdateDate = DateTime.Now;
                        updateStockList.Add(stock);
                    }
                    // Neu xuat du hang
                    if (soldQuantity == 0)  
                    {
                        break;
                    }
                }

                if (updateStockList.Count == 0 || soldQuantity > 0)
                {
                    // strange 
                    throw new BusinessException("Số lượng trong kho không đáp ứng đủ số lượng bán cho sản phẩm: " + detail.ProductMaster.ProductMasterId);
                }
                else
                {
                    foreach (DepartmentStockInDetail stock in updateStockList)
                    {
                        DepartmentStockInDetailDao.Update(stock);
                    }
                }*/
                detail.CreateDate = DateTime.Now;
                detail.UpdateDate = DateTime.Now;
                detail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                var purchaseOrderDetailPk = new PurchaseOrderDetailPK{DepartmentId = CurrentDepartment.Get().DepartmentId, PurchaseOrderId = purchaseOrderId, PurchaseOrderDetailId = id++};
                detail.PurchaseOrderDetailPK = purchaseOrderDetailPk;

                PurchaseOrderDetailDAO.Add(detail);

                // create Receipt.
            }

            return data;
        }

        private bool IsReturnOrder(IList details)
        {
            long returnCount = 0;
            foreach (PurchaseOrderDetail detail in details)
            {
                if(detail.PurchaseOrder!= null
                   && detail.PurchaseOrder.PurchaseOrderPK!=null
                   && !string.IsNullOrEmpty(detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId)
                    )
                {
                    returnCount += 1;
                }
            }
            return returnCount == details.Count;
        }

        private long FindOriginAmount(PurchaseOrderDetail detail)
        {
            PurchaseOrderDetail originDetail = PurchaseOrderDetailDAO.FindById(detail.PurchaseOrderDetailPK);
            if(originDetail!=null)
            {
                return originDetail.Quantity;
            }
            return 0;
        }


        protected IReceiptDAO ReceiptDAO
        {
            get; set;
        }

        /// <summary>
        /// Update PurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PurchaseOrder data)
        {
            PurchaseOrderDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PurchaseOrder data)
        {
            PurchaseOrderDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PurchaseOrderDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PurchaseOrderDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PurchaseOrderDAO.FindPaging(criteria);
        }
    }
}