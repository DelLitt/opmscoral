			 


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
    public class GiftLogic : IGiftLogic
    {
        private IGiftDao _innerDao;
        public IGiftDao GiftDao
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
        /// Find Gift object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Gift</param>
        /// <returns></returns>
        public Gift FindById(object id)
        {
            return GiftDao.FindById(id);
        }
        
        /// <summary>
        /// Add Gift to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Gift Add(Gift data)
        {
            GiftDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Gift to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Gift data)
        {
            GiftDao.Update(data);
        }
        
        /// <summary>
        /// Delete Gift from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Gift data)
        {
            GiftDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Gift from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            GiftDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Gift from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Gift> FindAll(ObjectCriteria<Gift> criteria)
        {
            return GiftDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Gift from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Gift> criteria)
        {
            return GiftDao.FindPaging(criteria);
        }
    }
}