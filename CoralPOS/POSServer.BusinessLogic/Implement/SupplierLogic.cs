			 


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
    public class SupplierLogic : ISupplierLogic
    {
        private ISupplierDao _innerDao;
        public ISupplierDao SupplierDao
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
        /// Find Supplier object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Supplier</param>
        /// <returns></returns>
        public Supplier FindById(object id)
        {
            return SupplierDao.FindById(id);
        }
        
        /// <summary>
        /// Add Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Supplier Add(Supplier data)
        {
            SupplierDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Supplier data)
        {
            SupplierDao.Update(data);
        }
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Supplier data)
        {
            SupplierDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SupplierDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Supplier from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Supplier> FindAll(ObjectCriteria<Supplier> criteria)
        {
            return SupplierDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Supplier from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Supplier> criteria)
        {
            return SupplierDao.FindPaging(criteria);
        }
    }
}