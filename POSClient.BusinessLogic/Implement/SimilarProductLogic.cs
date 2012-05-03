			 


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
    public class SimilarProductLogic : ISimilarProductLogic
    {
        private ISimilarProductDao _innerDao;
        public ISimilarProductDao SimilarProductDao
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
        /// Find SimilarProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SimilarProduct</param>
        /// <returns></returns>
        public SimilarProduct FindById(object id)
        {
            return SimilarProductDao.FindById(id);
        }
        
        /// <summary>
        /// Add SimilarProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SimilarProduct Add(SimilarProduct data)
        {
            SimilarProductDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update SimilarProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(SimilarProduct data)
        {
            SimilarProductDao.Update(data);
        }
        
        /// <summary>
        /// Delete SimilarProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SimilarProduct data)
        {
            SimilarProductDao.Delete(data);
        }
        
        /// <summary>
        /// Delete SimilarProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SimilarProductDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SimilarProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<SimilarProduct> FindAll(ObjectCriteria<SimilarProduct> criteria)
        {
            return SimilarProductDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SimilarProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<SimilarProduct> criteria)
        {
            return SimilarProductDao.FindPaging(criteria);
        }
    }
}