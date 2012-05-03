			 


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
    public class PurchaseOrdersLogLogic : IPurchaseOrdersLogLogic
    {
        private IPurchaseOrdersLogDao _innerDao;
        public IPurchaseOrdersLogDao PurchaseOrdersLogDao
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
        /// Find PurchaseOrdersLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrdersLog</param>
        /// <returns></returns>
        public PurchaseOrdersLog FindById(object id)
        {
            return PurchaseOrdersLogDao.FindById(id);
        }
        
        /// <summary>
        /// Add PurchaseOrdersLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PurchaseOrdersLog Add(PurchaseOrdersLog data)
        {
            PurchaseOrdersLogDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PurchaseOrdersLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PurchaseOrdersLog data)
        {
            PurchaseOrdersLogDao.Update(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrdersLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PurchaseOrdersLog data)
        {
            PurchaseOrdersLogDao.Delete(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrdersLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PurchaseOrdersLogDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PurchaseOrdersLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<PurchaseOrdersLog> FindAll(ObjectCriteria<PurchaseOrdersLog> criteria)
        {
            return PurchaseOrdersLogDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PurchaseOrdersLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<PurchaseOrdersLog> criteria)
        {
            return PurchaseOrdersLogDao.FindPaging(criteria);
        }
    }
}