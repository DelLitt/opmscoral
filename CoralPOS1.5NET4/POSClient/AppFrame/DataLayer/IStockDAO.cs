using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface ISubStockDAO
    {
        /// <summary>
        /// Find SubStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SubStock</param>
        /// <returns></returns>
        SubStock FindById(object id);
        
        /// <summary>
        /// Add SubStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        SubStock Add(SubStock data);
        
        /// <summary>
        /// Update SubStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(SubStock data);
        
        /// <summary>
        /// Delete SubStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(SubStock data);
        
        /// <summary>
        /// Delete SubStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all SubStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all SubStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... SubStock from database.
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