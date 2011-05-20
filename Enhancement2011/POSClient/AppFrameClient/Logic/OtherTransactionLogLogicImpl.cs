using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class OtherTransactionLogLogicImpl : IOtherTransactionLogLogic
    {
        private IOtherTransactionLogDAO _otherTransactionLogDAO;

        public IOtherTransactionLogDAO OtherTransactionLogDAO
        {
            get 
            { 
                return _otherTransactionLogDAO; 
            }
            set 
            { 
                _otherTransactionLogDAO = value; 
            }
        }
        
        /// <summary>
        /// Find OtherTransactionLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of OtherTransactionLog</param>
        /// <returns></returns>
        public OtherTransactionLog FindById(object id)
        {
            return OtherTransactionLogDAO.FindById(id);
        }
        
        /// <summary>
        /// Add OtherTransactionLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public OtherTransactionLog Add(OtherTransactionLog data)
        {
            OtherTransactionLogDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update OtherTransactionLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(OtherTransactionLog data)
        {
            OtherTransactionLogDAO.Update(data);
        }
        
        /// <summary>
        /// Delete OtherTransactionLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(OtherTransactionLog data)
        {
            OtherTransactionLogDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete OtherTransactionLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            OtherTransactionLogDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all OtherTransactionLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return OtherTransactionLogDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all OtherTransactionLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return OtherTransactionLogDAO.FindPaging(criteria);
        }
    }
}