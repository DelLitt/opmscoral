			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class ProductTypeLogicImpl : IProductTypeLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductType Add(ProductType data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductType data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}