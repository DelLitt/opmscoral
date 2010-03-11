			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class PublishedCouponLogic : IPublishedCouponLogic
    {
        private IPublishedCouponDao _innerDao;
        public IPublishedCouponDao PublishedCouponDao
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
        /// Find PublishedCoupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PublishedCoupon</param>
        /// <returns></returns>
        public PublishedCoupon FindById(object id)
        {
            return PublishedCouponDao.FindById(id);
        }
        
        /// <summary>
        /// Add PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PublishedCoupon Add(PublishedCoupon data)
        {
            PublishedCouponDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PublishedCoupon data)
        {
            PublishedCouponDao.Update(data);
        }
        
        /// <summary>
        /// Delete PublishedCoupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PublishedCoupon data)
        {
            PublishedCouponDao.Delete(data);
        }
        
        /// <summary>
        /// Delete PublishedCoupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PublishedCouponDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PublishedCoupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<PublishedCoupon> FindAll(ObjectCriteria criteria)
        {
            return PublishedCouponDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PublishedCoupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PublishedCouponDao.FindPaging(criteria);
        }
    }
}