			 


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
    public class ExProductColorLogic : IExProductColorLogic
    {
        private IExProductColorDao _innerDao;
        public IExProductColorDao ExProductColorDao
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
        /// Find ExProductColor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ExProductColor</param>
        /// <returns></returns>
        public ExProductColor FindById(object id)
        {
            return ExProductColorDao.FindById(id);
        }
        
        /// <summary>
        /// Add ExProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ExProductColor Add(ExProductColor data)
        {
            ExProductColorDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ExProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ExProductColor data)
        {
            ExProductColorDao.Update(data);
        }
        
        /// <summary>
        /// Delete ExProductColor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ExProductColor data)
        {
            ExProductColorDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ExProductColor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ExProductColorDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ExProductColor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ExProductColor> FindAll(ObjectCriteria<ExProductColor> criteria)
        {
            return ExProductColorDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ExProductColor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ExProductColor> criteria)
        {
            return ExProductColorDao.FindPaging(criteria);
        }
    }
}