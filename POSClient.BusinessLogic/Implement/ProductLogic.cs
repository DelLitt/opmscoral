			 


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
    public class ProductLogic : IProductLogic
    {
        private IProductDao _innerDao;
        public IProductDao ProductDao
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
        /// Find Product object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Product</param>
        /// <returns></returns>
        public Product FindById(object id)
        {
            return ProductDao.FindById(id);
        }
        
        /// <summary>
        /// Add Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Product Add(Product data)
        {
            ProductDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Product data)
        {
            ProductDao.Update(data);
        }
        
        /// <summary>
        /// Delete Product from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Product data)
        {
            ProductDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Product from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Product from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Product> FindAll(ObjectCriteria<Product> criteria)
        {
            return ProductDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Product from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Product> criteria)
        {
            return ProductDao.FindPaging(criteria);
        }
    }
}