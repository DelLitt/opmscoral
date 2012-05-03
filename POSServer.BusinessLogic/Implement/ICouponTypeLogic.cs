			 
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
    public interface ICouponTypeLogic
    {
        /// <summary>
        /// Find  CouponType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  CouponType</param>
        /// <returns></returns>
         CouponType FindById(object id);
        
        /// <summary>
        /// Add  CouponType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         CouponType Add( CouponType data);
        
        /// <summary>
        /// Update  CouponType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( CouponType data);
        
        /// <summary>
        /// Delete  CouponType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( CouponType data);
        
        /// <summary>
        /// Delete  CouponType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  CouponType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<CouponType> FindAll(ObjectCriteria<CouponType> criteria);
        
        /// <summary>
        /// Find all  CouponType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<CouponType> criteria);
    }
}