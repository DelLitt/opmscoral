			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class CustomerDetailLogicImpl : ICustomerDetailLogic
    {
        private ICustomerDetailDao _innerDao;

        public ICustomerDetailDao CustomerDetailDao
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
        /// Find CustomerDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CustomerDetail</param>
        /// <returns></returns>
        public CustomerDetail FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add CustomerDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public CustomerDetail Add(CustomerDetail data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update CustomerDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(CustomerDetail data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete CustomerDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(CustomerDetail data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete CustomerDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all CustomerDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all CustomerDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}