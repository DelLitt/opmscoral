			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using POSServer.BusinessLogic.Common;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ProductMasterLogic : IProductMasterLogic
    {
        private IProductMasterDao _innerDao;
        public IProductMasterDao ProductMasterDao
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

        public IProductTypeDao ProductTypeDao { get; set; }
        public ICategoryDao CategoryDao { get; set; }
        public IExProductColorDao ProductColorDao { get; set; }
        public IExProductSizeDao ProductSizeDao { get; set; }
        /// <summary>
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        public ProductMaster FindById(object id)
        {
            return ProductMasterDao.FindById(id);
        }
        
        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductMaster Add(ProductMaster data)
        {
            ProductMasterDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductMaster data)
        {
            ProductMasterDao.Update(data);
        }
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductMaster data)
        {
            ProductMasterDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductMasterDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ProductMaster> FindAll(ObjectCriteria criteria)
        {
            return ProductMasterDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductMasterDao.FindPaging(criteria);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void PreloadDefinition(ISession session)
        {
            IList<Category> categories = CategoryDao.FindAll(null);
            session.Put(FlowConstants.CATEGORY_LIST,categories);
            IList<ProductType> productTypes = ProductTypeDao.FindAll(null);
            session.Put(FlowConstants.PRODUCT_TYPE_LIST,productTypes);
            IList<ExProductColor> productColors = ProductColorDao.FindAll(null);
            session.Put(FlowConstants.PRODUCT_COLOR_LIST, productColors);
            IList<ExProductSize> productSizes = ProductSizeDao.FindAll(null);
            session.Put(FlowConstants.PRODUCT_SIZE_LIST, productSizes);

        }
    }
}