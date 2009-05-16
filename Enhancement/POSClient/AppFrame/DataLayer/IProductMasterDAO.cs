using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IProductMasterDAO
    {
        /// <summary>
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        ProductMaster FindById(object id);
        
        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductMaster Add(ProductMaster data);
        
        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ProductMaster data);
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ProductMaster data);
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ProductMaster from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        IList FindLikeId(object id, int limit, bool allDepartment);
        IList FindLikeName(object name, int limit, bool allDepartment);
        IList FindProductColorsByName(string name);
        IList FindProductSizesByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="master"></param>
        /// <param name="allDepartment"></param>
        /// <returns></returns>
        IList FindAllInDepartment(ProductMaster master, bool allDepartment);
    }
}