using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ReturnPoLogicImpl : IReturnPoLogic
    {
        private IReturnPoDAO _returnPoDAO;

        public IReturnPoDAO ReturnPoDAO
        {
            get 
            { 
                return _returnPoDAO; 
            }
            set 
            { 
                _returnPoDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ReturnPo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnPo</param>
        /// <returns></returns>
        public ReturnPo FindById(object id)
        {
            return ReturnPoDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ReturnPo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReturnPo Add(ReturnPo data)
        {
            ReturnPoDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReturnPo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReturnPo data)
        {
            ReturnPoDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ReturnPo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReturnPo data)
        {
            ReturnPoDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ReturnPo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReturnPoDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReturnPo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ReturnPoDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReturnPo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReturnPoDAO.FindPaging(criteria);
        }

        #region IReturnPoLogic Members


        public object FindQuantityById(ReturnPoPK pk)
        {
            return ReturnPoDAO.FindQuantityById(pk);
        }

        #endregion
    }
}