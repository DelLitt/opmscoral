			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ProductUnitLogic : IProductUnitLogic
    {
        private IProductUnitDao _innerDao;
        public IProductUnitDao ProductUnitDao
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
        /// Find ProductUnit object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductUnit</param>
        /// <returns></returns>
        public ProductUnit FindById(object id)
        {
            return ProductUnitDao.FindById(id);
        }
        
        /// <summary>
        /// Add ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductUnit Add(ProductUnit data)
        {
            ProductUnitDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductUnit data)
        {
            ProductUnitDao.Update(data);
        }
        
        /// <summary>
        /// Delete ProductUnit from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductUnit data)
        {
            ProductUnitDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductUnit from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductUnitDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductUnit from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ProductUnit> FindAll(ObjectCriteria criteria)
        {
            return ProductUnitDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductUnit from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductUnitDao.FindPaging(criteria);
        }
    }
}