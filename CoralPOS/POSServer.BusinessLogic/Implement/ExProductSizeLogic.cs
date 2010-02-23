			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class ExProductSizeLogicImpl : IExProductSizeLogic
    {
        private IExProductSizeDao _innerDao;

        public IExProductSizeDao ExProductSizeDao
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
        /// Find ExProductSize object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ExProductSize</param>
        /// <returns></returns>
        public ExProductSize FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ExProductSize Add(ExProductSize data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ExProductSize data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ExProductSize from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ExProductSize data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ExProductSize from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ExProductSize from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ExProductSize from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}