using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface ISupplierLogic
    {
        /// <summary>
        /// Find Supplier object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Supplier</param>
        /// <returns></returns>
        Supplier FindById(object id);
        
        /// <summary>
        /// Add Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Supplier Add(Supplier data);
        
        /// <summary>
        /// Update Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Supplier data);
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Supplier data);
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Supplier from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Supplier from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}