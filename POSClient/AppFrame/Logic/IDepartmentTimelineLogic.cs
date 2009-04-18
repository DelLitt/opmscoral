using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IDepartmentTimelineLogic
    {
        /// <summary>
        /// Find DepartmentTimeline object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentTimeline</param>
        /// <returns></returns>
        DepartmentTimeline FindById(object id);
        
        /// <summary>
        /// Add DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentTimeline Add(DepartmentTimeline data);
        
        /// <summary>
        /// Update DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentTimeline data);
        
        /// <summary>
        /// Delete DepartmentTimeline from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentTimeline data);
        
        /// <summary>
        /// Delete DepartmentTimeline from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentTimeline from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentTimeline from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        void ProcessPeriod(bool isConfirmPeriod);
    }
}