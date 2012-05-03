			 


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
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class DistributorLogic : IDistributorLogic
    {
        private IDistributorDao _innerDao;
        public IDistributorDao DistributorDao
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
        /// Find Distributor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Distributor</param>
        /// <returns></returns>
        public Distributor FindById(object id)
        {
            return DistributorDao.FindById(id);
        }
        
        /// <summary>
        /// Add Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Distributor Add(Distributor data)
        {
            DistributorDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Distributor data)
        {
            DistributorDao.Update(data);
        }
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Distributor data)
        {
            DistributorDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DistributorDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Distributor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Distributor> FindAll(ObjectCriteria<Distributor> criteria)
        {
            return DistributorDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Distributor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Distributor> criteria)
        {
            return DistributorDao.FindPaging(criteria);
        }
    }
}