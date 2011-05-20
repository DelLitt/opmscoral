using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IReturnProductDAO
    {
        /// <summary>
        /// Find ReturnProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnProduct</param>
        /// <returns></returns>
        ReturnProduct FindById(object id);
        
        /// <summary>
        /// Add ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReturnProduct Add(ReturnProduct data);
        
        /// <summary>
        /// Update ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ReturnProduct data);
        
        /// <summary>
        /// Delete ReturnProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ReturnProduct data);
        
        /// <summary>
        /// Delete ReturnProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ReturnProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReturnProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ReturnProduct from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}