using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class CouponTypeLogicImpl : ICouponTypeLogic
    {
        private ICouponTypeDAO _couponTypeDAO;

        public ICouponTypeDAO CouponTypeDAO
        {
            get 
            { 
                return _couponTypeDAO; 
            }
            set 
            { 
                _couponTypeDAO = value; 
            }
        }
        
        /// <summary>
        /// Find CouponType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CouponType</param>
        /// <returns></returns>
        public CouponType FindById(object id)
        {
            return CouponTypeDAO.FindById(id);
        }
        
        /// <summary>
        /// Add CouponType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public CouponType Add(CouponType data)
        {
            CouponTypeDAO.Add(data);
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
            CouponTypeDAO.Update(data);
        }
        
        /// <summary>
        /// Delete CouponType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(CouponType data)
        {
            CouponTypeDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete CouponType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CouponTypeDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all CouponType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return CouponTypeDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all CouponType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CouponTypeDAO.FindPaging(criteria);
        }
    }
}