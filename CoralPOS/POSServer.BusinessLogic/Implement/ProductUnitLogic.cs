			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class ProductUnitLogicImpl : IProductUnitLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductUnit Add(ProductUnit data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ProductUnit from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductUnit data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductUnit from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductUnit from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductUnit from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}