using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PublishedCouponLogicImpl : IPublishedCouponLogic
    {
        private IPublishedCouponDAO _publishedCouponDAO;

        public IPublishedCouponDAO PublishedCouponDAO
        {
            get 
            { 
                return _publishedCouponDAO; 
            }
            set 
            { 
                _publishedCouponDAO = value; 
            }
        }
        
        /// <summary>
        /// Find PublishedCoupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PublishedCoupon</param>
        /// <returns></returns>
        public PublishedCoupon FindById(object id)
        {
            return PublishedCouponDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PublishedCoupon Add(PublishedCoupon data)
        {
            PublishedCouponDAO.Add(data);
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
            PublishedCouponDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PublishedCoupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PublishedCoupon data)
        {
            PublishedCouponDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PublishedCoupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PublishedCouponDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PublishedCoupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PublishedCouponDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PublishedCoupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PublishedCouponDAO.FindPaging(criteria);
        }
    }
}