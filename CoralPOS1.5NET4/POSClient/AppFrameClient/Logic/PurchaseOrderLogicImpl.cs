using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Utility;
using AppFrameClient.Common;
using AppFrameClient.View;
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
        public IProductDAO ProductDAO { get; set; }
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
            string deptId = string.Format("{0:000}", CurrentDepartment.Get().DepartmentId);
            object maxId = PurchaseOrderDAO.SelectSpecificType(null, Projections.Max("PurchaseOrderPK.PurchaseOrderId"));
            string purchaseOrderId = "000000000001";
            if (maxId != null)
            {
                purchaseOrderId = string.Format("{0:000000000000000}", Int64.Parse(maxId.ToString()) + 1);
            }
            else
            {
                long tempId = ClientSetting.MaxPOId;
                if(tempId ==1)
                {
                    purchaseOrderId = deptId + "000000000001";    
                }
                else
                {
                    purchaseOrderId = string.Format("{0:000000000000000}", Int64.Parse(tempId.ToString()) + 1);
                }
                
            }
            ClientSetting.MaxPOId = Int64.Parse(purchaseOrderId);
            ClientSetting.Save();
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

            PurchaseOrderPK purchaseOrderPk = new PurchaseOrderPK { DepartmentId = CurrentDepartment.Get().DepartmentId, PurchaseOrderId = purchaseOrderId };
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

            bool isReturnOrder = IsReturnOrder(purchaseOrderPk.PurchaseOrderId,data.PurchaseOrderDetails);

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
            IDictionary<string,long> stockList = new Dictionary<string,long>();
            IDictionary<string, Product> productList = new Dictionary<string, Product>();
            foreach (PurchaseOrderDetail detail in data.PurchaseOrderDetails)
            {
                PurchaseOrderDetailPK currDetailKey = detail.PurchaseOrderDetailPK;
                // nếu là hàng trả đổi có xác định hóa đơn
                if(     detail.PurchaseOrder!= null
                    && currDetailKey != null
                    && !CheckUtility.IsNullOrEmpty(currDetailKey.PurchaseOrderId)
                    && !purchaseOrderId.Equals(detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId)
                    )
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
                    if(detail.Price < 0)
                    {
                        po.Price = 0 - detail.Price;    
                    }
                    else
                    {
                        po.Price = detail.Price;    
                    }

                    po.ReturnDate = DateTime.Now;
                    po.Product = detail.Product;

                    // hàng trả không xác định
                    if (detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId.Equals("000"))
                    {
                        po.ReturnPoPK.PurchaseOrderId = undefinedPOId;
                        po.ReturnPoPK.PurchaseOrderDetailId = undefinedPODetailId++;
                        
                    }
                    else // hàng trả có xác định
                    {
                        // xác định số hàng đã trả so với hóa đơn gốc.
                        long originAmount = FindOriginAmount(detail);
                        if (originAmount == 0)
                        {
                            throw new BusinessException("Có lỗi ở hoá đơn gốc, đề nghị kiểm tra");
                        }
                        long returnedQuantity = (long) ReturnPoDAO.FindQuantityById(poPK);
                        long currentReturnQuantity = returnedQuantity + po.Quantity;
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

                        bool hasPrdFound = false;
                        foreach (string productId in stockList.Keys)
                        {
                            if (productId.Equals(detail.Product.ProductId))
                            {
                                long qty = stockList[productId];
                                qty = qty + detail.Quantity;
                                stockList[productId] = qty;
                                hasPrdFound = true;
                                break;
                            }
                        }
                        if (!hasPrdFound)
                        {
                            stockList.Add(detail.Product.ProductId,detail.Quantity);
                            productList.Add(detail.Product.ProductId,detail.Product);
                        }
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
                
                bool hasFound = false;
                foreach (string productId in stockList.Keys)
                {
                   if(productId.Equals(detail.Product.ProductId))
                   {
                       long qty = stockList[productId];
                       qty = qty - detail.Quantity;
                       stockList[productId] = qty;
                       hasFound = true;
                       break;
                   }
                }
                if(!hasFound)
                {
                    // add update quantity under a negative number
                    stockList.Add(detail.Product.ProductId,0-detail.Quantity);
                    productList.Add(detail.Product.ProductId, detail.Product);
                }
                
                detail.CreateDate = DateTime.Now;
                detail.UpdateDate = DateTime.Now;
                detail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                var purchaseOrderDetailPk = new PurchaseOrderDetailPK{DepartmentId = CurrentDepartment.Get().DepartmentId, PurchaseOrderId = purchaseOrderId, PurchaseOrderDetailId = id++};
                detail.PurchaseOrderDetailPK = purchaseOrderDetailPk;
                detail.PurchaseOrder = data;
                PurchaseOrderDetailDAO.Add(detail);

                // create Receipt.
            }

            // if departmentstock needs update
            if(stockList.Keys.Count > 0)
            {
                IList departmentStockViewList = new ArrayList();
                // get stock by product master
                foreach (string productId in stockList.Keys)
                {
                    if(!InDepartmentStockViewList(departmentStockViewList,productId))
                    {
                        Product searchProduct = productList[productId];
                        ObjectCriteria pmCrit = new ObjectCriteria();
                        pmCrit.AddEqCriteria("ProductMaster.ProductMasterId", searchProduct.ProductMaster.ProductMasterId);
                        IList list = ProductDAO.FindAll(pmCrit);
                        
                        IList searchPrdIds = new ArrayList();
                        foreach (Product product in list)
                        {
                            searchPrdIds.Add(product.ProductId);    
                        }
                        ObjectCriteria crit = new ObjectCriteria();
                        crit.AddSearchInCriteria("DepartmentStockPK.ProductId", searchPrdIds);
                        IList deptStockList = DepartmentStockDAO.FindAll(crit);

                        DepartmentStockView stockView = new DepartmentStockView();
                        stockView.ProductMaster = searchProduct.ProductMaster;
                        ((ArrayList)deptStockList).Sort();
                        stockView.DepartmentStocks = deptStockList;
                        departmentStockViewList.Add(stockView);
                    }
                }

                bool allowTempNegativeSelling = false;
                // slide id selling
                foreach (string productId in stockList.Keys)
                {
                    
                    if(InDepartmentStockViewList(departmentStockViewList,productId))
                    {
                        
                        // get origin product id and minus first
                        DepartmentStockView view = GetDepartmentStockViewList(departmentStockViewList, productId);
                        long updateQty = stockList[productId];
                        long originUpdateQty = updateQty;
                        DepartmentStock departmentStock = GetDepartmentStockFromView(view, productId);
                        // if stock has been negative
                        if (departmentStock.GoodQuantity <= 0)
                        {
                            // FIX : Using negative update setting
                            // accept negative quantity and process later
                            if (ClientSetting.NegativeSelling)
                            {
                                departmentStock.GoodQuantity += updateQty;
                                departmentStock.Quantity += updateQty;
                                continue;
                            }
                            
                            // END FIX
                        }
                        else // do minusing to stock
                        {
                            updateQty = departmentStock.GoodQuantity + updateQty;
                        }

                        // if not enough quantity and still remains update-needing quantity
                        if(updateQty < 0)
                        {
                            // empty the origin product id in stock
                            departmentStock.Quantity -= departmentStock.GoodQuantity;
                            departmentStock.GoodQuantity = 0;
                            // continue do minusing on other product id in stock;
                            foreach (DepartmentStock otherStock in view.DepartmentStocks)
                            {
                                if(otherStock.DepartmentStockPK.ProductId.Equals(departmentStock.DepartmentStockPK.ProductId))
                                {
                                    continue;
                                }
                                long backupUpdateQty = updateQty;
                                updateQty = otherStock.GoodQuantity + updateQty;
                                if(updateQty < 0)
                                {
                                    otherStock.Quantity -= otherStock.GoodQuantity;
                                    otherStock.GoodQuantity = 0;
                                }
                                else
                                {
                                    otherStock.GoodQuantity += backupUpdateQty;
                                    otherStock.Quantity += backupUpdateQty;
                                    break;
                                }
                            }
                            // FIX : Do not accept negative quantity
                            // if still remain, we accept the negative quantity
                            if(updateQty < 0)
                            {
                                
                                if (!ClientSetting.NegativeSelling)
                                {
                                    throw new BusinessException("Mặt hàng " +
                                                                departmentStock.Product.ProductMaster.ProductName +
                                                                " đã hết.");
                                }
                                else
                                {
                                    if (allowTempNegativeSelling == false)
                                    {
                                        // confirm before save
                                        DialogResult isConfirmed = System.Windows.Forms.DialogResult.Cancel;
                                        if (!ClientSetting.ConfirmByEmployeeId)
                                        {
                                            LoginForm loginForm =
                                                GlobalUtility.GetFormObject<LoginForm>(FormConstants.CONFIRM_LOGIN_VIEW);
                                            loginForm.ConfirmNegativeSelling = true;
                                            loginForm.StartPosition = FormStartPosition.CenterScreen;
                                            isConfirmed = loginForm.ShowDialog();
                                        }
                                        else
                                        {
                                            EmployeeCheckingForm employeeCheckingForm =
                                                GlobalUtility.GetFormObject<EmployeeCheckingForm>(
                                                    FormConstants.EMPLOYEE_CHECKING_VIEW);
                                            employeeCheckingForm.StartPosition = FormStartPosition.CenterScreen;
                                            isConfirmed = employeeCheckingForm.ShowDialog();
                                        }
                                        if (isConfirmed != System.Windows.Forms.DialogResult.OK)
                                        {
                                            throw new BusinessException("Không xác nhận được nguoi gửi ....");
                                        }
                                        else
                                        {
                                            allowTempNegativeSelling = true;
                                        }
                                    }

                                    departmentStock.GoodQuantity += updateQty;
                                    departmentStock.Quantity += updateQty;    
                                }
                            }
                            // END FIX
                        }
                        else // enough quantity
                        {
                            departmentStock.GoodQuantity += originUpdateQty;
                            departmentStock.Quantity += originUpdateQty;
                        }
                    }
                }

                // update stock
                foreach (DepartmentStockView departmentStockView in departmentStockViewList)
                {
                    foreach (DepartmentStock stock in departmentStockView.DepartmentStocks)
                    {
                        DepartmentStockDAO.Update(stock);
                    }
                }
            }

            return data;
        }

        private DepartmentStock GetDepartmentStockFromView(DepartmentStockView view, string id)
        {
            foreach (DepartmentStock stock in view.DepartmentStocks)
            {
                if(stock.DepartmentStockPK.ProductId.Equals(id))
                {
                    return stock;
                }
            }
            return null;
        }

        private void SortByProductId(IList temps)
        {
            DepartmentStock stockTemp = null;
            for (int i = 0; i < temps.Count - 1; i++)
            {
                DepartmentStock stockTemp1 = (DepartmentStock)temps[i];
                long prdId1 = ConvertToLong(stockTemp1.Product.ProductId);
                for (int j = i + 1; j < temps.Count; j++)
                {
                    DepartmentStock stockTemp2 = (DepartmentStock)temps[j];
                    long prdId2 = ConvertToLong(stockTemp2.Product.ProductId);
                    if (prdId1 > prdId2)
                    {
                        stockTemp = stockTemp1;
                        stockTemp1 = stockTemp2;
                        stockTemp2 = stockTemp;
                    }
                }

            }
        }

        private long ConvertToLong(string id)
        {
            long retLong = 0;
            try
            {
                retLong = Int64.Parse(id);
            }
            catch (Exception)
            {
                // new barcode
                string block = id.Substring(7);
                DateTime blockDate = StringUtility.ConvertFourCharToDate(block.Substring(0, 3));
                string blockId = string.Format("{0:000000}",Int32.Parse(block.Substring(3)));
                retLong = Int64.Parse(blockDate.ToString("yyMMdd") + blockId);
            }
            return retLong;
        }

        private bool InDepartmentStockViewList(IList list, string id)
        {
            foreach (DepartmentStockView stockView in list)
            {
                foreach (DepartmentStock stock in stockView.DepartmentStocks)
                {
                    if(stock.DepartmentStockPK.ProductId.Equals(id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private DepartmentStockView GetDepartmentStockViewList(IList list, string id)
        {
            foreach (DepartmentStockView stockView in list)
            {
                foreach (DepartmentStock stock in stockView.DepartmentStocks)
                {
                    if (stock.DepartmentStockPK.ProductId.Equals(id))
                    {
                        return stockView;
                    }
                }
            }
            return null;
        }

        private bool IsReturnOrder(string currPOId,IList details)
        {
            long returnCount = 0;
            foreach (PurchaseOrderDetail detail in details)
            {
                if(detail.PurchaseOrder!= null
                   && detail.PurchaseOrder.PurchaseOrderPK!=null
                   && !string.IsNullOrEmpty(detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId)
                   && !currPOId.Equals(detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId) 
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