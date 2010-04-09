			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IStockOutDao
    {
        /// <summary>
        /// Find Tax object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Tax</param>
        /// <returns></returns>
        StockOut FindById(object id);
        
        /// <summary>
        /// Add Tax to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockOut Add(StockOut data);
        
        /// <summary>
        /// Update Tax to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(StockOut data);
        
        /// <summary>
        /// Delete Tax from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(StockOut data);
        
        /// <summary>
        /// Delete Tax from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);

        /// <summary>
        /// Find all Tax from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>		
        IList<StockOut> FindAll(LinqCriteria<StockOut> criteria);

        IList<StockOut> FindAll(ObjectCriteria<StockOut> criteria);
		
        object FindFirst(ObjectCriteria<StockOut> criteria);
		
		/// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="criteria"></param>
        /// <param name="subProp"></param>
        /// <returns></returns>
        IList<TClass> FindAllSubProperty<TClass>(LinqCriteria<StockOut> criteria,Func<StockOut,TClass> subProp);

        /// <summary>
        /// Find all Tax from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<StockOut> criteria);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        int Count(ObjectCriteria<StockOut> criteria);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria<StockOut> criteria, IProjection type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="exposeSession"></param>
        /// <returns></returns>
        object Execute(IHibernateCallback callback, bool exposeSession);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delegated"></param>
        /// <returns></returns>
        object Execute(HibernateDelegate delegated);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delegated"></param>
        /// <returns></returns>
        object ExecuteExposedSession(HibernateDelegate delegated);

        StockOut Fetch(StockOut stockOut);
    }
}

