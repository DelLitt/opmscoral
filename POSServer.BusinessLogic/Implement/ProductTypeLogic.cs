			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using NHibernate.Criterion;
using POSServer.BusinessLogic.Common;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;
using AppFrame.DataLayer;

namespace POSServer.BusinessLogic.Implement
{
    public class ProductTypeLogic : IProductTypeLogic
    {
        private IProductTypeDao _innerDao;
        public IProductTypeDao ProductTypeDao
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
        
        /// <summary>
        /// Find ProductType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductType</param>
        /// <returns></returns>
        public ProductType FindById(object id)
        {
            return ProductTypeDao.FindById(id);
        }
        
        /// <summary>
        /// Add ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductType Add(ProductType data)
        {
            ProductTypeDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductType data)
        {
            ProductTypeDao.Update(data);
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductType data)
        {
            ProductTypeDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductTypeDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ProductType> FindAll(ObjectCriteria<ProductType> criteria)
        {
            return ProductTypeDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ProductType> criteria)
        {
            return ProductTypeDao.FindPaging(criteria);
        }

        public void LoadDefinition(IFlowSession flowSession)
        {
            IList<ProductType> productTypes = ProductTypeDao.FindAll(new ObjectCriteria<ProductType>());
            flowSession.Put(FlowConstants.PRODUCT_TYPE_LIST, productTypes);
        }

        public void Update(IList productTypeList)
        {
            var maxIdResult = ProductTypeDao.SelectSpecificType(null, Projections.Max("TypeId"));
            long maxColorId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;
            foreach (ProductType productType in productTypeList)
            {
                if (productType.TypeId > 0)
                {
                    ProductType current = ProductTypeDao.FindById(productType.TypeId);
                    current.TypeName = productType.TypeName;
                    current.UpdateDate = DateTime.Now;
                    ProductTypeDao.Update(current);
                }
                else
                {
                    productType.TypeId = maxColorId++;
                    productType.CreateDate = DateTime.Now;
                    productType.UpdateDate = DateTime.Now;
                    ProductTypeDao.Add(productType);
                }
            }
        }
    }
}