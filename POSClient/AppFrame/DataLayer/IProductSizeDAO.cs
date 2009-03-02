using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IProductSizeDAO
    {
        /// <summary>
        /// Find ProductSize object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductSize</param>
        /// <returns></returns>
        ProductSize FindById(object id);
        
        /// <summary>
        /// Add ProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductSize Add(ProductSize data);
        
        /// <summary>
        /// Update ProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ProductSize data);
        
        /// <summary>
        /// Delete ProductSize from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ProductSize data);
        
        /// <summary>
        /// Delete ProductSize from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ProductSize from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ProductSize from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ProductSize from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}