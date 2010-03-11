			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class CouponLogic : ICouponLogic
    {
        private ICouponDao _innerDao;
        public ICouponDao CouponDao
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
        /// Find Coupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Coupon</param>
        /// <returns></returns>
        public Coupon FindById(object id)
        {
            return CouponDao.FindById(id);
        }
        
        /// <summary>
        /// Add Coupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Coupon Add(Coupon data)
        {
            CouponDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Coupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Coupon data)
        {
            CouponDao.Update(data);
        }
        
        /// <summary>
        /// Delete Coupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Coupon data)
        {
            CouponDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Coupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CouponDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Coupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Coupon> FindAll(ObjectCriteria criteria)
        {
            return CouponDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Coupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CouponDao.FindPaging(criteria);
        }
    }
}