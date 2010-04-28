			 


using System;
using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
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
        [Transaction(ReadOnly=false)]
        public DepartmentPurchaseOrder Add(DepartmentPurchaseOrder data)
        {
            DepartmentPurchaseOrderDao.Add(data);
            return data;
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

        public Product ProcessBarcode(string barCode)
        {
            var product = ProductDao.FindById(barCode);
            if (product != null)
            {
                // process sale actions
                return product;
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
                if (productMaster == null || color == null || size == null) throw new ArgumentException("Invalid Barcode");

                Product exProduct = new Product
                                        {
                                            ProductColor = color,
                                            ProductSize = size,
                                            ProductMaster = productMaster,
                                            Barcode = barCode,
                                            AdhocCase = 1
                                        };
                return exProduct;

            }
        }
    }
}