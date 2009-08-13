using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Utility;
using Common.Logging;
using log4net.Repository.Hierarchy;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ProductMasterLogicImpl : IProductMasterLogic
    {
        public IProductMasterDAO ProductMasterDAO { get; set; }
        public IProductDAO ProductDAO { get; set; }
        public IDepartmentStockDAO DepartmentStockDAO { get; set; }
        public IDepartmentStockInDAO DepartmentStockInDAO { get; set; }
        public IDepartmentStockInDetailDAO DepartmentStockInDetailDAO { get; set; }
        public IPurchaseOrderDAO PurchaseOrderDAO { get; set; }
        public IPurchaseOrderDetailDAO PurchaseOrderDetailDAO { get; set; }
        public IDepartmentPriceDAO DepartmentPriceDAO { get; set; }

        /// <summary>
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        public ProductMaster FindById(object id)
        {
            return ProductMasterDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductMaster Add(ProductMaster data)
        {
            ILog logger = LogManager.GetLogger("AppFrame");
            //string deptId = string.Format("{0:000}", CurrentDepartment.Get().DepartmentId);
            // always insert goods at main stock
            string deptId = "000";
            //var criteria = new ObjectCriteria();
            //criteria.AddBetweenCriteria("ProductMasterId", "0000000000", deptId + "9999999999" );
            object maxId = ProductMasterDAO.SelectSpecificType(null, Projections.Max("ProductMasterId"));
            if (maxId != null)
            {
                data.ProductMasterId = string.Format("{0:0000000000000}" ,Int64.Parse(maxId.ToString()) + 1);
            }
            else
            {
                data.ProductMasterId = deptId + "0000000001";
            }
            data.Barcode = data.ProductMasterId;
/*            if (data.ProductType != null)
            {
                data.Barcode = string.Format("{0:000}", data.ProductType.TypeId) + data.ProductMasterId;
            } else
            {
                data.Barcode = "000" + data.ProductMasterId;
            }*/
            data.ImagePath = data.ProductMasterId + ".jpg";
            ProductMasterDAO.Add(data);
            
            return data;
        }

        [Transaction(ReadOnly = false)]
        public void AddAll(List<ProductMaster> productMasters)
        {
            //string deptId = string.Format("{0:000}", CurrentDepartment.Get().DepartmentId);
            // always insert goods at main stock
            string deptId = "000";
            var criteria = new ObjectCriteria();
            criteria.AddBetweenCriteria("ProductMasterId", deptId + "0000000000", deptId + "9999999999");
            object maxId = ProductMasterDAO.SelectSpecificType(criteria, Projections.Max("ProductMasterId"));
            long id = 0;
            if (maxId != null)
            {
                id = Int64.Parse(maxId.ToString()) + 1;
                //data.ProductMasterId = string.Format("{0:0000000000000}", Int64.Parse(maxId.ToString()) + 1);
            }
            else
            {
                id = Int64.Parse("0000000000001");
                //data.ProductMasterId = deptId + "0000000001";
            }
            foreach (ProductMaster productMaster in productMasters)
            {
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("ProductName", productMaster.ProductName);
                criteria.AddEqCriteria("Packager", productMaster.Packager);
                criteria.AddEqCriteria("Distributor", productMaster.Distributor);
                criteria.AddEqCriteria("Manufacturer", productMaster.Manufacturer);
                criteria.AddEqCriteria("ProductType", productMaster.ProductType);
                criteria.AddEqCriteria("ProductSize", productMaster.ProductSize);
                criteria.AddEqCriteria("ProductColor", productMaster.ProductColor);
                criteria.AddEqCriteria("Country", productMaster.Country);
                IList list = ProductMasterDAO.FindAll(criteria);

                if (list.Count == 0)
                {
                    productMaster.ProductMasterId = string.Format("{0:0000000000000}", id++);
                    productMaster.Barcode = productMaster.ProductMasterId;
                    productMaster.ImagePath = StringUtility.ConvertUniStringToHexChar(productMaster.ProductName) + ".jpg";
                    ProductMasterDAO.Add(productMaster);                    
                }
            }
            
        }

        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductMaster data)
        {
            var originalProMaster = ProductMasterDAO.FindById(data.ProductMasterId);

            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddNotEqualsCriteria("ProductMasterId", data.ProductMasterId);
            criteria.AddEqCriteria("ProductType", originalProMaster.ProductType);
            criteria.AddEqCriteria("Country", originalProMaster.Country);
            criteria.AddEqCriteria("Manufacturer", originalProMaster.Manufacturer);
            criteria.AddEqCriteria("Distributor", originalProMaster.Distributor);
            criteria.AddEqCriteria("Packager", originalProMaster.Packager);
            criteria.AddEqCriteria("ProductName", originalProMaster.ProductName);

            IList list = ProductMasterDAO.FindAll(criteria);
            foreach (ProductMaster master in list)
            {
                master.ProductName = data.ProductName;
                master.ProductType = data.ProductType;
                master.ProductFullName = data.ProductFullName;
                master.Manufacturer = data.Manufacturer;
                master.Packager = data.Packager;
                master.Distributor = data.Distributor;
                master.Packager = data.Packager;
                master.Country = data.Country;
                master.UpdateDate = DateTime.Now;
                master.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                ProductMasterDAO.Update(master);
            }
            ProductMasterDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductMaster data)
        {
            long deptId = CurrentDepartment.Get().DepartmentId;
            // delete product master
            ProductMaster master = ProductMasterDAO.FindById(data.ProductMasterId);
            if (master != null)
            {
                master.UpdateDate = DateTime.Now;
                master.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                master.DelFlg = 1;
                ProductMasterDAO.Update(master);
            }

            // delete product
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("ProductMaster.ProductMasterId", data.ProductMasterId);
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            IList products = ProductDAO.FindAll(criteria);
            IList productIds = new ArrayList();
            foreach (Product product in products)
            {
                product.UpdateDate = DateTime.Now;
                product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                product.DelFlg = 1;
                ProductDAO.Update(product);
                productIds.Add(product.ProductId);
            }
            
            if (productIds.Count > 0)
            {
                // delete stock in detail
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DepartmentStockInDetailPK.DepartmentId", deptId);
                criteria.AddSearchInCriteria("DepartmentStockInDetailPK.ProductId", productIds);
                IList stockInDetails = DepartmentStockInDetailDAO.FindAll(criteria);
                IList stockInIds = new ArrayList();
                foreach (DepartmentStockInDetail detail in stockInDetails)
                {
                    detail.UpdateDate = DateTime.Now;
                    detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    detail.DelFlg = 1;
                    DepartmentStockInDetailDAO.Update(detail);
                    stockInIds.Add(detail.DepartmentStockInDetailPK.StockInId);
                }

                // delete stock in
                if (stockInIds.Count > 0)
                {
                    criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("DepartmentStockInPK.DepartmentId", deptId);
                    criteria.AddSearchInCriteria("DepartmentStockInPK.StockInId", stockInIds);
                    IList stockIns = DepartmentStockInDAO.FindAll(criteria);
                    foreach (DepartmentStockIn stockIn in stockIns)
                    {
                        stockIn.UpdateDate = DateTime.Now;
                        stockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockIn.DelFlg = 1;
                        DepartmentStockInDAO.Update(stockIn);
                    }
                }

                // delete stock
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DepartmentStockPK.DepartmentId", deptId);
                criteria.AddSearchInCriteria("DepartmentStockPK.ProductId", productIds);
                IList stocks = DepartmentStockDAO.FindAll(criteria);
                foreach (DepartmentStock stock in stocks)
                {
                    stock.UpdateDate = DateTime.Now;
                    stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stock.DelFlg = 1;
                    DepartmentStockDAO.Update(stock);
                }

                // delete purchase order detail
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("PurchaseOrderDetailPK.DepartmentId", deptId);
                criteria.AddEqCriteria("ProductMaster.ProductMasterId", data.ProductMasterId);
                IList purchaseOrderDetails = PurchaseOrderDetailDAO.FindAll(criteria);
                IList purchaseOrderIds = new ArrayList();
                foreach (PurchaseOrderDetail detail in purchaseOrderDetails)
                {
                    detail.UpdateDate = DateTime.Now;
                    detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    detail.DelFlg = 1;
                    PurchaseOrderDetailDAO.Update(detail);
                    purchaseOrderIds.Add(detail.PurchaseOrderDetailPK.PurchaseOrderId);
                }

                // delete purchase order 
                if (purchaseOrderIds.Count > 0)
                {
                    criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("PurchaseOrderPK.DepartmentId", deptId);
                    criteria.AddSearchInCriteria("PurchaseOrderPK.PurchaseOrderId", purchaseOrderIds);
                    IList purchaseOrders = PurchaseOrderDAO.FindAll(criteria);
                    foreach (PurchaseOrder po in purchaseOrders)
                    {
                        po.UpdateDate = DateTime.Now;
                        po.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        po.DelFlg = 1;
                        PurchaseOrderDAO.Update(po);
                    }
                }
            }

            // delete price
            var pricePk = new DepartmentPricePK{DepartmentId = deptId, ProductMasterId = data.ProductMasterId};
            var deptPrice = DepartmentPriceDAO.FindById(pricePk);
            if (deptPrice != null)
            {
                deptPrice.UpdateDate = DateTime.Now;
                deptPrice.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                deptPrice.DelFlg = 1;
                DepartmentPriceDAO.Update(deptPrice);
            }
        }
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductMasterDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ProductMasterDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductMasterDAO.FindPaging(criteria);
        }
        public IList FindProductMasterById(object id,int limit,bool allDepartment)
        {
            return ProductMasterDAO.FindLikeId(id, limit,allDepartment);
        }
        public IList FindProductMasterByName(object name, int limit, bool allDepartment)
        {
            IList list = ProductMasterDAO.FindLikeName(name, limit,allDepartment);
            IList retlist = RemoveDuplicateName(list);
            return retlist;
        }

        private IList RemoveDuplicateName(IList prdlist)
        {
            IList list = new ArrayList();
            foreach (ProductMaster productMaster in prdlist)
            {
                 if(NotInList(productMaster,list))
                 {
                     list.Add(productMaster);
                 }
            }
            return list;
        }

        private bool NotInList(ProductMaster master, IList list)
        {
            foreach (ProductMaster productMaster in list)
            {
                if(productMaster.ProductName.Equals(master.ProductName))
                {
                    return false;
                }
            }
            return true;
        }

        #region IProductMasterLogic Members


        public IList FindProductColorsByName(string name)
        {
            return ProductMasterDAO.FindProductColorsByName(name);
        }

        #endregion

        #region IProductMasterLogic Members


        public IList FindProductSizesByName(string name)
        {
            return ProductMasterDAO.FindProductSizesByName(name);
        }

        public IList FindProductMasterByNameAllDepartment(string name, int i)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IProductMasterLogic Members
        

        #endregion

        #region IProductMasterLogic Members
        

        public IList FindAllInDepartment(ProductMaster master, bool allDepartment)
        {
            return ProductMasterDAO.FindAllInDepartment(master, allDepartment);
        }

        public IList FindDistinctNames()
        {
            return ProductMasterDAO.FindDistinctNames(); 
        }

        #endregion
    }
}