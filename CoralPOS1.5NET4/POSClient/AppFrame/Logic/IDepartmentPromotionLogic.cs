using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IDepartmentPromotionLogic
    {
        /// <summary>
        /// Find DepartmentPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPromotion</param>
        /// <returns></returns>
        DepartmentPromotion FindById(object id);
        
        /// <summary>
        /// Add DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentPromotion Add(DepartmentPromotion data);
        
        /// <summary>
        /// Update DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentPromotion data);
        
        /// <summary>
        /// Delete DepartmentPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentPromotion data);
        
        /// <summary>
        /// Delete DepartmentPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}