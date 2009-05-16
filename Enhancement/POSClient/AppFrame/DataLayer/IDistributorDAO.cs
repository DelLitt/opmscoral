using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDistributorDAO
    {
        /// <summary>
        /// Find Distributor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Distributor</param>
        /// <returns></returns>
        Distributor FindById(object id);
        
        /// <summary>
        /// Add Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Distributor Add(Distributor data);
        
        /// <summary>
        /// Update Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Distributor data);
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Distributor data);
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Distributor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Distributor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Distributor from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}