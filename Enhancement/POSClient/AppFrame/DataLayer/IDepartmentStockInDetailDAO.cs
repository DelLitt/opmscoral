using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentStockInDetailDAO
    {
        /// <summary>
        /// Find DepartmentStockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInDetail</param>
        /// <returns></returns>
        DepartmentStockInDetail FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockInDetail Add(DepartmentStockInDetail data);
        
        /// <summary>
        /// Update DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentStockInDetail data);
        
        /// <summary>
        /// Delete DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentStockInDetail data);
        
        /// <summary>
        /// Delete DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        IList FindByQuery(string sqlString, ObjectCriteria criteria);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchProductMaster"></param>
        /// <returns></returns>
        IList FindAllProductMaster(ProductMaster searchProductMaster);

        IList FindReStock(string id);
    }
}