			 
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
    public interface IDepartmentTimelineLogic
    {
        /// <summary>
        /// Find  DepartmentTimeline object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentTimeline</param>
        /// <returns></returns>
         DepartmentTimeline FindById(object id);
        
        /// <summary>
        /// Add  DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentTimeline Add( DepartmentTimeline data);
        
        /// <summary>
        /// Update  DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentTimeline data);
        
        /// <summary>
        /// Delete  DepartmentTimeline from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentTimeline data);
        
        /// <summary>
        /// Delete  DepartmentTimeline from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentTimeline from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentTimeline> FindAll(ObjectCriteria<DepartmentTimeline> criteria);
        
        /// <summary>
        /// Find all  DepartmentTimeline from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentTimeline> criteria);
    }
}