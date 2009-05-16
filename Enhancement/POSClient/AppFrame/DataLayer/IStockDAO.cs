using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IStockDAO
    {
        /// <summary>
        /// Find Stock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Stock</param>
        /// <returns></returns>
        Stock FindById(object id);
        
        /// <summary>
        /// Add Stock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Stock Add(Stock data);
        
        /// <summary>
        /// Update Stock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Stock data);
        
        /// <summary>
        /// Delete Stock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Stock data);
        
        /// <summary>
        /// Delete Stock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Stock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Stock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Stock from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        IList FindByQuery(string sqlString, ObjectCriteria criteria);
        IList FindByProductMasterName();
        IList FindAllErrors();
        IList FindByProductMasterName(ProductMaster master);
        IList FindAllProductMasters();
    }
}