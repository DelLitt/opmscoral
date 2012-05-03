			 


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
    public class ExProductSizeLogic : IExProductSizeLogic
    {
        private IExProductSizeDao _innerDao;
        public IExProductSizeDao ExProductSizeDao
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
        /// Find ExProductSize object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ExProductSize</param>
        /// <returns></returns>
        public ExProductSize FindById(object id)
        {
            return ExProductSizeDao.FindById(id);
        }
        
        /// <summary>
        /// Add ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ExProductSize Add(ExProductSize data)
        {
            ExProductSizeDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ExProductSize data)
        {
            ExProductSizeDao.Update(data);
        }
        
        /// <summary>
        /// Delete ExProductSize from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ExProductSize data)
        {
            ExProductSizeDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ExProductSize from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ExProductSizeDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ExProductSize from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ExProductSize> FindAll(ObjectCriteria<ExProductSize> criteria)
        {
            return ExProductSizeDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ExProductSize from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ExProductSize> criteria)
        {
            return ExProductSizeDao.FindPaging(criteria);
        }
    }
}