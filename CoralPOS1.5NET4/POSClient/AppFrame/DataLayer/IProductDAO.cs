using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IProductDAO
    {
        /// <summary>
        /// Find Product object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Product</param>
        /// <returns></returns>
        Product FindById(object id);
        
        /// <summary>
        /// Add Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Product Add(Product data);
        
        /// <summary>
        /// Update Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Product data);
        
        /// <summary>
        /// Delete Product from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Product data);
        
        /// <summary>
        /// Delete Product from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Product from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Product from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Product from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="limit"></param>
        /// <param name="allDepartment"></param>
        /// <returns></returns>
        IList FindLikeId(string id, int limit, bool allDepartment);
    }
}