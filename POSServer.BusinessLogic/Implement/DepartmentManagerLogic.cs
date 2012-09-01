			 


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
    public class DepartmentManagerLogic : IDepartmentManagerLogic
    {
        private IDepartmentManagerDao _innerDao;
        public IDepartmentManagerDao DepartmentManagerDao
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
        /// Find DepartmentManager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentManager</param>
        /// <returns></returns>
        public DepartmentManager FindById(object id)
        {
            return DepartmentManagerDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentManager Add(DepartmentManager data)
        {
            DepartmentManagerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentManager data)
        {
            DepartmentManagerDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentManager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentManager data)
        {
            DepartmentManagerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentManager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentManagerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentManager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentManager> FindAll(ObjectCriteria<DepartmentManager> criteria)
        {
            return DepartmentManagerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentManager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentManager> criteria)
        {
            return DepartmentManagerDao.FindPaging(criteria);
        }
    }
}