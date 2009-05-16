using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IPublishedCouponDAO
    {
        /// <summary>
        /// Find PublishedCoupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PublishedCoupon</param>
        /// <returns></returns>
        PublishedCoupon FindById(object id);
        
        /// <summary>
        /// Add PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PublishedCoupon Add(PublishedCoupon data);
        
        /// <summary>
        /// Update PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PublishedCoupon data);
        
        /// <summary>
        /// Delete PublishedCoupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PublishedCoupon data);
        
        /// <summary>
        /// Delete PublishedCoupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PublishedCoupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PublishedCoupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... PublishedCoupon from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}