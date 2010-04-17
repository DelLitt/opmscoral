using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ContractLogicImpl : IContractLogic
    {
        private IContractDAO _contractDAO;

        public IContractDAO ContractDAO
        {
            get 
            { 
                return _contractDAO; 
            }
            set 
            { 
                _contractDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Contract object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Contract</param>
        /// <returns></returns>
        public Contract FindById(object id)
        {
            return ContractDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Contract Add(Contract data)
        {
            ContractDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Contract data)
        {
            ContractDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Contract from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Contract data)
        {
            ContractDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Contract from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ContractDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Contract from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ContractDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Contract from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ContractDAO.FindPaging(criteria);
        }
    }
}