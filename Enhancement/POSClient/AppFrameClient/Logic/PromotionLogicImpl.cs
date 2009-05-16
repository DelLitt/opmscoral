using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PromotionLogicImpl : IPromotionLogic
    {
        private IPromotionDAO _promotionDAO;

        public IPromotionDAO PromotionDAO
        {
            get 
            { 
                return _promotionDAO; 
            }
            set 
            { 
                _promotionDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Promotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Promotion</param>
        /// <returns></returns>
        public Promotion FindById(object id)
        {
            return PromotionDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Promotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Promotion Add(Promotion data)
        {
            PromotionDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Promotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Promotion data)
        {
            PromotionDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Promotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Promotion data)
        {
            PromotionDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Promotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PromotionDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Promotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PromotionDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Promotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PromotionDAO.FindPaging(criteria);
        }
    }
}