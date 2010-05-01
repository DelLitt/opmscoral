using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class DepartmentPurchaseOrderLogic : IDepartmentPurchaseOrderLogic
    {
        private IDepartmentPurchaseOrderDao _innerDao;
        public IDepartmentPurchaseOrderDao DepartmentPurchaseOrderDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }

        public IProductDao ProductDao { get; set; }
        public IProductMasterDao ProductMasterDao { get; set; }
        public IDepartmentStockDao DepartmentStockDao { get; set; }
        public IExProductColorDao ProductColorDao { get; set; }
        public IExProductSizeDao ProductSizeDao { get; set; }
        public IMainPriceDao MainPriceDao { get; set; }
        public IDepartmentPurchaseOrderDetailDao DepartmentPurchaseOrderDetailDao { get; set; }

        public string FindNextId()
        {
            return (string) DepartmentPurchaseOrderDao.Execute(
                delegate(ISession session)
                {
                    var maxId = (from po in session.Linq<DepartmentPurchaseOrder>()
                                 select po.DepartmentPurchaseOrderPK.PurchaseOrderId).Max();
                    string nextId = string.IsNullOrEmpty(maxId) ? "1" : (Int64.Parse(maxId)+1).ToString();
                    return nextId;
                }
                                );
  
        }

        /// <summary>
        /// Find DepartmentPurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrder</param>
        /// <returns></returns>
        public DepartmentPurchaseOrder FindById(object id)
        {
            return DepartmentPurchaseOrderDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction()]
        public DepartmentPurchaseOrder Add(DepartmentPurchaseOrder data)
        {
            IList<DepartmentStock> needUpdateStocks = new List<DepartmentStock>();
            IList<Product> adhocProducts = new List<Product>();
            IList<DepartmentStock> adhocStocks = new List<DepartmentStock>();
            // process master
            
            // if has financial invoice 
            // if has not financial invoice

            // process details
            var details = data.DepartmentPurchaseOrderDetails;
            DepartmentPurchaseOrderDao.Execute(
                delegate(ISession session)
                    {
                        foreach (DepartmentPurchaseOrderDetail detail in details)
                        {
                            // 1:NORMAL CASE
                            if (detail.Product.AdhocCase == 0)
                            {
                                // select all stocks
                                var stockList = from stk in session.Linq<DepartmentStock>()
                                                where
                                                    stk.ProductMaster.ProductMasterId ==
                                                    detail.ProductMaster.ProductMasterId
                                                orderby stk.Product.ProductId
                                                select stk;
                                AddToList(needUpdateStocks, stockList.ToList());
                                // select stk correspond to product id
                                // find from founded stock
                                DepartmentStock deptStk = null;
                                deptStk = (from stk in needUpdateStocks
                                           where stk.Product.ProductId == detail.Product.ProductId
                                           select stk).FirstOrDefault();

                                // minus stock
                                if (detail.Quantity < 0 || deptStk.GoodQuantity >= detail.Quantity)
                                {
                                    deptStk.Quantity -= detail.Quantity;
                                    deptStk.GoodQuantity -= detail.Quantity;
                                    if (deptStk.HasChanges) deptStk.HasChanges = true;
                                    continue;
                                }
                                else // update relevant stock
                                {
                                    long quantity = detail.Quantity;
                                    quantity -= deptStk.GoodQuantity;
                                    deptStk.Quantity = 0;
                                    deptStk.GoodQuantity = 0;
                                    if (deptStk.HasChanges) deptStk.HasChanges = true;
                                    var otherStocks = from stk in needUpdateStocks
                                                      where
                                                          stk.ProductMaster.ProductMasterId.Equals(
                                                              detail.ProductMaster.ProductMasterId)
                                                          && !stk.Product.ProductId.Equals(detail.Product.ProductId)
                                                      orderby stk.Product.ProductId
                                                      select stk;
                                    foreach (DepartmentStock departmentStock in otherStocks)
                                    {
                                        if (departmentStock.GoodQuantity == 0) continue;
                                        if (departmentStock.GoodQuantity >= quantity)
                                        {
                                            departmentStock.GoodQuantity -= quantity;
                                            departmentStock.Quantity -= quantity;
                                            quantity = 0;
                                            if (deptStk.HasChanges) deptStk.HasChanges = true;
                                            break;
                                        }
                                        else
                                        {
                                            quantity -= deptStk.GoodQuantity;
                                            deptStk.Quantity = 0;
                                            deptStk.GoodQuantity = 0;
                                            if (deptStk.HasChanges) deptStk.HasChanges = true;
                                        }
                                    }
                                    if (quantity > 0)
                                        throw new ArgumentException("Available stock of " +
                                                                    detail.ProductMaster.ProductName +
                                                                    "does not enough for selling");
                                }
                            }
                            else // 2:ADHOC CASE
                            {
                                ObjectUtility.AddToList<Product>(adhocProducts,detail.Product,"ProductId");
                                var result = (from stk in session.Linq<DepartmentStock>()
                                             where stk.DepartmentStockPK.ProductId == detail.Product.ProductId
                                             select stk)
                                             .Union
                                             (from stk in adhocStocks
                                             where stk.DepartmentStockPK.ProductId == detail.Product.ProductId
                                             select stk);
                                if (result.Count() == 0)
                                {
                                    DepartmentStock adhocStock = new DepartmentStock
                                                                     {
                                                                         CreateDate = DateTime.Now,
                                                                         CreateId = "admin",
                                                                         UpdateDate = DateTime.Now,
                                                                         UpdateId = "admin",
                                                                         GoodQuantity = 0,
                                                                         Quantity = 0,
                                                                         DelFlg = 0,
                                                                         ExclusiveKey = 1
                                                                     };
                                    adhocStocks.Add(adhocStock);
                                }
                            }
                        }
                        return null;   
                    }  
                );

            // save adhoc
            foreach (var adhocProduct in adhocProducts)
            {
                ProductDao.Add(adhocProduct);
            }
            foreach (DepartmentStock adhocStock in adhocStocks)
            {
                DepartmentStockDao.Add(adhocStock);
            }
            // save master
            DepartmentPurchaseOrderDao.Add(data);
            // save detail
            foreach (DepartmentPurchaseOrderDetail departmentPurchaseOrderDetail in details)
            {
                DepartmentPurchaseOrderDetailDao.Add(departmentPurchaseOrderDetail);
            }
            // update stock
            foreach (DepartmentStock departmentStock in needUpdateStocks)
            {
                if(departmentStock.HasChanges)
                {
                    DepartmentStockDao.Update(departmentStock);
                }
            }
            // process print
            
            return data;
        }

        private void AddToList(IList<DepartmentStock> needUpdateStocks, IList<DepartmentStock> stockList)
        {
            foreach (DepartmentStock departmentStock in stockList)
            {
                if(!ProductIdExistInStockList(needUpdateStocks,departmentStock))
                    needUpdateStocks.Add(departmentStock);
            }
        }

        private bool ProductIdExistInStockList(IList<DepartmentStock> needUpdateStocks, DepartmentStock departmentStock)
        {
            var exist = from stk in needUpdateStocks
                        where stk.Product.ProductId.Equals(departmentStock.Product.ProductId)
                        select stk;
            return exist.Count() > 0;
        }

        private void AddOrReplace(IList<DepartmentStock> needUpdateStocks, DepartmentStock deptStk)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update DepartmentPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPurchaseOrder data)
        {
            DepartmentPurchaseOrderDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPurchaseOrder data)
        {
            DepartmentPurchaseOrderDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPurchaseOrderDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentPurchaseOrder> FindAll(ObjectCriteria<DepartmentPurchaseOrder> criteria)
        {
            return DepartmentPurchaseOrderDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrder> criteria)
        {
            return DepartmentPurchaseOrderDao.FindPaging(criteria);
        }

        public IEnumerable ProcessBarcode(string barCode)
        {
            
            MainPrice price;
            var product = ProductDao.FindById(barCode);
            if (product != null)
            {
                product.ProductMaster = ProductMasterDao.FindById(product.ProductMaster.ProductMasterId);
                // process sale actions
                price =
                    MainPriceDao.FindById(new MainPricePK
                                              {
                                                  DepartmentId = 0,
                                                  ProductMasterId = product.ProductMaster.ProductMasterId
                                              });

            }
            else
            {
                // check whether it is a valid barcode
                string productMasterId = string.Format("{0:0000000000000}", Int64.Parse(barCode.Substring(0, 7)));
                long colorId = Int64.Parse(barCode.Substring(7, 2));
                long sizeId = Int64.Parse(barCode.Substring(9, 2));
                var productMaster = ProductMasterDao.FindById(productMasterId);
                

                var color = ProductColorDao.FindById(colorId);
                var size = ProductSizeDao.FindById(sizeId);
                if (productMaster == null || color == null || size == null) throw new Exception("Invalid Barcode");

                Product exProduct = new Product
                                        {
                                            ProductId = string.Format("{0:0000000}",Int64.Parse(productMaster.ProductMasterId)) 
                                                         + string.Format("{0:00}",color.ColorId)
                                                         + string.Format("{0:00}", size.SizeId)
                                                         +"F",
                                            ProductColor = color,
                                            ProductSize = size,
                                            ProductMaster = productMaster,
                                            Barcode = barCode,
                                            AdhocCase = 1
                                        };
                product = exProduct;
                price =
                    MainPriceDao.FindById(new MainPricePK
                    {
                        DepartmentId = 0,
                        ProductMasterId = productMaster.ProductMasterId
                    });
            }
            yield return product;
            yield return price;
        }
    }
}