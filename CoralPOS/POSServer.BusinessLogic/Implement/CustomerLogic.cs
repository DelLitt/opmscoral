			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerDao _innerDao;
        public ICustomerDao CustomerDao
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
        /// Find Customer object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Customer</param>
        /// <returns></returns>
        public Customer FindById(object id)
        {
            return CustomerDao.FindById(id);
        }
        
        /// <summary>
        /// Add Customer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Customer Add(Customer data)
        {
            CustomerDao.Add(data);
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
            CustomerDao.Update(data);
        }
        
        /// <summary>
        /// Delete Customer from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Customer data)
        {
            CustomerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Customer from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CustomerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Customer from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Customer> FindAll(ObjectCriteria<Customer> criteria)
        {
            return CustomerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Customer from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Customer> criteria)
        {
            return CustomerDao.FindPaging(criteria);
        }
    }
}