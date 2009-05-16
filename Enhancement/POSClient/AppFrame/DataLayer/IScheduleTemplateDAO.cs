using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IScheduleTemplateDAO
    {
        /// <summary>
        /// Find ScheduleTemplate object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ScheduleTemplate</param>
        /// <returns></returns>
        ScheduleTemplate FindById(object id);
        
        /// <summary>
        /// Add ScheduleTemplate to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ScheduleTemplate Add(ScheduleTemplate data);
        
        /// <summary>
        /// Update ScheduleTemplate to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ScheduleTemplate data);
        
        /// <summary>
        /// Delete ScheduleTemplate from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ScheduleTemplate data);
        
        /// <summary>
        /// Delete ScheduleTemplate from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ScheduleTemplate from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ScheduleTemplate from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ScheduleTemplate from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}