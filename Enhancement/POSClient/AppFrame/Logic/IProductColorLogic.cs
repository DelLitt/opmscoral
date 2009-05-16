using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IProductColorLogic
    {
        /// <summary>
        /// Find ProductColor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductColor</param>
        /// <returns></returns>
        ProductColor FindById(object id);
        
        /// <summary>
        /// Add ProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductColor Add(ProductColor data);
        
        /// <summary>
        /// Update ProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ProductColor data);
        
        /// <summary>
        /// Delete ProductColor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ProductColor data);
        
        /// <summary>
        /// Delete ProductColor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ProductColor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ProductColor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}