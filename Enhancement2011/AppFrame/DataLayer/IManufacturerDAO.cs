using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IManufacturerDAO
    {
        /// <summary>
        /// Find Manufacturer object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Manufacturer</param>
        /// <returns></returns>
        Manufacturer FindById(object id);
        
        /// <summary>
        /// Add Manufacturer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Manufacturer Add(Manufacturer data);
        
        /// <summary>
        /// Update Manufacturer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Manufacturer data);
        
        /// <summary>
        /// Delete Manufacturer from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Manufacturer data);
        
        /// <summary>
        /// Delete Manufacturer from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Manufacturer from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Manufacturer from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Manufacturer from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}