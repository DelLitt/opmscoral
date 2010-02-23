			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class SupplierLogicImpl : ISupplierLogic
    {
        private ISupplierDao _innerDao;

        public ISupplierDao SupplierDao
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
        /// Find Supplier object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Supplier</param>
        /// <returns></returns>
        public Supplier FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Supplier Add(Supplier data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Supplier data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Supplier data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Supplier from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Supplier from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}