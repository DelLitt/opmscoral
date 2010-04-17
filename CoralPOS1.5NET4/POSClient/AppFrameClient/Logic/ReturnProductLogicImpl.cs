using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ReturnProductLogicImpl : IReturnProductLogic
    {
        private IReturnProductDAO _returnProductDAO;

        public IReturnProductDAO ReturnProductDAO
        {
            get 
            { 
                return _returnProductDAO; 
            }
            set 
            { 
                _returnProductDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ReturnProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnProduct</param>
        /// <returns></returns>
        public ReturnProduct FindById(object id)
        {
            return ReturnProductDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReturnProduct Add(ReturnProduct data)
        {
            ReturnProductDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReturnProduct data)
        {
            ReturnProductDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ReturnProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReturnProduct data)
        {
            ReturnProductDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ReturnProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReturnProductDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReturnProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ReturnProductDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReturnProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReturnProductDAO.FindPaging(criteria);
        }
    }
}