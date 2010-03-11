			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class CountryLogic : ICountryLogic
    {
        private ICountryDao _innerDao;
        public ICountryDao CountryDao
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
        /// Find Country object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Country</param>
        /// <returns></returns>
        public Country FindById(object id)
        {
            return CountryDao.FindById(id);
        }
        
        /// <summary>
        /// Add Country to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Country Add(Country data)
        {
            CountryDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Country to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Country data)
        {
            CountryDao.Update(data);
        }
        
        /// <summary>
        /// Delete Country from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Country data)
        {
            CountryDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Country from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CountryDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Country from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Country> FindAll(ObjectCriteria criteria)
        {
            return CountryDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Country from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CountryDao.FindPaging(criteria);
        }
    }
}