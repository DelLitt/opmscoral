using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IPackagerDAO
    {
        /// <summary>
        /// Find Packager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Packager</param>
        /// <returns></returns>
        Packager FindById(object id);
        
        /// <summary>
        /// Add Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Packager Add(Packager data);
        
        /// <summary>
        /// Update Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Packager data);
        
        /// <summary>
        /// Delete Packager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Packager data);
        
        /// <summary>
        /// Delete Packager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Packager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Packager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Packager from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}