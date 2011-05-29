using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class CustomerDetailLogicImpl : ICustomerDetailLogic
    {
        private ICustomerDetailDAO _customerDetailDAO;

        public ICustomerDetailDAO CustomerDetailDAO
        {
            get 
            { 
                return _customerDetailDAO; 
            }
            set 
            { 
                _customerDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find CustomerDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CustomerDetail</param>
        /// <returns></returns>
        public CustomerDetail FindById(object id)
        {
            return CustomerDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add CustomerDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public CustomerDetail Add(CustomerDetail data)
        {
            CustomerDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update CustomerDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(CustomerDetail data)
        {
            CustomerDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete CustomerDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(CustomerDetail data)
        {
            CustomerDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete CustomerDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CustomerDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all CustomerDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return CustomerDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all CustomerDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CustomerDetailDAO.FindPaging(criteria);
        }
    }
}