			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class EmpLogicImpl : IEmpLogic
    {
        private IEmpDao _innerDao;

        public IEmpDao EmpDao
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
        /// Find Emp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Emp</param>
        /// <returns></returns>
        public Emp FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add Emp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Emp Add(Emp data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Emp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Emp data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete Emp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Emp data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Emp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Emp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Emp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}