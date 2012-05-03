			 


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
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ReturnBlockInLogic : IReturnBlockInLogic
    {
        private IReturnBlockInDao _innerDao;
        public IReturnBlockInDao ReturnBlockInDao
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
        /// Find ReturnBlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnBlockIn</param>
        /// <returns></returns>
        public ReturnBlockIn FindById(object id)
        {
            return ReturnBlockInDao.FindById(id);
        }
        
        /// <summary>
        /// Add ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReturnBlockIn Add(ReturnBlockIn data)
        {
            ReturnBlockInDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReturnBlockIn data)
        {
            ReturnBlockInDao.Update(data);
        }
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReturnBlockIn data)
        {
            ReturnBlockInDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReturnBlockInDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReturnBlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ReturnBlockIn> FindAll(ObjectCriteria<ReturnBlockIn> criteria)
        {
            return ReturnBlockInDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReturnBlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ReturnBlockIn> criteria)
        {
            return ReturnBlockInDao.FindPaging(criteria);
        }
    }
}