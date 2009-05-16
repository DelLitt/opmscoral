using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ReturnBlockInLogicImpl : IReturnBlockInLogic
    {
        private IReturnBlockInDAO _returnBlockInDAO;

        public IReturnBlockInDAO ReturnBlockInDAO
        {
            get 
            { 
                return _returnBlockInDAO; 
            }
            set 
            { 
                _returnBlockInDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ReturnBlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnBlockIn</param>
        /// <returns></returns>
        public ReturnBlockIn FindById(object id)
        {
            return ReturnBlockInDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReturnBlockIn Add(ReturnBlockIn data)
        {
            ReturnBlockInDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReturnBlockIn data)
        {
            ReturnBlockInDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReturnBlockIn data)
        {
            ReturnBlockInDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReturnBlockInDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReturnBlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ReturnBlockInDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReturnBlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReturnBlockInDAO.FindPaging(criteria);
        }
    }
}