using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class GiftLogicImpl : IGiftLogic
    {
        private IGiftDAO _giftDAO;

        public IGiftDAO GiftDAO
        {
            get 
            { 
                return _giftDAO; 
            }
            set 
            { 
                _giftDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Gift object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Gift</param>
        /// <returns></returns>
        public Gift FindById(object id)
        {
            return GiftDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Gift to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Gift Add(Gift data)
        {
            GiftDAO.Add(data);
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
            GiftDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Gift from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Gift data)
        {
            GiftDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Gift from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            GiftDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Gift from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return GiftDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Gift from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return GiftDAO.FindPaging(criteria);
        }
    }
}