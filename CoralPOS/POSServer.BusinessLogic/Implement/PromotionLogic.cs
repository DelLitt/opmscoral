			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class PromotionLogic : IPromotionLogic
    {
        private IPromotionDao _innerDao;
        public IPromotionDao PromotionDao
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
        /// Find Promotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Promotion</param>
        /// <returns></returns>
        public Promotion FindById(object id)
        {
            return PromotionDao.FindById(id);
        }
        
        /// <summary>
        /// Add Promotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Promotion Add(Promotion data)
        {
            PromotionDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Promotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Promotion data)
        {
            PromotionDao.Update(data);
        }
        
        /// <summary>
        /// Delete Promotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Promotion data)
        {
            PromotionDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Promotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PromotionDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Promotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Promotion> FindAll(ObjectCriteria criteria)
        {
            return PromotionDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Promotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PromotionDao.FindPaging(criteria);
        }
    }
}