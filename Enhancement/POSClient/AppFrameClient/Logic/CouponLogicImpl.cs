using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class CouponLogicImpl : ICouponLogic
    {
        private ICouponDAO _couponDAO;

        public ICouponDAO CouponDAO
        {
            get 
            { 
                return _couponDAO; 
            }
            set 
            { 
                _couponDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Coupon object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Coupon</param>
        /// <returns></returns>
        public Coupon FindById(object id)
        {
            return CouponDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Coupon to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Coupon Add(Coupon data)
        {
            CouponDAO.Add(data);
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
            CouponDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Coupon from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Coupon data)
        {
            CouponDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Coupon from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CouponDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Coupon from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return CouponDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Coupon from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CouponDAO.FindPaging(criteria);
        }
    }
}