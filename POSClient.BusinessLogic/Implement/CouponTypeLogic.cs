			 


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
    public class CouponTypeLogic : ICouponTypeLogic
    {
        private ICouponTypeDao _innerDao;
        public ICouponTypeDao CouponTypeDao
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
        /// Find CouponType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CouponType</param>
        /// <returns></returns>
        public CouponType FindById(object id)
        {
            return CouponTypeDao.FindById(id);
        }
        
        /// <summary>
        /// Add CouponType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public CouponType Add(CouponType data)
        {
            CouponTypeDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update CouponType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(CouponType data)
        {
            CouponTypeDao.Update(data);
        }
        
        /// <summary>
        /// Delete CouponType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(CouponType data)
        {
            CouponTypeDao.Delete(data);
        }
        
        /// <summary>
        /// Delete CouponType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CouponTypeDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all CouponType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<CouponType> FindAll(ObjectCriteria<CouponType> criteria)
        {
            return CouponTypeDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all CouponType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<CouponType> criteria)
        {
            return CouponTypeDao.FindPaging(criteria);
        }
    }
}