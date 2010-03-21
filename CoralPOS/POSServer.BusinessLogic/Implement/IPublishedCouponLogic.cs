			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IPublishedCouponLogic
    {
        /// <summary>
        /// Find  PublishedCoupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  PublishedCoupon</param>
        /// <returns></returns>
         PublishedCoupon FindById(object id);
        
        /// <summary>
        /// Add  PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         PublishedCoupon Add( PublishedCoupon data);
        
        /// <summary>
        /// Update  PublishedCoupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( PublishedCoupon data);
        
        /// <summary>
        /// Delete  PublishedCoupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( PublishedCoupon data);
        
        /// <summary>
        /// Delete  PublishedCoupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  PublishedCoupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<PublishedCoupon> FindAll(ObjectCriteria<PublishedCoupon> criteria);
        
        /// <summary>
        /// Find all  PublishedCoupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<PublishedCoupon> criteria);
    }
}