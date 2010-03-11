			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ContractLogic : IContractLogic
    {
        private IContractDao _innerDao;
        public IContractDao ContractDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }
        
        /// <summary>
        /// Find Contract object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Contract</param>
        /// <returns></returns>
        public Contract FindById(object id)
        {
            return ContractDao.FindById(id);
        }
        
        /// <summary>
        /// Add Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Contract Add(Contract data)
        {
            ContractDao.Add(data);
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
            ContractDao.Update(data);
        }
        
        /// <summary>
        /// Delete Contract from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Contract data)
        {
            ContractDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Contract from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ContractDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Contract from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Contract> FindAll(ObjectCriteria criteria)
        {
            return ContractDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Contract from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ContractDao.FindPaging(criteria);
        }
    }
}