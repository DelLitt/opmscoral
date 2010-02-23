			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class ExProductColorLogicImpl : IExProductColorLogic
    {
        private IExProductColorDao _innerDao;

        public IExProductColorDao ExProductColorDao
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
        /// Find ExProductColor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ExProductColor</param>
        /// <returns></returns>
        public ExProductColor FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ExProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ExProductColor Add(ExProductColor data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ExProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ExProductColor data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ExProductColor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ExProductColor data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ExProductColor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ExProductColor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ExProductColor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}