			 
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
    public interface ICouponLogic
    {
        /// <summary>
        /// Find  Coupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Coupon</param>
        /// <returns></returns>
         Coupon FindById(object id);
        
        /// <summary>
        /// Add  Coupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Coupon Add( Coupon data);
        
        /// <summary>
        /// Update  Coupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Coupon data);
        
        /// <summary>
        /// Delete  Coupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Coupon data);
        
        /// <summary>
        /// Delete  Coupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Coupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Coupon> FindAll(ObjectCriteria<Coupon> criteria);
        
        /// <summary>
        /// Find all  Coupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Coupon> criteria);
    }
}