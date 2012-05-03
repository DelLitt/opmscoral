			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class ScheduleTemplateLogic : IScheduleTemplateLogic
    {
        private IScheduleTemplateDao _innerDao;
        public IScheduleTemplateDao ScheduleTemplateDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }
        
        /// <summary>
        /// Find ScheduleTemplate object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ScheduleTemplate</param>
        /// <returns></returns>
        public ScheduleTemplate FindById(object id)
        {
            return ScheduleTemplateDao.FindById(id);
        }
        
        /// <summary>
        /// Add ScheduleTemplate to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ScheduleTemplate Add(ScheduleTemplate data)
        {
            ScheduleTemplateDao.Add(data);
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
            ScheduleTemplateDao.Update(data);
        }
        
        /// <summary>
        /// Delete ScheduleTemplate from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ScheduleTemplate data)
        {
            ScheduleTemplateDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ScheduleTemplate from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ScheduleTemplateDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ScheduleTemplate from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ScheduleTemplate> FindAll(ObjectCriteria<ScheduleTemplate> criteria)
        {
            return ScheduleTemplateDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ScheduleTemplate from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ScheduleTemplate> criteria)
        {
            return ScheduleTemplateDao.FindPaging(criteria);
        }
    }
}