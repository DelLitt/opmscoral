			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class PackagerLogic : IPackagerLogic
    {
        private IPackagerDao _innerDao;
        public IPackagerDao PackagerDao
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
        /// Find Packager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Packager</param>
        /// <returns></returns>
        public Packager FindById(object id)
        {
            return PackagerDao.FindById(id);
        }
        
        /// <summary>
        /// Add Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Packager Add(Packager data)
        {
            PackagerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Packager data)
        {
            PackagerDao.Update(data);
        }
        
        /// <summary>
        /// Delete Packager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Packager data)
        {
            PackagerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Packager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PackagerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Packager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Packager> FindAll(ObjectCriteria criteria)
        {
            return PackagerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Packager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PackagerDao.FindPaging(criteria);
        }
    }
}