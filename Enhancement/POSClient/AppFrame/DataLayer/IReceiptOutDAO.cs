using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IReceiptOutDAO
    {
        /// <summary>
        /// Find ReceiptOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReceiptOut</param>
        /// <returns></returns>
        ReceiptOut FindById(object id);
        
        /// <summary>
        /// Add ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReceiptOut Add(ReceiptOut data);
        
        /// <summary>
        /// Update ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ReceiptOut data);
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ReceiptOut data);
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ReceiptOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReceiptOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ReceiptOut from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}