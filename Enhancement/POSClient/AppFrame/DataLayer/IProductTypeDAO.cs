using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IProductTypeDAO
    {
        /// <summary>
        /// Find ProductType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductType</param>
        /// <returns></returns>
        ProductType FindById(object id);
        
        /// <summary>
        /// Add ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductType Add(ProductType data);
        
        /// <summary>
        /// Update ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ProductType data);
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ProductType data);
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ProductType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ProductType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ProductType from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}