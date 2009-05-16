using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentPromotionLogicImpl : IDepartmentPromotionLogic
    {
        private IDepartmentPromotionDAO _departmentPromotionDAO;

        public IDepartmentPromotionDAO DepartmentPromotionDAO
        {
            get 
            { 
                return _departmentPromotionDAO; 
            }
            set 
            { 
                _departmentPromotionDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPromotion</param>
        /// <returns></returns>
        public DepartmentPromotion FindById(object id)
        {
            return DepartmentPromotionDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPromotion Add(DepartmentPromotion data)
        {
            DepartmentPromotionDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPromotion data)
        {
            DepartmentPromotionDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPromotion data)
        {
            DepartmentPromotionDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPromotionDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentPromotionDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentPromotionDAO.FindPaging(criteria);
        }
    }
}