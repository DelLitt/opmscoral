			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
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
    public class DepartmentStockLogic : IDepartmentStockLogic
    {
        private IDepartmentStockDao _innerDao;
        public IDepartmentStockDao DepartmentStockDao
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
        /// Find DepartmentStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStock</param>
        /// <returns></returns>
        public DepartmentStock FindById(object id)
        {
            return DepartmentStockDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStock Add(DepartmentStock data)
        {
            DepartmentStockDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStock data)
        {
            DepartmentStockDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStock data)
        {
            DepartmentStockDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStock> FindAll(ObjectCriteria<DepartmentStock> criteria)
        {
            return DepartmentStockDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStock> criteria)
        {
            return DepartmentStockDao.FindPaging(criteria);
        }

        public IList FindProductMasterAvailInStock(string name)
        {
            LinqCriteria<DepartmentStock> crit = new LinqCriteria<DepartmentStock>();
            crit.AddCriteria(stk => stk.Quantity > 0);
            crit.AddCriteria(stk => stk.ProductMaster.ProductName.Contains(name));
            crit.MaxResult = 20;
            IList<ProductMaster> list = DepartmentStockDao.FindAllSubProperty(crit, stk => stk.ProductMaster);
            var reslist = new ArrayList();
            ObjectUtility.AddToList(reslist, list, "ProductName");
            return reslist;
        }

        public DepartmentStock FindByProductId(string key)
        {
            ObjectCriteria<DepartmentStock> objectCriteria = new ObjectCriteria<DepartmentStock>();
            objectCriteria.Add(mstk => mstk.Product.ProductId == key);
            return (DepartmentStock)DepartmentStockDao.FindFirst(objectCriteria);
        }
    }
}