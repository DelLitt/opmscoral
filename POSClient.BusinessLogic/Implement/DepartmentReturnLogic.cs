			 


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
    public class DepartmentReturnLogic : IDepartmentReturnLogic
    {
        private IDepartmentReturnDao _innerDao;
        public IDepartmentReturnDao DepartmentReturnDao
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
        /// Find DepartmentReturn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturn</param>
        /// <returns></returns>
        public DepartmentReturn FindById(object id)
        {
            return DepartmentReturnDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentReturn Add(DepartmentReturn data)
        {
            DepartmentReturnDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentReturn data)
        {
            DepartmentReturnDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentReturn data)
        {
            DepartmentReturnDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentReturnDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentReturn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentReturn> FindAll(ObjectCriteria<DepartmentReturn> criteria)
        {
            return DepartmentReturnDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentReturn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentReturn> criteria)
        {
            return DepartmentReturnDao.FindPaging(criteria);
        }
    }
}