using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ScheduleTemplateLogicImpl : IScheduleTemplateLogic
    {
        private IScheduleTemplateDAO _scheduleTemplateDAO;

        public IScheduleTemplateDAO ScheduleTemplateDAO
        {
            get 
            { 
                return _scheduleTemplateDAO; 
            }
            set 
            { 
                _scheduleTemplateDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ScheduleTemplate object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ScheduleTemplate</param>
        /// <returns></returns>
        public ScheduleTemplate FindById(object id)
        {
            return ScheduleTemplateDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ScheduleTemplate to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ScheduleTemplate Add(ScheduleTemplate data)
        {
            ScheduleTemplateDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ScheduleTemplate to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ScheduleTemplate data)
        {
            ScheduleTemplateDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ScheduleTemplate from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ScheduleTemplate data)
        {
            ScheduleTemplateDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ScheduleTemplate from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ScheduleTemplateDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ScheduleTemplate from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ScheduleTemplateDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ScheduleTemplate from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ScheduleTemplateDAO.FindPaging(criteria);
        }
    }
}