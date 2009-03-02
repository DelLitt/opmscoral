using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class CustomerLogicImpl : ICustomerLogic
    {
        private ICustomersDAO _customerDAO;

        public ICustomersDAO CustomerDAO
        {
            get 
            { 
                return _customerDAO; 
            }
            set 
            { 
                _customerDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Customer object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Customer</param>
        /// <returns></returns>
        public Customer FindById(object id)
        {
            return CustomerDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Customer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Customer Add(Customer data)
        {
            CustomerDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Customer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Customer data)
        {
            CustomerDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Customer from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Customer data)
        {
            CustomerDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Customer from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CustomerDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Customer from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return CustomerDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Customer from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CustomerDAO.FindPaging(criteria);
        }
    }
}